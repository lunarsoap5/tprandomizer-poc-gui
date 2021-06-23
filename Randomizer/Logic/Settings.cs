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
        public string goldenBugsShuffled {get; set;}
        public bool treasureChestsShuffled {get; set;}
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
        public string[] logicRules = new string[]
        {
            "Glitchless",
            "Glitched",
            "No_Logic"
        };
        public string[] castleRequirements = new string[]
        {};
        public string[] palaceRequirements = new string[]
        {};
        public string[] faronWoodsLogic = new string[]
        {};
        public bool mdhSkipped {get; set;}
        public bool introSkipped {get; set;}
        public string[] smallKeySettings = new string[]
        {};
        public string[] bossKeySettings = new string[]
        {};
        public string[] mapAndCompassSettings = new string[]
        {};
        public bool goldenBugsShuffled {get; set;}
        public bool treasureChestsShuffled {get; set;}
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
        public string[] iceTrapSettings = new string[]
        {};
        public List<Item> StartingItems {get; set;}
        public List<string> ExcludedChecks {get; set;}
        public string[] TunicColor = new string[]
        {};
        public string[] MidnaHairColor = new string[]
        {};
    }
}