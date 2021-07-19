using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

using System.Collections;
namespace TPRandomizer
{
    public class BackendFunctions
    {
        LogicFunctions LogicFunc = new LogicFunctions();
        CheckFunctions CheckFunc = new CheckFunctions();
        RoomFunctions RoomFunc = new RoomFunctions();

        //Encode the settings string. 
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Decode the settings string.
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void interpretSettingsString(string settingsString)
        {
            //Convert the settings string into a binary string to be interpreted.
            string bitString = textToBitString(settingsString);
            List<byte> bits = new List<byte>();
			PropertyInfo[] randoSettingProperties = Randomizer.RandoSetting.GetType().GetProperties();
            PropertyInfo[] settingDataProperties = Randomizer.RandoSettingData.GetType().GetProperties();
                foreach (PropertyInfo settingProperty in randoSettingProperties)
                {
                    string evaluatedByteString = "";
                    int settingBitWidth = 0;
                    bool reachedEndofList = false;
                    if (settingProperty.PropertyType == typeof(bool))
                    {
                        int value = Convert.ToInt32(bitString[0].ToString(), 2);
                        if (value == 1)
                        {
                            settingProperty.SetValue(Randomizer.RandoSetting, true, null);
                        } 
                        else
                        {
                            settingProperty.SetValue(Randomizer.RandoSetting, false, null);
                        }
                        bitString = bitString.Remove(0,1);
                    }
                    if (settingProperty.PropertyType == typeof(string))
                    {
                        //We loop through the Settings Data to match the index with the appropriate value.
                        foreach (PropertyInfo dataProperty in settingDataProperties)
			            {
                            var dataValue = dataProperty.GetValue(Randomizer.RandoSettingData, null);
                            if (settingProperty.Name == dataProperty.Name)
                            {
                                settingBitWidth = 4;
                                //We want to get the binary values in the string in 4 bit pieces since that is what is was encrypted with.
                                for (int j = 0; j < settingBitWidth; j++)
                                {
                                    evaluatedByteString = evaluatedByteString + bitString[0];
                                    bitString = bitString.Remove(0,1);
                                }
                                
                                string[] dataArray = (string[])dataValue;
                                settingProperty.SetValue(Randomizer.RandoSetting, dataArray[Convert.ToInt32(evaluatedByteString, 2)], null);
                                break;
                            }
                        }
                    }
                    if (settingProperty.PropertyType == typeof(List<Item>))
                    {
                        List<Item> startingItems = new List<Item>();
                        //We want to get the binary values in the string in 8 bit pieces since that is what is was encrypted with.
                        settingBitWidth = 8;
                        while (!reachedEndofList)
                        {
                            for (int j = 0; j < settingBitWidth; j++)
                            {
                                evaluatedByteString = evaluatedByteString + bitString[0];
                                bitString = bitString.Remove(0,1);
                            }
                            int itemIndex = Convert.ToInt32(evaluatedByteString, 2);
                            if (itemIndex != 255) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                            {
                                foreach (Item item in Randomizer.Items.ImportantItems)
                                {
                                    if (itemIndex == (byte)item)
                                    {
                                        startingItems.Add(item);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                reachedEndofList = true;
                            }
                            evaluatedByteString = "";
                        }
                        settingProperty.SetValue(Randomizer.RandoSetting, startingItems, null);
                    }
                    if (settingProperty.PropertyType == typeof(List<string>))
                    {
                        List<string> excludedChecks = new List<string>();
                        //We want to get the binary values in the string in 9 bit pieces since that is what is was encrypted with.
                        settingBitWidth = 9;
                        while (!reachedEndofList)
                        {
                            for (int j = 0; j < settingBitWidth; j++)
                            {
                                evaluatedByteString = evaluatedByteString + bitString[0];
                                bitString = bitString.Remove(0,1);
                            }
                            int checkIndex = Convert.ToInt32(evaluatedByteString, 2);
                            if (checkIndex != 511) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                            {
                                excludedChecks.Add(Randomizer.Checks.CheckDict.ElementAt(checkIndex).Key);
                            }
                            else
                            {
                                reachedEndofList = true;
                            }
                            evaluatedByteString = "";
                        }
                        settingProperty.SetValue(Randomizer.RandoSetting, excludedChecks, null);
                    }
                    Console.WriteLine(settingProperty.Name + settingProperty.GetValue(Randomizer.RandoSetting, null));
            }

            foreach (string excludedCheck in Randomizer.RandoSetting.ExcludedChecks)
            {
                foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
                {
                    Check currentCheck = checkList.Value;
                    if (excludedCheck == currentCheck.checkName)
                    {
                        currentCheck.isExcluded = true;
                        Randomizer.Checks.CheckDict[currentCheck.checkName] = currentCheck;
                    }
                }
            }
            return;
        }

        public static string settingsLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";
        public static char index_to_letter(int index) 
        { 
            char c = settingsLetters[index]; 
            return c; 
        }
        public static int letter_to_index(char letter)
        { 
            for (int i = 0; i < settingsLetters.Length; i++)
            {
                if (letter == settingsLetters[i])
                {
                    return i;
                }
            }
            return 0; 
        }

        public static string bitStringToText(string bits)
        {
            string result = "";
            //Pad the string to a value of 5
            while (bits.Length % 5 != 0)
            {
                bits = bits + "0";
            }
             
            for (int i = 0; i < bits.Length; i+=5)
            {
                string value = "";
                for (int j = 0; j < 5; j++)
                {
                    value = value + bits[i +j];
                }
                int byteValue = Convert.ToInt32(value, 2);
                result += index_to_letter(byteValue);
            }
            Console.WriteLine(bits);
            return result;
        }

        public static string textToBitString(string text)
        {
            string byteToBinary = "";
            foreach (char c in text)
            {
                int index = letter_to_index(c);
                byteToBinary = byteToBinary + Convert.ToString(index, 2).PadLeft(5, '0');
            }
            while (byteToBinary.Length % 5 != 0)
            {
                byteToBinary.TrimEnd('0');
            }
            Console.WriteLine("Read in settings string: " + byteToBinary);
            return byteToBinary;
        }   

        public static void generateSpoilerLog(Room startingRoom)
        {
            bool hasCompletedSphere;
            Check currentCheck;
            Random rnd = new Random();
            string fileHash = "TPR - v1.0 - " + HashAssets.hashAdjectives[rnd.Next(HashAssets.hashAdjectives.Count()-1)] + " " + HashAssets.characterNames[rnd.Next(HashAssets.characterNames.Count()-1)] + ".txt";
            //Once everything is complete, we want to write the results to a spoiler log.
            using (StreamWriter file = new(fileHash))
            {
                file.WriteLine("Randomizer Version: 1.0b");
                file.WriteLine("Settings: ");
                file.WriteLine(JsonConvert.SerializeObject(Randomizer.RandoSetting, Formatting.Indented));
                file.WriteLine("");
                file.WriteLine("Item Locations: ");
                foreach (KeyValuePair<string, Check> check in  Randomizer.Checks.CheckDict)
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
                foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
                {
                    Check listedCheck = checkList.Value;
                    listedCheck.hasBeenReached = false;
                    Randomizer.Checks.CheckDict[listedCheck.checkName] = listedCheck;
                }
                
                Randomizer.Items.generateItemPool();
                Randomizer.Items.heldItems.Clear();
                Randomizer.Items.ImportantItems.Add(Item.Ganon_Defeated);
                
                List<Item> playthroughItems = new List<Item>();
                int sphereCount = 0;
                while (!Randomizer.Items.heldItems.Contains(Item.Ganon_Defeated))
                {
                    hasCompletedSphere = false;
                    foreach (KeyValuePair<string, Room> roomList in Randomizer.Rooms.RoomDict.ToList())
                    {
                        Room currentRoom = roomList.Value;
                        currentRoom.visited = false;
                        Randomizer.Rooms.RoomDict[currentRoom.name] = currentRoom;
                    }
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
                            var areNeighbourRequirementsMet = Randomizer.Logic.evaluateRequirements(roomsToExplore[0].neighbourRequirements[i]);
                            //If you can access the neighbour and it hasnt been visited yet.
                            if ((((bool)areNeighbourRequirementsMet == true)) && (Randomizer.Rooms.RoomDict[roomsToExplore[0].neighbours[i]].visited == false))
                            {
                                Room currentNeighbour = Randomizer.Rooms.RoomDict[roomsToExplore[0].neighbours[i]];
                                currentNeighbour.visited = true;
                                //Console.WriteLine("Neighbour: " + currentNeighbour.name + " added to room list.");
                                roomsToExplore.Add(currentNeighbour);
                            }
                        }
                        for (int i = 0; i < roomsToExplore[0].checks.Count(); i++)
                        {
                            //Create reference to the dictionary entry of the check whose logic we are evaluating
                            if (!Randomizer.Checks.CheckDict.TryGetValue(roomsToExplore[0].checks[i], out currentCheck))
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
                                var areCheckRequirementsMet = Randomizer.Logic.evaluateRequirements(currentCheck.requirements);
                                //Confirms that we can get the check and checks to see if an item was placed in it.
                                if (((bool)areCheckRequirementsMet == true))
                                {
                                    if (currentCheck.itemWasPlaced)
                                    {
                                        playthroughItems.Add(currentCheck.itemId);
                                        currentCheck.hasBeenReached = true;
                                        if (Randomizer.Items.ImportantItems.Contains(currentCheck.itemId) || Randomizer.Items.DungeonSmallKeys.Contains(currentCheck.itemId) || Randomizer.Items.DungeonBigKeys.Contains(currentCheck.itemId) || Randomizer.Items.VanillaDungeonRewards.Contains(currentCheck.itemId))
                                        {
                                            file.WriteLine("    " + currentCheck.checkName + ": " + currentCheck.itemId);
                                        }
                                        hasCompletedSphere = true;
                                    }

                                }
                            }
                        }
                        roomsToExplore.Remove(roomsToExplore[0]);
                    }
                    Randomizer.Items.heldItems.AddRange(playthroughItems);
                    playthroughItems.Clear();
                    sphereCount++; 
                    if (hasCompletedSphere == false)
                    {
                        file.WriteLine("Could not validate playthrough. Most likely there is an error in logic. Please debug and try again.");
                        break;
                    }
                }
            }
        } 
    }
}