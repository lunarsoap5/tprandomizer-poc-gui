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
        public int attemptsLeft = 15;


        /// <summary>
        /// Generates a randomizer seed given a settings string
        /// </summary>
        /// <param name="settingsString"> The Settings String to be read in. </param>
        public void start(string settingsString)
        {
            begin:
            //Generate the dictionary values that are needed and initialize the data for the selected logic type.
            Checks.InitializeChecks();
            Rooms.InitializeRooms();
            deserializeChecks();
            deserializeRooms();

            //Read in the settings string and set the settings values accordingly
            BackendFunctions.interpretSettingsString(settingsString);

            Checks.generateCheckList();
            //Generate the item pool based on user settings/input.           
            Items.generateItemPool();
            Console.WriteLine("Remaining Items:");
                    foreach(Item leftItem in Items.alwaysItems)
                    {
                        Console.WriteLine(leftItem.ToString());
                    }
            //Generate the world based on the room class values and their neighbour values. If we want to randomize entrances, we would do it before this step.
            Room startingRoom = setupGraph();
            try 
            {
                //Place the items in the world based on the starting room.
                placeItemsInWorld(startingRoom);
            }
            
            //If for some reason the assumed fill fails, we want to dump everything and start over.
            catch (ArgumentOutOfRangeException a)
            {
                if (attemptsLeft > 0)
                {
                    Console.WriteLine(a + " No checks remaining, starting over..");
                    startOver();
                    attemptsLeft--;
                    Console.WriteLine("Remaining Items:");
                    foreach(Item leftItem in Items.alwaysItems)
                    {
                        Console.WriteLine(leftItem.ToString());
                    }
                    goto begin;
                }
                else
                {
                    Console.WriteLine("Randomization Failed. Please check your settings and try again.");
                }
                
            }
            BackendFunctions.generateSpoilerLog(startingRoom);
        } 

        void placeItemsInWorld(Room startingRoom)
        {
            //Any vanilla checks will be placed first for the sake of logic. Even if they aren't available to be randomized in the game yet, we may need to logically account for their placement.
            placeVanillaChecks (Items.ItemPool, Checks.vanillaChecks);
            
            //Excluded checks are next and will just be filled with "junk" items (i.e. ammo refills, etc.)
            placeExcludedChecks();
            
            //Dungeon rewards
            placeItemsRestricted(startingRoom, Checks.dungeonRewardChecks, Items.ShuffledDungeonRewards, Items.ItemPool); //starting room, list of checks to be randomized, items to be randomized, item pool.
            
            //Next we want to replace items that are locked in their respective region
            placeRegionItems(startingRoom, Items.ItemPool, Items.RandomizedDungeonRegionItems);
            
            //Next we want to place items that can lock locations
            placeItemsUnrestricted(startingRoom, Items.ItemPool, Items.RandomizedImportantItems);
            
            //Next we will place the "always" items. Basically the constants in every seed, so Heart Pieces, Heart Containers, etc.
            placeNonImpactItems(startingRoom, Items.alwaysItems);
            
            placeJunkItems(startingRoom, Items.miscItems);

            return;
        }


        void placeVanillaChecks (List<Item> heldItems, List<string> vanillaChecks)
        {
            List<string> availableChecks = new List<string>();
            Item itemToPlace;
            Check checkToReciveItem;
            
            foreach (var check in vanillaChecks)
            {
                checkToReciveItem = Checks.CheckDict[check];
                itemToPlace = checkToReciveItem.itemId;
                heldItems.Remove(itemToPlace);
                placeItemInCheck(itemToPlace, checkToReciveItem);
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
                    placeItemInCheck(Items.miscItems[rnd.Next(Items.miscItems.Count() - 1)], currentCheck);
                }
            }
        }

        void placeRegionItems (Room startingRoom, List<Item> heldItems, List<Item> ItemsToBeRandomized)
        {
            Random rnd = new Random();
            List<string> availableChecks = new List<string>();
            Item itemToPlace;
            Check checkToReciveItem;
            

            while (ItemsToBeRandomized.Count() > 0)
            {
                itemToPlace = ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)];
                Console.WriteLine("Item to place: " + itemToPlace);
                heldItems.Remove(itemToPlace);
                ItemsToBeRandomized.Remove(itemToPlace);
                availableChecks = listAllAvailableRegionChecks(startingRoom, itemToPlace);
                checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                
                placeItemInCheck(itemToPlace,checkToReciveItem);

                availableChecks.Clear();
            }
            return;
        }
      List<string> listAllAvailableRegionChecks(Room startingRoom, Item itemToPlace)
        {
            Items.heldItems.AddRange(Items.ItemPool);
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            restart:
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            List<string> roomChecks = new List<string>();
            List<Room> roomsToExplore = new List<Room>();
            startingRoom.visited = true;
            roomsToExplore.Add(startingRoom);

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
                    }
                }
                for (int i = 0; i < roomsToExplore[0].checks.Count(); i++)
                {
                    //Create reference to the dictionary entry of the check whose logic we are evaluating
                    Check currentCheck;
                    if (!Checks.CheckDict.TryGetValue(roomsToExplore[0].checks[i], out currentCheck))
                    {
                        if (roomsToExplore[0].checks[i].ToString() == "")
                        {
                            //Console.WriteLine("Room has no checks, continuing on....");
                            break;
                        }
                        Console.WriteLine("Check: " + roomsToExplore[0].checks[i] + " does not exist.");
                    }
                    if (!currentCheck.hasBeenReached)
                    {
                        //Parse the requirements to see if we can get the check
                        var areCheckRequirementsMet = Logic.evaluateRequirements(currentCheck.requirements);
                        //Confirms that we can get the check and checks to see if an item was placed in it.
                        if (((bool)areCheckRequirementsMet == true))
                        {
                            if (currentCheck.itemWasPlaced)
                            {
                                Items.heldItems.Add(currentCheck.itemId);
                                currentCheck.hasBeenReached = true;
                                Console.WriteLine("Added " + currentCheck.itemId + " to item list.");
                                goto restart;
                            }
                            else
                            {
                                if (Rooms.isRegionCheck(itemToPlace, currentCheck, roomsToExplore[0]))
                                {
                                    roomChecks.Add(currentCheck.checkName);
                                }
                            }

                        }
                    }
                }
                roomsToExplore.Remove(roomsToExplore[0]);
            }
            Items.heldItems.Clear();
            return roomChecks;
        }  

        void placeItemsRestricted (Room startingRoom, List<string> checksToBeRandomized, List<Item> ItemsToBeRandomized, List<Item> currentItemPool)
        {
            Random rnd = new Random();
            List<string> availableChecks = new List<string>();
            Item itemToPlace;
            Check checkToReciveItem;

                while (ItemsToBeRandomized.Count() > 0)
                {
                    itemToPlace = ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)];
                    Console.WriteLine("Item to place: " + itemToPlace);
                    currentItemPool.Remove(itemToPlace);
                    ItemsToBeRandomized.Remove(itemToPlace);
                    availableChecks = listAvailableRestrictedChecks(startingRoom, checksToBeRandomized, currentItemPool);
                    
                    checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                    placeItemInCheck(itemToPlace,checkToReciveItem);

                    availableChecks.Clear();
                }
            return;
        }

        void placeItemsUnrestricted (Room startingRoom, List<Item> heldItems, List<Item> ItemsToBeRandomized)
        {
            Random rnd = new Random();
            List<string> availableChecks = new List<string>();
            Item itemToPlace;
            Check checkToReciveItem;

                while (ItemsToBeRandomized.Count() > 0)
                {
                    itemToPlace = ItemsToBeRandomized[rnd.Next(ItemsToBeRandomized.Count()-1)];
                    Console.WriteLine("Item to place: " + itemToPlace);
                    heldItems.Remove(itemToPlace);
                    ItemsToBeRandomized.Remove(itemToPlace);
                    availableChecks = listAllAvailableChecks(startingRoom, itemToPlace);
                    
                    checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                    placeItemInCheck(itemToPlace,checkToReciveItem);

                    availableChecks.Clear();
                    GC.Collect();
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
                availableChecks = listNonPlacedChecks(startingRoom, itemToPlace);
                
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

        public List<string> listAvailableRestrictedChecks(Room startingRoom, List<string> checksToBeRandomized, List<Item> currentItemPool)
        {
            Items.heldItems.AddRange(currentItemPool);
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            restart:
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            List<string> roomChecks = new List<string>();
            List<Room> roomsToExplore = new List<Room>();
            startingRoom.visited = true;
            roomsToExplore.Add(startingRoom);

            //Build the world by parsing through each room, linking their neighbours, and setting the logic for the checks in the room to reflect the world.
            while (roomsToExplore.Count() > 0)
            {
                //Console.WriteLine("Currently exploring " + roomsToExplore[0].name);
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
                    }
                }
                for (int i = 0; i < roomsToExplore[0].checks.Count(); i++)
                {
                    //Create reference to the dictionary entry of the check whose logic we are evaluating
                    Check currentCheck;
                    if (!Checks.CheckDict.TryGetValue(roomsToExplore[0].checks[i], out currentCheck))
                    {
                        if (roomsToExplore[0].checks[i].ToString() == "")
                        {
                            //Console.WriteLine("Room has no checks, continuing on....");
                            break;
                        }
                        Console.WriteLine("Check: " + roomsToExplore[0].checks[i] + " does not exist.");
                    }
                    if (!currentCheck.hasBeenReached)
                    {
                        //Parse the requirements to see if we can get the check
                        var areCheckRequirementsMet = Logic.evaluateRequirements(currentCheck.requirements);
                        //Confirms that we can get the check and checks to see if an item was placed in it.
                        if (((bool)areCheckRequirementsMet == true))
                        {
                            if (currentCheck.itemWasPlaced)
                            {
                                Items.heldItems.Add(currentCheck.itemId);
                                currentCheck.hasBeenReached = true;
                                Console.WriteLine("Added " + currentCheck.itemId + " to item list.");
                                goto restart;
                            }
                            else if (checksToBeRandomized.Contains(currentCheck.checkName))
                            {
                                roomChecks.Add(currentCheck.checkName);
                            }

                        }
                    }
                }
                roomsToExplore.Remove(roomsToExplore[0]);
            }
            Items.heldItems.Clear();
            return roomChecks;
        }
        
        public List<string> listAllAvailableChecks(Room startingRoom, Item itemToPlace)
        {
            Items.heldItems.AddRange(Items.ItemPool);
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            restart:
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            List<string> roomChecks = new List<string>();
            List<Room> roomsToExplore = new List<Room>();
            startingRoom.visited = true;
            roomsToExplore.Add(startingRoom);

            //Build the world by parsing through each room, linking their neighbours, and setting the logic for the checks in the room to reflect the world.
            while (roomsToExplore.Count() > 0)
            {
                for (int i = 0; i < roomsToExplore[0].neighbours.Count(); i++)
                {
                    //Create reference to the dictionary entry of the room we are evaluating

                    //Parse the neighbour's requirements to find out if we can access it
                    var areNeighbourRequirementsMet = Logic.evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
                    //If you can access the neighbour and it hasnt been visited yet.
                    if ((((bool)areNeighbourRequirementsMet == true)) && (Rooms.RoomDict[roomsToExplore[0].neighbours[i]].visited == false))
                    {
                        Room currentNeighbour = Rooms.RoomDict[roomsToExplore[0].neighbours[i]];
                        currentNeighbour.visited = true;
                        //Console.WriteLine("Neighbour: " + currentNeighbour.name + " added to room list.");
                        roomsToExplore.Add(currentNeighbour);
                    }
                }
                for (int i = 0; i < roomsToExplore[0].checks.Count(); i++)
                {
                    //Create reference to the dictionary entry of the check whose logic we are evaluating
                    Check currentCheck;
                    if (!Checks.CheckDict.TryGetValue(roomsToExplore[0].checks[i], out currentCheck))
                    {
                        if (roomsToExplore[0].checks[i].ToString() == "")
                        {
                            //Console.WriteLine("Room has no checks, continuing on....");
                            break;
                        }
                        Console.WriteLine("Check: " + roomsToExplore[0].checks[i] + " does not exist.");
                    }
                    if (!currentCheck.hasBeenReached)
                    {
                        //Parse the requirements to see if we can get the check
                        var areCheckRequirementsMet = Logic.evaluateRequirements(currentCheck.requirements);
                        //Confirms that we can get the check and checks to see if an item was placed in it.
                        if (((bool)areCheckRequirementsMet == true))
                        {
                            if (currentCheck.itemWasPlaced)
                            {
                                Items.heldItems.Add(currentCheck.itemId);
                                currentCheck.hasBeenReached = true;
                                //Console.WriteLine("Added " + currentCheck.itemId + " to item list.");
                                goto restart;
                            }
                            else
                            {
                                roomChecks.Add(currentCheck.checkName);
                            }

                        }
                    }
                }
                roomsToExplore.Remove(roomsToExplore[0]);
            }
            Items.heldItems.Clear();
            return roomChecks;
        }

        public List<string> listNonPlacedChecks(Room startingRoom, Item itemToPlace)
        {
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check listedCheck = checkList.Value;
                listedCheck.hasBeenReached = false;
                Checks.CheckDict[listedCheck.checkName] = listedCheck;
            }
            List<string> roomChecks = new List<string>();
            List<Item> playthroughItems = new List<Item>();
            Check currentCheck;
    
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                currentCheck = checkList.Value;
                if (!currentCheck.itemWasPlaced)
                {
                    roomChecks.Add(currentCheck.checkName);
                }
            }
            return roomChecks;
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
            Console.WriteLine("Starting Over.");
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            Checks.CheckDict.Clear();
            Rooms.RoomDict.Clear();
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
                Checks.CheckDict[fileName] = JsonConvert.DeserializeObject<Check>(contents);
                Check currentCheck = Checks.CheckDict[fileName];
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
                Rooms.RoomDict[fileName] = JsonConvert.DeserializeObject<Room>(contents);
                Room currentRoom = Rooms.RoomDict[fileName];
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

        
    } 
}