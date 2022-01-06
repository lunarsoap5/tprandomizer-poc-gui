using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using System.Text;

namespace TPRandomizer
{ 
    public class SeedData
    {
        struct regionFlag
        {
            internal byte region_id;
            internal byte bit_id;
        };

        struct eventFlag
        {
            internal byte offset;
            internal byte flag;
        };

        List<eventFlag> seedEventFlags = new List<eventFlag>();

        class dzxCheck
        {
            internal ushort hash;
            internal byte stageIDX;
            internal byte magicByte;     // ignore this byte in data[]
            internal byte[] data;
        };

        struct RELCheck
        {
            internal uint stageIDX;
            internal uint moduleID;
            internal uint offset;
            internal uint relOverride;
        };

        struct POECheck
        {
            internal byte stageIDX;
            internal byte flag;      // Flag used for identification
            internal ushort item;     // New item id
        };

        public struct ARCReplacement
        {
            internal uint offset;                         // The offset of the byte where the item is stored from the start of the file.
            internal int arcFileIndex;                   // The index of the file that contains the check.
            internal uint replacementValue;              // Used to be item, but can be more now.
            internal byte directory;                // The type of directory where the check is stored.
            internal string fileName;                // The name of the file where the check is stored
            internal byte replacementType;     // The type of replacement that is taking place.
        };

        struct BOSSCheck
        {
            internal short stageIDX;     // The stage where the replacement is taking place.
            internal short item;         // New item id
        };

        struct HiddenSkillCheck
        {
            ushort indexNumber;
            short itemID;
        };

        struct BugReward
        {
            internal ushort bugID;
            internal ushort itemID;
        };

        struct SkyCharacter
        {
            internal ushort stageIDX;
            internal byte roomID;
            internal byte itemID;
        };

        byte[,] faronTwilightEventFlags = new byte[,]
        {
            {0x5, 0xFF},
            {0x6, 0x10},
            {0xC, 0x8}
        };

