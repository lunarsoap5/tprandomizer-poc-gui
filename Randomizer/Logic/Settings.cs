using System.Collections.Generic;

namespace TPRandomizer
{
    /// <summary>
    /// summary text.
    /// </summary>
    public class RandomizerSetting
    {
        public string logicRules { get; set; }

        public string castleRequirements { get; set; }

        public string palaceRequirements { get; set; }

        public string faronWoodsLogic { get; set; }

        public bool mdhSkipped { get; set; }

        public bool introSkipped { get; set; }

        public string smallKeySettings { get; set; }

        public string bossKeySettings { get; set; }

        public string mapAndCompassSettings { get; set; }

        public bool goldenBugsShuffled { get; set; }

        public bool poesShuffled { get; set; }

        public bool npcItemsShuffled { get; set; }

        public bool shopItemsShuffled { get; set; }

        public bool faronTwilightCleared { get; set; }

        public bool eldinTwilightCleared { get; set; }

        public bool lanayruTwilightCleared { get; set; }

        public bool skipMinorCutscenes { get; set; }

        public bool fastIronBoots { get; set; }

        public bool quickTransform { get; set; }

        public bool transformAnywhere { get; set; }

        public string iceTrapSettings { get; set; }

        public List<Item> StartingItems { get; set; }

        public List<string> ExcludedChecks { get; set; }

        public int TunicColor { get; set; }

        public int MidnaHairColor { get; set; }

        public int lanternColor { get; set; }

        public int heartColor { get; set; }

        public int aButtonColor { get; set; }

        public int bButtonColor { get; set; }

        public int xButtonColor { get; set; }

        public int yButtonColor { get; set; }

        public int zButtonColor { get; set; }

        public bool shuffleBackgroundMusic { get; set; }

        public bool shuffleItemFanfares { get; set; }

        public bool disableEnemyBackgoundMusic { get; set; }

        public string gameRegion { get; set; }

        public bool shuffleHiddenSkills { get; set; }

        public bool shuffleSkyCharacters { get; set; }

        public int seedNumber { get; set; }

        public bool increaseWallet { get; set; }

        public bool reduceDonations { get; set; }
    }

    public class SettingData
    {
        public static string[] logicRules { get; set; } =
            new string[] { "Glitchless", "Glitched", "No_Logic" };

        public string[] castleRequirements { get; set; } =
            new string[]
            {
                "Open",
                "Fused_Shadows",
                "Mirror_Shards",
                "All_Dungeons",
                "Random_Dungeons",
                "Vanilla",
            };

        public string[] palaceRequirements { get; set; } =
            new string[] { "Open", "Fused_Shadows", "Mirror_Shards", "Vanilla" };

        public string[] faronWoodsLogic { get; set; } = new string[] { "Open", "Closed" };

        public bool mdhSkipped { get; set; }

        public bool introSkipped { get; set; }

        public string[] smallKeySettings { get; set; } =
            new string[] { "Vanilla", "Own_Dungeon", "Any_Dungeon", "Keysanity", "Keysey" };

        public string[] bossKeySettings { get; set; } =
            new string[] { "Vanilla", "Own_Dungeon", "Any_Dungeon", "Keysanity", "Keysey" };

        public string[] mapAndCompassSettings { get; set; } =
            new string[] { "Vanilla", "Own_Dungeon", "Any_Dungeon", "Anywhere", "Start_With" };

        public bool goldenBugsShuffled { get; set; }

        public bool poesShuffled { get; set; }

        public bool npcItemsShuffled { get; set; }

        public bool shopItemsShuffled { get; set; }

        public bool faronTwilightCleared { get; set; }

        public bool eldinTwilightCleared { get; set; }

        public bool lanayruTwilightCleared { get; set; }

        public bool skipMinorCutscenes { get; set; }

        public bool fastIronBoots { get; set; }

        public bool quickTransform { get; set; }

        public bool transformAnywhere { get; set; }

        public string[] iceTrapSettings { get; set; } =
            new string[] { "None", "Few", "Extra", "Mayhem", "Nightmare" };

        public List<Item> StartingItems { get; set; }

        public List<string> ExcludedChecks { get; set; }

        public string[] TunicColor { get; set; } =
            new string[]
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
                "Random",
            };

        public string[] MidnaHairColor { get; set; } =
            new string[] { "Default", "Red", "Blue", "Cyan" };

        public string[] lanternColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Orange",
                "Yellow",
                "Lime Green",
                "Dark Green",
                "Blue",
                "Purple",
                "Black",
                "White",
                "Cyan"
            };

        public string[] heartColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Rainbow",
                "Teal",
                "Pink",
                "Orange",
                "Blue",
                "Purple",
                "Green",
                "Black",
                "Mango",
                "Dragon Fruit"
            };

        public string[] aButtonColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Red",
                "Orange",
                "Yellow",
                "Dark Green",
                "Purple",
                "Black",
                "Grey",
                "Pink"
            };

        public string[] bButtonColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Orange",
                "Pink",
                "Green",
                "Blue",
                "Purple",
                "Black",
                "Teal"
            };

        public string[] xButtonColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Red",
                "Orange",
                "Yellow",
                "Lime Green",
                "Dark Green",
                "Blue",
                "Purple",
                "Black",
                "Pink",
                "Cyan"
            };

        public string[] yButtonColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Red",
                "Orange",
                "Yellow",
                "Lime Green",
                "Dark Green",
                "Blue",
                "Purple",
                "Black",
                "Pink",
                "Cyan"
            };

        public string[] zButtonColor { get; set; } =
            new string[]
            {
                "Default",
                "Random",
                "Red",
                "Orange",
                "Yellow",
                "Lime Green",
                "Dark Green",
                "Purple",
                "Black",
                "Light Blue"
            };

        public bool shuffleBackgroundMusic { get; set; }

        public bool shuffleItemFanfares { get; set; }

        public bool disableEnemyBackgoundMusic { get; set; }

        public string[] gameRegion { get; set; } = new string[] { "NTSC", "PAL", "JAP" };

        public bool shuffleHiddenSkills { get; set; }

        public bool shuffleSkyCharacters { get; set; }

        public string[] seedNumber { get; set; } =
            new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public bool increaseWallet { get; set; }

        public bool reduceDonations { get; set; }
    }
}
