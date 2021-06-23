using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

//Settings string based on code by DigShake https://bitbucket.org/digshake/z2randomizer/src/master/WindowsFormsApplication1/Form1.cs

namespace TPRandomizer
{
    public partial class Form1 : Form
    {
        Randomizer randomizer = new Randomizer();
        GuiSetting settings = new GuiSetting();
        bool dontrunhandler;

        public Form1()
        {
            InitializeComponent();
            dontrunhandler = false;
            logicRulesBox.SelectedIndex = 0;
                    castleLogicComboBox.SelectedIndex = 1;
                    faronWoodsLogicComboBox.SelectedIndex = 1;
                    palaceLogicComboBox.SelectedIndex = 1;
                    mdhCheckBox.Checked = false;
                    smallKeyShuffleComboBox.SelectedIndex = 1;
                    bossKeyShuffleComboBox.SelectedIndex = 1;
                    mapsAndCompassesComboBox.SelectedIndex = 1;
                    goldenBugsCheckBox.Checked = true;
                    giftFromNPCsCheckBox.Checked = true;
                    treasureChestCheckBox.Checked = true;
                    shopItemsCheckBox.Checked = true;
                    faronTwilightClearedCheckBox.Checked = true;
                    eldinTwilightClearedCheckBox.Checked = true;
                    lanayruTwilightClearedCheckBox.Checked = true;
                    skipMinorCutscenesCheckBox.Checked = true;
                    skipMasterSwordPuzzleCheckBox.Checked = true;
                    fastIronBootsCheckBox.Checked = true;
                    quickTransformCheckBox.Checked = true;
                    transformAnywhereCheckBox.Checked = true;
                    skipIntroCheckBox.Checked = true;
                    foolishItemsComboBox.SelectedIndex = 1;
                    tunicColorComboBox.SelectedIndex = 1;
                    midnaHairColorComboBox.SelectedIndex = 1;
            logicRulesBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            castleLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            palaceLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            faronWoodsLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            mdhCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            smallKeyShuffleComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            bossKeyShuffleComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            mapsAndCompassesComboBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            goldenBugsCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            giftFromNPCsCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            treasureChestCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            shopItemsCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            faronTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            eldinTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            lanayruTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            skipMinorCutscenesCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            skipMasterSwordPuzzleCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            fastIronBootsCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            quickTransformCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            transformAnywhereCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            skipIntroCheckBox.CheckedChanged += new System.EventHandler(this.updateFlags);
            startingItemsListBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            excludedChecksListBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            listofChecksListBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);
            itemPoolListBox.SelectedIndexChanged += new System.EventHandler(this.updateFlags);

            foreach (KeyValuePair<string, Check> check in Singleton.getInstance().Checks.CheckDict)
            {
                string currentCheckName = check.Key;
                listofChecksListBox.Items.Add(currentCheckName);
                
            }
            foreach (var item in Singleton.getInstance().Items.ImportantItems)
            {
                string itemName = item.ToString();
                itemName = itemName.Replace("_", " ");
                itemPoolListBox.Items.Add(itemName);
            }
            
        }

