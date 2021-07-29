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
            "Ganondorf Defeated"
        };

        public List<string> dungeonRewardChecks = new List<string>()
        {
            "Forest Temple Dungeon Reward",
            "Goron Mines Dungeon Reward",
            "Lakebed Temple Dungeon Reward",
            "Arbiters Grounds Dungeon Reward",
            "Snowpeak Ruins Dungeon Reward", 
            "Temple of Time Dungeon Reward",
            "City in The Sky Dungeon Reward",
            "Palace of Twilight Dungeon Reward"
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
                if (!parseSetting.goldenBugsShuffled)
                {
                    if (currentCheck.category.Contains("Golden Bug"))
                    {
                        Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                        Randomizer.Items.RandomizedImportantItems.Remove(currentCheck.itemId);
                    }
                }
            }
            if (!parseSetting.introSkipped)
            {
                //We want to set Uli Cradle Delivery vanilla if intro is skipped since a Fishing Rod has to be there in order to progress the seed.
                Check currentCheck = Randomizer.Checks.CheckDict["Uli Cradle Delivery"];
                Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                Randomizer.Items.RandomizedImportantItems.Remove(currentCheck.itemId);
            }
            else
            {
                Check currentCheck = Randomizer.Checks.CheckDict["Uli Cradle Delivery"];
                currentCheck.isExcluded = true;
                currentCheck = Randomizer.Checks.CheckDict["Ordon Cat Rescue"];
                currentCheck.isExcluded = true;
                currentCheck = Randomizer.Checks.CheckDict["Sera Shop Slingshot"];
                currentCheck.isExcluded = true;
                currentCheck = Randomizer.Checks.CheckDict["Ordon Sword"];
                currentCheck.isExcluded = true;
                currentCheck = Randomizer.Checks.CheckDict["Ordon Shield"];
                currentCheck.isExcluded = true;
            }
        } 
    }
}