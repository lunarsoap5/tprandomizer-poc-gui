using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;

namespace TPRandomizer
{ 
    public class Randomizer
    {
        public static LogicFunctions Logic = new LogicFunctions();
        public static CheckFunctions Checks = new CheckFunctions();
        public static RoomFunctions Rooms = new RoomFunctions();
        public static ItemFunctions Items = new ItemFunctions();
        public static RandomizerSetting RandoSetting = new RandomizerSetting();
        public static SettingData RandoSettingData = new SettingData();


        /// <summary>
        /// Generates a randomizer seed given a settings string
        /// </summary>
        /// <param name="settingsString"> The Settings String to be read in. </param>
        public void start(string settingsString)
        {
            int remainingGenerationAttempts = 15;
            //Generate the dictionary values that are needed and initialize the data for the selected logic type.
            deserializeChecks();
            deserializeRooms();

            //Read in the settings string and set the settings values accordingly
            BackendFunctions.interpretSettingsString(settingsString);

            //Generate the item pool based on user settings/input.  
            Randomizer.Items.generateItemPool();
            Checks.generateCheckList();
            
            //Generate the world based on the room class values and their neighbour values. If we want to randomize entrances, we would do it before this step.
            Room startingRoom = setupGraph();
            while (remainingGenerationAttempts > 0)
            {
                Randomizer.Items.heldItems.AddRange(Items.BaseItemPool);
                remainingGenerationAttempts --;
                try 
                {
                    //Place the items in the world based on the starting room.
                    placeItemsInWorld(startingRoom);
                }
                //If for some reason the assumed fill fails, we want to dump everything and start over.
                catch (ArgumentOutOfRangeException a)
                {
                    Console.WriteLine(a + " No checks remaining, starting over..");
                    startOver();
                    continue;
                }
                BackendFunctions.generateSpoilerLog(startingRoom);
                break;
            }
        } 

        void placeItemsInWorld(Room startingRoom)
        {
            //Any vanilla checks will be placed first for the sake of logic. Even if they aren't available to be randomized in the game yet, 
            //we may need to logically account for their placement.
            placeVanillaChecks (Checks.vanillaChecks);
            
            //Excluded checks are next and will just be filled with "junk" items (i.e. ammo refills, etc.)
            placeExcludedChecks();
            
            //Dungeon rewards
            //starting room, list of checks to be randomized, items to be randomized, item pool, restriction
            placeItemsRestricted(startingRoom, Items.ShuffledDungeonRewards, Randomizer.Items.heldItems, "Dungeon Rewards"); 
            
            //Next we want to replace items that are locked in their respective region
            placeItemsRestricted(startingRoom, Items.RandomizedDungeonRegionItems, Randomizer.Items.heldItems, "Region");
            
            //Next we want to place items that can lock locations
            placeItemsRestricted(startingRoom, Items.ImportantItems, Randomizer.Items.heldItems, "");
            
            //Next we will place the "always" items. Basically the constants in every seed, so Heart Pieces, Heart Containers, etc.
            placeNonImpactItems(startingRoom, Items.alwaysItems);
            
            placeJunkItems(startingRoom, Items.JunkItems);

            return;
        }


        void placeVanillaChecks (List<string> vanillaChecks)
        {
            foreach (var check in vanillaChecks)
            {
                Randomizer.Items.heldItems.Remove(Checks.CheckDict[check.ToString()].itemId);
                placeItemInCheck(Checks.CheckDict[check].itemId, Checks.CheckDict[check]);
            }
            return;
        }

        void placeExcludedChecks()
        {
            Random rnd = new Random();
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (!currentCheck.itemWasPlaced && currentCheck.isExcluded)
                {
                    placeItemInCheck(Items.JunkItems[rnd.Next(Items.JunkItems.Count() - 1)], currentCheck);
                }
            }
        }