        private void updateFlags(object sender, EventArgs e)
        {
            if (!dontrunhandler)
            {
                
                    settings.logicRules = logicRulesBox.SelectedIndex;
                    settings.castleRequirements = castleLogicComboBox.SelectedIndex;
                    settings.palaceRequirements = palaceLogicComboBox.SelectedIndex;
                    settings.faronWoodsLogic = faronWoodsLogicComboBox.SelectedIndex;
                    settings.mdhSkipped = mdhCheckBox.Checked;
                    settings.smallKeySettings = smallKeyShuffleComboBox.SelectedIndex;
                    settings.bossKeySettings = bossKeyShuffleComboBox.SelectedIndex;
                    settings.mapAndCompassSettings = mapsAndCompassesComboBox.SelectedIndex;
                    settings.goldenBugsShuffled = goldenBugsCheckBox.Checked;
                    settings.npcItemsShuffled = giftFromNPCsCheckBox.Checked;
                    settings.treasureChestsShuffled = treasureChestCheckBox.Checked;
                    settings.shopItemsShuffled = shopItemsCheckBox.Checked;
                    settings.faronTwilightCleared = faronTwilightClearedCheckBox.Checked;
                    settings.eldinTwilightCleared = eldinTwilightClearedCheckBox.Checked;
                    settings.lanayruTwilightCleared = lanayruTwilightClearedCheckBox.Checked;
                    settings.skipMinorCutscenes = skipMinorCutscenesCheckBox.Checked;
                    settings.skipMasterSwordPuzzle = skipMasterSwordPuzzleCheckBox.Checked;
                    settings.fastIronBoots = fastIronBootsCheckBox.Checked;
                    settings.quickTransform = quickTransformCheckBox.Checked;
                    settings.transformAnywhere = transformAnywhereCheckBox.Checked;
                    settings.introSkipped = skipIntroCheckBox.Checked;
                    settings.iceTrapSettings = foolishItemsComboBox.SelectedIndex;
                    settings.StartingItems = startingItemsListBox.Items.OfType<Item>().ToList();
                    foreach (string startingItem in startingItemsListBox.Items)
                    {
                        string itemName = startingItem;
                        itemName = itemName.Replace(" ", "_");
                        foreach (Item item in Singleton.getInstance().Items.ImportantItems)
                        {
                            if (item.ToString() == itemName)
                            {
                                settings.StartingItems.Add(item);
                                break;
                            }
                        }
                    }
                    settings.ExcludedChecks = excludedChecksListBox.Items.OfType<string>().ToList();
                    settings.TunicColor = tunicColorComboBox.SelectedIndex;
                    settings.MidnaHairColor = midnaHairColorComboBox.SelectedIndex;

                    settingsStringTextbox.Text = getSettingsString();
                
            }
        }

        private void updateInterface()
        {
            startingItemsListBox.Items.Clear();
                excludedChecksListBox.Items.Clear();
                listofChecksListBox.Items.Clear();
                itemPoolListBox.Items.Clear();

                foreach (KeyValuePair<string, Check> check in Singleton.getInstance().Checks.CheckDict)
                {
                    string currentCheckName = check.Key;
                    listofChecksListBox.Items.Add(currentCheckName);
                    
                }
                
                foreach (var item in Singleton.getInstance().Items.ImportantItems)
                {
                    string itemName = item.ToString();
                    itemName = itemName.Replace("_", " ");
                    itemPoolListBox.Items.Add(itemName);
                }
                getSettingsDisplay();
                
                    logicRulesBox.SelectedIndex = settings.logicRules;
                    castleLogicComboBox.SelectedIndex = settings.castleRequirements;
                    palaceLogicComboBox.SelectedIndex = settings.palaceRequirements;
                    faronWoodsLogicComboBox.SelectedIndex = settings.faronWoodsLogic;
                    mdhCheckBox.Checked = settings.mdhSkipped;
                    smallKeyShuffleComboBox.SelectedIndex = settings.smallKeySettings;
                    bossKeyShuffleComboBox.SelectedIndex = settings.bossKeySettings;
                    mapsAndCompassesComboBox.SelectedIndex = settings.mapAndCompassSettings;
                    goldenBugsCheckBox.Checked = settings.goldenBugsShuffled;
                    giftFromNPCsCheckBox.Checked = settings.npcItemsShuffled;
                    treasureChestCheckBox.Checked = settings.treasureChestsShuffled;
                    shopItemsCheckBox.Checked = settings.shopItemsShuffled;
                    faronTwilightClearedCheckBox.Checked = settings.faronTwilightCleared;
                    eldinTwilightClearedCheckBox.Checked = settings.eldinTwilightCleared;
                    lanayruTwilightClearedCheckBox.Checked = settings.lanayruTwilightCleared;
                    skipMinorCutscenesCheckBox.Checked = settings.skipMinorCutscenes;
                    skipMasterSwordPuzzleCheckBox.Checked = settings.skipMasterSwordPuzzle;
                    fastIronBootsCheckBox.Checked = settings.fastIronBoots;
                    quickTransformCheckBox.Checked = settings.quickTransform;
                    transformAnywhereCheckBox.Checked = settings.transformAnywhere;
                    skipIntroCheckBox.Checked = settings.introSkipped;
                    foolishItemsComboBox.SelectedIndex = settings.iceTrapSettings;
                    foreach (Item startingItem in settings.StartingItems)
                    {
                        string itemName = startingItem.ToString();
                        itemName = itemName.Replace("_", " ");
                        startingItemsListBox.Items.Add(itemName);
                        itemPoolListBox.Items.Remove(itemName);
                    }
                    foreach (string excludedCheck in settings.ExcludedChecks)
                    {
                        excludedChecksListBox.Items.Add(excludedCheck);
                        listofChecksListBox.Items.Remove(excludedCheck);
                    }
                    tunicColorComboBox.SelectedIndex = settings.TunicColor;
                    midnaHairColorComboBox.SelectedIndex = settings.MidnaHairColor;

                    settingsStringTextbox.Text = getSettingsString();
                
        }

