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

//Settings string formula based on the Ocarina of Time Randomizer https://github.com/TestRunnerSRL/OoT-Randomizer/blob/Dev/Settings.py

namespace TPRandomizer
{
    public partial class Form1 : Form
    {
        Randomizer randomizer = new Randomizer();
        GuiSetting settings = new GuiSetting();
        bool dontrunhandler;
        bool isDarkModeEnabled;

        public Form1()
        {
            InitializeComponent();
            dontrunhandler = false;
            isDarkModeEnabled = false;
            logicRulesBox.SelectedIndex = 0;
            castleLogicComboBox.SelectedIndex = 0;
            faronWoodsLogicComboBox.SelectedIndex = 0;
            palaceLogicComboBox.SelectedIndex = 0;
            smallKeyShuffleComboBox.SelectedIndex = 0;
            bossKeyShuffleComboBox.SelectedIndex = 0;
            mapsAndCompassesComboBox.SelectedIndex = 0;
            foolishItemsComboBox.SelectedIndex = 0;
            tunicColorComboBox.SelectedIndex = 0;
            midnaHairColorComboBox.SelectedIndex = 0;
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

        /// <summary>
        /// Updates all of the backend settings to be reflective of the values displayed by the GUI.
        /// </summary>
        /// <param name="sender"> The object parameter triggering the function. </param>
        /// <param name="e"> The event being triggered. </param>
        private void updateFlags(object sender, EventArgs e)
        {
            //We have this small gatekeep to allow us to run functions against the senders without triggering this event.
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

        /// <summary>
        /// Decrypts the Settings string and updates the GUI with the appropriate settings.
        /// </summary>
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

            parseSettingsString(settingsStringTextbox.Text);
        
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

        /// <summary>
        /// Generates a settings string based on the current settings
        /// </summary>
        /// <returns> A string, representing the Settings String that is visible to the user.</returns>
        public string getSettingsString()
        {
            string bits = "";
            //Get the properties of the class that contains the settings values so we can iterate through them.
			PropertyInfo[] properties = settings.GetType().GetProperties(); 
			foreach (PropertyInfo property in properties)
			{
                var value = property.GetValue(settings, null);
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
                    value = property.GetValue(settings, null);
                    //Pad the integer value to 4 bits. No drop down menu uses more than 8 options so this is a safe bet.
                    i_bits = Convert.ToString((int)value, 2).PadLeft(4, '0'); 
                }
                if (property.PropertyType == typeof(List<Item>)) //Starting Items list
                    {
                        if ((List<Item>)value != null)
                        {
                            List<Item> itemList = new List<Item>();
                            itemList.AddRange((List<Item>)value);
                            foreach (Item item in itemList)
                            {
                                //We pad the byte to 8 bits since item IDs don't go over 0xFF
                                i_bits = i_bits + Convert.ToString((byte)item, 2).PadLeft(8, '0');
                            }
                        }
                        //Place this at the end of the bit string. Will be useful when decoding to know when we've reached the end of the list.
                        i_bits = i_bits + "11111111"; 
                    }
                if (property.PropertyType == typeof(List<string>)) //List of Excluded Checks
                    {
                        List<string> checkList = new List<string>();
                        checkList.AddRange((List<string>)value);
                        foreach (string check in checkList)
                        {
                            int index = Singleton.getInstance().Checks.CheckDict.Keys.ToList().IndexOf(check);
                            //We have to pad to 9 bits here because there are hundreds of checks. Will need to be changed to 10 if we go over 512 checks though.
                            i_bits = i_bits + Convert.ToString(index, 2).PadLeft(9, '0');
                        }
                        //Place this at the end of the bit string. Will be useful when decoding to know when we've reached the end of the list.
                        i_bits = i_bits + "111111111";
                    }
                bits = bits + i_bits;
            }
            return BackendFunctions.bitStringToText(bits);
        }

        /// <summary>
        /// Sets the appropriate settings based off of an inputted settings string.
        /// </summary>
        /// <param name="settingsString"> The Settings String that is to be deciphered. </param>
        public void parseSettingsString(string settingsString)
        {
            //Convert the settings string into a binary string to be interpreted.
            string bitString = BackendFunctions.textToBitString(settingsString);
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
                    //We want to get the binary values in the string in 4 bit pieces since that is what is was encrypted with.
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
                    property.SetValue(settings, startingItems, null);
                }
                if (property.PropertyType == typeof(List<string>))
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
                    property.SetValue(settings, excludedChecks, null);
                }
            }
            return;
        }

        private void moveCheckToExcludedButton_Click(object sender, EventArgs e)
        {
            if (listofChecksListBox.SelectedItem != null) //A little security feature in case the user mis-clicks
            {
                excludedChecksListBox.Items.Add(listofChecksListBox.SelectedItem);
                listofChecksListBox.Items.Remove(listofChecksListBox.SelectedItem);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Singleton.getInstance().Checks.CheckDict.Clear();
            randomizer.start(settingsStringTextbox.Text);
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

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDarkModeEnabled)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                this.ForeColor = Color.LightGray;
                optionsMenu.BackColor = Color.FromArgb(34, 36, 49);
                randomizationSettingsTabPage.BackColor = Color.FromArgb(34, 36, 49);
                randomizationSettingsBox.BackColor = Color.FromArgb(34, 36, 49);
                logicRulesBox.BackColor = Color.FromArgb(34, 36, 49); 
                logicRulesLabel.BackColor = Color.FromArgb(34, 36, 49); 
                itemPoolOptionsGroupBox.BackColor = Color.FromArgb(34, 36, 49); 
                itemCategoriesGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                foolishItemsComboBox.BackColor = Color.FromArgb(34, 36, 49); 
                foolishItemsLabel.BackColor = Color.FromArgb(34, 36, 49); 
                shopItemsCheckBox.BackColor = Color.FromArgb(34, 36, 49); 
                treasureChestCheckBox.BackColor = Color.FromArgb(34, 36, 49); 
                giftFromNPCsCheckBox.BackColor = Color.FromArgb(34, 36, 49); 
                goldenBugsCheckBox.BackColor = Color.FromArgb(34, 36, 49); 
                dungeonItemsGroupBox.BackColor = Color.FromArgb(34, 36, 49); 
                smallKeyShuffleComboBox.BackColor = Color.FromArgb(34, 36, 49); 
                mapsAndCompassesComboBox.BackColor = Color.FromArgb(34, 36, 49); 
                smallKeyShuffleLabel.BackColor = Color.FromArgb(34, 36, 49); 
                bossKeyShuffleComboBox.BackColor = Color.FromArgb(34, 36, 49); 
                bossKeyShuffleLabel.BackColor = Color.FromArgb(34, 36, 49);
                mapsAndCompassesLabel.BackColor = Color.FromArgb(34, 36, 49); 
                accessOptionsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                skipIntroCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                faronWoodsLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                faronWoodsLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                mdhCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                palaceLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                palaceLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                castleLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                castleLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                gameplaySettingsTabPage.BackColor = Color.FromArgb(34, 36, 49); 
                cutsceneMundaneSkipsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                skipMasterSwordPuzzleCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                skipMinorCutscenesCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                clearedTwilightsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                lanayruTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                eldinTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                faronTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                excludedChecksTabPage.BackColor = Color.FromArgb(34, 36, 49);
                excludedChecksListBox.BackColor = Color.WhiteSmoke;
                listofChecksListBox.BackColor = Color.WhiteSmoke;
                excludedChecksLabel.BackColor = Color.FromArgb(34, 36, 49);
                listofChecksLabel.BackColor = Color.FromArgb(34, 36, 49);
                moveExcludedToCheckButton.BackColor = Color.FromArgb(34, 36, 49);
                moveCheckToExcludedButton.BackColor = Color.FromArgb(34, 36, 49);
                inventoryTabPage.BackColor = Color.FromArgb(34, 36, 49);
                removeItemFromStartingItemsButton.BackColor = Color.FromArgb(34, 36, 49);
                addItemToStartingItemsButton.BackColor = Color.FromArgb(34, 36, 49);
                startingItemsLabel.BackColor = Color.FromArgb(34, 36, 49);
                startingItemsListBox.BackColor = Color.WhiteSmoke;
                itemPoolListBox.BackColor = Color.WhiteSmoke;
                label1.BackColor = Color.FromArgb(34, 36, 49);
                cosmeticsTabPage.BackColor = Color.FromArgb(34, 36, 49);
                transformAnywhereCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                quickTransformCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                midnaHairColorComboBox.BackColor = Color.FromArgb(34, 36, 49);
                midnaHairColorLabel.BackColor = Color.FromArgb(34, 36, 49);
                lanternColorComboBox.BackColor = Color.FromArgb(34, 36, 49);
                lanternColorLabel.BackColor = Color.FromArgb(34, 36, 49);
                tunicColorComboBox.BackColor = Color.FromArgb(34, 36, 49);
                fastIronBootsCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                tunicColorLabel.BackColor = Color.FromArgb(34, 36, 49); 
                generateButton.BackColor = Color.FromArgb(34, 36, 49);
                generateSpoilerLogCheckBox.BackColor = Color.FromArgb(34, 36, 49); 
                settingPresetsLabel.BackColor = Color.FromArgb(34, 36, 49); 
                settingsPresetsComboBox.BackColor = Color.FromArgb(34, 36, 49);
                listBox1.BackColor = Color.FromArgb(34, 36, 49); 
                outputTextBox.BackColor = Color.FromArgb(34, 36, 49); 
                MainMenuStrip.BackColor = Color.FromArgb(34, 36, 49); 
                fileToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                openToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                toolStripSeparator.BackColor = Color.FromArgb(34, 36, 49); 
                saveToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                toolStripSeparator1.BackColor = Color.FromArgb(34, 36, 49); 
                exitToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49);
                helpToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                WikiMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                toolStripSeparator5.BackColor = Color.FromArgb(34, 36, 49); ;
                aboutToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49); 
                settingsStringLabel.BackColor = Color.FromArgb(34, 36, 49); 
                settingsStringTextbox.BackColor = Color.LightGray;
                importButton.BackColor = Color.FromArgb(34, 36, 49);
                darkModeToolStripMenuItem.BackColor = Color.FromArgb(34, 36, 49);
                toolStripSeparator.BackColor = Color.FromArgb(34, 36, 49);
                toolStripSeparator1.BackColor = Color.FromArgb(34, 36, 49);

                optionsMenu.ForeColor = Color.LightGray;
                randomizationSettingsTabPage.ForeColor = Color.LightGray;
                randomizationSettingsBox.ForeColor = Color.LightGray;
                logicRulesBox.ForeColor = Color.LightGray; 
                logicRulesLabel.ForeColor = Color.LightGray; 
                itemPoolOptionsGroupBox.ForeColor = Color.LightGray; 
                itemCategoriesGroupBox.ForeColor = Color.LightGray;
                foolishItemsComboBox.ForeColor = Color.LightGray; 
                foolishItemsLabel.ForeColor = Color.LightGray; 
                shopItemsCheckBox.ForeColor = Color.LightGray; 
                treasureChestCheckBox.ForeColor = Color.LightGray; 
                giftFromNPCsCheckBox.ForeColor = Color.LightGray; 
                goldenBugsCheckBox.ForeColor = Color.LightGray; 
                dungeonItemsGroupBox.ForeColor = Color.LightGray; 
                smallKeyShuffleComboBox.ForeColor = Color.LightGray; 
                mapsAndCompassesComboBox.ForeColor = Color.LightGray; 
                smallKeyShuffleLabel.ForeColor = Color.LightGray; 
                bossKeyShuffleComboBox.ForeColor = Color.LightGray; 
                bossKeyShuffleLabel.ForeColor = Color.LightGray;
                mapsAndCompassesLabel.ForeColor = Color.LightGray; 
                accessOptionsGroupBox.ForeColor = Color.LightGray;
                skipIntroCheckBox.ForeColor = Color.LightGray;
                faronWoodsLogicComboBox.ForeColor = Color.LightGray;
                faronWoodsLogicLabel.ForeColor = Color.LightGray;
                mdhCheckBox.ForeColor = Color.LightGray;
                palaceLogicComboBox.ForeColor = Color.LightGray;
                palaceLogicLabel.ForeColor = Color.LightGray;
                castleLogicLabel.ForeColor = Color.LightGray;
                castleLogicComboBox.ForeColor = Color.LightGray;
                gameplaySettingsTabPage.ForeColor = Color.LightGray; 
                cutsceneMundaneSkipsGroupBox.ForeColor = Color.LightGray;
                skipMasterSwordPuzzleCheckBox.ForeColor = Color.LightGray;
                skipMinorCutscenesCheckBox.ForeColor = Color.LightGray;
                clearedTwilightsGroupBox.ForeColor = Color.LightGray;
                lanayruTwilightClearedCheckBox.ForeColor = Color.LightGray;
                eldinTwilightClearedCheckBox.ForeColor = Color.LightGray;
                faronTwilightClearedCheckBox.ForeColor = Color.LightGray;
                excludedChecksTabPage.ForeColor = Color.LightGray;
                excludedChecksLabel.ForeColor = Color.LightGray;
                listofChecksLabel.ForeColor = Color.LightGray;
                moveExcludedToCheckButton.ForeColor = Color.LightGray;
                moveCheckToExcludedButton.ForeColor = Color.LightGray;
                inventoryTabPage.ForeColor = Color.LightGray;
                removeItemFromStartingItemsButton.ForeColor = Color.LightGray;
                addItemToStartingItemsButton.ForeColor = Color.LightGray;
                startingItemsLabel.ForeColor = Color.LightGray;
                label1.ForeColor = Color.LightGray;
                cosmeticsTabPage.ForeColor = Color.LightGray;
                transformAnywhereCheckBox.ForeColor = Color.LightGray;
                quickTransformCheckBox.ForeColor = Color.LightGray;
                midnaHairColorComboBox.ForeColor = Color.LightGray;
                midnaHairColorLabel.ForeColor = Color.LightGray;
                lanternColorComboBox.ForeColor = Color.LightGray;
                lanternColorLabel.ForeColor = Color.LightGray;
                tunicColorComboBox.ForeColor = Color.LightGray;
                fastIronBootsCheckBox.ForeColor = Color.LightGray;
                tunicColorLabel.ForeColor = Color.LightGray; 
                generateButton.ForeColor = Color.LightGray;
                generateSpoilerLogCheckBox.ForeColor = Color.LightGray; 
                settingPresetsLabel.ForeColor = Color.LightGray; 
                settingsPresetsComboBox.ForeColor = Color.LightGray;
                listBox1.ForeColor = Color.LightGray; 
                outputTextBox.ForeColor = Color.LightGray; 
                MainMenuStrip.ForeColor = Color.LightGray; 
                fileToolStripMenuItem.ForeColor = Color.LightGray; 
                openToolStripMenuItem.ForeColor = Color.LightGray; 
                toolStripSeparator.ForeColor = Color.LightGray; 
                saveToolStripMenuItem.ForeColor = Color.LightGray; 
                toolStripSeparator1.ForeColor = Color.LightGray; 
                exitToolStripMenuItem.ForeColor = Color.LightGray;
                helpToolStripMenuItem.ForeColor = Color.LightGray; 
                WikiMenuItem.ForeColor = Color.LightGray; 
                toolStripSeparator5.ForeColor = Color.LightGray; ;
                aboutToolStripMenuItem.ForeColor = Color.LightGray; 
                settingsStringLabel.ForeColor = Color.LightGray; 
                importButton.ForeColor = Color.LightGray;
                darkModeToolStripMenuItem.ForeColor = Color.LightGray;
                toolStripSeparator.ForeColor = Color.LightGray;
                toolStripSeparator1.ForeColor = Color.LightGray;
                isDarkModeEnabled = true;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                optionsMenu.BackColor = Color.White;
                randomizationSettingsTabPage.BackColor = Color.White;
                randomizationSettingsBox.BackColor = Color.White;
                logicRulesBox.BackColor = Color.White; 
                logicRulesLabel.BackColor = Color.White; 
                itemPoolOptionsGroupBox.BackColor = Color.White; 
                itemCategoriesGroupBox.BackColor = Color.White;
                foolishItemsComboBox.BackColor = Color.White; 
                foolishItemsLabel.BackColor = Color.White; 
                shopItemsCheckBox.BackColor = Color.White; 
                treasureChestCheckBox.BackColor = Color.White; 
                giftFromNPCsCheckBox.BackColor = Color.White; 
                goldenBugsCheckBox.BackColor = Color.White; 
                dungeonItemsGroupBox.BackColor = Color.White; 
                smallKeyShuffleComboBox.BackColor = Color.White; 
                mapsAndCompassesComboBox.BackColor = Color.White; 
                smallKeyShuffleLabel.BackColor = Color.White; 
                bossKeyShuffleComboBox.BackColor = Color.White; 
                bossKeyShuffleLabel.BackColor = Color.White;
                mapsAndCompassesLabel.BackColor = Color.White; 
                accessOptionsGroupBox.BackColor = Color.White;
                skipIntroCheckBox.BackColor = Color.White;
                faronWoodsLogicComboBox.BackColor = Color.White;
                faronWoodsLogicLabel.BackColor = Color.White;
                mdhCheckBox.BackColor = Color.White;
                palaceLogicComboBox.BackColor = Color.White;
                palaceLogicLabel.BackColor = Color.White;
                castleLogicLabel.BackColor = Color.White;
                castleLogicComboBox.BackColor = Color.White;
                gameplaySettingsTabPage.BackColor = Color.White; 
                cutsceneMundaneSkipsGroupBox.BackColor = Color.White;
                skipMasterSwordPuzzleCheckBox.BackColor = Color.White;
                skipMinorCutscenesCheckBox.BackColor = Color.White;
                clearedTwilightsGroupBox.BackColor = Color.White;
                lanayruTwilightClearedCheckBox.BackColor = Color.White;
                eldinTwilightClearedCheckBox.BackColor = Color.White;
                faronTwilightClearedCheckBox.BackColor = Color.White;
                excludedChecksTabPage.BackColor = Color.White;
                excludedChecksListBox.BackColor = Color.White;
                listofChecksListBox.BackColor = Color.White;
                excludedChecksLabel.BackColor = Color.White;
                listofChecksLabel.BackColor = Color.White;
                moveExcludedToCheckButton.BackColor = Color.White;
                moveCheckToExcludedButton.BackColor = Color.White;
                inventoryTabPage.BackColor = Color.White;
                removeItemFromStartingItemsButton.BackColor = Color.White;
                addItemToStartingItemsButton.BackColor = Color.White;
                startingItemsLabel.BackColor = Color.White;
                startingItemsListBox.BackColor = Color.White;
                itemPoolListBox.BackColor = Color.White;
                label1.BackColor = Color.White;
                cosmeticsTabPage.BackColor = Color.White;
                transformAnywhereCheckBox.BackColor = Color.White;
                quickTransformCheckBox.BackColor = Color.White;
                midnaHairColorComboBox.BackColor = Color.White;
                midnaHairColorLabel.BackColor = Color.White;
                lanternColorComboBox.BackColor = Color.White;
                lanternColorLabel.BackColor = Color.White;
                tunicColorComboBox.BackColor = Color.White;
                fastIronBootsCheckBox.BackColor = Color.White;
                tunicColorLabel.BackColor = Color.White; 
                generateButton.BackColor = Color.White;
                generateSpoilerLogCheckBox.BackColor = Color.White; 
                settingPresetsLabel.BackColor = Color.White; 
                settingsPresetsComboBox.BackColor = Color.White;
                listBox1.BackColor = Color.White; 
                outputTextBox.BackColor = Color.White; 
                MainMenuStrip.BackColor = Color.White; 
                fileToolStripMenuItem.BackColor = Color.White; 
                openToolStripMenuItem.BackColor = Color.White; 
                toolStripSeparator.BackColor = Color.White; 
                saveToolStripMenuItem.BackColor = Color.White; 
                toolStripSeparator1.BackColor = Color.White; 
                exitToolStripMenuItem.BackColor = Color.White;
                helpToolStripMenuItem.BackColor = Color.White; 
                WikiMenuItem.BackColor = Color.White; 
                toolStripSeparator5.BackColor = Color.White; ;
                aboutToolStripMenuItem.BackColor = Color.White; 
                settingsStringLabel.BackColor = Color.White; 
                settingsStringTextbox.BackColor = Color.White;
                importButton.BackColor = Color.White;
                darkModeToolStripMenuItem.BackColor = Color.White;
                toolStripSeparator.BackColor = Color.White;
                toolStripSeparator1.BackColor = Color.White;

                optionsMenu.ForeColor = Color.Black;
                randomizationSettingsTabPage.ForeColor = Color.Black;
                randomizationSettingsBox.ForeColor = Color.Black;
                logicRulesBox.ForeColor = Color.Black; 
                logicRulesLabel.ForeColor = Color.Black; 
                itemPoolOptionsGroupBox.ForeColor = Color.Black; 
                itemCategoriesGroupBox.ForeColor = Color.Black;
                foolishItemsComboBox.ForeColor = Color.Black; 
                foolishItemsLabel.ForeColor = Color.Black; 
                shopItemsCheckBox.ForeColor = Color.Black; 
                treasureChestCheckBox.ForeColor = Color.Black; 
                giftFromNPCsCheckBox.ForeColor = Color.Black; 
                goldenBugsCheckBox.ForeColor = Color.Black; 
                dungeonItemsGroupBox.ForeColor = Color.Black; 
                smallKeyShuffleComboBox.ForeColor = Color.Black; 
                mapsAndCompassesComboBox.ForeColor = Color.Black; 
                smallKeyShuffleLabel.ForeColor = Color.Black; 
                bossKeyShuffleComboBox.ForeColor = Color.Black; 
                bossKeyShuffleLabel.ForeColor = Color.Black;
                mapsAndCompassesLabel.ForeColor = Color.Black; 
                accessOptionsGroupBox.ForeColor = Color.Black;
                skipIntroCheckBox.ForeColor = Color.Black;
                faronWoodsLogicComboBox.ForeColor = Color.Black;
                faronWoodsLogicLabel.ForeColor = Color.Black;
                mdhCheckBox.ForeColor = Color.Black;
                palaceLogicComboBox.ForeColor = Color.Black;
                palaceLogicLabel.ForeColor = Color.Black;
                castleLogicLabel.ForeColor = Color.Black;
                castleLogicComboBox.ForeColor = Color.Black;
                gameplaySettingsTabPage.ForeColor = Color.Black; 
                cutsceneMundaneSkipsGroupBox.ForeColor = Color.Black;
                skipMasterSwordPuzzleCheckBox.ForeColor = Color.Black;
                skipMinorCutscenesCheckBox.ForeColor = Color.Black;
                clearedTwilightsGroupBox.ForeColor = Color.Black;
                lanayruTwilightClearedCheckBox.ForeColor = Color.Black;
                eldinTwilightClearedCheckBox.ForeColor = Color.Black;
                faronTwilightClearedCheckBox.ForeColor = Color.Black;
                excludedChecksTabPage.ForeColor = Color.Black;
                excludedChecksLabel.ForeColor = Color.Black;
                listofChecksLabel.ForeColor = Color.Black;
                moveExcludedToCheckButton.ForeColor = Color.Black;
                moveCheckToExcludedButton.ForeColor = Color.Black;
                inventoryTabPage.ForeColor = Color.Black;
                removeItemFromStartingItemsButton.ForeColor = Color.Black;
                addItemToStartingItemsButton.ForeColor = Color.Black;
                startingItemsLabel.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                cosmeticsTabPage.ForeColor = Color.Black;
                transformAnywhereCheckBox.ForeColor = Color.Black;
                quickTransformCheckBox.ForeColor = Color.Black;
                midnaHairColorComboBox.ForeColor = Color.Black;
                midnaHairColorLabel.ForeColor = Color.Black;
                lanternColorComboBox.ForeColor = Color.Black;
                lanternColorLabel.ForeColor = Color.Black;
                tunicColorComboBox.ForeColor = Color.Black;
                fastIronBootsCheckBox.ForeColor = Color.Black;
                tunicColorLabel.ForeColor = Color.Black; 
                generateButton.ForeColor = Color.Black;
                generateSpoilerLogCheckBox.ForeColor = Color.Black; 
                settingPresetsLabel.ForeColor = Color.Black; 
                settingsPresetsComboBox.ForeColor = Color.Black;
                listBox1.ForeColor = Color.Black; 
                outputTextBox.ForeColor = Color.Black; 
                MainMenuStrip.ForeColor = Color.Black; 
                fileToolStripMenuItem.ForeColor = Color.Black; 
                openToolStripMenuItem.ForeColor = Color.Black; 
                toolStripSeparator.ForeColor = Color.Black; 
                saveToolStripMenuItem.ForeColor = Color.Black; 
                toolStripSeparator1.ForeColor = Color.Black; 
                exitToolStripMenuItem.ForeColor = Color.Black;
                helpToolStripMenuItem.ForeColor = Color.Black; 
                WikiMenuItem.ForeColor = Color.Black; 
                toolStripSeparator5.ForeColor = Color.Black; ;
                aboutToolStripMenuItem.ForeColor = Color.Black; 
                settingsStringLabel.ForeColor = Color.Black; 
                importButton.ForeColor = Color.Black;
                darkModeToolStripMenuItem.ForeColor = Color.Black;
                toolStripSeparator.ForeColor = Color.Black;
                toolStripSeparator1.ForeColor = Color.Black;
                isDarkModeEnabled = false;
            }
        }


        private void importButton_Click(object sender, EventArgs e)
        {
            dontrunhandler = true;
            updateInterface();
            dontrunhandler = false;
        }
    }
}
