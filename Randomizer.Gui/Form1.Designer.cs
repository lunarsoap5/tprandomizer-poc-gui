using System.Windows;
namespace TPRandomizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.optionsMenu = new System.Windows.Forms.TabControl();
            this.randomizationSettingsTabPage = new System.Windows.Forms.TabPage();
            this.randomizationSettingsBox = new System.Windows.Forms.GroupBox();
            this.logicRulesBox = new System.Windows.Forms.ComboBox();
            this.logicRulesLabel = new System.Windows.Forms.Label();
            this.itemPoolOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.itemCategoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.shopItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.treasureChestCheckBox = new System.Windows.Forms.CheckBox();
            this.giftFromNPCsCheckBox = new System.Windows.Forms.CheckBox();
            this.goldenBugsCheckBox = new System.Windows.Forms.CheckBox();
            this.dungeonItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.smallKeyShuffleComboBox = new System.Windows.Forms.ComboBox();
            this.mapsAndCompassesComboBox = new System.Windows.Forms.ComboBox();
            this.smallKeyShuffleLabel = new System.Windows.Forms.Label();
            this.bossKeyShuffleComboBox = new System.Windows.Forms.ComboBox();
            this.bossKeyShuffleLabel = new System.Windows.Forms.Label();
            this.mapsAndCompassesLabel = new System.Windows.Forms.Label();
            this.accessOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.skipIntroCheckBox = new System.Windows.Forms.CheckBox();
            this.faronWoodsLogicComboBox = new System.Windows.Forms.ComboBox();
            this.faronWoodsLogicLabel = new System.Windows.Forms.Label();
            this.mdhCheckBox = new System.Windows.Forms.CheckBox();
            this.palaceLogicComboBox = new System.Windows.Forms.ComboBox();
            this.palaceLogicLabel = new System.Windows.Forms.Label();
            this.castleLogicLabel = new System.Windows.Forms.Label();
            this.castleLogicComboBox = new System.Windows.Forms.ComboBox();
            this.gameplaySettingsTabPage = new System.Windows.Forms.TabPage();
            this.cutsceneMundaneSkipsGroupBox = new System.Windows.Forms.GroupBox();
            this.skipMasterSwordPuzzleCheckBox = new System.Windows.Forms.CheckBox();
            this.skipMinorCutscenesCheckBox = new System.Windows.Forms.CheckBox();
            this.clearedTwilightsGroupBox = new System.Windows.Forms.GroupBox();
            this.lanayruTwilightClearedCheckBox = new System.Windows.Forms.CheckBox();
            this.eldinTwilightClearedCheckBox = new System.Windows.Forms.CheckBox();
            this.faronTwilightClearedCheckBox = new System.Windows.Forms.CheckBox();
            this.excludedChecksTabPage = new System.Windows.Forms.TabPage();
            this.excludedChecksListBox = new System.Windows.Forms.ListBox();
            this.listofChecksListBox = new System.Windows.Forms.ListBox();
            this.excludedChecksLabel = new System.Windows.Forms.Label();
            this.listofChecksLabel = new System.Windows.Forms.Label();
            this.moveExcludedToCheckButton = new System.Windows.Forms.Button();
            this.moveCheckToExcludedButton = new System.Windows.Forms.Button();
            this.inventoryTabPage = new System.Windows.Forms.TabPage();
            this.cosmeticsTabPage = new System.Windows.Forms.TabPage();
            this.transformAnywhereCheckBox = new System.Windows.Forms.CheckBox();
            this.quickTransformCheckBox = new System.Windows.Forms.CheckBox();
            this.midnaHairColorComboBox = new System.Windows.Forms.ComboBox();
            this.midnaHairColorLabel = new System.Windows.Forms.Label();
            this.lanternColorComboBox = new System.Windows.Forms.ComboBox();
            this.lanternColorLabel = new System.Windows.Forms.Label();
            this.tunicColorComboBox = new System.Windows.Forms.ComboBox();
            this.fastIronBootsCheckBox = new System.Windows.Forms.CheckBox();
            this.tunicColorLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.settingsStringTextBox = new System.Windows.Forms.TextBox();
            this.settingsStringLabel = new System.Windows.Forms.Label();
            this.generateSpoilerLogCheckBox = new System.Windows.Forms.CheckBox();
            this.settingPresetsLabel = new System.Windows.Forms.Label();
            this.settingsPresetsComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemPoolListBox = new System.Windows.Forms.ListBox();
            this.startingItemsListBox = new System.Windows.Forms.ListBox();
            this.startingItemsLabel = new System.Windows.Forms.Label();
            this.addItemToStartingItemsButton = new System.Windows.Forms.Button();
            this.removeItemFromStartingItemsButton = new System.Windows.Forms.Button();
            this.optionsMenu.SuspendLayout();
            this.randomizationSettingsTabPage.SuspendLayout();
            this.randomizationSettingsBox.SuspendLayout();
            this.itemPoolOptionsGroupBox.SuspendLayout();
            this.itemCategoriesGroupBox.SuspendLayout();
            this.dungeonItemsGroupBox.SuspendLayout();
            this.accessOptionsGroupBox.SuspendLayout();
            this.gameplaySettingsTabPage.SuspendLayout();
            this.cutsceneMundaneSkipsGroupBox.SuspendLayout();
            this.clearedTwilightsGroupBox.SuspendLayout();
            this.excludedChecksTabPage.SuspendLayout();
            this.inventoryTabPage.SuspendLayout();
            this.cosmeticsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsMenu
            // 
            this.optionsMenu.Controls.Add(this.randomizationSettingsTabPage);
            this.optionsMenu.Controls.Add(this.gameplaySettingsTabPage);
            this.optionsMenu.Controls.Add(this.excludedChecksTabPage);
            this.optionsMenu.Controls.Add(this.inventoryTabPage);
            this.optionsMenu.Controls.Add(this.cosmeticsTabPage);
            this.optionsMenu.Location = new System.Drawing.Point(10, 9);
            this.optionsMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.SelectedIndex = 0;
            this.optionsMenu.Size = new System.Drawing.Size(679, 344);
            this.optionsMenu.TabIndex = 1;
            // 
            // randomizationSettingsTabPage
            // 
            this.randomizationSettingsTabPage.Controls.Add(this.randomizationSettingsBox);
            this.randomizationSettingsTabPage.Controls.Add(this.itemPoolOptionsGroupBox);
            this.randomizationSettingsTabPage.Controls.Add(this.accessOptionsGroupBox);
            this.randomizationSettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this.randomizationSettingsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizationSettingsTabPage.Name = "randomizationSettingsTabPage";
            this.randomizationSettingsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizationSettingsTabPage.Size = new System.Drawing.Size(671, 316);
            this.randomizationSettingsTabPage.TabIndex = 0;
            this.randomizationSettingsTabPage.Text = "Randomization Settings";
            this.randomizationSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // randomizationSettingsBox
            // 
            this.randomizationSettingsBox.Controls.Add(this.logicRulesBox);
            this.randomizationSettingsBox.Controls.Add(this.logicRulesLabel);
            this.randomizationSettingsBox.Location = new System.Drawing.Point(8, 3);
            this.randomizationSettingsBox.Name = "randomizationSettingsBox";
            this.randomizationSettingsBox.Size = new System.Drawing.Size(332, 62);
            this.randomizationSettingsBox.TabIndex = 3;
            this.randomizationSettingsBox.TabStop = false;
            this.randomizationSettingsBox.Text = "Logic Settings";
            this.randomizationSettingsBox.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // logicRulesBox
            // 
            this.logicRulesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicRulesBox.FormattingEnabled = true;
            this.logicRulesBox.Items.AddRange(new object[] {
            "Glitchess",
            "Glitched",
            "No Logic"});
            this.logicRulesBox.Location = new System.Drawing.Point(82, 19);
            this.logicRulesBox.Name = "logicRulesBox";
            this.logicRulesBox.Size = new System.Drawing.Size(121, 23);
            this.logicRulesBox.TabIndex = 1;
            // 
            // logicRulesLabel
            // 
            this.logicRulesLabel.AutoSize = true;
            this.logicRulesLabel.Location = new System.Drawing.Point(6, 22);
            this.logicRulesLabel.Name = "logicRulesLabel";
            this.logicRulesLabel.Size = new System.Drawing.Size(70, 15);
            this.logicRulesLabel.TabIndex = 0;
            this.logicRulesLabel.Text = "Logic Rules:";
            this.logicRulesLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // itemPoolOptionsGroupBox
            // 
            this.itemPoolOptionsGroupBox.Controls.Add(this.itemCategoriesGroupBox);
            this.itemPoolOptionsGroupBox.Controls.Add(this.dungeonItemsGroupBox);
            this.itemPoolOptionsGroupBox.Location = new System.Drawing.Point(346, 3);
            this.itemPoolOptionsGroupBox.Name = "itemPoolOptionsGroupBox";
            this.itemPoolOptionsGroupBox.Size = new System.Drawing.Size(316, 310);
            this.itemPoolOptionsGroupBox.TabIndex = 2;
            this.itemPoolOptionsGroupBox.TabStop = false;
            this.itemPoolOptionsGroupBox.Text = "Item Pool Options";
            // 
            // itemCategoriesGroupBox
            // 
            this.itemCategoriesGroupBox.Controls.Add(this.shopItemsCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.treasureChestCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.giftFromNPCsCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.goldenBugsCheckBox);
            this.itemCategoriesGroupBox.Location = new System.Drawing.Point(7, 128);
            this.itemCategoriesGroupBox.Name = "itemCategoriesGroupBox";
            this.itemCategoriesGroupBox.Size = new System.Drawing.Size(303, 176);
            this.itemCategoriesGroupBox.TabIndex = 7;
            this.itemCategoriesGroupBox.TabStop = false;
            this.itemCategoriesGroupBox.Text = "Item Categories";
            // 
            // shopItemsCheckBox
            // 
            this.shopItemsCheckBox.AutoSize = true;
            this.shopItemsCheckBox.Location = new System.Drawing.Point(13, 102);
            this.shopItemsCheckBox.Name = "shopItemsCheckBox";
            this.shopItemsCheckBox.Size = new System.Drawing.Size(85, 19);
            this.shopItemsCheckBox.TabIndex = 3;
            this.shopItemsCheckBox.Text = "Shop Items";
            this.shopItemsCheckBox.UseVisualStyleBackColor = true;
            // 
            // treasureChestCheckBox
            // 
            this.treasureChestCheckBox.AutoSize = true;
            this.treasureChestCheckBox.Location = new System.Drawing.Point(13, 76);
            this.treasureChestCheckBox.Name = "treasureChestCheckBox";
            this.treasureChestCheckBox.Size = new System.Drawing.Size(107, 19);
            this.treasureChestCheckBox.TabIndex = 2;
            this.treasureChestCheckBox.Text = "Treasure Chests";
            this.treasureChestCheckBox.UseVisualStyleBackColor = true;
            // 
            // giftFromNPCsCheckBox
            // 
            this.giftFromNPCsCheckBox.AutoSize = true;
            this.giftFromNPCsCheckBox.Location = new System.Drawing.Point(13, 50);
            this.giftFromNPCsCheckBox.Name = "giftFromNPCsCheckBox";
            this.giftFromNPCsCheckBox.Size = new System.Drawing.Size(113, 19);
            this.giftFromNPCsCheckBox.TabIndex = 1;
            this.giftFromNPCsCheckBox.Text = "Gifts From NPCs";
            this.giftFromNPCsCheckBox.UseVisualStyleBackColor = true;
            // 
            // goldenBugsCheckBox
            // 
            this.goldenBugsCheckBox.AutoSize = true;
            this.goldenBugsCheckBox.Location = new System.Drawing.Point(13, 24);
            this.goldenBugsCheckBox.Name = "goldenBugsCheckBox";
            this.goldenBugsCheckBox.Size = new System.Drawing.Size(93, 19);
            this.goldenBugsCheckBox.TabIndex = 0;
            this.goldenBugsCheckBox.Text = "Golden Bugs";
            this.goldenBugsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dungeonItemsGroupBox
            // 
            this.dungeonItemsGroupBox.Controls.Add(this.smallKeyShuffleComboBox);
            this.dungeonItemsGroupBox.Controls.Add(this.mapsAndCompassesComboBox);
            this.dungeonItemsGroupBox.Controls.Add(this.smallKeyShuffleLabel);
            this.dungeonItemsGroupBox.Controls.Add(this.bossKeyShuffleComboBox);
            this.dungeonItemsGroupBox.Controls.Add(this.bossKeyShuffleLabel);
            this.dungeonItemsGroupBox.Controls.Add(this.mapsAndCompassesLabel);
            this.dungeonItemsGroupBox.Location = new System.Drawing.Point(7, 22);
            this.dungeonItemsGroupBox.Name = "dungeonItemsGroupBox";
            this.dungeonItemsGroupBox.Size = new System.Drawing.Size(303, 100);
            this.dungeonItemsGroupBox.TabIndex = 6;
            this.dungeonItemsGroupBox.TabStop = false;
            this.dungeonItemsGroupBox.Text = "Dungeon Items";
            // 
            // smallKeyShuffleComboBox
            // 
            this.smallKeyShuffleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smallKeyShuffleComboBox.FormattingEnabled = true;
            this.smallKeyShuffleComboBox.Items.AddRange(new object[] {
            "Vanilla",
            "Overworld",
            "Own Dungeon",
            "Any Dungeon",
            "Keysanity",
            "Keysey"});
            this.smallKeyShuffleComboBox.Location = new System.Drawing.Point(140, 17);
            this.smallKeyShuffleComboBox.Name = "smallKeyShuffleComboBox";
            this.smallKeyShuffleComboBox.Size = new System.Drawing.Size(121, 23);
            this.smallKeyShuffleComboBox.TabIndex = 0;
            this.smallKeyShuffleComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // mapsAndCompassesComboBox
            // 
            this.mapsAndCompassesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapsAndCompassesComboBox.FormattingEnabled = true;
            this.mapsAndCompassesComboBox.Items.AddRange(new object[] {
            "Vanilla",
            "Overworld",
            "Own Dungeon",
            "Any Dungeon",
            "Anywhere",
            "Start With"});
            this.mapsAndCompassesComboBox.Location = new System.Drawing.Point(140, 75);
            this.mapsAndCompassesComboBox.Name = "mapsAndCompassesComboBox";
            this.mapsAndCompassesComboBox.Size = new System.Drawing.Size(121, 23);
            this.mapsAndCompassesComboBox.TabIndex = 5;
            // 
            // smallKeyShuffleLabel
            // 
            this.smallKeyShuffleLabel.AutoSize = true;
            this.smallKeyShuffleLabel.Location = new System.Drawing.Point(6, 20);
            this.smallKeyShuffleLabel.Name = "smallKeyShuffleLabel";
            this.smallKeyShuffleLabel.Size = new System.Drawing.Size(101, 15);
            this.smallKeyShuffleLabel.TabIndex = 1;
            this.smallKeyShuffleLabel.Text = "Small Key Shuffle:";
            // 
            // bossKeyShuffleComboBox
            // 
            this.bossKeyShuffleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bossKeyShuffleComboBox.FormattingEnabled = true;
            this.bossKeyShuffleComboBox.Items.AddRange(new object[] {
            "Vanilla",
            "Overworld",
            "Own Dungeon",
            "Any Dungeon",
            "Keysanity",
            "Keysey"});
            this.bossKeyShuffleComboBox.Location = new System.Drawing.Point(140, 46);
            this.bossKeyShuffleComboBox.Name = "bossKeyShuffleComboBox";
            this.bossKeyShuffleComboBox.Size = new System.Drawing.Size(121, 23);
            this.bossKeyShuffleComboBox.TabIndex = 4;
            // 
            // bossKeyShuffleLabel
            // 
            this.bossKeyShuffleLabel.AutoSize = true;
            this.bossKeyShuffleLabel.Location = new System.Drawing.Point(6, 49);
            this.bossKeyShuffleLabel.Name = "bossKeyShuffleLabel";
            this.bossKeyShuffleLabel.Size = new System.Drawing.Size(96, 15);
            this.bossKeyShuffleLabel.TabIndex = 2;
            this.bossKeyShuffleLabel.Text = "Boss Key Shuffle:";
            // 
            // mapsAndCompassesLabel
            // 
            this.mapsAndCompassesLabel.AutoSize = true;
            this.mapsAndCompassesLabel.Location = new System.Drawing.Point(6, 78);
            this.mapsAndCompassesLabel.Name = "mapsAndCompassesLabel";
            this.mapsAndCompassesLabel.Size = new System.Drawing.Size(125, 15);
            this.mapsAndCompassesLabel.TabIndex = 3;
            this.mapsAndCompassesLabel.Text = "Maps and Compasses:";
            // 
            // accessOptionsGroupBox
            // 
            this.accessOptionsGroupBox.Controls.Add(this.skipIntroCheckBox);
            this.accessOptionsGroupBox.Controls.Add(this.faronWoodsLogicComboBox);
            this.accessOptionsGroupBox.Controls.Add(this.faronWoodsLogicLabel);
            this.accessOptionsGroupBox.Controls.Add(this.mdhCheckBox);
            this.accessOptionsGroupBox.Controls.Add(this.palaceLogicComboBox);
            this.accessOptionsGroupBox.Controls.Add(this.palaceLogicLabel);
            this.accessOptionsGroupBox.Controls.Add(this.castleLogicLabel);
            this.accessOptionsGroupBox.Controls.Add(this.castleLogicComboBox);
            this.accessOptionsGroupBox.Location = new System.Drawing.Point(8, 71);
            this.accessOptionsGroupBox.Name = "accessOptionsGroupBox";
            this.accessOptionsGroupBox.Size = new System.Drawing.Size(332, 237);
            this.accessOptionsGroupBox.TabIndex = 1;
            this.accessOptionsGroupBox.TabStop = false;
            this.accessOptionsGroupBox.Text = "Access Options";
            // 
            // skipIntroCheckBox
            // 
            this.skipIntroCheckBox.AutoSize = true;
            this.skipIntroCheckBox.Location = new System.Drawing.Point(6, 145);
            this.skipIntroCheckBox.Name = "skipIntroCheckBox";
            this.skipIntroCheckBox.Size = new System.Drawing.Size(76, 19);
            this.skipIntroCheckBox.TabIndex = 7;
            this.skipIntroCheckBox.Text = "Skip Intro";
            this.skipIntroCheckBox.UseVisualStyleBackColor = true;
            // 
            // faronWoodsLogicComboBox
            // 
            this.faronWoodsLogicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.faronWoodsLogicComboBox.FormattingEnabled = true;
            this.faronWoodsLogicComboBox.Items.AddRange(new object[] {
            "Open ",
            "Closed"});
            this.faronWoodsLogicComboBox.Location = new System.Drawing.Point(118, 82);
            this.faronWoodsLogicComboBox.Name = "faronWoodsLogicComboBox";
            this.faronWoodsLogicComboBox.Size = new System.Drawing.Size(121, 23);
            this.faronWoodsLogicComboBox.TabIndex = 6;
            // 
            // faronWoodsLogicLabel
            // 
            this.faronWoodsLogicLabel.AutoSize = true;
            this.faronWoodsLogicLabel.Location = new System.Drawing.Point(0, 87);
            this.faronWoodsLogicLabel.Name = "faronWoodsLogicLabel";
            this.faronWoodsLogicLabel.Size = new System.Drawing.Size(112, 15);
            this.faronWoodsLogicLabel.TabIndex = 5;
            this.faronWoodsLogicLabel.Text = "Faron Woods Logic:";
            // 
            // mdhCheckBox
            // 
            this.mdhCheckBox.AutoSize = true;
            this.mdhCheckBox.Location = new System.Drawing.Point(6, 120);
            this.mdhCheckBox.Name = "mdhCheckBox";
            this.mdhCheckBox.Size = new System.Drawing.Size(178, 19);
            this.mdhCheckBox.TabIndex = 4;
            this.mdhCheckBox.Text = "Skip Midna\'s Desperate Hour";
            this.mdhCheckBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.mdhCheckBox.UseVisualStyleBackColor = true;
            // 
            // palaceLogicComboBox
            // 
            this.palaceLogicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.palaceLogicComboBox.FormattingEnabled = true;
            this.palaceLogicComboBox.Items.AddRange(new object[] {
            "Open (Mirror is Assembled)",
            "All Fused Shadows",
            "All Mirror Shards",
            "Vanilla"});
            this.palaceLogicComboBox.Location = new System.Drawing.Point(184, 49);
            this.palaceLogicComboBox.Name = "palaceLogicComboBox";
            this.palaceLogicComboBox.Size = new System.Drawing.Size(121, 23);
            this.palaceLogicComboBox.TabIndex = 3;
            // 
            // palaceLogicLabel
            // 
            this.palaceLogicLabel.AutoSize = true;
            this.palaceLogicLabel.Location = new System.Drawing.Point(0, 52);
            this.palaceLogicLabel.Name = "palaceLogicLabel";
            this.palaceLogicLabel.Size = new System.Drawing.Size(178, 15);
            this.palaceLogicLabel.TabIndex = 2;
            this.palaceLogicLabel.Text = "Palace of Twilight Requirements:";
            // 
            // castleLogicLabel
            // 
            this.castleLogicLabel.AutoSize = true;
            this.castleLogicLabel.Location = new System.Drawing.Point(0, 22);
            this.castleLogicLabel.Name = "castleLogicLabel";
            this.castleLogicLabel.Size = new System.Drawing.Size(156, 15);
            this.castleLogicLabel.TabIndex = 1;
            this.castleLogicLabel.Text = "Hyrule Castle Requirements:";
            // 
            // castleLogicComboBox
            // 
            this.castleLogicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.castleLogicComboBox.FormattingEnabled = true;
            this.castleLogicComboBox.Items.AddRange(new object[] {
            "Open (Barrier is removed)",
            "All Fused Shadows",
            "All Mirror Shards",
            "All Dungeons",
            "Random Dungeons",
            "Vanilla"});
            this.castleLogicComboBox.Location = new System.Drawing.Point(162, 19);
            this.castleLogicComboBox.Name = "castleLogicComboBox";
            this.castleLogicComboBox.Size = new System.Drawing.Size(121, 23);
            this.castleLogicComboBox.TabIndex = 0;
            this.castleLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gameplaySettingsTabPage
            // 
            this.gameplaySettingsTabPage.Controls.Add(this.cutsceneMundaneSkipsGroupBox);
            this.gameplaySettingsTabPage.Controls.Add(this.clearedTwilightsGroupBox);
            this.gameplaySettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this.gameplaySettingsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameplaySettingsTabPage.Name = "gameplaySettingsTabPage";
            this.gameplaySettingsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameplaySettingsTabPage.Size = new System.Drawing.Size(671, 316);
            this.gameplaySettingsTabPage.TabIndex = 1;
            this.gameplaySettingsTabPage.Text = "Gameplay Settings";
            this.gameplaySettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // cutsceneMundaneSkipsGroupBox
            // 
            this.cutsceneMundaneSkipsGroupBox.Controls.Add(this.skipMasterSwordPuzzleCheckBox);
            this.cutsceneMundaneSkipsGroupBox.Controls.Add(this.skipMinorCutscenesCheckBox);
            this.cutsceneMundaneSkipsGroupBox.Location = new System.Drawing.Point(11, 125);
            this.cutsceneMundaneSkipsGroupBox.Name = "cutsceneMundaneSkipsGroupBox";
            this.cutsceneMundaneSkipsGroupBox.Size = new System.Drawing.Size(647, 100);
            this.cutsceneMundaneSkipsGroupBox.TabIndex = 3;
            this.cutsceneMundaneSkipsGroupBox.TabStop = false;
            this.cutsceneMundaneSkipsGroupBox.Text = "Cutscene/Mundane Skips";
            // 
            // skipMasterSwordPuzzleCheckBox
            // 
            this.skipMasterSwordPuzzleCheckBox.AutoSize = true;
            this.skipMasterSwordPuzzleCheckBox.Location = new System.Drawing.Point(7, 48);
            this.skipMasterSwordPuzzleCheckBox.Name = "skipMasterSwordPuzzleCheckBox";
            this.skipMasterSwordPuzzleCheckBox.Size = new System.Drawing.Size(159, 19);
            this.skipMasterSwordPuzzleCheckBox.TabIndex = 1;
            this.skipMasterSwordPuzzleCheckBox.Text = "Skip Master Sword Puzzle";
            this.skipMasterSwordPuzzleCheckBox.UseVisualStyleBackColor = true;
            // 
            // skipMinorCutscenesCheckBox
            // 
            this.skipMinorCutscenesCheckBox.AutoSize = true;
            this.skipMinorCutscenesCheckBox.Location = new System.Drawing.Point(7, 23);
            this.skipMinorCutscenesCheckBox.Name = "skipMinorCutscenesCheckBox";
            this.skipMinorCutscenesCheckBox.Size = new System.Drawing.Size(140, 19);
            this.skipMinorCutscenesCheckBox.TabIndex = 0;
            this.skipMinorCutscenesCheckBox.Text = "Skip Minor Cutscenes";
            this.skipMinorCutscenesCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearedTwilightsGroupBox
            // 
            this.clearedTwilightsGroupBox.Controls.Add(this.lanayruTwilightClearedCheckBox);
            this.clearedTwilightsGroupBox.Controls.Add(this.eldinTwilightClearedCheckBox);
            this.clearedTwilightsGroupBox.Controls.Add(this.faronTwilightClearedCheckBox);
            this.clearedTwilightsGroupBox.Location = new System.Drawing.Point(11, 15);
            this.clearedTwilightsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearedTwilightsGroupBox.Name = "clearedTwilightsGroupBox";
            this.clearedTwilightsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearedTwilightsGroupBox.Size = new System.Drawing.Size(647, 94);
            this.clearedTwilightsGroupBox.TabIndex = 2;
            this.clearedTwilightsGroupBox.TabStop = false;
            this.clearedTwilightsGroupBox.Text = "Cleared Twilights";
            // 
            // lanayruTwilightClearedCheckBox
            // 
            this.lanayruTwilightClearedCheckBox.AutoSize = true;
            this.lanayruTwilightClearedCheckBox.Location = new System.Drawing.Point(5, 64);
            this.lanayruTwilightClearedCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lanayruTwilightClearedCheckBox.Name = "lanayruTwilightClearedCheckBox";
            this.lanayruTwilightClearedCheckBox.Size = new System.Drawing.Size(155, 19);
            this.lanayruTwilightClearedCheckBox.TabIndex = 2;
            this.lanayruTwilightClearedCheckBox.Text = "Lanayru Twilight Cleared";
            this.lanayruTwilightClearedCheckBox.UseVisualStyleBackColor = true;
            // 
            // eldinTwilightClearedCheckBox
            // 
            this.eldinTwilightClearedCheckBox.AutoSize = true;
            this.eldinTwilightClearedCheckBox.Location = new System.Drawing.Point(5, 42);
            this.eldinTwilightClearedCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eldinTwilightClearedCheckBox.Name = "eldinTwilightClearedCheckBox";
            this.eldinTwilightClearedCheckBox.Size = new System.Drawing.Size(139, 19);
            this.eldinTwilightClearedCheckBox.TabIndex = 2;
            this.eldinTwilightClearedCheckBox.Text = "Eldin Twilight Cleared";
            this.eldinTwilightClearedCheckBox.UseVisualStyleBackColor = true;
            // 
            // faronTwilightClearedCheckBox
            // 
            this.faronTwilightClearedCheckBox.AutoSize = true;
            this.faronTwilightClearedCheckBox.Location = new System.Drawing.Point(5, 20);
            this.faronTwilightClearedCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.faronTwilightClearedCheckBox.Name = "faronTwilightClearedCheckBox";
            this.faronTwilightClearedCheckBox.Size = new System.Drawing.Size(143, 19);
            this.faronTwilightClearedCheckBox.TabIndex = 0;
            this.faronTwilightClearedCheckBox.Text = "Faron Twilight Cleared";
            this.faronTwilightClearedCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludedChecksTabPage
            // 
            this.excludedChecksTabPage.Controls.Add(this.excludedChecksListBox);
            this.excludedChecksTabPage.Controls.Add(this.listofChecksListBox);
            this.excludedChecksTabPage.Controls.Add(this.excludedChecksLabel);
            this.excludedChecksTabPage.Controls.Add(this.listofChecksLabel);
            this.excludedChecksTabPage.Controls.Add(this.moveExcludedToCheckButton);
            this.excludedChecksTabPage.Controls.Add(this.moveCheckToExcludedButton);
            this.excludedChecksTabPage.Location = new System.Drawing.Point(4, 24);
            this.excludedChecksTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excludedChecksTabPage.Name = "excludedChecksTabPage";
            this.excludedChecksTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excludedChecksTabPage.Size = new System.Drawing.Size(671, 316);
            this.excludedChecksTabPage.TabIndex = 2;
            this.excludedChecksTabPage.Text = "Excluded Checks";
            this.excludedChecksTabPage.UseVisualStyleBackColor = true;
            // 
            // excludedChecksListBox
            // 
            this.excludedChecksListBox.FormattingEnabled = true;
            this.excludedChecksListBox.ItemHeight = 15;
            this.excludedChecksListBox.Location = new System.Drawing.Point(410, 35);
            this.excludedChecksListBox.Name = "excludedChecksListBox";
            this.excludedChecksListBox.Size = new System.Drawing.Size(252, 274);
            this.excludedChecksListBox.TabIndex = 8;
            // 
            // listofChecksListBox
            // 
            this.listofChecksListBox.FormattingEnabled = true;
            this.listofChecksListBox.ItemHeight = 15;
            this.listofChecksListBox.Location = new System.Drawing.Point(11, 35);
            this.listofChecksListBox.Name = "listofChecksListBox";
            this.listofChecksListBox.Size = new System.Drawing.Size(253, 274);
            this.listofChecksListBox.TabIndex = 7;
            // 
            // excludedChecksLabel
            // 
            this.excludedChecksLabel.AutoSize = true;
            this.excludedChecksLabel.Location = new System.Drawing.Point(410, 18);
            this.excludedChecksLabel.Name = "excludedChecksLabel";
            this.excludedChecksLabel.Size = new System.Drawing.Size(96, 15);
            this.excludedChecksLabel.TabIndex = 6;
            this.excludedChecksLabel.Text = "Excluded Checks";
            // 
            // listofChecksLabel
            // 
            this.listofChecksLabel.AutoSize = true;
            this.listofChecksLabel.Location = new System.Drawing.Point(11, 18);
            this.listofChecksLabel.Name = "listofChecksLabel";
            this.listofChecksLabel.Size = new System.Drawing.Size(80, 15);
            this.listofChecksLabel.TabIndex = 5;
            this.listofChecksLabel.Text = "List of Checks";
            // 
            // moveExcludedToCheckButton
            // 
            this.moveExcludedToCheckButton.Location = new System.Drawing.Point(284, 207);
            this.moveExcludedToCheckButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moveExcludedToCheckButton.Name = "moveExcludedToCheckButton";
            this.moveExcludedToCheckButton.Size = new System.Drawing.Size(101, 56);
            this.moveExcludedToCheckButton.TabIndex = 4;
            this.moveExcludedToCheckButton.Text = "<";
            this.moveExcludedToCheckButton.UseVisualStyleBackColor = true;
            this.moveExcludedToCheckButton.Click += new System.EventHandler(this.moveExcludedToCheckButton_Click);
            // 
            // moveCheckToExcludedButton
            // 
            this.moveCheckToExcludedButton.Location = new System.Drawing.Point(284, 80);
            this.moveCheckToExcludedButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moveCheckToExcludedButton.Name = "moveCheckToExcludedButton";
            this.moveCheckToExcludedButton.Size = new System.Drawing.Size(101, 56);
            this.moveCheckToExcludedButton.TabIndex = 1;
            this.moveCheckToExcludedButton.Text = ">";
            this.moveCheckToExcludedButton.UseVisualStyleBackColor = true;
            this.moveCheckToExcludedButton.Click += new System.EventHandler(this.moveCheckToExcludedButton_Click);
            // 
            // inventoryTabPage
            // 
            this.inventoryTabPage.Controls.Add(this.removeItemFromStartingItemsButton);
            this.inventoryTabPage.Controls.Add(this.addItemToStartingItemsButton);
            this.inventoryTabPage.Controls.Add(this.startingItemsLabel);
            this.inventoryTabPage.Controls.Add(this.startingItemsListBox);
            this.inventoryTabPage.Controls.Add(this.itemPoolListBox);
            this.inventoryTabPage.Controls.Add(this.label1);
            this.inventoryTabPage.Location = new System.Drawing.Point(4, 24);
            this.inventoryTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventoryTabPage.Name = "inventoryTabPage";
            this.inventoryTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventoryTabPage.Size = new System.Drawing.Size(671, 316);
            this.inventoryTabPage.TabIndex = 3;
            this.inventoryTabPage.Text = "Inventory";
            this.inventoryTabPage.UseVisualStyleBackColor = true;
            // 
            // cosmeticsTabPage
            // 
            this.cosmeticsTabPage.Controls.Add(this.transformAnywhereCheckBox);
            this.cosmeticsTabPage.Controls.Add(this.quickTransformCheckBox);
            this.cosmeticsTabPage.Controls.Add(this.midnaHairColorComboBox);
            this.cosmeticsTabPage.Controls.Add(this.midnaHairColorLabel);
            this.cosmeticsTabPage.Controls.Add(this.lanternColorComboBox);
            this.cosmeticsTabPage.Controls.Add(this.lanternColorLabel);
            this.cosmeticsTabPage.Controls.Add(this.tunicColorComboBox);
            this.cosmeticsTabPage.Controls.Add(this.fastIronBootsCheckBox);
            this.cosmeticsTabPage.Controls.Add(this.tunicColorLabel);
            this.cosmeticsTabPage.Location = new System.Drawing.Point(4, 24);
            this.cosmeticsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cosmeticsTabPage.Name = "cosmeticsTabPage";
            this.cosmeticsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cosmeticsTabPage.Size = new System.Drawing.Size(671, 316);
            this.cosmeticsTabPage.TabIndex = 4;
            this.cosmeticsTabPage.Text = "Cosmetics and Quirks";
            this.cosmeticsTabPage.UseVisualStyleBackColor = true;
            // 
            // transformAnywhereCheckBox
            // 
            this.transformAnywhereCheckBox.AutoSize = true;
            this.transformAnywhereCheckBox.Location = new System.Drawing.Point(4, 170);
            this.transformAnywhereCheckBox.Name = "transformAnywhereCheckBox";
            this.transformAnywhereCheckBox.Size = new System.Drawing.Size(135, 19);
            this.transformAnywhereCheckBox.TabIndex = 8;
            this.transformAnywhereCheckBox.Text = "Transform Anywhere";
            this.transformAnywhereCheckBox.UseVisualStyleBackColor = true;
            // 
            // quickTransformCheckBox
            // 
            this.quickTransformCheckBox.AutoSize = true;
            this.quickTransformCheckBox.Location = new System.Drawing.Point(4, 144);
            this.quickTransformCheckBox.Name = "quickTransformCheckBox";
            this.quickTransformCheckBox.Size = new System.Drawing.Size(113, 19);
            this.quickTransformCheckBox.TabIndex = 7;
            this.quickTransformCheckBox.Text = "Quick Transform";
            this.quickTransformCheckBox.UseVisualStyleBackColor = true;
            // 
            // midnaHairColorComboBox
            // 
            this.midnaHairColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midnaHairColorComboBox.FormattingEnabled = true;
            this.midnaHairColorComboBox.Location = new System.Drawing.Point(111, 80);
            this.midnaHairColorComboBox.Name = "midnaHairColorComboBox";
            this.midnaHairColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.midnaHairColorComboBox.TabIndex = 6;
            // 
            // midnaHairColorLabel
            // 
            this.midnaHairColorLabel.AutoSize = true;
            this.midnaHairColorLabel.Location = new System.Drawing.Point(4, 83);
            this.midnaHairColorLabel.Name = "midnaHairColorLabel";
            this.midnaHairColorLabel.Size = new System.Drawing.Size(101, 15);
            this.midnaHairColorLabel.TabIndex = 5;
            this.midnaHairColorLabel.Text = "Midna Hair Color:";
            // 
            // lanternColorComboBox
            // 
            this.lanternColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lanternColorComboBox.FormattingEnabled = true;
            this.lanternColorComboBox.Location = new System.Drawing.Point(92, 45);
            this.lanternColorComboBox.Name = "lanternColorComboBox";
            this.lanternColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.lanternColorComboBox.TabIndex = 4;
            // 
            // lanternColorLabel
            // 
            this.lanternColorLabel.AutoSize = true;
            this.lanternColorLabel.Location = new System.Drawing.Point(4, 48);
            this.lanternColorLabel.Name = "lanternColorLabel";
            this.lanternColorLabel.Size = new System.Drawing.Size(82, 15);
            this.lanternColorLabel.TabIndex = 3;
            this.lanternColorLabel.Text = "Lantern Color:";
            // 
            // tunicColorComboBox
            // 
            this.tunicColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tunicColorComboBox.FormattingEnabled = true;
            this.tunicColorComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "Purple",
            "Gray",
            "Black",
            "White",
            "Random",
            "Custom"});
            this.tunicColorComboBox.Location = new System.Drawing.Point(81, 14);
            this.tunicColorComboBox.Name = "tunicColorComboBox";
            this.tunicColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.tunicColorComboBox.TabIndex = 2;
            // 
            // fastIronBootsCheckBox
            // 
            this.fastIronBootsCheckBox.AutoSize = true;
            this.fastIronBootsCheckBox.Location = new System.Drawing.Point(4, 118);
            this.fastIronBootsCheckBox.Name = "fastIronBootsCheckBox";
            this.fastIronBootsCheckBox.Size = new System.Drawing.Size(104, 19);
            this.fastIronBootsCheckBox.TabIndex = 1;
            this.fastIronBootsCheckBox.Text = "Fast Iron Boots";
            this.fastIronBootsCheckBox.UseVisualStyleBackColor = true;
            this.fastIronBootsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // tunicColorLabel
            // 
            this.tunicColorLabel.AutoSize = true;
            this.tunicColorLabel.Location = new System.Drawing.Point(4, 17);
            this.tunicColorLabel.Name = "tunicColorLabel";
            this.tunicColorLabel.Size = new System.Drawing.Size(71, 15);
            this.tunicColorLabel.TabIndex = 0;
            this.tunicColorLabel.Text = "Tunic Color:";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(308, 497);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(82, 22);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // settingsStringTextBox
            // 
            this.settingsStringTextBox.Location = new System.Drawing.Point(100, 430);
            this.settingsStringTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsStringTextBox.Name = "settingsStringTextBox";
            this.settingsStringTextBox.Size = new System.Drawing.Size(576, 23);
            this.settingsStringTextBox.TabIndex = 3;
            this.settingsStringTextBox.TextChanged += new System.EventHandler(this.settingsStringTextBox_TextChanged);
            // 
            // settingsStringLabel
            // 
            this.settingsStringLabel.AutoSize = true;
            this.settingsStringLabel.Location = new System.Drawing.Point(10, 433);
            this.settingsStringLabel.Name = "settingsStringLabel";
            this.settingsStringLabel.Size = new System.Drawing.Size(86, 15);
            this.settingsStringLabel.TabIndex = 4;
            this.settingsStringLabel.Text = "Settings String:";
            this.settingsStringLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // generateSpoilerLogCheckBox
            // 
            this.generateSpoilerLogCheckBox.AutoSize = true;
            this.generateSpoilerLogCheckBox.Location = new System.Drawing.Point(10, 407);
            this.generateSpoilerLogCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateSpoilerLogCheckBox.Name = "generateSpoilerLogCheckBox";
            this.generateSpoilerLogCheckBox.Size = new System.Drawing.Size(135, 19);
            this.generateSpoilerLogCheckBox.TabIndex = 5;
            this.generateSpoilerLogCheckBox.Text = "Generate Spoiler Log";
            this.generateSpoilerLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingPresetsLabel
            // 
            this.settingPresetsLabel.AutoSize = true;
            this.settingPresetsLabel.Location = new System.Drawing.Point(14, 372);
            this.settingPresetsLabel.Name = "settingPresetsLabel";
            this.settingPresetsLabel.Size = new System.Drawing.Size(92, 15);
            this.settingPresetsLabel.TabIndex = 6;
            this.settingPresetsLabel.Text = "Settings Presets:";
            // 
            // settingsPresetsComboBox
            // 
            this.settingsPresetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.settingsPresetsComboBox.FormattingEnabled = true;
            this.settingsPresetsComboBox.Items.AddRange(new object[] {
            "Standard",
            "Beginner",
            "Experienced",
            "Insanity (Cheese Logic)"});
            this.settingsPresetsComboBox.Location = new System.Drawing.Point(112, 369);
            this.settingsPresetsComboBox.Name = "settingsPresetsComboBox";
            this.settingsPresetsComboBox.Size = new System.Drawing.Size(121, 23);
            this.settingsPresetsComboBox.TabIndex = 7;
            this.settingsPresetsComboBox.SelectedIndexChanged += new System.EventHandler(this.settingsPresetsComboBox_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(-9, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 94);
            this.listBox1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 531);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(679, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(6, 570);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(679, 86);
            this.outputTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Pool";
            // 
            // itemPoolListBox
            // 
            this.itemPoolListBox.FormattingEnabled = true;
            this.itemPoolListBox.ItemHeight = 15;
            this.itemPoolListBox.Location = new System.Drawing.Point(12, 40);
            this.itemPoolListBox.Name = "itemPoolListBox";
            this.itemPoolListBox.Size = new System.Drawing.Size(231, 259);
            this.itemPoolListBox.TabIndex = 1;
            // 
            // startingItemsListBox
            // 
            this.startingItemsListBox.FormattingEnabled = true;
            this.startingItemsListBox.ItemHeight = 15;
            this.startingItemsListBox.Location = new System.Drawing.Point(431, 40);
            this.startingItemsListBox.Name = "startingItemsListBox";
            this.startingItemsListBox.Size = new System.Drawing.Size(231, 259);
            this.startingItemsListBox.TabIndex = 2;
            // 
            // startingItemsLabel
            // 
            this.startingItemsLabel.AutoSize = true;
            this.startingItemsLabel.Location = new System.Drawing.Point(431, 19);
            this.startingItemsLabel.Name = "startingItemsLabel";
            this.startingItemsLabel.Size = new System.Drawing.Size(80, 15);
            this.startingItemsLabel.TabIndex = 3;
            this.startingItemsLabel.Text = "Starting Items";
            // 
            // addItemToStartingItemsButton
            // 
            this.addItemToStartingItemsButton.Location = new System.Drawing.Point(301, 70);
            this.addItemToStartingItemsButton.Name = "addItemToStartingItemsButton";
            this.addItemToStartingItemsButton.Size = new System.Drawing.Size(75, 65);
            this.addItemToStartingItemsButton.TabIndex = 4;
            this.addItemToStartingItemsButton.Text = ">";
            this.addItemToStartingItemsButton.UseVisualStyleBackColor = true;
            // 
            // removeItemFromStartingItemsButton
            // 
            this.removeItemFromStartingItemsButton.Location = new System.Drawing.Point(301, 214);
            this.removeItemFromStartingItemsButton.Name = "removeItemFromStartingItemsButton";
            this.removeItemFromStartingItemsButton.Size = new System.Drawing.Size(75, 65);
            this.removeItemFromStartingItemsButton.TabIndex = 5;
            this.removeItemFromStartingItemsButton.Text = "<";
            this.removeItemFromStartingItemsButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 658);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.settingsPresetsComboBox);
            this.Controls.Add(this.settingPresetsLabel);
            this.Controls.Add(this.generateSpoilerLogCheckBox);
            this.Controls.Add(this.settingsStringLabel);
            this.Controls.Add(this.settingsStringTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.optionsMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Twilight Princess Randomizer - Version 1.0";
            this.optionsMenu.ResumeLayout(false);
            this.randomizationSettingsTabPage.ResumeLayout(false);
            this.randomizationSettingsBox.ResumeLayout(false);
            this.randomizationSettingsBox.PerformLayout();
            this.itemPoolOptionsGroupBox.ResumeLayout(false);
            this.itemCategoriesGroupBox.ResumeLayout(false);
            this.itemCategoriesGroupBox.PerformLayout();
            this.dungeonItemsGroupBox.ResumeLayout(false);
            this.dungeonItemsGroupBox.PerformLayout();
            this.accessOptionsGroupBox.ResumeLayout(false);
            this.accessOptionsGroupBox.PerformLayout();
            this.gameplaySettingsTabPage.ResumeLayout(false);
            this.cutsceneMundaneSkipsGroupBox.ResumeLayout(false);
            this.cutsceneMundaneSkipsGroupBox.PerformLayout();
            this.clearedTwilightsGroupBox.ResumeLayout(false);
            this.clearedTwilightsGroupBox.PerformLayout();
            this.excludedChecksTabPage.ResumeLayout(false);
            this.excludedChecksTabPage.PerformLayout();
            this.inventoryTabPage.ResumeLayout(false);
            this.inventoryTabPage.PerformLayout();
            this.cosmeticsTabPage.ResumeLayout(false);
            this.cosmeticsTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl optionsMenu;
        private System.Windows.Forms.TabPage randomizationSettingsTabPage;
        private System.Windows.Forms.TabPage gameplaySettingsTabPage;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label settingsStringLabel;
        private System.Windows.Forms.TabPage excludedChecksTabPage;
        private System.Windows.Forms.TabPage inventoryTabPage;
        private System.Windows.Forms.GroupBox clearedTwilightsGroupBox;
        private System.Windows.Forms.CheckBox lanayruTwilightClearedCheckBox;
        private System.Windows.Forms.CheckBox eldinTwilightClearedCheckBox;
        private System.Windows.Forms.CheckBox faronTwilightClearedCheckBox;
        private System.Windows.Forms.Button moveCheckToExcludedButton;
        private System.Windows.Forms.Label excludedChecksLabel;
        private System.Windows.Forms.Label listofChecksLabel;
        private System.Windows.Forms.Button moveExcludedToCheckButton;
        private System.Windows.Forms.TabPage cosmeticsTabPage;
        private System.Windows.Forms.CheckBox generateSpoilerLogCheckBox;
        private System.Windows.Forms.GroupBox accessOptionsGroupBox;
        private System.Windows.Forms.Label castleLogicLabel;
        private System.Windows.Forms.ComboBox castleLogicComboBox;
        private System.Windows.Forms.ComboBox palaceLogicComboBox;
        private System.Windows.Forms.Label palaceLogicLabel;
        private System.Windows.Forms.GroupBox itemPoolOptionsGroupBox;
        private System.Windows.Forms.GroupBox dungeonItemsGroupBox;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox mapsAndCompassesComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox bossKeyShuffleComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label mapsAndCompassesLabel;
        private System.Windows.Forms.GroupBox randomizationSettingsBox;
        private System.Windows.Forms.Label logicRulesLabel;
        private System.Windows.Forms.GroupBox itemCategoriesGroupBox;
        private System.Windows.Forms.CheckBox shopItemsCheckBox;
        private System.Windows.Forms.CheckBox treasureChestCheckBox;
        private System.Windows.Forms.CheckBox giftFromNPCsCheckBox;
        private System.Windows.Forms.CheckBox goldenBugsCheckBox;
        private System.Windows.Forms.Label settingPresetsLabel;
        private System.Windows.Forms.ComboBox settingsPresetsComboBox;
        private System.Windows.Forms.ComboBox faronWoodsLogicComboBox;
        private System.Windows.Forms.Label faronWoodsLogicLabel;
        private System.Windows.Forms.CheckBox mdhCheckBox;
        private System.Windows.Forms.GroupBox cutsceneMundaneSkipsGroupBox;
        private System.Windows.Forms.CheckBox skipMasterSwordPuzzleCheckBox;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.ComboBox midnaHairColorComboBox;
        private System.Windows.Forms.Label midnaHairColorLabel;
        private System.Windows.Forms.ComboBox lanternColorComboBox;
        private System.Windows.Forms.Label lanternColorLabel;
        private System.Windows.Forms.ComboBox tunicColorComboBox;
        private System.Windows.Forms.CheckBox fastIronBootsCheckBox;
        private System.Windows.Forms.Label tunicColorLabel;
        private System.Windows.Forms.CheckBox transformAnywhereCheckBox;
        private System.Windows.Forms.CheckBox quickTransformCheckBox;
        private System.Windows.Forms.ComboBox logicRulesBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label smallKeyShuffleLabel;
        private System.Windows.Forms.ComboBox smallKeyShuffleComboBox;
        private System.Windows.Forms.Label bossKeyShuffleLabel;
        private System.Windows.Forms.TextBox settingsStringTextBox;
        private System.Windows.Forms.CheckBox skipMinorCutscenesCheckBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.CheckBox skipIntroCheckBox;
        private System.Windows.Forms.ListBox listofChecksListBox;
        private System.Windows.Forms.ListBox excludedChecksListBox;
        private System.Windows.Forms.Button removeItemFromStartingItemsButton;
        private System.Windows.Forms.Button addItemToStartingItemsButton;
        private System.Windows.Forms.Label startingItemsLabel;
        private System.Windows.Forms.ListBox startingItemsListBox;
        private System.Windows.Forms.ListBox itemPoolListBox;
        private System.Windows.Forms.Label label1;
    }
}

