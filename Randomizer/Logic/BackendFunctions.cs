using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using System.Collections;
namespace TPRandomizer
{
    public class RandomizerSetting
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
    public class BackendFunctions
    {
        //Encode the settings string. 
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Decode the settings string.
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void interpretSettingsString()
        {
            string contents = File.ReadAllText("SeedSettings.json");
            Singleton.getInstance().RandoSetting = JsonConvert.DeserializeObject<RandomizerSetting>(contents);
            RandomizerSetting parseSetting = Singleton.getInstance().RandoSetting;
            parseSetting.logicRules = parseSetting.logicRules.Replace(" ", "_");
            parseSetting.castleRequirements = parseSetting.castleRequirements.Replace(" ", "_");
            parseSetting.palaceRequirements = parseSetting.palaceRequirements.Replace(" ", "_");
            parseSetting.faronWoodsLogic = parseSetting.faronWoodsLogic.Replace(" ", "_");
            parseSetting.smallKeySettings = parseSetting.smallKeySettings.Replace(" ", "_");
            parseSetting.bossKeySettings = parseSetting.bossKeySettings.Replace(" ", "_");
            parseSetting.mapAndCompassSettings = parseSetting.mapAndCompassSettings.Replace(" ", "_");
            parseSetting.iceTrapSettings = parseSetting.iceTrapSettings.Replace(" ", "_");
            for (int i = 0; i < parseSetting.StartingItems.Count; i++)
            {
                parseSetting.StartingItems[i] = parseSetting.StartingItems[i].Replace(" ", "_");
            }
            for (int i = 0; i < parseSetting.ExcludedChecks.Count; i++)
            {
                parseSetting.ExcludedChecks[i] = parseSetting.ExcludedChecks[i].Replace(" ", "_");
            }
            Singleton.getInstance().RandoSetting = parseSetting;
            Console.WriteLine("Settings File Loaded Successfully");
        }
    }
}