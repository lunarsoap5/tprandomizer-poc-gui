using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TPRandomizer
{
    public class Check
    {
        public string checkName { set; get;} //the common name for the check this can be used in the randomizer to identify the check."
        public string requirements { get; set;} //List of requirements to obtain this check while inside the room (so does not include the items needed to enter the room)
        public string hash { get; set;} //the fletcher hash that will be compared to on stage load
        public bool isExcluded { get; set;} //Identifies if the check is excluded or not. We can write the randomizer to not place important items in excluded checks
        public List<string> category { get; set;} //Allows grouping of checks to make it easier to randomize them based on their type, region, exclusion status, etc.
        public Item itemId { get; set;} //The original item id of the check. This allows us to make an array of all items in the item pool for randomization purposes. Also is useful for documentation purposes.
        public bool itemWasPlaced { get; set;} //Identifies if we already placed an item on this check.
        public bool hasBeenReached {get; set;} //indicates that we can get the current check. Prevents unneccesary repetitive parsing.
    }

    public class CheckFunctions
    {
        public Dictionary<string, Check> CheckDict = new Dictionary<string, Check>();
        public Dictionary<string, Check> DungeonRewardDict = new Dictionary<string, Check>();

        public List<string> vanillaChecks = new List<string>();
        public List<string> nonRandomizedChecks = new List<string>()
        {
            "Agitha First Bug Pair Reward",
            "Agitha Second Bug Pair Reward",
            "Agitha Third Bug Pair Reward",
            "Agitha Fourth Bug Pair Reward",
            "Agitha Fifth Bug Pair Reward",
            "Agitha Sixth Bug Pair Reward",
            "Agitha Seventh Bug Pair Reward",
            "Agitha Eighth Bug Pair Reward",
            "Agitha Ninth Bug Pair Reward",
            "Agitha Tenth Bug Pair Reward",
            "Agitha Eleventh Bug Pair Reward",
            "Agitha Second Single Bug Reward",
            "Agitha Third Single Bug Reward",
            "Agitha Fourth Single Bug Reward",
            "Agitha Fifth Single Bug Reward",
            "Agitha Sixth Single Bug Reward",
            "Agitha Seventh Single Bug Reward",
            "Agitha Eighth Single Bug Reward",
            "Agitha Ninth Single Bug Reward",
            "Agitha Tenth Single Bug Reward",
            "Agitha Eleventh Single Bug Reward",
            "Agitha Twelfth Single Bug Reward",
            "Ganondorf Defeated"
        };

        public List<string> dungeonRewardChecks = new List<string>()
        {
            "Forest Temple Diababa Heart Container",
            "Goron Mines Fyrus Heart Container",
            "Lakebed Temple Morpheel Heart Container",
            "Arbiters Grounds Stallord Heart Container",
            "Snowpeak Ruins Blizzeta Heart Container", 
            "Temple of Time Armogohma Heart Container",
            "City in The Sky Argorok Heart Container",
            "Palace of Twilight Zant Heart Container"
        };

        public void generateCheckList()
        {
            Randomizer.Checks.vanillaChecks.Clear();
            Randomizer.Checks.vanillaChecks.AddRange(nonRandomizedChecks);

            RandomizerSetting parseSetting = Randomizer.RandoSetting;
            foreach (KeyValuePair<string, Check> check in Randomizer.Checks.CheckDict)
            {
                Check currentCheck = check.Value;
                if ((parseSetting.smallKeySettings == "Vanilla") && currentCheck.category.Contains("Small Key"))
                {
                    Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                }
                if ((parseSetting.bossKeySettings == "Vanilla") && currentCheck.category.Contains("Big Key"))
                {
                    Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                }
                if ((parseSetting.mapAndCompassSettings == "Vanilla") && (currentCheck.category.Contains("Dungeon Map") || currentCheck.category.Contains("Compass")))
                {
                    Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                }
                if (!parseSetting.npcItemsShuffled)
                {
                    if (currentCheck.category.Contains("Npc"))
                    {
                        currentCheck.isExcluded = true;
                    }
                }
                if (!parseSetting.treasureChestsShuffled)
                {
                    if (currentCheck.category.Contains("Chest"))
                    {
                        currentCheck.isExcluded = true;
                    }
                }
            }
            if (!parseSetting.introSkipped)
            {
                Check currentCheck = Randomizer.Checks.CheckDict["Uli Cradle Delivery"];
                Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                Randomizer.Items.ImportantItems.Remove(Item.Progressive_Fishing_Rod);
            }
        } 
    }
}