        public static void generateSeedData()
        {
            Random rnd = new Random();
            List<ARCReplacement> listOfArcReplacements = new List<ARCReplacement>();
            List<dzxCheck> listOfDZXReplacements = new List<dzxCheck>();
            List<POECheck> listOfPOEReplacements = new List<POECheck>();
            List<RELCheck> listOfRelReplacements = new List<RELCheck>();
            List<BOSSCheck> listOfBossReplacements = new List<BOSSCheck>();
            List<SkyCharacter> listOfSkyCharacters = new List<SkyCharacter>();
            List<BugReward> listOfBugRewards = new List<BugReward>();
            string fileHash = "TPR - v1.0 - " + Randomizer.seedHash + "-Seed-Data.txt";
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                bool isData = false;
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("ARC"))
                {
                    ARCReplacement currentArcCheck = new ARCReplacement();
                    for (int i = 0; i < currentCheck.arcFileValues.Count; i++)
                    {
                        List<string> listOfArcValues = currentCheck.arcFileValues[i];
                        currentArcCheck.fileName = listOfArcValues[0];
                        for (int j = 1; j < listOfArcValues.Count; j++)
                        {
                            currentArcCheck.offset = uint.Parse(listOfArcValues[j], System.Globalization.NumberStyles.HexNumber);
                            currentArcCheck.arcFileIndex = 0;
                            currentArcCheck.replacementValue = (uint)currentCheck.itemId;
                            currentArcCheck.directory = currentCheck.fileDirectoryType[i];
                            currentArcCheck.replacementType = currentCheck.replacementType[i]; 
                            listOfArcReplacements.Add(currentArcCheck);
                        }
                    }
                    isData = true;
                }
                if (currentCheck.category.Contains("DZX"))
                {
                    dzxCheck currentDZXCheck = new dzxCheck();
                    byte[] dataArray = new byte[32];
                    for(int i = 0; i < currentCheck.data.Length;i++)
                    {
                        dataArray[i] = byte.Parse(currentCheck.data[i], System.Globalization.NumberStyles.HexNumber);
                    }
                    if (currentCheck.dzxTag =="TRES")
                    {
                        dataArray[28] = (byte)currentCheck.itemId;
                    }
                    else if (currentCheck.dzxTag =="ACTR")
                    {
                        dataArray[11] = (byte)currentCheck.itemId;
                    }
                    currentDZXCheck.data = dataArray;
                    currentDZXCheck.hash = ushort.Parse(currentCheck.hash, System.Globalization.NumberStyles.HexNumber);
                    currentDZXCheck.stageIDX = currentCheck.stageIDX;

                    listOfDZXReplacements.Add(currentDZXCheck);
                    isData = true;
                }
                if (currentCheck.category.Contains("Poe"))
                {
                    POECheck currentPOECheck = new POECheck();
                    currentPOECheck.stageIDX = currentCheck.stageIDX;
                    currentPOECheck.flag = byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber);
                    currentPOECheck.item = (ushort)currentCheck.itemId;
                    listOfPOEReplacements.Add(currentPOECheck);
                    isData = true;
                }
                if (currentCheck.category.Contains("REL"))
                {
                    RELCheck currentRELCheck = new RELCheck();
                    for (int i = 0; i < currentCheck.offsets.Count; i++)
                    {
                        currentRELCheck.stageIDX = currentCheck.stageIDX;
                        currentRELCheck.moduleID = uint.Parse(currentCheck.moduleID, System.Globalization.NumberStyles.HexNumber);
                        currentRELCheck.offset = uint.Parse(currentCheck.offsets[i], System.Globalization.NumberStyles.HexNumber);
                        currentRELCheck.relOverride = (uint.Parse(currentCheck.relOverride, System.Globalization.NumberStyles.HexNumber) + (byte)currentCheck.itemId);
                        listOfRelReplacements.Add(currentRELCheck);
                        isData = true;
                    }
                }
                if (currentCheck.category.Contains("Boss"))
                {
                    BOSSCheck currentBossCheck = new BOSSCheck();
                    currentBossCheck.stageIDX = currentCheck.stageIDX;
                    currentBossCheck.item = (short)currentCheck.itemId; 
                    listOfBossReplacements.Add(currentBossCheck);
                    isData = true;
                }
                if (currentCheck.category.Contains("Bug Reward"))
                {
                    BugReward currentBugReward = new BugReward();
                    currentBugReward.bugID = byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber);
                    currentBugReward.itemID = (byte)currentCheck.itemId;
                    listOfBugRewards.Add(currentBugReward);
                    isData = true;
                }
                if (currentCheck.category.Contains("Sky Book"))
                {
                    SkyCharacter currentSkyCharacter = new SkyCharacter();
                    currentSkyCharacter.stageIDX = currentCheck.stageIDX;
                    currentSkyCharacter.roomID = currentCheck.roomIDX;
                    currentSkyCharacter.itemID = (byte)currentCheck.itemId;
                    listOfSkyCharacters.Add(currentSkyCharacter);
                    isData = true;
                }
                if (!isData)
                {
                    Console.WriteLine("Unrandomized check due to missing or invalid category: " + currentCheck.checkName);
                }
            }

            
            
            using (StreamWriter file = new(fileHash))
            {
                file.WriteLine("//ARC");
                foreach (ARCReplacement arcCheck in listOfArcReplacements)
                {
                    file.WriteLine(arcCheck.offset + "," + arcCheck.arcFileIndex + "," + arcCheck.replacementValue + "," + arcCheck.directory + "," + arcCheck.fileName + "," + arcCheck.replacementType);
                }
                file.WriteLine("//DZX");
                foreach (dzxCheck dzxCheck in listOfDZXReplacements)
                {
                    file.WriteLine(dzxCheck.hash + "," + dzxCheck.stageIDX + "," + dzxCheck.data);
                }

                file.WriteLine("//POE");
                foreach (POECheck poeCheck in listOfPOEReplacements)
                {
                    file.WriteLine(poeCheck.stageIDX + "," + poeCheck.flag + "," + poeCheck.item);
                }
                file.WriteLine("//REL");
                foreach (RELCheck relCheck in listOfRelReplacements)
                {
                    file.WriteLine(relCheck.stageIDX + "," + relCheck.moduleID + "," + relCheck.offset + "," + relCheck.relOverride);
                }
                file.WriteLine("//Boss");
                foreach (BOSSCheck bossCheck in listOfBossReplacements)
                {
                    file.WriteLine(bossCheck.stageIDX + "," + bossCheck.item);
                }
                file.WriteLine("//BugRewards");
                foreach (BugReward bugReward in listOfBugRewards)
                {
                    file.WriteLine(bugReward.bugID + "," + bugReward.itemID);
                }
                file.WriteLine("//SkyCharacter");
                foreach (SkyCharacter skyCharacter in listOfSkyCharacters)
                {
                    file.WriteLine(skyCharacter.stageIDX + "," + skyCharacter.roomID + "," + skyCharacter.itemID);
                }
                file.Close();
            }
        }
    }

    

}