using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TPRandomizer
{
    public class GuiSetting
    {
        public int logicRules {get; set;}
        public int castleRequirements {get; set;}
        public int palaceRequirements {get; set;}
        public int faronWoodsLogic {get; set;}
        public bool mdhSkipped {get; set;}
        public bool introSkipped {get; set;}
        public int smallKeySettings {get; set;}
        public int bossKeySettings {get; set;}
        public int mapAndCompassSettings {get; set;}
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
        public int iceTrapSettings {get; set;}
        public List<Item> StartingItems {get; set;}
        public List<string> ExcludedChecks {get; set;}
        public int TunicColor {get; set;}
        public int MidnaHairColor {get; set;}
        public int lanternColor {get; set;}
        public int heartColor {get; set;}
        public int aButtonColor {get; set;}
        public int bButtonColor {get; set;}
        public int xButtonColor {get; set;}
        public int yButtonColor {get; set;}
        public int zButtonColor {get; set;}
        public bool shuffleBackgroundMusic {get; set;}
        public bool shuffleItemFanfares {get; set;}
        public bool disableEnemyBackgoundMusic {get; set;}
        public int gameRegion {get; set;}
        public bool shuffleHiddenSkills {get; set;}
        public bool shuffleSkyCharacters {get; set;}
    }
}