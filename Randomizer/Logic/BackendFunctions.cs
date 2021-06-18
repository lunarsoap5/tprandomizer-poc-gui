using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

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
        public string TunicColor;
        public string MidnaHairColor;
        public bool ShuffleBackgroundMusic;
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

        public static string bitStringToText(BitArray bits)
        {
            string result = "";
            // pad the bits array to be multiple of 5
            while (bits.Length % 5 > 0)
            {
                bits.Length++;
            }
            // convert to characters
            string binary = null;
            int[] intBits = bits.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            for (int i = 0; i < intBits.Length; i+=5)
            {
                int value = 0;
                for (int j = 0; j < 5; j++)
                {
                    binary = binary + intBits[i +j].ToString();
                }
                value = Convert.ToInt32(binary, 2);
                result += index_to_letter(value);
            }
            return result;
        }

        public BitArray text_to_bit_string(string text)
        {
            BitArray bits = null;
            foreach (char c in text)
            {
                int index = letter_to_index(c);
                bits = new BitArray(new byte[] { (byte)index });
                int[] intBits = bits.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            }
            return bits;
        }

        public static BitArray Append(BitArray current, BitArray after) 
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }
        
            /* Settings string key
            logicRules- 
            castleRequirements- 
            palaceRequirements-
            faronWoodsLogic- 
            mdhSkipped-
            introSkipped-
            smallKeySettings-
            bossKeySettings-
            mapAndCompassSettings- 
            goldenBugsShuffled-
            treasureChestsShuffled-
            npcItemsShuffled-
            shopItemsShuffled- 
            faronTwilightCleared- 
            eldinTwilightCleared-
            lanayruTwilightCleared-
            skipMinorCutscenes-
            skipMasterSwordPuzzle- 
            fastIronBoots-
            quickTransform- 
            transformAnywhere- 
            iceTrapSettings-
            StartingItems-
            ExcludedChecks 
            TunicColor-
            MidnaHairColor-
            ShuffleBackgroundMusic-
            */
        
    }
}

/* Ignore everything below. This is just a code sample that I have been testing with.
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;
					

namespace CompressString
{
    internal static class StringCompressor
    {
        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
		class Person
		{
			private int age;
			private string name;

			public int Age
			{
				get { return age; }
				set { age = value; }
			}

			public string Name
			{
				get { return name; }
				set { name = value; }
			}
			public bool isAlive
			{
				get { return isAlive; }
				set { isAlive = value; }
			}
		}
		public static void Main()
		{
			int x = 255;
			string y = null;
			string s = Convert.ToString(x, 2); //Convert to binary in a string

			int[] bits= s.PadLeft(8, '0') // Add 0's from left
				 .Select(c => int.Parse(c.ToString())) // convert each char to int
				 .ToArray(); // Convert IEnumerable from select to Array
			foreach (var item in bits)
			{
				y = y + item.ToString();
			}
			Console.WriteLine(y);
			y = "Gift From Rusl";
			y = CompressString(y);
			Console.WriteLine(y);
			
			Person person = new Person();
			person.Age = 27;
			person.Name = "Fernando Vezzali";

			Type type = typeof(Person);
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties)
			{
				Console.WriteLine(property.PropertyType);
				if(property.PropertyType == typeof(bool))
				{
					Console.WriteLine("true");
				}
			}
		}
    }
}
*/