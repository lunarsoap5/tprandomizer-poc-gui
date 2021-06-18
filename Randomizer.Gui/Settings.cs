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
        public int logicRules;
        public int castleRequirements;
        public int palaceRequirements;
        public int faronWoodsLogic;
        public bool mdhSkipped;
        public bool introSkipped;
        public int smallKeySettings;
        public int bossKeySettings;
        public int mapAndCompassSettings;
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
        public int iceTrapSettings;
        public List<int> StartingItems;
        public List<int> ExcludedChecks;
        public List<int> TunicColor;
        public List<int> MidnaHairColor;
    }
}