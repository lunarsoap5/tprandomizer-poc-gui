using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using System.Text;
using TPRandomizer.Assets;


namespace TPRandomizer.Assets
{ 
    public class SeedData
    {
        internal static List<byte> CheckDataRaw = new List<byte> ();
        internal static SeedHeader SeedHeaderRaw = new SeedHeader();
        internal static List<byte> currentSeedData = new List<byte>();
        internal static List<byte> currentSeedHeader = new List<byte>();

        public class SeedHeader
        {
            public UInt32 fileSize {get; set;}       // Total number of bytes including the header
            public UInt64 seed {get; set;}            // Current seed
            public UInt16 minVersion {get; set;}       // minimal required REL version, u8 Major and u8 Minor
            public UInt16 maxVersion {get; set;}       // maximum supported REL version, u8 Major and u8 Minor
            public UInt16 patchInfoNumEntries {get; set;}       // bitArray where each bit represents a patch/modification to be applied for this playthrough
            public UInt16 patchInfoDataOffset {get; set;}
            public UInt16 eventFlagsInfoNumEntries {get; set;}       // eventFlags that need to be set for this seed
            public UInt16 eventFlagsInfoDataOffset {get; set;} 
            public UInt16 regionFlagsInfoNumEntries {get; set;}       // regionFlags that need to be set, alternating
            public UInt16 regionFlagsInfoDataOffset {get; set;}
            public UInt16 dzxCheckInfoNumEntries {get; set;}
            public UInt16 dzxCheckInfoDataOffset {get; set;} 
            public UInt16 relCheckInfoNumEntries {get; set;}
            public UInt16 relCheckInfoDataOffset {get; set;}
            public UInt16 poeCheckInfoNumEntries {get; set;}
            public UInt16 poeCheckInfoDataOffset {get; set;}
            public UInt16 arcCheckInfoNumEntries {get; set;}
            public UInt16 arcCheckInfoDataOffset {get; set;}
            public UInt16 bossCheckInfoNumEntries {get; set;}
            public UInt16 bossCheckInfoDataOffset {get; set;}
            public UInt16 hiddenSkillCheckInfoNumEntries {get; set;}  
            public UInt16 hiddenSkillCheckInfoDataOffset {get; set;}
            public UInt16 bugRewardCheckInfoNumEntries {get; set;}
            public UInt16 bugRewardCheckInfoDataOffset {get; set;}
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

        

        

        public static void generateSeedData()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            //Header Info
            
            
            
            CheckDataRaw.AddRange(generateEventFlags());
            CheckDataRaw.AddRange(generateRegionFlags());
            CheckDataRaw.AddRange(parseDZXReplacements());
            CheckDataRaw.AddRange(parseRELOverrides());
            CheckDataRaw.AddRange(parsePOEReplacements());
            CheckDataRaw.AddRange(parseARCReplacements());
            CheckDataRaw.AddRange(parseBossReplacements());
            CheckDataRaw.AddRange(parseBugRewards()); 
            //CheckDataRaw.Add(parseSkyCharacters()); 
            currentSeedHeader.AddRange(generateSeedHeader(randomizerSettings.seedNumber));
            
            currentSeedData.AddRange(currentSeedHeader);
            currentSeedData.AddRange(CheckDataRaw);
            
            var gci = new gci((byte)randomizerSettings.seedNumber, randomizerSettings.gameRegion, currentSeedData);
            string fileHash = "TPR - v1.0 - " + Randomizer.seedHash + "-Seed-Data.gci";
            File.WriteAllBytes(fileHash,gci.gciFile);
        }

