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
        internal static byte seedHeaderSize = 0x48;

        internal class SeedHeader
        {
            public UInt32 fileSize {get; set;}       // Total number of bytes including the header
            public UInt64 seed {get; set;}            // Current seed
            public UInt16 minVersion {get; set;}       // minimal required REL version
            public UInt16 maxVersion {get; set;}       // maximum supported REL version
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
            public UInt16 skyCharacterCheckInfoNumEntries {get; set;}
            public UInt16 skyCharacterCheckInfoDataOffset {get; set;}
            public UInt16 shopCheckInfoNumEntries {get; set;}
            public UInt16 shopCheckInfoDataOffset {get; set;}
        };

        public static void generateSeedData()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> currentSeedHeader = new List<byte>();
            List<byte> currentSeedData = new List<byte>();
            //Header Info
            CheckDataRaw.AddRange(generatePatchSettings());
            CheckDataRaw.AddRange(generateEventFlags());
            CheckDataRaw.AddRange(generateRegionFlags());
            CheckDataRaw.AddRange(parseDZXReplacements());
            CheckDataRaw.AddRange(parseRELOverrides());
            CheckDataRaw.AddRange(parsePOEReplacements());
            CheckDataRaw.AddRange(parseARCReplacements());
            CheckDataRaw.AddRange(parseBossReplacements());
            CheckDataRaw.AddRange(parseHiddenSkills());
            CheckDataRaw.AddRange(parseBugRewards()); 
            CheckDataRaw.AddRange(parseSkyCharacters()); 
            CheckDataRaw.AddRange(parseShopItems()); 
            currentSeedHeader.AddRange(generateSeedHeader(randomizerSettings.seedNumber));
            
            currentSeedData.AddRange(currentSeedHeader);
            currentSeedData.AddRange(CheckDataRaw);
            
            var gci = new gci((byte)randomizerSettings.seedNumber, randomizerSettings.gameRegion, currentSeedData);
            string fileHash = "TPR-v1.0-" + Randomizer.seedHash + "-Seed-Data.gci";
            File.WriteAllBytes(fileHash,gci.gciFile);
        }

        static List <byte> generateSeedHeader(int seedNumber)
        {
            List<byte> seedHeader = new List<byte>();
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            SeedHeaderRaw.fileSize = 0xA000;
            SeedHeaderRaw.seed = BackendFunctions.GetChecksum(Randomizer.seedHash, 64);
            SeedHeaderRaw.minVersion = (ushort)(Randomizer.RANDOMIER_VERSION_MAJOR << 8 | Randomizer.RANDOMIER_VERSION_MINOR);
            SeedHeaderRaw.maxVersion = (ushort)(Randomizer.RANDOMIER_VERSION_MAJOR << 8 | Randomizer.RANDOMIER_VERSION_MINOR);
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
            seedHeader.Add(Converter.gcByte(randomizerSettings.heartColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.aButtonColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.bButtonColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.xButtonColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.yButtonColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.zButtonColor));
            seedHeader.Add(Converter.gcByte(randomizerSettings.lanternColor));
            seedHeader.Add(Converter.gcByte((randomizerSettings.transformAnywhere ? 1:0)));

            seedHeader.Add(Converter.gcByte(seedNumber));
            return seedHeader;
        }

        static List<byte> generatePatchSettings()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> listOfPatches = new List<byte>();
            byte patchOptions = 0x0;
            /*if (randomizerSettings.increaseWallet)
            {
                patchOptions |= 0x80;
            }*/
            if (randomizerSettings.shuffleBackgroundMusic)
            {
                patchOptions |= 0x40;
            }
            if (randomizerSettings.disableEnemyBackgoundMusic)
            {
                patchOptions |= 0x20;
            }
            if (randomizerSettings.fastIronBoots)
            {
                patchOptions |= 0x10;
            }
            listOfPatches.Add(Converter.gcByte(patchOptions));
            SeedHeaderRaw.patchInfoNumEntries = 0x1;
            SeedHeaderRaw.patchInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfPatches;
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
                    for (int i = 0; i < currentCheck.arcFileValues.Count; i++)
                    {
                        List<string> listOfArcValues = currentCheck.arcFileValues[i];
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)uint.Parse(listOfArcValues[1], System.Globalization.NumberStyles.HexNumber)));
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)0x00));
                        listOfArcReplacements.AddRange(Converter.gcBytes((UInt32)currentCheck.itemId));
                        listOfArcReplacements.Add(Converter.gcByte(currentCheck.fileDirectoryType[i]));
                        listOfArcReplacements.Add(Converter.gcByte(currentCheck.replacementType[i])); 
                        List<byte> fileNameBytes = new List<byte>();
                        fileNameBytes.AddRange(Converter.stringBytes(listOfArcValues[0]));
                        for (int numberofFileNameBytes = fileNameBytes.Count; numberofFileNameBytes < 18; numberofFileNameBytes++)
                        {
                            //pad the length of the file name to 0x12 bytes.
                            fileNameBytes.Add(Converter.gcByte(0x00));
                        }
                        listOfArcReplacements.AddRange(fileNameBytes);
                        count++;
                    }
                }
            }
            SeedHeaderRaw.arcCheckInfoNumEntries = count;
            SeedHeaderRaw.arcCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
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
                    if (currentCheck.magicByte == null)
                    {
                        listOfDZXReplacements.Add(Converter.gcByte(0xFF)); //change to magicByte once we get it set
                    }
                    else
                    {
                        listOfDZXReplacements.Add(Converter.gcByte(byte.Parse(currentCheck.magicByte, System.Globalization.NumberStyles.HexNumber))); //change to magicByte once we get it set
                    }
                    listOfDZXReplacements.AddRange(dataArray);
                    count++;
                }
            }
            SeedHeaderRaw.dzxCheckInfoNumEntries = count;
            SeedHeaderRaw.dzxCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
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
            SeedHeaderRaw.poeCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
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
            SeedHeaderRaw.relCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
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
            SeedHeaderRaw.bossCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
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
            SeedHeaderRaw.bugRewardCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfBugRewards;    
        }

        static List<byte> parseSkyCharacters()
        {
            List<byte> listOfSkyCharacters = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Sky Book"))
                {
                    listOfSkyCharacters.Add(Converter.gcByte((byte)currentCheck.itemId));
                    listOfSkyCharacters.AddRange(Converter.gcBytes((UInt16)currentCheck.stageIDX));
                    listOfSkyCharacters.Add(Converter.gcByte(currentCheck.roomIDX));
                    count++;
                }
            }
            SeedHeaderRaw.skyCharacterCheckInfoNumEntries = count;
            SeedHeaderRaw.skyCharacterCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfSkyCharacters;    
        }

        static List<byte> parseHiddenSkills()
        {
            List<byte> listOfHiddenSkills = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Hidden Skill"))
                {
                    listOfHiddenSkills.AddRange(Converter.gcBytes((UInt16)short.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber)));
                    listOfHiddenSkills.AddRange(Converter.gcBytes((UInt16)currentCheck.itemId));
                    listOfHiddenSkills.AddRange(Converter.gcBytes((UInt16)currentCheck.stageIDX));
                    listOfHiddenSkills.AddRange(Converter.gcBytes((UInt16)currentCheck.roomIDX));
                    count++;
                }
            }
            SeedHeaderRaw.hiddenSkillCheckInfoNumEntries = count;
            SeedHeaderRaw.hiddenSkillCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfHiddenSkills;    
        }

        static List<byte> parseShopItems()
        {
            List<byte> listOfShopItems = new List<byte>();
            ushort count = 0;
            foreach (KeyValuePair<string, Check> checkList in Randomizer.Checks.CheckDict.ToList())
            {
                Check currentCheck = checkList.Value;
                if (currentCheck.category.Contains("Shop"))
                {
                    listOfShopItems.AddRange(Converter.gcBytes((UInt16)short.Parse(currentCheck.flag, System.Globalization.NumberStyles.HexNumber)));
                    listOfShopItems.AddRange(Converter.gcBytes((UInt16)currentCheck.itemId));
                    count++;
                }
            }
            SeedHeaderRaw.shopCheckInfoNumEntries = count;
            SeedHeaderRaw.shopCheckInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfShopItems;    
        }

        static List<byte> generateEventFlags()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> listOfEventFlags = new List<byte>();
            ushort count = 0;
            byte[,] arrayOfEventFlags = {};
            byte[,] baseRandomizerEventFlags = new byte[,]
            {
                {0x6, 0x1}, //Tame Epona
                {0x14, 0x10}, //Put Bo outside, ready to wrestle
                {0xA, 0x20}, //Bridge of Eldin Stolen
                {0xF, 0x8}, //Bridge of Eldin Warped Back
                {0x40, 0x8} //Visited Gerudo Desert for the first time.
            };

            byte[,] faronTwilightEventFlags = new byte[,]
            {
                {0x5, 0x7F}, //Midna Charge Unlocked, Finished Sewers, Midna text after entering Faron Twilight, Met Zelda in sewers, Midna cut prison chain, Watched Sewers intro CS, Escaped cell in sewers.
                {0x6, 0x10}, //Cleared Faron Twilight
                {0xC, 0x8} //Midna accompanies Wolf
            };

            arrayOfEventFlags = BackendFunctions.concatFlagArrays(arrayOfEventFlags, baseRandomizerEventFlags);
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
            SeedHeaderRaw.eventFlagsInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfEventFlags;
        }

        static List<byte> generateRegionFlags()
        {
            RandomizerSetting randomizerSettings = Randomizer.RandoSetting;
            List<byte> listOfRegionFlags = new List<byte>();
            ushort count = 0;
            byte[,] arrayOfRegionFlags = {};
            //Flag translation: 
            //shift: 0 = 0x80 and 7 = 0x1
            // 
            byte[,] faronTwilightRegionFlags = new byte[,]
            {
                {0x2, 0x40},
                {0x2, 0x41},
                {0x2, 0x43},
                {0x2, 0x44},
                {0x2, 0x46},
                {0x2, 0x47}
            };

            byte[,] baseRandomizerRegionFlags = new byte[,]
            {
                {0x0, 0x57}, //Spider on Link's Ladder killed.
                {0x16, 0x47} //West Bridge in CiTS Broken
            };

            arrayOfRegionFlags = BackendFunctions.concatFlagArrays(arrayOfRegionFlags, baseRandomizerRegionFlags);

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
            SeedHeaderRaw.regionFlagsInfoDataOffset = (ushort)(CheckDataRaw.Count + 1 + seedHeaderSize);
            return listOfRegionFlags;
        }
    }
}