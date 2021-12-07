using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

using System.Collections;
namespace TPRandomizer
{
    public class RandomizerSetting
    {
        public string logicRules {get; set;}
        public string castleRequirements {get; set;}
        public string palaceRequirements {get; set;}
        public string faronWoodsLogic {get; set;}
        public bool mdhSkipped {get; set;}
        public bool introSkipped {get; set;}
        public string smallKeySettings {get; set;}
        public string bossKeySettings {get; set;}
        public string mapAndCompassSettings {get; set;}
        public bool goldenBugsShuffled {get; set;}
        public bool poesShuffled {get; set;}
        public bool npcItemsShuffled {get; set;}
        public bool shopItemsShuffled {get; set;}
        public bool faronTwilightCleared {get; set;}
        public bool eldinTwilightCleared {get; set;}
        public bool lanayruTwilightCleared {get; set;}
        public bool skipMinorCutscenes {get; set;}
        public bool skipMasterSwordPuzzle {get; set;}
        public bool fastIronBoots {get; set;}
        public bool quickTransform {get; set;}
        public bool transformAnywhere {get; set;}
        public string iceTrapSettings {get; set;}
        public List<Item> StartingItems {get; set;}
        public List<string> ExcludedChecks {get; set;}
        public string TunicColor {get; set;}
        public string MidnaHairColor {get; set;}
    }

    public class SettingData
    {
        public static string[] logicRules {get; set;} = new string[] 
        {
            "Glitchless",
            "Glitched",
            "No_Logic"
        }; 
        public string[] castleRequirements {get; set;} = new string[]
        {
            "Open",
            "Fused_Shadows",
            "Mirror_Shards",
            "All_Dungeons",
            "Random_Dungeons",
            "Vanilla"
        };
        public string[] palaceRequirements {get; set;} = new string[]
        {
            "Open",
            "Fused_Shadows",
            "Mirror_Shards",
            "Vanilla"
        };
        public string[] faronWoodsLogic {get; set;} = new string[]
        {
            "Open",
            "Closed"
        };
        public bool mdhSkipped {get; set;}
        public bool introSkipped {get; set;}
        public string[] smallKeySettings {get; set;} = new string[]
        {
            "Vanilla",
            "Own_Dungeon",
            "Any_Dungeon",
            "Keysanity",
            "Keysey"
        };
        public string[] bossKeySettings {get; set;} = new string[]
        {
            "Vanilla",
            "Own_Dungeon",
            "Any_Dungeon",
            "Keysanity",
            "Keysey"
        };
        public string[] mapAndCompassSettings {get; set;} = new string[]
        {
            "Vanilla",
            "Own_Dungeon",
            "Any_Dungeon",
            "Anywhere",
            "Start_With"
        };
        public bool goldenBugsShuffled {get; set;}
        public bool poesShuffled {get; set;}
        public bool npcItemsShuffled {get; set;}
        public bool shopItemsShuffled {get; set;}
        public bool faronTwilightCleared {get; set;}
        public bool eldinTwilightCleared {get; set;}
        public bool lanayruTwilightCleared {get; set;}
        public bool skipMinorCutscenes {get; set;}
        public bool skipMasterSwordPuzzle {get; set;}
        public bool fastIronBoots {get; set;}
        public bool quickTransform {get; set;}
        public bool transformAnywhere {get; set;}
        public string[] iceTrapSettings {get; set;} = new string[]
        {
            "None",
            "Few",
            "Extra",
            "Mayhem",
            "Nightmare"
        };
        public List<Item> StartingItems {get; set;}
        public List<string> ExcludedChecks {get; set;}
        public string[] TunicColor {get; set;} = new string[]
        {
            "Default",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "Purple",
            "Grey",
            "Black",
            "White",
            "Random"
        };
        public string[] MidnaHairColor {get; set;} = new string[]
        {
            "Default",
            "Red",
            "Blue",
            "Cyan"
        };
    }
}