

//Settings string formula based on the Ocarina of Time Randomizer https://github.com/TestRunnerSRL/OoT-Randomizer/blob/Dev/Settings.py

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

    /// <summary>
    /// Generates a randomizer seed given a settings string.
    /// </summary>
    public partial class Form1 : Form 
    {
        private readonly Randomizer randomizer = new Randomizer();
        public static readonly GuiSetting settings = new GuiSetting();
        private readonly ItemFunctions items = new ItemFunctions();
        private bool dontrunhandler;
        private bool isDarkModeEnabled;

        public static List<string> RandomizerChecks = new List<string>();


        public Form1() {
            InitializeComponent();
            TextBoxWriter writer = new TextBoxWriter(this.outputTextBox);
            //Console.SetOut(writer);
            this.dontrunhandler = false;
            this.isDarkModeEnabled = false;
            this.logicRulesBox.SelectedIndex = 0;
            this.castleLogicComboBox.SelectedIndex = 0;
            this.faronWoodsLogicComboBox.SelectedIndex = 0;
            this.palaceLogicComboBox.SelectedIndex = 0;
            this.smallKeyShuffleComboBox.SelectedIndex = 0;
            this.bossKeyShuffleComboBox.SelectedIndex = 0;
            this.mapsAndCompassesComboBox.SelectedIndex = 0;
            this.foolishItemsComboBox.SelectedIndex = 0;
            this.tunicColorComboBox.SelectedIndex = 0;
            this.midnaHairColorComboBox.SelectedIndex = 0;
            this.lanternColorComboBox.SelectedIndex = 0;
            this.heartColorComboBox.SelectedIndex = 0;
            this.aButtonComboBox.SelectedIndex = 0;
            this.bButtonComboBox.SelectedIndex = 0;
            this.xButtonComboBox.SelectedIndex = 0;
            this.yButtonComboBox.SelectedIndex = 0;
            this.zButtonComboBox.SelectedIndex = 0;
            this.regionComboBox.SelectedIndex = 0;
            this.seedNumberComboBox.SelectedIndex = 0;
            this.logicRulesBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.castleLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.palaceLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.faronWoodsLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.mdhCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.smallKeyShuffleComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.bossKeyShuffleComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.mapsAndCompassesComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.goldenBugsCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.giftFromNPCsCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.poeCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.shopItemsCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.faronTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.eldinTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.lanayruTwilightClearedCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.skipMinorCutscenesCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.fastIronBootsCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.quickTransformCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.transformAnywhereCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.skipIntroCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.tunicColorComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.midnaHairColorComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.lanternColorComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.heartColorComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.aButtonComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.bButtonComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.xButtonComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.yButtonComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.zButtonComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.bgmCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.fanfareCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.enemyBgmCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.regionComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.skillsCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.skyCharacterCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.outputTextBox.TextChanged += new System.EventHandler(this.outputTextBox_textChanged);
            this.seedNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateFlags);
            this.walletCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);
            this.donationCheckBox.CheckedChanged += new System.EventHandler(this.UpdateFlags);

            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/World/Checks/","*",SearchOption.AllDirectories)) 
            {
                string contents = File.ReadAllText(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                RandomizerChecks.Add(fileName);
            }
            for ( int i = 0; i < RandomizerChecks.Count; i++) 
            {
                this.listofChecksListBox.Items.Add(new ListItem { Name = RandomizerChecks[i], Value = i});
            }
            foreach (var item in items.ImportantItems) 
            {
                string itemName = item.ToString();
                itemName = itemName.Replace("_", " ");
                this.itemPoolListBox.Items.Add(new ListItem { Name = itemName, Value = (byte)item});
            }
            settings.ExcludedChecks = new ();
        }

        /// <summary>
        /// Updates all of the backend settings to be reflective of the values displayed by the GUI.
        /// </summary>
        /// <param name="sender"> The object parameter triggering the function. </param>
        /// <param name="e"> The event being triggered. </param>
        private void UpdateFlags(object sender, EventArgs e) 
        {
            //We have this small gatekeep to allow us to run functions against the senders without triggering this event.
            if (!this.dontrunhandler) 
            {
                settings.logicRules = this.logicRulesBox.SelectedIndex;
                settings.castleRequirements = this.castleLogicComboBox.SelectedIndex;
                settings.palaceRequirements = this.palaceLogicComboBox.SelectedIndex;
                settings.faronWoodsLogic = this.faronWoodsLogicComboBox.SelectedIndex;
                settings.mdhSkipped = this.mdhCheckBox.Checked;
                settings.smallKeySettings = this.smallKeyShuffleComboBox.SelectedIndex;
                settings.bossKeySettings = this.bossKeyShuffleComboBox.SelectedIndex;
                settings.mapAndCompassSettings = this.mapsAndCompassesComboBox.SelectedIndex;
                settings.goldenBugsShuffled = this.goldenBugsCheckBox.Checked;
                settings.npcItemsShuffled = this.giftFromNPCsCheckBox.Checked;
                settings.poesShuffled = this.poeCheckBox.Checked;
                settings.shopItemsShuffled = this.shopItemsCheckBox.Checked;
                settings.faronTwilightCleared = this.faronTwilightClearedCheckBox.Checked;
                settings.eldinTwilightCleared = this.eldinTwilightClearedCheckBox.Checked;
                settings.lanayruTwilightCleared = this.lanayruTwilightClearedCheckBox.Checked;
                settings.skipMinorCutscenes = this.skipMinorCutscenesCheckBox.Checked;
                settings.fastIronBoots = this.fastIronBootsCheckBox.Checked;
                settings.quickTransform = this.quickTransformCheckBox.Checked;
                settings.transformAnywhere = this.transformAnywhereCheckBox.Checked;
                settings.introSkipped = this.skipIntroCheckBox.Checked;
                settings.iceTrapSettings = this.foolishItemsComboBox.SelectedIndex;
                settings.StartingItems = this.startingItemsListBox.Items.OfType<Item>().ToList();
                settings.TunicColor = this.tunicColorComboBox.SelectedIndex;
                settings.lanternColor = this.lanternColorComboBox.SelectedIndex;
                settings.MidnaHairColor = this.midnaHairColorComboBox.SelectedIndex;
                settings.heartColor = this.heartColorComboBox.SelectedIndex;
                settings.aButtonColor = this.aButtonComboBox.SelectedIndex;
                settings.bButtonColor = this.bButtonComboBox.SelectedIndex;
                settings.xButtonColor = this.xButtonComboBox.SelectedIndex;
                settings.yButtonColor = this.yButtonComboBox.SelectedIndex;
                settings.zButtonColor = this.zButtonComboBox.SelectedIndex;
                settings.shuffleBackgroundMusic = this.bgmCheckBox.Checked;
                settings.shuffleItemFanfares = this.fanfareCheckBox.Checked;
                settings.disableEnemyBackgoundMusic = this.enemyBgmCheckBox.Checked;
                settings.gameRegion = this.regionComboBox.SelectedIndex;
                settings.shuffleHiddenSkills = this.skillsCheckBox.Checked;
                settings.shuffleSkyCharacters = this.skyCharacterCheckBox.Checked;
                settings.seedNumber = this.seedNumberComboBox.SelectedIndex;
                settings.ExcludedChecks.Clear();
                foreach (string startingItem in this.startingItemsListBox.Items) 
                {
                    string itemName = startingItem;
                    itemName = itemName.Replace(" ", "_");
                    foreach (Item item in items.ImportantItems) 
                    {
                        if (item.ToString() == itemName) 
                        {
                            settings.StartingItems.Add(item);
                            break;
                        }
                    }
                }
                foreach (ListItem excludedCheck in excludedChecksListBox.Items)
                {
                    settings.ExcludedChecks.Add((int)excludedCheck.Value);
                }
                 
                settings.TunicColor = this.tunicColorComboBox.SelectedIndex;
                settings.MidnaHairColor = this.midnaHairColorComboBox.SelectedIndex;
                settings.upgradeWallet = this.walletCheckBox.Checked;
                settings.reduceDonations = this.donationCheckBox.Checked;
                settingsStringTextbox.Text = GuiBackendFunctions.GetSettingsString();
            }
        }

        /// <summary>
        /// Decrypts the Settings string and updates the GUI with the appropriate settings.
        /// </summary>
        private void UpdateInterface() 
        {
            this.startingItemsListBox.Items.Clear();
            this.excludedChecksListBox.Items.Clear();
            this.listofChecksListBox.Items.Clear();
            this.itemPoolListBox.Items.Clear();

            for ( int i = 0; i < RandomizerChecks.Count; i++) 
            {
                this.listofChecksListBox.Items.Add(new ListItem { Name = RandomizerChecks[i], Value = i});
            }
            foreach (var item in items.ImportantItems) 
            {
                string itemName = item.ToString();
                itemName = itemName.Replace("_", " ");
                this.itemPoolListBox.Items.Add(new ListItem { Name = itemName, Value = (byte)item});
            }

            GuiBackendFunctions.ParseSettingsString(this.settingsStringTextbox.Text);

            this.logicRulesBox.SelectedIndex = settings.logicRules;
            this.castleLogicComboBox.SelectedIndex = settings.castleRequirements;
            this.palaceLogicComboBox.SelectedIndex = settings.palaceRequirements;
            this.faronWoodsLogicComboBox.SelectedIndex = settings.faronWoodsLogic;
            this.mdhCheckBox.Checked = settings.mdhSkipped;
            this.smallKeyShuffleComboBox.SelectedIndex = settings.smallKeySettings;
            this.bossKeyShuffleComboBox.SelectedIndex = settings.bossKeySettings;
            this.mapsAndCompassesComboBox.SelectedIndex = settings.mapAndCompassSettings;
            this.goldenBugsCheckBox.Checked = settings.goldenBugsShuffled;
            this.giftFromNPCsCheckBox.Checked = settings.npcItemsShuffled;
            this.poeCheckBox.Checked = settings.poesShuffled;
            this.shopItemsCheckBox.Checked = settings.shopItemsShuffled;
            this.faronTwilightClearedCheckBox.Checked = settings.faronTwilightCleared;
            this.eldinTwilightClearedCheckBox.Checked = settings.eldinTwilightCleared;
            this.lanayruTwilightClearedCheckBox.Checked = settings.lanayruTwilightCleared;
            this.skipMinorCutscenesCheckBox.Checked = settings.skipMinorCutscenes;
            this.fastIronBootsCheckBox.Checked = settings.fastIronBoots;
            this.quickTransformCheckBox.Checked = settings.quickTransform;
            this.transformAnywhereCheckBox.Checked = settings.transformAnywhere;
            this.skipIntroCheckBox.Checked = settings.introSkipped;
            this.foolishItemsComboBox.SelectedIndex = settings.iceTrapSettings;
            this.tunicColorComboBox.SelectedIndex = settings.TunicColor;
            this.midnaHairColorComboBox.SelectedIndex = settings.MidnaHairColor;
            this.lanternColorComboBox.SelectedIndex = settings.lanternColor;
            this.heartColorComboBox.SelectedIndex = settings.heartColor;
            this.aButtonComboBox.SelectedIndex = settings.aButtonColor;
            this.bButtonComboBox.SelectedIndex = settings.bButtonColor;
            this.xButtonComboBox.SelectedIndex = settings.xButtonColor;
            this.yButtonComboBox.SelectedIndex = settings.yButtonColor;
            this.zButtonComboBox.SelectedIndex = settings.zButtonColor;
            this.bgmCheckBox.Checked = settings.shuffleBackgroundMusic;
            this.fanfareCheckBox.Checked = settings.shuffleItemFanfares;
            this.enemyBgmCheckBox.Checked = settings.disableEnemyBackgoundMusic;
            this.regionComboBox.SelectedIndex = settings.gameRegion;
            this.skillsCheckBox.Checked = settings.shuffleHiddenSkills;
            this.skyCharacterCheckBox.Checked = settings.shuffleSkyCharacters;
            this.seedNumberComboBox.SelectedIndex = settings.seedNumber;

            foreach (Item startingItem in settings.StartingItems) 
            {
                string itemName = startingItem.ToString();
                itemName = itemName.Replace("_", " ");
                this.startingItemsListBox.Items.Add(itemName);
                this.itemPoolListBox.Items.Remove(itemName);
            }
            foreach (int excludedCheck in settings.ExcludedChecks) 
            {
                foreach (ListItem check in listofChecksListBox.Items)
                {
                    if (excludedCheck == check.Value)
                    {
                        this.excludedChecksListBox.Items.Add( new ListItem { Name = check.Name, Value = check.Value});
                        this.listofChecksListBox.Items.Remove(excludedCheck);
                    }
                } 
            }

            this.tunicColorComboBox.SelectedIndex = settings.TunicColor;
            this.midnaHairColorComboBox.SelectedIndex = settings.MidnaHairColor;
            this.walletCheckBox.Checked = settings.upgradeWallet;
            this.donationCheckBox.Checked = settings.reduceDonations;

            this.settingsStringTextbox.Text = GuiBackendFunctions.GetSettingsString();
        }

        

        

        private void moveCheckToExcludedButton_Click(object sender, EventArgs e) 
        {
            if (this.listofChecksListBox.SelectedItem != null) //A little security feature in case the user mis-clicks
            {
                this.excludedChecksListBox.Items.Add( new ListItem { Name = ((ListItem)this.listofChecksListBox.SelectedItem).Name, Value = ((ListItem)this.listofChecksListBox.SelectedItem).Value});
                this.listofChecksListBox.Items.Remove(this.listofChecksListBox.SelectedItem);
                UpdateFlags(sender, e);
            }
        }

        private void moveExcludedToCheckButton_Click(object sender, EventArgs e) 
        {
            if (this.excludedChecksListBox.SelectedItem != null)
            {
                this.listofChecksListBox.Items.Add( new ListItem { Name = ((ListItem)this.excludedChecksListBox.SelectedItem).Name, Value = ((ListItem)this.excludedChecksListBox.SelectedItem).Value});
                this.excludedChecksListBox.Items.Remove(this.excludedChecksListBox.SelectedItem);
                UpdateFlags(sender, e);
            }
        }

        private void generateButton_Click(object sender, EventArgs e) 
        {
            bool generateSeed = Randomizer.Start(this.settingsStringTextbox.Text);
            if (generateSeed)
            {
                MessageBox.Show("Seed Generated! Check the folder for the randomizer gci and spoiler log!");
            }
            else
            {
                MessageBox.Show("Failed to generate a seed! Please check the console output for more details!");
            }
        }

        private void settingsPresetsComboBox_SelectedIndexChanged(object sender, EventArgs e) 
        {
            string currentItem = this.settingsPresetsComboBox.SelectedItem.ToString();
            switch (currentItem) {
                case "Standard":
                    this.settingsStringTextbox.Text = "QUlJTUlSSDdZUDc3NkFBQUFBQUFBQUE=";
                    GuiBackendFunctions.ParseSettingsString(this.settingsStringTextbox.Text);
                    break;
            }
        }

        

        private void Form1_Load(object sender, EventArgs e) 
        {
            this.logicTooltip.SetToolTip(
                this.logicRulesBox,
                "Sets the main logic rules for the seed:"
                    + Environment.NewLine
                    + "Glitchless: Does not require any glitches, tricks, etc. Recommended for beginners."
                    + Environment.NewLine
                    + "Glitched: assumes most glitches are in logic. Consult the Wiki for a complete list."
                    + Environment.NewLine
                    + "No Logic: generates a seed without using logic, meaning it may not be completable."
            );

            this.regionTooltip.SetToolTip(
                this.regionComboBox,
                "The region of the game that you wish to play on."
            );

            this.dungeonItemsTooltip.SetToolTip(
                this.dungeonItemsGroupBox,
                "Vanilla: Places the items in their original spot."
                    + Environment.NewLine
                    + "Own Dungeon: Randomizes items in the same dungeon as the vanilla check."
                    + Environment.NewLine
                    + "Any Dungeon: Randomizes items among all dungeons."
                    + Environment.NewLine
                    + "Keysanity/Anywhere: Places items anywhere in the world."
                    + Environment.NewLine
                    + "Keysey/Start With: Removes the locks to the respective doors and starts with the specified item."
            );

            this.categoriesTooltip.SetToolTip(
                this.itemCategoriesGroupBox,
                "These options allow you to decide which groups of locations are to be randomized."
                    + Environment.NewLine
                    + "If unchecked, the location will be vanilla."
            );

            this.foolishItemsTooltip.SetToolTip(
                this.foolishItemsComboBox,
                "Determines the number of foolish (trap) items to be placed into the item pool."
                    + Environment.NewLine
                    + "None: No foolish items are in the item pool."
                    + Environment.NewLine
                    + "Few: There is a small chance that a foolish item can appear."
                    + Environment.NewLine
                    + "Many: There is an increased chance that a foolish item can appear."
                    + Environment.NewLine
                    + "Mayhem: More than half of the junk items in the item pool are replaced with foolish items."
                    + Environment.NewLine
                    + "Nightmare: All junk items in the item fool are foolish items."
            );

            this.settingsToolTip.SetToolTip(
                this.settingsPresetsComboBox,
                "Standard: Whatever settings are commonly being used."
                    + Environment.NewLine
                    + "Beginner: Designed for people who are not familiar with the game. Smaller item pool and less skips."
                    + Environment.NewLine
                    + "Experienced: Created for players who are very familiar with the game. Expects minimal, easy to perform glitches."
                    + Environment.NewLine
                    + "Insanity (Cheese Logic): The ultimate test of knowledge for Twilight Princess."
                    + Environment.NewLine
                    + "Only with skill, precision, and knowledge of the most obscure glitches will you obtain victory."
            );

            this.twilightTooltip.SetToolTip(
                this.clearedTwilightsGroupBox,
                "Clears the Twilight in the selected regions."
            );

            this.cutsceneTooltip.SetToolTip(
                this.cutsceneMundaneSkipsGroupBox,
                "Skips small events that do not usually take up much time."
                    + Environment.NewLine
                    + "Skip Minor Cutscenes: Removes CS that plays when entering certain areas for the first time and the random Midna text prompts."
            );
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) 
        { }

        private void addItemToStartingItemsButton_Click(object sender, EventArgs e) 
        {
            this.startingItemsListBox.Items.Add(this.itemPoolListBox.SelectedItem);
            this.itemPoolListBox.Items.Remove(this.itemPoolListBox.SelectedItem);
        }

        private void removeItemFromStartingItemsButton_Click(object sender, EventArgs e) 
        {
            this.itemPoolListBox.Items.Add(this.startingItemsListBox.SelectedItem);
            this.startingItemsListBox.Items.Remove(this.startingItemsListBox.SelectedItem);
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (!this.isDarkModeEnabled) 
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                this.ForeColor = Color.LightGray;
                this.optionsMenu.BackColor = Color.FromArgb(34, 36, 49);
                this.randomizationSettingsTabPage.BackColor = Color.FromArgb(34, 36, 49);
                this.randomizationSettingsBox.BackColor = Color.FromArgb(34, 36, 49);
                this.logicRulesBox.BackColor = Color.FromArgb(34, 36, 49);
                this.logicRulesLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.itemPoolOptionsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.itemCategoriesGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.foolishItemsComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.foolishItemsLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.shopItemsCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.poeCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.giftFromNPCsCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.goldenBugsCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.dungeonItemsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.smallKeyShuffleComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.mapsAndCompassesComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.smallKeyShuffleLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.bossKeyShuffleComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.bossKeyShuffleLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.mapsAndCompassesLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.accessOptionsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.skipIntroCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.faronWoodsLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.faronWoodsLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.mdhCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.palaceLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.palaceLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.castleLogicLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.castleLogicComboBox.BackColor = Color.FromArgb(34, 36, 49);
                this.gameplaySettingsTabPage.BackColor = Color.FromArgb(34, 36, 49);
                this.cutsceneMundaneSkipsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.skipMinorCutscenesCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.clearedTwilightsGroupBox.BackColor = Color.FromArgb(34, 36, 49);
                this.lanayruTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.eldinTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.faronTwilightClearedCheckBox.BackColor = Color.FromArgb(34, 36, 49);
                this.excludedChecksTabPage.BackColor = Color.FromArgb(34, 36, 49);
                this.excludedChecksListBox.BackColor = Color.WhiteSmoke;
                this.listofChecksListBox.BackColor = Color.WhiteSmoke;
                this.excludedChecksLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.listofChecksLabel.BackColor = Color.FromArgb(34, 36, 49);
                this.moveExcludedToCheckButton.BackColor = Color.FromArgb(34, 36, 49);
                this.moveCheckToExcludedButton.BackColor = Color.FromArgb(34, 36, 49);
                this.inventoryTabPage.BackColor = Color.FromArgb(34, 36, 49);
                this.removeItemFromStartingItemsButton.BackColor = Color.FromArgb(34, 36, 49);
                this.addItemToStartingItemsButton.BackColor = Color.FromArgb(34, 36, 49);
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
                toolStripSeparator5.BackColor = Color.FromArgb(34, 36, 49);
                ;
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
                poeCheckBox.ForeColor = Color.LightGray;
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
                toolStripSeparator5.ForeColor = Color.LightGray;
                ;
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
                poeCheckBox.BackColor = Color.White;
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
                toolStripSeparator5.BackColor = Color.White;
                ;
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
                poeCheckBox.ForeColor = Color.Black;
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
                toolStripSeparator5.ForeColor = Color.Black;
                ;
                aboutToolStripMenuItem.ForeColor = Color.Black;
                settingsStringLabel.ForeColor = Color.Black;
                importButton.ForeColor = Color.Black;
                darkModeToolStripMenuItem.ForeColor = Color.Black;
                toolStripSeparator.ForeColor = Color.Black;
                toolStripSeparator1.ForeColor = Color.Black;
                isDarkModeEnabled = false;
            }
        }

        public class ListItem
        {
            public string Name {get; set;}
            public int Value {get; set;}

            public override string ToString()
            {
                return Name;
            }
        }
        private void importButton_Click(object sender, EventArgs e) 
        {
            dontrunhandler = true;
            UpdateInterface();
            dontrunhandler = false;
        }

        private void outputTextBox_textChanged(object sender, EventArgs e) 
        {
            outputTextBox.SelectionStart = outputTextBox.Text.Length;
            outputTextBox.ScrollToCaret();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public class TextBoxWriter : TextWriter 
        {
            // The control where we will write text.
            private readonly Control myControl;

            public TextBoxWriter(Control control) 
            {
                this.myControl = control;
            }

            public override void Write(char value) 
            {
                this.myControl.Text += value;
            }

            public override void Write(string value) 
            {
                myControl.Text += value;
            }

            public override Encoding Encoding 
            {
                get { return Encoding.Unicode; }
            }
        }
    }
}