        static List <byte> generateSeedHeader(int seedNumber)
        {
            List<byte> seedHeader = new List<byte>();
            SeedHeaderRaw.fileSize = 0xA000;
            SeedHeaderRaw.seed = 0x7461636F62656C6C;
            SeedHeaderRaw.minVersion = 0x0100;
            SeedHeaderRaw.maxVersion = 0x0100;
            SeedHeaderRaw.patchInfoNumEntries = 0x0000;
            SeedHeaderRaw.patchInfoDataOffset = 0x0000;
            PropertyInfo[] seedHeaderProperties = SeedHeaderRaw.GetType().GetProperties();
            foreach (PropertyInfo headerObject in seedHeaderProperties)
            {
                if (headerObject.PropertyType == typeof(UInt32))
                {
                    seedHeader.AddRange(Converter.gcBytes((UInt32)headerObject.GetValue(SeedHeaderRaw, null)));
                }
                else if (headerObject.PropertyType == typeof(UInt64))
                {
                    seedHeader.AddRange(Converter.gcBytes((UInt64)headerObject.GetValue(SeedHeaderRaw, null)));
                }
                else if (headerObject.PropertyType == typeof(UInt16))
                {
                    seedHeader.AddRange(Converter.gcBytes((UInt16)headerObject.GetValue(SeedHeaderRaw, null)));
                }
            }
            seedHeader.Add(Converter.gcByte(seedNumber));
            return seedHeader;
        }

