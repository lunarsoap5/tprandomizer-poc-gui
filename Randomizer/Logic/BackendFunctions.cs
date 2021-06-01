using System;
using System.Collections.Generic;

using System.Collections;
namespace TPRandomizer
{
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

        public static void interpretSettingsString(string SettingsString)
        {
            String flags = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz1234567890!@#$";
            String flagText = Base64Decode(SettingsString);

            while (flagText.Length < 19)
            {
                flagText += "A";
            }

            BitArray v = new BitArray(new int[] { flags.IndexOf(flagText[0]) });
            int[] array = new int[1];

            BitArray w = new BitArray(3);
            w[0] = v[0];
            w[1] = v[1];
            w[2] = v[2];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Logic Rules
                case 0:
                    Singleton.getInstance().Logic.SettingsList[0, 1] = "Glitchless";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[0, 1] = "Glitched";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[0, 1] = "No_Logic";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[3];
            w[1] = v[4];
            w[2] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[1]) });
            w[3] = v[0];
            w[4] = v[1];
            w[5] = v[2];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Hyrule Castle Access Requirements
                case 0:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Fused_Shadows";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Mirror_Shards";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "All_Dungeons";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Random_Dungeons";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[1, 1] = "Vanilla";
                    break;
            }
            w = new BitArray(4);
            w[0] = v[3];
            w[1] = v[4];
            w[2] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[2]) });

            w[3] = v[0];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Palace of Twilight Access Requirements
                case 0:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Fused_Shadows";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Mirror_Shards";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[2, 1] = "Vanilla";
                    break;
            }
            w = new BitArray(2);
            w[0] = v[1];
            w[1] = v[2];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Faron Woods Logic
                case 0:
                    Singleton.getInstance().Logic.SettingsList[3, 1] = "Open";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[3, 1] = "Closed";
                    break;
            }
            Singleton.getInstance().Logic.SettingsList[4, 1] = v[3].ToString();
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[3]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Small Key Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Keysanity";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[6, 1] = "Keysey";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[4]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Big Key Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Keysanity";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[7, 1] = "Keysey";
                    break;
            }
            w = new BitArray(6);
            w[0] = v[4];
            w[1] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[5]) });

            w[2] = v[0];
            w[3] = v[1];
            w[4] = v[2];
            w[5] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Map and Compass Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Vanilla";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Overworld";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Own_Dungeon";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Any_Dungeon";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Anywhere";
                    break;
                case 5:
                    Singleton.getInstance().Logic.SettingsList[8, 1] = "Start_With";
                    break;
            }


            Singleton.getInstance().Logic.SettingsList[9, 1] = v[4].ToString(); //Golden Bug Shuffled?
            Singleton.getInstance().Logic.SettingsList[10, 1] = v[5].ToString(); //Gift from NPCs

            v = new BitArray(new int[] { flags.IndexOf(flagText[6]) });

            Singleton.getInstance().Logic.SettingsList[11, 1] = v[0].ToString(); //Treasure Chests
            Singleton.getInstance().Logic.SettingsList[12, 1] = v[1].ToString(); //Shop Items Shuffled
            Singleton.getInstance().Logic.SettingsList[13, 1] = v[2].ToString(); //Faron Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[14, 1] = v[3].ToString(); //Eldin Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[15, 1] = v[4].ToString(); //Lanayru Twilight Cleared
            Singleton.getInstance().Logic.SettingsList[16, 1] = v[5].ToString(); //Skip Minor Cutscenes

            v = new BitArray(new int[] { flags.IndexOf(flagText[7]) });

            Singleton.getInstance().Logic.SettingsList[17, 1] = v[0].ToString(); //Skip Master Sword Puzzle
            Singleton.getInstance().Logic.SettingsList[18, 1] = v[1].ToString(); //Fast Iron Boots
            Singleton.getInstance().Logic.SettingsList[19, 1] = v[2].ToString(); //Quick Transform
            Singleton.getInstance().Logic.SettingsList[20, 1] = v[3].ToString(); //Transform Anywhere
            Singleton.getInstance().Logic.SettingsList[5, 1] = v[4].ToString(); // Intro Skipped
            w = new BitArray(6);
            w[0] = v[5];

            v = new BitArray(new int[] { flags.IndexOf(flagText[8]) });

            w[1] = v[0];
            w[2] = v[1];
            w[3] = v[2];
            w[4] = v[3];
            w.CopyTo(array, 0);
            switch (array[0])
            {
                //Map and Compass Settings
                case 0:
                    Singleton.getInstance().Logic.SettingsList[21, 1] = "None";
                    break;
                case 1:
                    Singleton.getInstance().Logic.SettingsList[21, 1] = "Few";
                    break;
                case 2:
                    Singleton.getInstance().Logic.SettingsList[21, 1] = "Extra";
                    break;
                case 3:
                    Singleton.getInstance().Logic.SettingsList[21, 1] = "Mayhem";
                    break;
                case 4:
                    Singleton.getInstance().Logic.SettingsList[21, 1] = "Nightmare";
                    break;
            }
        }
    }
}