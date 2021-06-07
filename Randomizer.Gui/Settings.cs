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
        public string logicRules;
        public string castleRequirements;
        public string palaceRequirements;
        public string faronWoodsLogic;
        public bool mdhSkipped;
        public bool introSkipped;
        public string smallKeySettings;
        public string bossKeySettings;
        public string mapAndCompassSettings;
        public bool goldenBugsShuffled;
        public bool treasureChestsShuffled;
        public bool npcItemsShuffled;
        public bool shopItemsShuffled;
        public bool faronTwilightCleared;
        public bool eldinTwilightCleared;
        public bool lanayruTwilightCleared;
        public bool skipMinorCutscenes;
        public bool skipMasterSwordPuzzle;
        public bool fastIronBoots;
        public bool quickTransform;
        public bool transformAnywhere;
        public string iceTrapSettings;
        public List<string> StartingItems;
        public List<string> ExcludedChecks;
    }
}