        public string getSettingsString()
        {
            string bits = "";
			PropertyInfo[] properties = settings.GetType().GetProperties();
			foreach (PropertyInfo property in properties)
			{
                var value = property.GetValue(settings, null);
                string i_bits = "";
                if (property.PropertyType == typeof(bool))
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
                if (property.PropertyType == typeof(int))
                {
                    value = property.GetValue(settings, null);
                    i_bits = Convert.ToString((int)value, 2).PadLeft(4, '0');
                }
                if (property.PropertyType == typeof(List<Item>))
                    {
                        if ((List<Item>)value != null)
                        {
                            Console.WriteLine("Current Item List: " + value);
                            List<Item> itemList = new List<Item>();
                            itemList.AddRange((List<Item>)value);
                            foreach (Item item in itemList)
                            {
                                Console.WriteLine("Current Item: " + item);
                                if(Singleton.getInstance().Items.ImportantItems.Contains(item))
                                {
                                    Console.WriteLine("Current Item: " + item);
                                    //We will use the item ID in the bit array as it takes less memory and is easier to append
                                    i_bits = i_bits + Convert.ToString((byte)item, 2).PadLeft(8, '0');
                                }
                            }
                        }
                        i_bits = i_bits + "11111111"; //Let the function know that we have reached the end
                    }
                if (property.PropertyType == typeof(List<string>))
                    {
                        List<byte> excludedItems = new List<byte>();
                        List<string> checkList = new List<string>();
                        checkList.AddRange((List<string>)value);
                        foreach (string check in checkList)
                        {
                            int index = Singleton.getInstance().Checks.CheckDict.Keys.ToList().IndexOf(check);
                            //We have to pad to 9 bits here because there are hundreds of checks. Will need to be changed to 10 if we go over 512 checks though.
                            i_bits = i_bits + Convert.ToString(index, 2).PadLeft(9, '0');
                        }
                        i_bits = i_bits + "111111111";
                    }
                bits = bits + i_bits;
            }
            return BackendFunctions.bitStringToText(bits);
        }

