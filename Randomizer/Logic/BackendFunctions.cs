using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

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

        public static void interpretSettingsString(string settingsString)
        {
            //Convert the settings string into a binary string to be interpreted.
            string bitString = textToBitString(settingsString);
            List<byte> bits = new List<byte>();
			PropertyInfo[] randoSettingProperties = Singleton.getInstance().RandoSetting.GetType().GetProperties();
            PropertyInfo[] settingDataProperties = Singleton.getInstance().RandoSettingData.GetType().GetProperties();
                foreach (PropertyInfo settingProperty in randoSettingProperties)
                {
                    string evaluatedByteString = "";
                    int settingBitWidth = 0;
                    bool reachedEndofList = false;
                    if (settingProperty.PropertyType == typeof(bool))
                    {
                        int value = Convert.ToInt32(bitString[0].ToString(), 2);
                        if (value == 1)
                        {
                            settingProperty.SetValue(Singleton.getInstance().RandoSetting, true, null);
                        } 
                        else
                        {
                            settingProperty.SetValue(Singleton.getInstance().RandoSetting, false, null);
                        }
                        bitString = bitString.Remove(0,1);
                    }
                    if (settingProperty.PropertyType == typeof(string))
                    {
                        //We loop through the Settings Data to match the index with the appropriate value.
                        foreach (PropertyInfo dataProperty in settingDataProperties)
			            {
                            var dataValue = dataProperty.GetValue(Singleton.getInstance().RandoSettingData, null);
                            Console.WriteLine(settingProperty.Name + " " + dataProperty.Name);
                            if (settingProperty.Name == dataProperty.Name)
                            {
                                settingBitWidth = 4;
                                //We want to get the binary values in the string in 4 bit pieces since that is what is was encrypted with.
                                for (int j = 0; j < settingBitWidth; j++)
                                {
                                    evaluatedByteString = evaluatedByteString + bitString[0];
                                    bitString = bitString.Remove(0,1);
                                }
                                
                                string[] dataArray = (string[])dataValue;
                                settingProperty.SetValue(Singleton.getInstance().RandoSetting, dataArray[Convert.ToInt32(evaluatedByteString, 2)], null);
                                break;
                            }
                        }
                    }
                    if (settingProperty.PropertyType == typeof(List<Item>))
                    {
                        List<Item> startingItems = new List<Item>();
                        //We want to get the binary values in the string in 8 bit pieces since that is what is was encrypted with.
                        settingBitWidth = 8;
                        while (!reachedEndofList)
                        {
                            for (int j = 0; j < settingBitWidth; j++)
                            {
                                evaluatedByteString = evaluatedByteString + bitString[0];
                                bitString = bitString.Remove(0,1);
                            }
                            int itemIndex = Convert.ToInt32(evaluatedByteString, 2);
                            if (itemIndex != 255) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                            {
                                foreach (Item item in Singleton.getInstance().Items.ImportantItems)
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
                        settingProperty.SetValue(Singleton.getInstance().RandoSetting, startingItems, null);
                    }
                    if (settingProperty.PropertyType == typeof(List<string>))
                    {
                        List<string> excludedChecks = new List<string>();
                        //We want to get the binary values in the string in 9 bit pieces since that is what is was encrypted with.
                        settingBitWidth = 9;
                        while (!reachedEndofList)
                        {
                            for (int j = 0; j < settingBitWidth; j++)
                            {
                                evaluatedByteString = evaluatedByteString + bitString[0];
                                bitString = bitString.Remove(0,1);
                            }
                            int checkIndex = Convert.ToInt32(evaluatedByteString, 2);
                            if (checkIndex != 511) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
                            {
                                excludedChecks.Add(Singleton.getInstance().Checks.CheckDict.ElementAt(checkIndex).Key);
                            }
                            else
                            {
                                reachedEndofList = true;
                            }
                            evaluatedByteString = "";
                        }
                        settingProperty.SetValue(Singleton.getInstance().RandoSetting, excludedChecks, null);
                    }
                    Console.WriteLine(settingProperty.Name + settingProperty.GetValue(Singleton.getInstance().RandoSetting, null));
            }
            return;
        }

        public static string settingsLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";
        public static char index_to_letter(int index) 
        { 
            char c = settingsLetters[index]; 
            return c; 
        }
        public static int letter_to_index(char letter)
        { 
            for (int i = 0; i < settingsLetters.Length; i++)
            {
                if (letter == settingsLetters[i])
                {
                    return i;
                }
            }
            return 0; 
        }

        public static string bitStringToText(string bits)
        {
            string result = "";
            //Pad the string to a value of 5
            while (bits.Length % 5 != 0)
            {
                bits = bits + "0";
            }
             
            for (int i = 0; i < bits.Length; i+=5)
            {
                string value = "";
                for (int j = 0; j < 5; j++)
                {
                    value = value + bits[i +j];
                }
                int byteValue = Convert.ToInt32(value, 2);
                result += index_to_letter(byteValue);
            }
            Console.WriteLine(bits);
            return result;
        }

        public static string textToBitString(string text)
        {
            string byteToBinary = "";
            foreach (char c in text)
            {
                int index = letter_to_index(c);
                byteToBinary = byteToBinary + Convert.ToString(index, 2).PadLeft(5, '0');
            }
            while (byteToBinary.Length % 5 != 0)
            {
                byteToBinary.TrimEnd('0');
            }
            Console.WriteLine("Read in settings string: " + byteToBinary);
            return byteToBinary;
        }    
    }
}