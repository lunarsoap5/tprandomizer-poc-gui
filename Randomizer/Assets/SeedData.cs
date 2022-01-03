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
            short stageIDX;
            short roomID;
        };

        struct BugReward
        {
            internal ushort bugID;
            internal ushort itemID;
        };

        struct skyCharacter
        {
            internal ushort stageIDX;
            internal byte roomID;
            internal byte itemID;
        };
        public static void generateSeedData()
        {
            Random rnd = new Random();
            List<ARCReplacement> listOfArcReplacements = new List<ARCReplacement>();
            List<dzxCheck> listOfDZXReplacements = new List<dzxCheck>();
            List<POECheck> listOfPOEReplacements = new List<POECheck>();
            List<RELCheck> listOfRelReplacements = new List<RELCheck>();
            string fileHash = "TPR - v1.0 - " + Randomizer.seedHash + "-Seed-Data.txt";
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("ARC"))
                {
                    ARCReplacement currentArcCheck = new ARCReplacement();

                    currentArcCheck.offset = uint.Parse(currentCheck.offset, System.Globalization.NumberStyles.HexNumber);
                    currentArcCheck.arcFileIndex = 0;
                    currentArcCheck.replacementValue = (uint)currentCheck.itemId;
                    currentArcCheck.directory = currentCheck.fileDirectoryType;
                    currentArcCheck.fileName = currentCheck.arcFileName;
                    currentArcCheck.replacementType = currentCheck.replacementType;
                    listOfArcReplacements.Add(currentArcCheck);
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
                }
                if (currentCheck.category.Contains("Poe"))
                {
                    POECheck currentPOECheck = new POECheck();
                    currentPOECheck.stageIDX = currentCheck.stageIDX;
                    currentPOECheck.flag = byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber);
                    currentPOECheck.item = (ushort)currentCheck.itemId;
                    listOfPOEReplacements.Add(currentPOECheck);
                }
                if (currentCheck.category.Contains("REL"))
                {
                    RELCheck currentRELCheck = new RELCheck();
                    currentRELCheck.stageIDX = currentCheck.stageIDX;
                    currentRELCheck.moduleID = uint.Parse(currentCheck.moduleID, System.Globalization.NumberStyles.HexNumber);
                    currentRELCheck.offset = uint.Parse(currentCheck.offset, System.Globalization.NumberStyles.HexNumber);
                    currentRELCheck.relOverride = (uint.Parse(currentCheck.relOverride, System.Globalization.NumberStyles.HexNumber) + (byte)currentCheck.itemId);
                    listOfRelReplacements.Add(currentRELCheck);
                }
                if (currentCheck.category.Contains("Boss"))
                {
                    BOSSCheck currentBossCheck = new BOSSCheck();
                    currentBossCheck.stageIDX = currentCheck.stageIDX;
                    currentBossCheck.item = (short)currentCheck.itemId; 
                }
                if (currentCheck.category.Contains("Bug Reward"))
                {
                    BugReward currentBugReward = new BugReward();
                    currentBugReward.bugID = byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber);
                    currentBugReward.itemID = (byte)currentCheck.itemId;
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
                file.Close();
            }
        }
    }

    

}