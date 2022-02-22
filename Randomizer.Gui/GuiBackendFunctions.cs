namespace TPRandomizer
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    public class GuiBackendFunctions
    {
        /// <summary>
        /// Sets the appropriate settings based off of an inputted settings string.
        /// </summary>
        /// <param name="settingsString"> The Settings String that is to be deciphered. </param>
        public static void ParseSettingsString(string settingsString) 
        {
            ItemFunctions items = new ();
            settingsString = BackendFunctions.Base64Decode(settingsString);
            // Convert the settings string into a binary string to be interpreted.
            string bitString = BackendFunctions.TextToBitString(settingsString);
            PropertyInfo[] properties = Form1.settings.GetType().GetProperties();
            foreach (PropertyInfo property in properties) 
            {
                string evaluatedByteString = "";
                int settingBitWidth = 0;
                bool reachedEndofList = false;
                if (property.PropertyType == typeof(bool)) 
                {
                    int value = Convert.ToInt32(bitString[0].ToString(), 2);
                    if (value == 1) 
                    {
                        property.SetValue(Form1.settings, true, null);
                    }
                    else 
                    {
                        property.SetValue(Form1.settings, false, null);
                    }
                    bitString = bitString.Remove(0, 1);
                }
                if (property.PropertyType == typeof(int)) 
                {
                    settingBitWidth = 4;
                    // We want to get the binary values in the string in 4 bit pieces since that is what is was encrypted with.
                    for (int j = 0; j < settingBitWidth; j++) 
                    {
                        evaluatedByteString = evaluatedByteString + bitString[0];
                        bitString = bitString.Remove(0, 1);
                    }
                    property.SetValue(Form1.settings, Convert.ToInt32(evaluatedByteString, 2), null);
                }
                if (property.PropertyType == typeof(List<Item>)) 
                {
                    List<Item> startingItems = new ();
                    // We want to get the binary values in the string in 8 bit pieces since that is what is was encrypted with.
                    settingBitWidth = 9;
                    while (!reachedEndofList) 
                    {
                        for (int j = 0; j < settingBitWidth; j++) 
                        {
                            evaluatedByteString = evaluatedByteString + bitString[0];
                            bitString = bitString.Remove(0, 1);
                        }
                        int itemIndex = Convert.ToInt32(evaluatedByteString, 2);
                        if (itemIndex != 511) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                        {
                            foreach (Item item in items.ImportantItems) 
                            {
                                if (itemIndex == (byte)item) 
                                {
                                    startingItems.Add(item);
                                    break;
                                }
                            }
                        }
                        else 
                        {
                            reachedEndofList = true;
                        }
                        evaluatedByteString = "";
                    }
                    property.SetValue(Form1.settings, startingItems, null);
                }
                if (property.PropertyType == typeof(List<int>)) 
                {
                    List<int> excludedChecks = new ();
                    //We want to get the binary values in the string in 9 bit pieces since that is what is was encrypted with.
                    settingBitWidth = 9;
                    while (!reachedEndofList) 
                    {
                        for (int j = 0; j < settingBitWidth; j++) 
                        {
                            evaluatedByteString = evaluatedByteString + bitString[0];
                            bitString = bitString.Remove(0, 1);
                        }
                        int checkIndex = Convert.ToInt32(evaluatedByteString, 2);
                        if (checkIndex != 511) // Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                        {

                            excludedChecks.Add(checkIndex);
                        }
                        else 
                        {
                            reachedEndofList = true;
                        }
                        evaluatedByteString = "";
                    }
                    property.SetValue(Form1.settings, excludedChecks, null);
                }
            }
            return;
        }

        /// <summary>
        /// Generates a settings string based on the current settings.
        /// </summary>
        /// <returns> A string, representing the Settings String that is visible to the user.</returns>
        public static string GetSettingsString() 
        {
            string bits = "";
            //Get the properties of the class that contains the settings values so we can iterate through them.
            PropertyInfo[] properties = Form1.settings.GetType().GetProperties();
            foreach (PropertyInfo property in properties) 
            {
                var value = property.GetValue(Form1.settings, null);
                string i_bits = "";
                if (property.PropertyType == typeof(bool)) //Settings that only have two options (Shuffle Golden Bugs, etc.)
                {
                    if ((bool)value == true) 
                    {
                        i_bits = "1";
                    }
                    else 
                    {
                        i_bits = "0";
                    }
                }
                if (property.PropertyType == typeof(int)) //Settings that have multiple options (Hyrule Castle Requirements, etc.)
                {
                    value = property.GetValue(Form1.settings, null);
                    //Pad the integer value to 4 bits. No drop down menu uses more than 15 options so this is a safe bet.
                    i_bits = Convert.ToString((int)value, 2).PadLeft(4, '0');
                }
                if (property.PropertyType == typeof(List<Item>)) //Starting Items list
                {
                    if ((List<Item>)value != null) 
                    {
                        List<Item> itemList = new ();
                        itemList.AddRange((List<Item>)value);
                        foreach (Item item in itemList) 
                        {
                            //We pad the byte to 8 bits since item IDs don't go over 0xFF
                            i_bits = i_bits + Convert.ToString((byte)item, 2).PadLeft(9, '0');
                        }
                    }
                    //Place this at the end of the bit string. Will be useful when decoding to know when we've reached the end of the list.
                    i_bits = i_bits + "111111111";
                }
                if (property.PropertyType == typeof(List<int>)) //List of Excluded Checks
                {
                    List<int> checkList = new ();
                    checkList.AddRange((List<int>)value);
                    foreach (int check in checkList) 
                    {
                        //We have to pad to 9 bits here because there are hundreds of checks. Will need to be changed to 10 if we go over 512 checks though.
                        i_bits = i_bits + Convert.ToString((int)check, 2).PadLeft(9, '0');
                    }
                    //Place this at the end of the bit string. Will be useful when decoding to know when we've reached the end of the list.
                    i_bits = i_bits + "111111111";
                }
                bits = bits + i_bits;
            }
            return BackendFunctions.Base64Encode(BackendFunctions.BitStringToText(bits));
        }
    }
}