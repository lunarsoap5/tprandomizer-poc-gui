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
        public bool isExcluded { get; set;} //Identifies if the check is excluded or not. We can write the randomizer to not place important items in excluded checks
        public List<string> category { get; set;} //Allows grouping of checks to make it easier to randomize them based on their type, region, exclusion status, etc.
        public Item itemId { get; set;} //The original item id of the check. This allows us to make an array of all items in the item pool for randomization purposes. Also is useful for documentation purposes.
        public bool itemWasPlaced { get; set;} //Identifies if we already placed an item on this check.
        public bool hasBeenReached {get; set;} //indicates that we can get the current check. Prevents unneccesary repetitive parsing.
        public string checkType { get; set;} //i.e Arc, REL, POE, etc.
        public string relID { get; set;}
        public string offset { get; set;}
    }

    public class CheckFunctions
    {
        public Dictionary<string, Check> CheckDict = new Dictionary<string, Check>();


        public List<string> vanillaChecks = new List<string>();

        public void generateCheckList()
        {
            Randomizer.Checks.vanillaChecks.Clear();

            RandomizerSetting parseSetting = Randomizer.RandoSetting;
            foreach (KeyValuePair<string, Check> check in Randomizer.Checks.CheckDict)
            {
                Check currentCheck = check.Value;
                if (!parseSetting.ExcludedChecks.Contains(currentCheck.checkName))
                {
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
                            if (Randomizer.Items.ImportantItems.Contains(currentCheck.itemId))
                            {
                                Randomizer.Items.ImportantItems.Remove(currentCheck.itemId);
                            }
                            
                            Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                        }
                    }
                    if (!parseSetting.poesShuffled)
                    {
                        if (currentCheck.category.Contains("Poe"))
                        {
                            Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                        }
                    }
                    if (!parseSetting.goldenBugsShuffled)
                    {
                        if (currentCheck.category.Contains("Golden Bug"))
                        {
                            Randomizer.Checks.vanillaChecks.Add(currentCheck.checkName);
                        }
                    }
                }
                else
                {
                    currentCheck.isExcluded = true;
                }
            }
            if (!parseSetting.introSkipped)
            {
                //We want to set Uli Cradle Delivery vanilla if intro is not skipped since a Fishing Rod has to be there in order to progress the seed.
                //We also place the Lantern vanilla because it is a big logic hole and since we don't know how to make coro give both items in one state yet, it's safer to do this.
                Randomizer.Checks.vanillaChecks.Add(Randomizer.Checks.CheckDict["Uli Cradle Delivery"].checkName);
                Randomizer.Items.ImportantItems.Remove(Randomizer.Checks.CheckDict["Uli Cradle Delivery"].itemId);
                Randomizer.Checks.vanillaChecks.Add(Randomizer.Checks.CheckDict["Coro Lantern"].checkName);
                Randomizer.Items.ImportantItems.Remove(Randomizer.Checks.CheckDict["Coro Lantern"].itemId);
            }
            else
            {
                Randomizer.Checks.CheckDict["Uli Cradle Delivery"].isExcluded = true;
                Randomizer.Checks.CheckDict["Ordon Cat Rescue"].isExcluded = true;
                Randomizer.Checks.CheckDict["Sera Shop Slingshot"].isExcluded = true;
                Randomizer.Checks.CheckDict["Ordon Sword"].isExcluded = true;
                Randomizer.Checks.CheckDict["Ordon Shield"].isExcluded = true;
                Randomizer.Checks.CheckDict["Coro Lantern"].isExcluded = true;
            }
        } 
    }
}