        public void getSettingsDisplay()
        {
            string bitString = BackendFunctions.textToBitString(settingsStringTextbox.Text);
            List<byte> bits = new List<byte>();
			PropertyInfo[] properties = settings.GetType().GetProperties();
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
                        property.SetValue(settings, true, null);
                    } 
                    else
                    {
                        property.SetValue(settings, false, null);
                    }
                    bitString = bitString.Remove(0,1);
                }
                if (property.PropertyType == typeof(int))
                {
                    settingBitWidth = 4;
                    //We want to get the binary values in the string in 8-bit pieces
                    for (int j = 0; j < settingBitWidth; j++)
                    {
                        evaluatedByteString = evaluatedByteString + bitString[0];
                        bitString = bitString.Remove(0,1);
                    }
                    property.SetValue(settings, Convert.ToInt32(evaluatedByteString, 2), null);
                }
                if (property.PropertyType == typeof(List<Item>))
                {
                    List<Item> startingItems = new List<Item>();
                    settingBitWidth = 8;
                    while (!reachedEndofList)
                    {
                        for (int j = 0; j < settingBitWidth; j++)
                        {
                            evaluatedByteString = evaluatedByteString + bitString[0];
                            bitString = bitString.Remove(0,1);
                        }
                        int itemIndex = Convert.ToInt32(evaluatedByteString, 2);
                        if (itemIndex != 255)
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
                    property.SetValue(settings, startingItems, null);
                }
                if (property.PropertyType == typeof(List<string>))
                {
                    List<string> excludedChecks = new List<string>();
                    settingBitWidth = 9;
                    while (!reachedEndofList)
                    {
                        for (int j = 0; j < settingBitWidth; j++)
                        {
                            evaluatedByteString = evaluatedByteString + bitString[0];
                            bitString = bitString.Remove(0,1);
                        }
                        int checkIndex = Convert.ToInt32(evaluatedByteString, 2);
                        if (checkIndex != 511)
                        {
                            excludedChecks.Add(Singleton.getInstance().Checks.CheckDict.ElementAt(checkIndex).Key);
                        }
                        else
                        {
                            reachedEndofList = true;
                        }
                        evaluatedByteString = "";
                    }
                    property.SetValue(settings, excludedChecks, null);
                }
            }
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void moveCheckToExcludedButton_Click(object sender, EventArgs e)
        {
            if (listofChecksListBox.SelectedItem != null) //A little security feature in case the user mis-clicks
            {
                excludedChecksListBox.Items.Add(listofChecksListBox.SelectedItem);
                listofChecksListBox.Items.Remove(listofChecksListBox.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }


        

        private void generateButton_Click(object sender, EventArgs e)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText("SeedSettings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, settings);
            }
            Singleton.getInstance().Checks.CheckDict.Clear();
            randomizer.start();
            MessageBox.Show("Seed Generated! Check the folder for the randomizer gci and spoiler log!");
        }

        private void settingsPresetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentItem = settingsPresetsComboBox.SelectedItem.ToString();
            switch (currentItem)
            {
                case "Standard":
                    logicRulesBox.SelectedIndex = 0;
                    castleLogicComboBox.SelectedIndex = 1;
                    faronWoodsLogicComboBox.SelectedIndex = 1;
                    palaceLogicComboBox.SelectedIndex = 1;
                    mdhCheckBox.Checked = false;
                    smallKeyShuffleComboBox.SelectedIndex = 1;
                    bossKeyShuffleComboBox.SelectedIndex = 1;
                    mapsAndCompassesComboBox.SelectedIndex = 1;
                    goldenBugsCheckBox.Checked = true;
                    giftFromNPCsCheckBox.Checked = true;
                    treasureChestCheckBox.Checked = true;
                    shopItemsCheckBox.Checked = true;
                    faronTwilightClearedCheckBox.Checked = true;
                    eldinTwilightClearedCheckBox.Checked = true;
                    lanayruTwilightClearedCheckBox.Checked = true;
                    skipMinorCutscenesCheckBox.Checked = true;
                    skipMasterSwordPuzzleCheckBox.Checked = true;
                    fastIronBootsCheckBox.Checked = true;
                    quickTransformCheckBox.Checked = true;
                    transformAnywhereCheckBox.Checked = true;
                    skipIntroCheckBox.Checked = true;
                    foolishItemsComboBox.SelectedIndex = 1;
                    tunicColorComboBox.SelectedIndex = 1;
                    midnaHairColorComboBox.SelectedIndex = 1;
                    break;
            }
            
        }

        private void listofChecksListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void moveExcludedToCheckButton_Click(object sender, EventArgs e)
        {
            listofChecksListBox.Items.Add(excludedChecksListBox.SelectedItem);
            excludedChecksListBox.Items.Remove(excludedChecksListBox.SelectedItem);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            logicTooltip.SetToolTip(logicRulesBox,
                "Sets the main logic rules for the seed:" + Environment.NewLine +
                "'Glitchless' does not require any glitches, tricks, etc. Recommended for beginners." + Environment.NewLine +
                "'Glitched' assumes most glitches are in logic. Consult the Wiki for a complete list." + Environment.NewLine +
                "'No Logic' generates a seed without using logic, meaning it may not be beatable.");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addItemToStartingItemsButton_Click(object sender, EventArgs e)
        {
            startingItemsListBox.Items.Add(itemPoolListBox.SelectedItem);
            itemPoolListBox.Items.Remove(itemPoolListBox.SelectedItem);
        }

        private void removeItemFromStartingItemsButton_Click(object sender, EventArgs e)
        {
            itemPoolListBox.Items.Add(startingItemsListBox.SelectedItem);
            startingItemsListBox.Items.Remove(startingItemsListBox.SelectedItem);
        }

        private void settingsStringTextbox_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            dontrunhandler = true;
            updateInterface();
            dontrunhandler = false;
        }
    }
}
