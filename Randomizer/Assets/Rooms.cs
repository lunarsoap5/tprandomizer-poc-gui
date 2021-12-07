using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TPRandomizer
{
    public class Room
		{
			public string name { get; set;} //Name we give the room to identify it (it can be a series of rooms that don't have requirements between each other to make the algorithm go faster)
			public List<string> neighbours { get; set;} //Refers to the rooms of the same stage that can be accesed from this room
			public List<string> neighbourRequirements { get; set;} //List of list of requirements to enter each neighbouring room
			public bool isStartingRoom { get; set;} //Defines if it is the stage you start the game in
			public List<string> checks { get; set;} //Checks contained inside the room
			public bool visited { get; set;}
			public string region { get; set;}
		}
    
    public class RoomFunctions
    {
        
        public Dictionary<string, Room> RoomDict = new Dictionary<string, Room>();

         public bool isRegionCheck(Item itemToPlace, Check currentCheck, Room currentRoom)
        {
            RandomizerSetting parseSetting = Randomizer.RandoSetting;
            string itemName = itemToPlace.ToString();
            itemName = itemName.Replace("_", " ");
            if (Randomizer.Items.RegionSmallKeys.Contains(itemToPlace))
            {
                if ((parseSetting.smallKeySettings == "Own_Dungeon") && itemName.Contains(currentRoom.region))
                {
                    return true;
                }
                else if ((parseSetting.smallKeySettings == "Any_Dungeon") && currentCheck.category.Contains("Dungeon"))
                {
                    return true;
                }
            }
            else if (Randomizer.Items.DungeonBigKeys.Contains(itemToPlace))
            {
                if (parseSetting.bossKeySettings == "Own_Dungeon")
                {
                    if (itemName.Contains(currentRoom.region))
                    {
                        return true;
                    }
                }
                else if (parseSetting.bossKeySettings == "Any_Dungeon")
                {
                    if (currentCheck.category.Contains("Dungeon"))
                    {
                        return true;
                    }
                }
            }
            else if (Randomizer.Items.DungeonMapsAndCompasses.Contains(itemToPlace))
            {
                if (parseSetting.mapAndCompassSettings == "Own_Dungeon")
                {
                    if (itemName.Contains(currentRoom.region))
                    {
                        return true;
                    }
                }
                else if (parseSetting.mapAndCompassSettings == "Any_Dungeon")
                {
                    if (currentCheck.category.Contains("Dungeon"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}