        void placeItemsRestricted (Room startingRoom, List<Item> ItemGroup, List<Item> itemPool, string restriction)
        {
            //Essentially we want to do the following: make a copy of our item pool for safe keeping so we can modify
            //the current item pool as the playthrough happens. We ONLY modify our copied item pool if we place an item.
            //Once all of the items in ItemGroup have been placed, we dump our item pool and restore it with the copy we have.
            if (ItemGroup.Count() > 0)
            {
                Random rnd = new Random();
                List<string> availableChecks = new List<string>();
                Item itemToPlace;
                Check checkToReciveItem;
                List<Item> ItemsToBeRandomized = new List<Item>();
                List<Item> playthroughItems = new List<Item>();
                List<Item> currentItemPool = new List<Item>();
                currentItemPool.AddRange(itemPool);
                ItemsToBeRandomized.AddRange(ItemGroup);

                while (ItemsToBeRandomized.Count() > 0)
                {
                    //NEEDS WORK: currently we have to dump the item pool and then refill it with the copy because if not,
                    //the item pool will compound and be way too big affecting both memory and logic.
                    itemPool.Clear();
                    itemPool.AddRange(currentItemPool);
                    itemToPlace = ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)];
                    Console.WriteLine("Item to place: " + itemToPlace);
                    itemPool.Remove(itemToPlace);
                    ItemsToBeRandomized.Remove(itemToPlace);
                    foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
                    {
                        Check currentCheck = checkList.Value;
                        currentCheck.hasBeenReached = false;
                        Checks.CheckDict[currentCheck.checkName] = currentCheck;
                    }

                    //Walk through the current graph and get a list of rooms that we can currently access
                    //If we collect any items during the playthrough, we add them to the player's inventory
                    //and try walking through the graph again until we have collected every item that we can.
                    do
                    {
                        playthroughItems.Clear();
                        List<Room> currentPlaythroughGraph = generatePlaythroughGraph(startingRoom);
                        foreach (Room graphRoom in currentPlaythroughGraph)
                        {
                            for (int i = 0; i < graphRoom.checks.Count(); i++)
                            {
                                //Create reference to the dictionary entry of the check whose logic we are evaluating
                                Check currentCheck;
                                if (!Checks.CheckDict.TryGetValue(graphRoom.checks[i], out currentCheck))
                                {
                                    if (graphRoom.checks[i].ToString() == "")
                                    {
                                        //Console.WriteLine("Room has no checks, continuing on....");
                                        break;
                                    }
                                }
                                if (!currentCheck.hasBeenReached)
                                {
                                    var areCheckRequirementsMet = Logic.evaluateRequirements(currentCheck.requirements);
                                    if (((bool)areCheckRequirementsMet == true))
                                    {
                                        if (currentCheck.itemWasPlaced)
                                        {
                                            playthroughItems.Add(currentCheck.itemId);
                                            Console.WriteLine("Added " + currentCheck.itemId + " to item list.");
                                        }
                                        else
                                        {
                                            if (restriction == "Region")
                                            {
                                                if (Rooms.isRegionCheck(itemToPlace, currentCheck, graphRoom))
                                                {
                                                    Console.WriteLine("Added " + currentCheck.checkName + " to check list.");
                                                    availableChecks.Add(currentCheck.checkName);
                                                }
                                            }
                                            else if (restriction == "Dungeon Rewards")
                                            {
                                                if (currentCheck.category.Contains("Dungeon Reward"))
                                                {
                                                    Console.WriteLine("Added " + currentCheck.checkName + " to check list.");
                                                    availableChecks.Add(currentCheck.checkName);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Added " + currentCheck.checkName + " to check list.");
                                                availableChecks.Add(currentCheck.checkName);
                                            }
                                        }
                                        currentCheck.hasBeenReached = true;
                                    }
                                }    
                            }
                        }
                        itemPool.AddRange(playthroughItems);
                    }
                    while (playthroughItems.Count() > 0);
                    
                    checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                    currentItemPool.Remove(itemToPlace);
                    placeItemInCheck(itemToPlace,checkToReciveItem);
                    availableChecks.Clear();
                }
                itemPool.Clear();
                itemPool.AddRange(currentItemPool);
            }
            return;
        }

        void placeNonImpactItems (Room startingRoom, List<Item> ItemsToBeRandomized)
        {
            Random rnd = new Random();
            List<string> availableChecks = new List<string>();
            Item itemToPlace;
            Check checkToReciveItem;

            while (ItemsToBeRandomized.Count() > 0)
            {
                itemToPlace = ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)];
                Console.WriteLine("Item to place: " + itemToPlace);
                ItemsToBeRandomized.Remove(itemToPlace);
                foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
                {
                    checkToReciveItem = checkList.Value;
                    if (!checkToReciveItem.itemWasPlaced)
                    {
                        availableChecks.Add(checkToReciveItem.checkName);
                    }
                }
                
                checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                placeItemInCheck(itemToPlace,checkToReciveItem);

                availableChecks.Clear();
            }
            return;
        }

        void placeJunkItems (Room startingRoom, List<Item> ItemsToBeRandomized)
        {
            Random rnd = new Random();
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (!currentCheck.itemWasPlaced)
                {
                    placeItemInCheck(ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)],currentCheck);
                }
            }
            return;
        }

        public void placeItemInCheck(Item item, Check check)
        {
            Console.WriteLine("Placing item in check.");
            check.itemWasPlaced = true;
            check.itemId = item;
            Console.WriteLine("Placed " + check.itemId + " in check " + check.checkName);
            return;
        }

         void startOver()
        {
            Randomizer.Items.heldItems.Clear();
            Console.WriteLine("Starting Over.");
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                currentCheck.itemWasPlaced = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            Rooms.RoomDict["Ordon Province"].isStartingRoom = true;
        }

        public Room setupGraph()
        {
            //We want to be safe and make sure that the room classes are prepped and ready to be linked together. Then we define our starting room.
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            Room startingRoom = Rooms.RoomDict["Ordon Province"];
            startingRoom.isStartingRoom = true;
            Rooms.RoomDict["Ordon Province"] = startingRoom;
            return startingRoom;
        }

        public void deserializeChecks()
        {
            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/World/Checks/", "*",SearchOption.AllDirectories))
            {
                string contents = File.ReadAllText(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                Checks.CheckDict.Add(fileName, new Check());
                Checks.CheckDict[fileName] = JsonConvert.DeserializeObject<Check>(contents);
                Check currentCheck = Checks.CheckDict[fileName];
                currentCheck.checkName = fileName;
                currentCheck.isExcluded = false;
                currentCheck.itemWasPlaced = false;
                currentCheck.requirements = "(" + currentCheck.requirements +")";
                Checks.CheckDict[fileName] = currentCheck;
                //Console.WriteLine("Check File Loaded " + fileName);
            }
            return;
        } 

        public void deserializeRooms()
        {
            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/World/Rooms/", "*", SearchOption.AllDirectories))
            {
                string contents = File.ReadAllText(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                Rooms.RoomDict.Add(fileName, new Room());
                Rooms.RoomDict[fileName] = JsonConvert.DeserializeObject<Room>(contents);
                Room currentRoom = Rooms.RoomDict[fileName];
                currentRoom.name = fileName;
                currentRoom.visited = false;
                currentRoom.isStartingRoom = false;
                for (int i = 0; i < currentRoom.neighbourRequirements.Count(); i++)
                {
                    string newRequirement = currentRoom.neighbourRequirements[i];
                    currentRoom.neighbourRequirements[i] = "(" + currentRoom.neighbourRequirements[i] + ")";
                }
                Rooms.RoomDict[fileName] = currentRoom;
                //Console.WriteLine("Room File Loaded " + fileName);
            }
            return;
        }

        List<Room> generatePlaythroughGraph(Room startingRoom)
        {
            List<Room> PlaythroughGraph = new List<Room>();
            
            List<string> roomChecks = new List<string>();
            List<Room> roomsToExplore = new List<Room>();
            
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }

            startingRoom.visited = true;
            roomsToExplore.Add(startingRoom);
            PlaythroughGraph.Add(startingRoom);

            //Build the world by parsing through each room, linking their neighbours, and setting the logic for the checks in the room to reflect the world.
            while (roomsToExplore.Count() > 0)
            {
                for (int i = 0; i < roomsToExplore[0].neighbours.Count(); i++)
                {
                    //Parse the neighbour's requirements to find out if we can access it
                    var areNeighbourRequirementsMet = Logic.evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
                    //If you can access the neighbour and it hasnt been visited yet.
                    if ((((bool)areNeighbourRequirementsMet == true)) && (Rooms.RoomDict[roomsToExplore[0].neighbours[i]].visited == false))
                    {
                        Room currentNeighbour = Rooms.RoomDict[roomsToExplore[0].neighbours[i]];
                        currentNeighbour.visited = true;
                        //Console.WriteLine("Neighbour: " + currentNeighbour.name + " added to room list.");
                        roomsToExplore.Add(currentNeighbour);
                        PlaythroughGraph.Add(currentNeighbour);
                    }
                }
                roomsToExplore.Remove(roomsToExplore[0]);
            }
            return PlaythroughGraph; 
        }
    } 
}