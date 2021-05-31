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
        LogicFunctions Logic = new LogicFunctions();
        RoomFunctions Rooms = new RoomFunctions();
        CheckFunctions Checks = new CheckFunctions();
        public void start(string SettingsString)
        {
            //Read in the settings string and set the settings values accordingly
            interpretSettingsString(SettingsString);
        begin:
            //Generate the dictionary that contains all of the checks.
            Checks.InitializeChecks();
            Form1.SetProgress(10);
            //Generate the dictionary that contains all of the rooms.
            Rooms.InitializeRooms();
            Form1.SetProgress(20);
            //Read in the information from the .json files and place them into the classes defined in the dictionary.
            deserializeChecks();
            Form1.SetProgress(30);
            //Read in the information from the .json files and place them in to the classes defined in the dictionary.
            deserializeRooms();
            Form1.SetProgress(40);

            //Generate the item pool based on user settings/input.           
            Singleton.getInstance().Items.generateItemPool();
            Form1.SetProgress(50);
            //Generate the world based on the room class values and their neighbour values. If we want to randomize entrances, we would do it before this step.
            Room startingRoom = setupGraph();
            Form1.SetProgress(60);
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
                goto begin;
            }
            Form1.SetProgress(90);
            generateSpoilerLog(startingRoom, SettingsString);
            Form1.SetProgress(100);
        }

        public void interpretSettingsString(string SettingsString)
        {
            String flags = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz1234567890!@#$";
            String flagText = BackendFunctions.Base64Decode(SettingsString);

            while (flagText.Length < 19)
            {
                flagText += "A";
            }

            BitArray v = new BitArray(new int[] { flags.IndexOf(flagText[0]) });
            int[] array = new int[1];

            BitArray w = new BitArray(3);
            w[0] = v[0];
            w[1] = v[1];
            w[2] = v[2];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Logic Rules
                case 0:
                    Singleton.getInstance().Logic.SettingsList[0,1] = "Glitchless";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[0,1] = "Glitched";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[0,1] = "No_Logic";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[3];
            w[1] = v[4];
            w[2] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[1]) });
            w[3] = v[0];
            w[4] = v[1];
            w[5] = v[2];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Hyrule Castle Access Requirements
                case 0:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Fused_Shadows";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Mirror_Shards";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "All_Dungeons";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Random_Dungeons";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Vanilla";
                    break;
            }
            w = new BitArray(4);
            w[0] = v[3];
            w[1] = v[4];
            w[2] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[2]) });

            w[3] = v[0];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Palace of Twilight Access Requirements
                case 0:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Fused_Shadows";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Mirror_Shards";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Vanilla";
                    break;
            }
            w = new BitArray(2);
            w[0] = v[1];
            w[1] = v[2];
            w.CopyTo(array, 0);
            switch(array[0])
            {
                //Faron Woods Logic
                case 0:
                    Singleton.getInstance().Logic.SettingsList[3, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[3, 1] = "Closed";
                    break;
            }
            Singleton.getInstance().Logic.SettingsList[4, 1] = v[3].ToString();
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[3]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Small Key Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Keysanity";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Keysey";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[4]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Boss Key Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Keysanity";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Keysey";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[5]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Map and Compass Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Anywhere";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Start_With";
                    break;
            }


            Singleton.getInstance().Logic.SettingsList[9, 1] = v[4].ToString(); //Golden Bug Shuffled?
            Singleton.getInstance().Logic.SettingsList[10, 1] = v[5].ToString(); //Gift from NPCs

            v = new BitArray(new int[] { flags.IndexOf(flagText[6]) });

            Singleton.getInstance().Logic.SettingsList[11, 1] = v[0].ToString(); //Treasure Chests
            Singleton.getInstance().Logic.SettingsList[12, 1] = v[1].ToString(); //Shop Items Shuffled
            Singleton.getInstance().Logic.SettingsList[13, 1] = v[2].ToString(); //Faron Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[14, 1] = v[3].ToString(); //Eldin Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[15, 1] = v[4].ToString(); //Lanayru Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[16, 1] = v[5].ToString(); //Skip Minor Cutscenes

            v = new BitArray(new int[] { flags.IndexOf(flagText[7]) });

            Singleton.getInstance().Logic.SettingsList[17, 1] = v[0].ToString(); //Skip Master Sword Puzzle
            Singleton.getInstance().Logic.SettingsList[18, 1] = v[1].ToString(); //Fast Iron Boots
            Singleton.getInstance().Logic.SettingsList[19, 1] = v[2].ToString(); //Quick Transform
            Singleton.getInstance().Logic.SettingsList[20, 1] = v[3].ToString(); //Transform Anywhere
            Singleton.getInstance().Logic.SettingsList[5, 1] = v[4].ToString(); // Intro Skipped
        }
        public Room setupGraph()
        {
            //We want to be safe and make sure that the room classes are prepped and ready to be linked together. Then we define our starting room.
            resetAllRoomsVisited();
            Room startingRoom = Rooms.RoomDict["Ordon Province"];
            startingRoom.isStartingRoom = true;
            Rooms.RoomDict["Ordon Province"] = startingRoom;
            return startingRoom;
        }

        public void resetAllRoomsVisited()
        {
            foreach (KeyValuePair<string, Room> roomList in Rooms.RoomDict.ToList())
            {
                Room currentRoom = roomList.Value;
                currentRoom.visited = false;
                Rooms.RoomDict[currentRoom.name] = currentRoom;
            }
            return;
        }
        public void resetAllRooms()
        {
            Rooms.RoomDict.Clear();
            return;
        }

        public void resetAllChecksVisited()
        {
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                currentCheck.hasBeenReached = false;
                Checks.CheckDict[currentCheck.checkName] = currentCheck;
            }
            return;
        }

        public void resetAllChecks()
        {
            Checks.CheckDict.Clear();
            return;
        }

        void startOver()
        {
            Console.WriteLine("Starting Over.");
            Singleton.getInstance().Items.heldItems.Clear();
            Singleton.getInstance().Items.RandomizedRegionItems.Clear();
            Singleton.getInstance().Items.alwaysItems.Clear();
            Singleton.getInstance().Items.miscItems.Clear();
            resetAllChecksVisited();
            resetAllRoomsVisited();
            resetAllChecks();
            resetAllRooms();
        }

        void placeItemsInWorld(Room startingRoom)
        {
            //Any vanilla checks will be placed first for the sake of logic. Even if they aren't available to be randomized in the game yet, we may need to logically account for their placement.
            placeVanillaChecks (Singleton.getInstance().Items.heldItems, Singleton.getInstance().Checks.vanillaChecks);
            //Excluded checks are next and will just be filled with "junk" items (i.e. ammo refills, etc.)
            
            //Shop Items

            //Next we want to replace items that are locked in their respective region
            placeDungeonItems (startingRoom, Singleton.getInstance().Items.heldItems, Singleton.getInstance().Items.RandomizedRegionItems);

            //Next we want to place items that can lock locations
            placeItemsUnrestricted(startingRoom, Singleton.getInstance().Items.heldItems, Singleton.getInstance().Items.RandomizedImportantItems);

            //Next we will place the "always" items. Basically the constants in every seed, so Heart Pieces, Heart Containers, etc.
            placeNonImpactItems(startingRoom, Singleton.getInstance().Items.heldItems, Singleton.getInstance().Items.alwaysItems);
            
            placeJunkItems(startingRoom, Singleton.getInstance().Items.heldItems, Singleton.getInstance().Items.miscItems);

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

        void placeDungeonItems (Room startingRoom, List<Item> heldItems, List<Item> ItemsToBeRandomized)
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
                availableChecks = listAllAvailableDungeonChecks(startingRoom, itemToPlace);
                checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                
                placeItemInCheck(itemToPlace,checkToReciveItem);

                availableChecks.Clear();
            }
            return;
        }
      public List<string> listAllAvailableDungeonChecks(Room startingRoom, Item itemToPlace)
        {
            List<Item> playthroughItems = new List<Item>();
            resetAllChecksVisited();
            restart:
            resetAllRoomsVisited();
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
                    var areNeighbourRequirementsMet = evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
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
                        var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                        //Confirms that we can get the check and checks to see if an item was placed in it.
                        if (((bool)areCheckRequirementsMet == true))
                        {
                            if (currentCheck.itemWasPlaced)
                            {
                                Singleton.getInstance().Items.heldItems.Add(currentCheck.itemId);
                                playthroughItems.Add(currentCheck.itemId);
                                currentCheck.hasBeenReached = true;
                                Console.WriteLine("Added " + currentCheck.itemId + " to item list.");
                                goto restart;
                            }
                            else
                            {
                                if (isDungeonCheck(itemToPlace.ToString(), roomsToExplore[0]))
                                {
                                    roomChecks.Add(currentCheck.checkName);
                                }
                            }

                        }
                    }
                }
                roomsToExplore.Remove(roomsToExplore[0]);
            }
            foreach (var newItem in playthroughItems)
            {
                Singleton.getInstance().Items.heldItems.Remove(newItem);
            }


            /*foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                //Parse through every check to see if an item has been placed in it
                Check currentCheck = checkList.Value;
                if (currentCheck.itemWasPlaced && (!currentCheck.hasBeenReached))
                {
                    //If the check has an item in it and has not been collected, we need to see if we can get the item.
                    //var areCheckRequirementsMet = CSharpScript.EvaluateAsync(currentCheck.requirements, options).Result;
                    var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                    if ((bool)areCheckRequirementsMet == true)
                    {
                        //If we can get the item, we add it to our inventory and restart our search since we may be able to get more placed items with our new item pool
                        Singleton.getInstance().Items.heldItems.Add(currentCheck.itemId);
                        playthroughItems.Add(currentCheck.itemId);
                        currentCheck.hasBeenReached = true;
                        GC.Collect();
                        goto restart;
                    }
                }
            }
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                //Confirms that we can get the check and checks to see if an item was placed in it.
                if (isDungeonCheck(itemToPlace.ToString(), currentCheck))
                {
                   //var areCheckRequirementsMet = CSharpScript.EvaluateAsync(currentCheck.requirements, options).Result;
                    var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                     if (((bool)areCheckRequirementsMet == true) && (!currentCheck.itemWasPlaced))
                    {
                        roomChecks.Add(currentCheck.checkName);
                    }
                }
            }
            foreach (var newItem in playthroughItems)
            {
                Singleton.getInstance().Items.heldItems.Remove(newItem);
            }*/
            return roomChecks;
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

        void placeNonImpactItems (Room startingRoom, List<Item> heldItems, List<Item> ItemsToBeRandomized)
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
                availableChecks = listNonPlacedChecks(startingRoom, itemToPlace);
                
                checkToReciveItem = Checks.CheckDict[availableChecks[rnd.Next(availableChecks.Count()-1)].ToString()];
                placeItemInCheck(itemToPlace,checkToReciveItem);

                availableChecks.Clear();
            }
            return;
        }

        void placeJunkItems (Room startingRoom, List<Item> heldItems, List<Item> ItemsToBeRandomized)
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

        
        
        public List<string> listAllAvailableChecks(Room startingRoom, Item itemToPlace)
        {
            List<Item> playthroughItems = new List<Item>();
            resetAllChecksVisited();
            restart:
            resetAllRoomsVisited();
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
                    var areNeighbourRequirementsMet = evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
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
                        var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                        //Confirms that we can get the check and checks to see if an item was placed in it.
                        if (((bool)areCheckRequirementsMet == true))
                        {
                            if (currentCheck.itemWasPlaced)
                            {
                                Singleton.getInstance().Items.heldItems.Add(currentCheck.itemId);
                                playthroughItems.Add(currentCheck.itemId);
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
            foreach (var newItem in playthroughItems)
            {
                Singleton.getInstance().Items.heldItems.Remove(newItem);
            }
            return roomChecks;

            /*resetAllChecksVisited();
            List<string> roomChecks = new List<string>();
            List<Item> playthroughItems = new List<Item>();
            Check currentCheck;
    
            restart: 
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                //Parse through every check to see if an item has been placed in it
                currentCheck = checkList.Value;
                if (currentCheck.itemWasPlaced && (!currentCheck.hasBeenReached))
                {
                    //If the check has an item in it and has not been collected, we need to see if we can get the item.
                    //areCheckRequirementsMet = (bool)CSharpScript.EvaluateAsync(currentCheck.requirements, options).Result;
                    var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                    if (areCheckRequirementsMet == true)
                    {
                        //If we can get the item, we add it to our inventory and restart our search since we may be able to get more placed items with our new item pool
                        Singleton.getInstance().Items.heldItems.Add(currentCheck.itemId);
                        playthroughItems.Add(currentCheck.itemId);
                        currentCheck.hasBeenReached = true;
                        GC.Collect();
                        goto restart;
                    }
                }
            }
            foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict.ToList())
            {
                currentCheck = checkList.Value;
                if (!currentCheck.itemWasPlaced)
                {
                    //If the check is empty, we want to see if we can get it
                    //areCheckRequirementsMet = (bool)CSharpScript.EvaluateAsync(currentCheck.requirements, options).Result;
                    var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                    if (areCheckRequirementsMet == true)
                    {
                        //If we can get the check, we want to add it to the list of available checks
                        roomChecks.Add(currentCheck.checkName);
                    }
                }
                GC.Collect();
            }
            foreach (var newItem in playthroughItems)
            {
                Singleton.getInstance().Items.heldItems.Remove(newItem);
            }
            GC.Collect();
            return roomChecks;*/
        }

        public List<string> listNonPlacedChecks(Room startingRoom, Item itemToPlace)
        {
            resetAllChecksVisited();
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

        public void deserializeChecks()
        {
            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/Checks/", "*",SearchOption.AllDirectories))
            {
                string contents = File.ReadAllText(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                Checks.CheckDict[fileName] = JsonConvert.DeserializeObject<Check>(contents);
                Check currentCheck = Checks.CheckDict[fileName];
                currentCheck.requirements = "(" + currentCheck.requirements +")";
                Checks.CheckDict[fileName] = currentCheck;
                Console.WriteLine("Check File Loaded " + fileName);
            }
            return;
        }
        

        public void deserializeRooms()
        {
            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/Assets/Rooms/", "*", SearchOption.AllDirectories))
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
                Console.WriteLine("Room File Loaded " + fileName);
            }
            return;
        }

        bool isDungeonCheck( string itemToPlace, Room currentRoom)
        {
            if (itemToPlace.Contains("Forest_Temple") && (currentRoom.region == "Forest Temple"))
            {
                return true;
            }
            else if (itemToPlace.Contains("Goron_Mines") && (currentRoom.region =="Goron Mines"))
            {
              return true;
            }
            else if (itemToPlace.Contains("Lakebed_Temple") && (currentRoom.region =="Lakebed Temple"))
            {
                return true;
            }
            else if (itemToPlace.Contains("Arbiters_Grounds") && (currentRoom.region == "Arbiters Grounds"))
            {
                return true;
            }
            else if ((itemToPlace.Contains("Snowpeak_Ruins") || itemToPlace.Contains("Ordon_Pumpkin") || itemToPlace.Contains("Ordon_Goat_Cheese")) && (currentRoom.region == "Snowpeak Ruins"))
            {
                return true;
            }
            else if (itemToPlace.Contains("Temple_of_Time") && (currentRoom.region == "Temple of Time"))
            {
               return true;
            }
            else if (itemToPlace.Contains("City_in_The_Sky") && (currentRoom.region == "City in The Sky"))
            {
                return true;
            }
            else if (itemToPlace.Contains("Palace_of_Twilight") && (currentRoom.region == "Palace of Twilight"))
            {
                return true;
            }
            else if (itemToPlace.Contains("Hyrule_Castle") && (currentRoom.region == "Hyrule Castle"))
            {
                return true;
            }
            return false;
        }

        public bool evaluateRequirements(string expression)
        {
            Parser parse = new Parser();
            parse.ParserReset();
            Singleton.getInstance().Logic.TokenDict = new Tokenizer(expression).Tokenize();
            return parse.Parse();
        }

        public void generateSpoilerLog(Room startingRoom, string SettingsString)
        {
            Check currentCheck;
            Random rnd = new Random();
            string fileHash = "TPR - v1.0 - " + HashAssets.hashAdjectives[rnd.Next(HashAssets.hashAdjectives.Count()-1)] + " " + HashAssets.characterNames[rnd.Next(HashAssets.characterNames.Count()-1)] + ".txt";
            //Once everything is complete, we want to write the results to a spoiler log.
            using (StreamWriter file = new(fileHash))
            {
                file.WriteLine("Randomizer Version: 1.0b");
                file.WriteLine("Settings String: " + SettingsString);
                file.WriteLine("Settings: ");
                for (int i = 0; i < Singleton.getInstance().Logic.SettingsList.GetLength(0); i++)
                {
                    file.WriteLine(Singleton.getInstance().Logic.SettingsList[i,0] + ": " + Singleton.getInstance().Logic.SettingsList[i,1]);
                }
                file.WriteLine("");
                file.WriteLine("Item Locations: ");
                foreach (KeyValuePair<string, Check> check in  Checks.CheckDict)
                {
                    currentCheck = check.Value;
                    if (currentCheck.itemWasPlaced)
                    {
                        file.WriteLine(currentCheck.checkName + ": " + currentCheck.itemId);
                    }
                    else 
                    {
                        Console.WriteLine("Check: " + currentCheck.checkName + " has no item.");
                    }
                }
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("Playthrough: ");
                resetAllChecksVisited();
                
                Singleton.getInstance().Items.generateItemPool();
                Singleton.getInstance().Items.heldItems.Clear();
                Singleton.getInstance().Items.ImportantItems.Add(Item.Ganon_Defeated);
                
                List<Item> playthroughItems = new List<Item>();
                int sphereCount = 0;
                while (!Singleton.getInstance().Items.heldItems.Contains(Item.Ganon_Defeated))
                {
                    resetAllRoomsVisited();
                    List<Room> roomsToExplore = new List<Room>();
                    startingRoom.visited = true;
                    roomsToExplore.Add(startingRoom);
                    file.WriteLine("Sphere: " + sphereCount);
                    while (roomsToExplore.Count() > 0)
                    {
                        for (int i = 0; i < roomsToExplore[0].neighbours.Count(); i++)
                        {
                            //Create reference to the dictionary entry of the room we are evaluating

                            //Parse the neighbour's requirements to find out if we can access it
                            var areNeighbourRequirementsMet = evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
                            //If you can access the neighbour and it hasnt been visited yet.
                            if ((((bool)areNeighbourRequirementsMet == true)) && (Rooms.RoomDict[roomsToExplore[0].neighbours[i]].visited == false))
                            {
                                Room currentNeighbour = Rooms.RoomDict[roomsToExplore[0].neighbours[i]];
                                currentNeighbour.visited = true;
                                Console.WriteLine("Neighbour: " + currentNeighbour.name + " added to room list.");
                                roomsToExplore.Add(currentNeighbour);
                            }
                        }
                        for (int i = 0; i < roomsToExplore[0].checks.Count(); i++)
                        {
                            //Create reference to the dictionary entry of the check whose logic we are evaluating
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
                                var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                                //Confirms that we can get the check and checks to see if an item was placed in it.
                                if (((bool)areCheckRequirementsMet == true))
                                {
                                    if (currentCheck.itemWasPlaced)
                                    {
                                        playthroughItems.Add(currentCheck.itemId);
                                        currentCheck.hasBeenReached = true;
                                        if (Singleton.getInstance().Items.ImportantItems.Contains(currentCheck.itemId) || Singleton.getInstance().Items.DungeonSmallKeys.Contains(currentCheck.itemId) || Singleton.getInstance().Items.DungeonBossKeys.Contains(currentCheck.itemId))
                                        {
                                            file.WriteLine("    " + currentCheck.checkName + ": " + currentCheck.itemId);
                                        }
                                        
                                    }

                                }
                            }
                        }
                        roomsToExplore.Remove(roomsToExplore[0]);
                    }
                    /*foreach (KeyValuePair<string, Check> checkList in Checks.CheckDict)
                    {
                        //Parse through every check to see if an item has been placed in it
                        currentCheck = checkList.Value;
                        if (!currentCheck.hasBeenReached)
                        {
                            //If the check has an item in it and has not been collected, we need to see if we can get the item.
                            //areCheckRequirementsMet = (bool)CSharpScript.EvaluateAsync(currentCheck.requirements, options).Result;
                            var areCheckRequirementsMet = evaluateRequirements(currentCheck.requirements);
                            if (areCheckRequirementsMet == true)
                            {
                                //If we can get the item, we add it to our inventory and restart our search since we may be able to get more placed items with our new item pool
                                playthroughItems.Add(currentCheck.itemId);
                                currentCheck.hasBeenReached = true;
                                if (Singleton.getInstance().Items.ImportantItems.Contains(currentCheck.itemId) || Singleton.getInstance().Items.RegionKeys.Contains(currentCheck.itemId))
                                {
                                    file.WriteLine("    " + currentCheck.checkName + ": " + currentCheck.itemId);
                                }
                            }
                        }
                    }
                    foreach (var newItem in playthroughItems)
                    {
                        Singleton.getInstance().Items.heldItems.Add(newItem);
                    }*/
                    Singleton.getInstance().Items.heldItems.AddRange(playthroughItems);
                    playthroughItems.Clear();
                    sphereCount++; 
                }
            }
        }
    } 
}