        static List<byte> parseARCReplacements()
        {
            List<byte> listOfArcReplacements = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("ARC"))
                {
                    ARCReplacement currentArcCheck = new ARCReplacement();
                    for (int i = 0; i < currentCheck.arcFileValues.Count; i++)
                    {
                        List<string> listOfArcValues = currentCheck.arcFileValues[i];
                        currentArcCheck.fileName = listOfArcValues[0];
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)uint.Parse(listOfArcValues[1], System.Globalization.NumberStyles.HexNumber)));
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)0x00));
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)currentCheck.itemId));
                        listOfArcReplacements.Add(Converter.gcByte(currentCheck.fileDirectoryType[i]));
                        listOfArcReplacements.AddRange(Converter.stringBytes(listOfArcValues[0]));
                        listOfArcReplacements.Add(Converter.gcByte(currentCheck.replacementType[i])); 
                        count++;
                    }
                }
            }
            SeedHeaderRaw.arcCheckInfoNumEntries = count;
            SeedHeaderRaw.arcCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfArcReplacements;
        }

        static List<byte> parseDZXReplacements()
        {
            List<byte> listOfDZXReplacements = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("DZX"))
                {
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
                    listOfDZXReplacements.AddRange(Converter.gcBytes((UInt16)ushort.Parse(currentCheck.hash, System.Globalization.NumberStyles.HexNumber)));
                    listOfDZXReplacements.Add(Converter.gcByte(currentCheck.stageIDX));
                    listOfDZXReplacements.Add(Converter.gcByte(0xFF)); //change to magicByte once we get it set
                    listOfDZXReplacements.AddRange(dataArray);
                    count++;
                }
            }
            SeedHeaderRaw.dzxCheckInfoNumEntries = count;
            SeedHeaderRaw.dzxCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfDZXReplacements;
        }

        static List<byte> parsePOEReplacements()
        {
            List<byte> listOfPOEReplacements = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Poe"))
                {
                    listOfPOEReplacements.Add(Converter.gcByte(currentCheck.stageIDX));
                    listOfPOEReplacements.Add(Converter.gcByte(byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber)));
                    listOfPOEReplacements.AddRange(Converter.gcBytes((UInt16)currentCheck.itemId));
                    count++;
                }
            }
            SeedHeaderRaw.poeCheckInfoNumEntries = count;
            SeedHeaderRaw.poeCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfPOEReplacements;
        }

        static List<byte> parseRELOverrides()
        {
            List<byte> listOfRELReplacements = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("REL"))
                {
                    for (int i = 0; i < currentCheck.offsets.Count; i++)
                    {
                        listOfRELReplacements.AddRange(Converter.gcBytes((UInt32)currentCheck.stageIDX));
                        listOfRELReplacements.AddRange(Converter.gcBytes((UInt32)uint.Parse(currentCheck.moduleID, System.Globalization.NumberStyles.HexNumber)));
                        listOfRELReplacements.AddRange(Converter.gcBytes((UInt32)uint.Parse(currentCheck.offsets[i], System.Globalization.NumberStyles.HexNumber)));
                        listOfRELReplacements.AddRange(Converter.gcBytes((UInt32)(uint.Parse(currentCheck.relOverride, System.Globalization.NumberStyles.HexNumber) + (byte)currentCheck.itemId)));
                        count++;
                    }
                }
            }
            SeedHeaderRaw.relCheckInfoNumEntries = count;
            SeedHeaderRaw.relCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfRELReplacements;
        }

        static List<byte> parseBossReplacements()
        {
            List<byte> listOfBossReplacements = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Boss"))
                {
                    listOfBossReplacements.AddRange(Converter.gcBytes((UInt16)currentCheck.stageIDX));
                    listOfBossReplacements.AddRange(Converter.gcBytes((UInt16)currentCheck.itemId)); 
                    count++;
                }
            }
            SeedHeaderRaw.bossCheckInfoNumEntries = count;
            SeedHeaderRaw.bossCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfBossReplacements;
        }

        static List<byte> parseBugRewards()
        {
            List<byte> listOfBugRewards = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Bug Reward"))
                {
                    listOfBugRewards.AddRange(Converter.gcBytes((UInt16)byte.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber)));
                    listOfBugRewards.AddRange(Converter.gcBytes((UInt16)(byte)currentCheck.itemId));
                    count++;
                }
            }
            SeedHeaderRaw.bugRewardCheckInfoNumEntries = count;
            SeedHeaderRaw.bugRewardCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfBugRewards;    
        }

        static List<byte> parseSkyCharacters()
        {
            List<byte> listOfSkyCharacters = new List<byte>();
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Sky Book"))
                {
                    listOfSkyCharacters.Add(Converter.gcByte((byte)currentCheck.itemId));
                    listOfSkyCharacters.AddRange(Converter.gcBytes((UInt16)currentCheck.stageIDX));
                    listOfSkyCharacters.Add(Converter.gcByte(currentCheck.roomIDX));
                }
            }
            return listOfSkyCharacters;    
        }

        static List<byte> generateEventFlags()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> listOfEventFlags = new List<byte>();
            ushort count = 0;
            byte[,] arrayOfEventFlags = {};
            byte[,] faronTwilightEventFlags = new byte[,]
            {
                {0x5, 0xFF},
                {0x6, 0x10},
                {0xC, 0x8}
            };

            if (randomizerSettings.faronTwilightCleared)
            {
                arrayOfEventFlags = BackendFunctions.concatFlagArrays(arrayOfEventFlags, faronTwilightEventFlags);
            }

            for (int i = 0; i < arrayOfEventFlags.GetLength(0); i++)
            {
                listOfEventFlags.Add(Converter.gcByte(arrayOfEventFlags[i,0]));
                listOfEventFlags.Add(Converter.gcByte(arrayOfEventFlags[i,1]));
                count++;
            }
            SeedHeaderRaw.eventFlagsInfoNumEntries = count;
            SeedHeaderRaw.eventFlagsInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfEventFlags;
        }

        static List<byte> generateRegionFlags()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> listOfRegionFlags = new List<byte>();
            ushort count = 0;
            byte[,] arrayOfRegionFlags = {};
            byte[,] faronTwilightRegionFlags = new byte[,]
            {
                {0x2, 0x1F},
                {0x2, 0x1E},
                {0x2, 0x1C},
                {0x2, 0x1B},
                {0x2, 0x1A},
                {0x2, 0x19},
                {0x2, 0x18}
            };

            if (randomizerSettings.faronTwilightCleared)
            {
                arrayOfRegionFlags = BackendFunctions.concatFlagArrays(arrayOfRegionFlags, faronTwilightRegionFlags);
            }

            for (int i = 0; i < arrayOfRegionFlags.GetLength(0); i++)
            {
                listOfRegionFlags.Add(Converter.gcByte(arrayOfRegionFlags[i,0]));
                listOfRegionFlags.Add(Converter.gcByte(arrayOfRegionFlags[i,1]));
                count++;
            }
            SeedHeaderRaw.regionFlagsInfoNumEntries = count;
            SeedHeaderRaw.regionFlagsInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + 0x38);
            return listOfRegionFlags;
        }
    }
}