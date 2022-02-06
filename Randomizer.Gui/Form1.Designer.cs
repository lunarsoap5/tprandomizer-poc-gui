using System.Windows;
using System.Collections.Generic;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.optionsMenu = new System.Windows.Forms.TabControl();
            this.randomizationSettingsTabPage = new System.Windows.Forms.TabPage();
            this.randomizationSettingsBox = new System.Windows.Forms.GroupBox();
            this.regionComboBox = new System.Windows.Forms.ComboBox();
            this.regionLabel = new System.Windows.Forms.Label();
            this.logicRulesBox = new System.Windows.Forms.ComboBox();
            this.logicRulesLabel = new System.Windows.Forms.Label();
            this.itemPoolOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.itemCategoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.skyCharacterCheckBox = new System.Windows.Forms.CheckBox();
            this.skillsCheckBox = new System.Windows.Forms.CheckBox();
            this.foolishItemsComboBox = new System.Windows.Forms.ComboBox();
            this.foolishItemsLabel = new System.Windows.Forms.Label();
            this.shopItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.poeCheckBox = new System.Windows.Forms.CheckBox();
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
            this.removeItemFromStartingItemsButton = new System.Windows.Forms.Button();
            this.addItemToStartingItemsButton = new System.Windows.Forms.Button();
            this.startingItemsLabel = new System.Windows.Forms.Label();
            this.startingItemsListBox = new System.Windows.Forms.ListBox();
            this.itemPoolListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cosmeticsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.enemyBgmCheckBox = new System.Windows.Forms.CheckBox();
            this.fanfareCheckBox = new System.Windows.Forms.CheckBox();
            this.bgmCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fastIronBootsCheckBox = new System.Windows.Forms.CheckBox();
            this.quickTransformCheckBox = new System.Windows.Forms.CheckBox();
            this.transformAnywhereCheckBox = new System.Windows.Forms.CheckBox();
            this.cosmeticsGroupBox = new System.Windows.Forms.GroupBox();
            this.zButtonComboBox = new System.Windows.Forms.ComboBox();
            this.zButtonLabel = new System.Windows.Forms.Label();
            this.yButtonComboBox = new System.Windows.Forms.ComboBox();
            this.yButtonLabel = new System.Windows.Forms.Label();
            this.xButtonComboBox = new System.Windows.Forms.ComboBox();
            this.xButtonLabel = new System.Windows.Forms.Label();
            this.bButtonComboBox = new System.Windows.Forms.ComboBox();
            this.bButtonLabel = new System.Windows.Forms.Label();
            this.aButtonComboBox = new System.Windows.Forms.ComboBox();
            this.aButtonLabel = new System.Windows.Forms.Label();
            this.heartColorComboBox = new System.Windows.Forms.ComboBox();
            this.tunicColorComboBox = new System.Windows.Forms.ComboBox();
            this.heartColorLabel = new System.Windows.Forms.Label();
            this.tunicColorLabel = new System.Windows.Forms.Label();
            this.lanternColorComboBox = new System.Windows.Forms.ComboBox();
            this.lanternColorLabel = new System.Windows.Forms.Label();
            this.midnaHairColorLabel = new System.Windows.Forms.Label();
            this.midnaHairColorComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.settingPresetsLabel = new System.Windows.Forms.Label();
            this.settingsPresetsComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.logicTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WikiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsStringLabel = new System.Windows.Forms.Label();
            this.settingsStringTextbox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.regionTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.settingsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.categoriesTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.foolishItemsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dungeonItemsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.additionalSettingsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cosmeticsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.sfxTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.twilightTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cutsceneTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.seedNumberLabel = new System.Windows.Forms.Label();
            this.seedNumberComboBox = new System.Windows.Forms.ComboBox();
            this.walletCheckBox = new System.Windows.Forms.CheckBox();
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
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cosmeticsGroupBox.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsMenu
            // 
            this.optionsMenu.Controls.Add(this.randomizationSettingsTabPage);
            this.optionsMenu.Controls.Add(this.gameplaySettingsTabPage);
            this.optionsMenu.Controls.Add(this.excludedChecksTabPage);
            this.optionsMenu.Controls.Add(this.inventoryTabPage);
            this.optionsMenu.Controls.Add(this.cosmeticsTabPage);
            this.optionsMenu.Location = new System.Drawing.Point(10, 32);
            this.optionsMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.SelectedIndex = 0;
            this.optionsMenu.Size = new System.Drawing.Size(679, 370);
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
            this.randomizationSettingsTabPage.Size = new System.Drawing.Size(671, 342);
            this.randomizationSettingsTabPage.TabIndex = 0;
            this.randomizationSettingsTabPage.Text = "Randomization Settings";
            this.randomizationSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // randomizationSettingsBox
            // 
            this.randomizationSettingsBox.Controls.Add(this.regionComboBox);
            this.randomizationSettingsBox.Controls.Add(this.regionLabel);
            this.randomizationSettingsBox.Controls.Add(this.logicRulesBox);
            this.randomizationSettingsBox.Controls.Add(this.logicRulesLabel);
            this.randomizationSettingsBox.Location = new System.Drawing.Point(8, 3);
            this.randomizationSettingsBox.Name = "randomizationSettingsBox";
            this.randomizationSettingsBox.Size = new System.Drawing.Size(332, 91);
            this.randomizationSettingsBox.TabIndex = 3;
            this.randomizationSettingsBox.TabStop = false;
            this.randomizationSettingsBox.Text = "Logic Settings";
            // 
            // regionComboBox
            // 
            this.regionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionComboBox.FormattingEnabled = true;
            this.regionComboBox.Items.AddRange(new object[] {
            "NTSC (US)",
            "PAL (EUR)",
            "JP (JAP)"});
            this.regionComboBox.Location = new System.Drawing.Point(82, 48);
            this.regionComboBox.Name = "regionComboBox";
            this.regionComboBox.Size = new System.Drawing.Size(121, 23);
            this.regionComboBox.TabIndex = 3;
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(6, 51);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(47, 15);
            this.regionLabel.TabIndex = 2;
            this.regionLabel.Text = "Region:";
            // 
            // logicRulesBox
            // 
            this.logicRulesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicRulesBox.FormattingEnabled = true;
            this.logicRulesBox.Items.AddRange(new object[] {
            "Glitchless",
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
            // 
            // itemPoolOptionsGroupBox
            // 
            this.itemPoolOptionsGroupBox.Controls.Add(this.itemCategoriesGroupBox);
            this.itemPoolOptionsGroupBox.Controls.Add(this.dungeonItemsGroupBox);
            this.itemPoolOptionsGroupBox.Location = new System.Drawing.Point(346, 3);
            this.itemPoolOptionsGroupBox.Name = "itemPoolOptionsGroupBox";
            this.itemPoolOptionsGroupBox.Size = new System.Drawing.Size(316, 331);
            this.itemPoolOptionsGroupBox.TabIndex = 2;
            this.itemPoolOptionsGroupBox.TabStop = false;
            this.itemPoolOptionsGroupBox.Text = "Item Pool Options";
            // 
            // itemCategoriesGroupBox
            // 
            this.itemCategoriesGroupBox.Controls.Add(this.skyCharacterCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.skillsCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.foolishItemsComboBox);
            this.itemCategoriesGroupBox.Controls.Add(this.foolishItemsLabel);
            this.itemCategoriesGroupBox.Controls.Add(this.shopItemsCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.poeCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.giftFromNPCsCheckBox);
            this.itemCategoriesGroupBox.Controls.Add(this.goldenBugsCheckBox);
            this.itemCategoriesGroupBox.Location = new System.Drawing.Point(7, 132);
            this.itemCategoriesGroupBox.Name = "itemCategoriesGroupBox";
            this.itemCategoriesGroupBox.Size = new System.Drawing.Size(303, 193);
            this.itemCategoriesGroupBox.TabIndex = 7;
            this.itemCategoriesGroupBox.TabStop = false;
            this.itemCategoriesGroupBox.Text = "Item Categories";
            // 
            // skyCharacterCheckBox
            // 
            this.skyCharacterCheckBox.AutoSize = true;
            this.skyCharacterCheckBox.Location = new System.Drawing.Point(160, 24);
            this.skyCharacterCheckBox.Name = "skyCharacterCheckBox";
            this.skyCharacterCheckBox.Size = new System.Drawing.Size(103, 19);
            this.skyCharacterCheckBox.TabIndex = 7;
            this.skyCharacterCheckBox.Text = "Sky Characters";
            this.skyCharacterCheckBox.UseVisualStyleBackColor = true;
            // 
            // skillsCheckBox
            // 
            this.skillsCheckBox.AutoSize = true;
            this.skillsCheckBox.Location = new System.Drawing.Point(13, 127);
            this.skillsCheckBox.Name = "skillsCheckBox";
            this.skillsCheckBox.Size = new System.Drawing.Size(94, 19);
            this.skillsCheckBox.TabIndex = 6;
            this.skillsCheckBox.Text = "Hidden Skills";
            this.skillsCheckBox.UseVisualStyleBackColor = true;
            // 
            // foolishItemsComboBox
            // 
            this.foolishItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foolishItemsComboBox.FormattingEnabled = true;
            this.foolishItemsComboBox.Items.AddRange(new object[] {
            "None",
            "Few ",
            "Extra",
            "Mayhem",
            "Nightmare"});
            this.foolishItemsComboBox.Location = new System.Drawing.Point(99, 157);
            this.foolishItemsComboBox.Name = "foolishItemsComboBox";
            this.foolishItemsComboBox.Size = new System.Drawing.Size(121, 23);
            this.foolishItemsComboBox.TabIndex = 5;
            // 
            // foolishItemsLabel
            // 
            this.foolishItemsLabel.AutoSize = true;
            this.foolishItemsLabel.Location = new System.Drawing.Point(11, 160);
            this.foolishItemsLabel.Name = "foolishItemsLabel";
            this.foolishItemsLabel.Size = new System.Drawing.Size(80, 15);
            this.foolishItemsLabel.TabIndex = 4;
            this.foolishItemsLabel.Text = "Foolish Items:";
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
            // poeCheckBox
            // 
            this.poeCheckBox.AutoSize = true;
            this.poeCheckBox.Location = new System.Drawing.Point(13, 76);
            this.poeCheckBox.Name = "poeCheckBox";
            this.poeCheckBox.Size = new System.Drawing.Size(51, 19);
            this.poeCheckBox.TabIndex = 2;
            this.poeCheckBox.Text = "Poes";
            this.poeCheckBox.UseVisualStyleBackColor = true;
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
            this.dungeonItemsGroupBox.Size = new System.Drawing.Size(303, 109);
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
            "Own Dungeon",
            "Any Dungeon",
            "Keysanity",
            "Keysey"});
            this.smallKeyShuffleComboBox.Location = new System.Drawing.Point(140, 17);
            this.smallKeyShuffleComboBox.Name = "smallKeyShuffleComboBox";
            this.smallKeyShuffleComboBox.Size = new System.Drawing.Size(121, 23);
            this.smallKeyShuffleComboBox.TabIndex = 0;
            // 
            // mapsAndCompassesComboBox
            // 
            this.mapsAndCompassesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapsAndCompassesComboBox.FormattingEnabled = true;
            this.mapsAndCompassesComboBox.Items.AddRange(new object[] {
            "Vanilla",
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
            this.bossKeyShuffleLabel.Size = new System.Drawing.Size(89, 15);
            this.bossKeyShuffleLabel.TabIndex = 2;
            this.bossKeyShuffleLabel.Text = "Big Key Shuffle:";
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
            this.accessOptionsGroupBox.Location = new System.Drawing.Point(8, 97);
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
            "Open",
            "Fused Shadows",
            "Mirror Shards",
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
            "Open",
            "Fused Shadows",
            "Mirror Shards",
            "All Dungeons",
            "Random Dungeons",
            "Vanilla"});
            this.castleLogicComboBox.Location = new System.Drawing.Point(162, 19);
            this.castleLogicComboBox.Name = "castleLogicComboBox";
            this.castleLogicComboBox.Size = new System.Drawing.Size(121, 23);
            this.castleLogicComboBox.TabIndex = 0;
            // 
            // gameplaySettingsTabPage
            // 
            this.gameplaySettingsTabPage.Controls.Add(this.cutsceneMundaneSkipsGroupBox);
            this.gameplaySettingsTabPage.Controls.Add(this.clearedTwilightsGroupBox);
            this.gameplaySettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this.gameplaySettingsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameplaySettingsTabPage.Name = "gameplaySettingsTabPage";
            this.gameplaySettingsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameplaySettingsTabPage.Size = new System.Drawing.Size(671, 342);
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
            this.excludedChecksTabPage.Size = new System.Drawing.Size(671, 342);
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
            this.inventoryTabPage.Size = new System.Drawing.Size(671, 342);
            this.inventoryTabPage.TabIndex = 3;
            this.inventoryTabPage.Text = "Inventory";
            this.inventoryTabPage.UseVisualStyleBackColor = true;
            // 
            // removeItemFromStartingItemsButton
            // 
            this.removeItemFromStartingItemsButton.Location = new System.Drawing.Point(301, 214);
            this.removeItemFromStartingItemsButton.Name = "removeItemFromStartingItemsButton";
            this.removeItemFromStartingItemsButton.Size = new System.Drawing.Size(75, 65);
            this.removeItemFromStartingItemsButton.TabIndex = 5;
            this.removeItemFromStartingItemsButton.Text = "<";
            this.removeItemFromStartingItemsButton.UseVisualStyleBackColor = true;
            this.removeItemFromStartingItemsButton.Click += new System.EventHandler(this.removeItemFromStartingItemsButton_Click);
            // 
            // addItemToStartingItemsButton
            // 
            this.addItemToStartingItemsButton.Location = new System.Drawing.Point(301, 70);
            this.addItemToStartingItemsButton.Name = "addItemToStartingItemsButton";
            this.addItemToStartingItemsButton.Size = new System.Drawing.Size(75, 65);
            this.addItemToStartingItemsButton.TabIndex = 4;
            this.addItemToStartingItemsButton.Text = ">";
            this.addItemToStartingItemsButton.UseVisualStyleBackColor = true;
            this.addItemToStartingItemsButton.Click += new System.EventHandler(this.addItemToStartingItemsButton_Click);
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
            // startingItemsListBox
            // 
            this.startingItemsListBox.FormattingEnabled = true;
            this.startingItemsListBox.ItemHeight = 15;
            this.startingItemsListBox.Location = new System.Drawing.Point(431, 40);
            this.startingItemsListBox.Name = "startingItemsListBox";
            this.startingItemsListBox.Size = new System.Drawing.Size(231, 259);
            this.startingItemsListBox.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Pool";
            // 
            // cosmeticsTabPage
            // 
            this.cosmeticsTabPage.Controls.Add(this.groupBox2);
            this.cosmeticsTabPage.Controls.Add(this.groupBox1);
            this.cosmeticsTabPage.Controls.Add(this.cosmeticsGroupBox);
            this.cosmeticsTabPage.Location = new System.Drawing.Point(4, 24);
            this.cosmeticsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cosmeticsTabPage.Name = "cosmeticsTabPage";
            this.cosmeticsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cosmeticsTabPage.Size = new System.Drawing.Size(671, 342);
            this.cosmeticsTabPage.TabIndex = 4;
            this.cosmeticsTabPage.Text = "Cosmetics and Quirks";
            this.cosmeticsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.enemyBgmCheckBox);
            this.groupBox2.Controls.Add(this.fanfareCheckBox);
            this.groupBox2.Controls.Add(this.bgmCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 135);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Music and SFX";
            // 
            // enemyBgmCheckBox
            // 
            this.enemyBgmCheckBox.AutoSize = true;
            this.enemyBgmCheckBox.Location = new System.Drawing.Point(6, 79);
            this.enemyBgmCheckBox.Name = "enemyBgmCheckBox";
            this.enemyBgmCheckBox.Size = new System.Drawing.Size(206, 19);
            this.enemyBgmCheckBox.TabIndex = 2;
            this.enemyBgmCheckBox.Text = "Disable Enemy Backgound Music?";
            this.enemyBgmCheckBox.UseVisualStyleBackColor = true;
            // 
            // fanfareCheckBox
            // 
            this.fanfareCheckBox.AutoSize = true;
            this.fanfareCheckBox.Location = new System.Drawing.Point(6, 54);
            this.fanfareCheckBox.Name = "fanfareCheckBox";
            this.fanfareCheckBox.Size = new System.Drawing.Size(137, 19);
            this.fanfareCheckBox.TabIndex = 1;
            this.fanfareCheckBox.Text = "Randomize Fanfares?";
            this.fanfareCheckBox.UseVisualStyleBackColor = true;
            // 
            // bgmCheckBox
            // 
            this.bgmCheckBox.AutoSize = true;
            this.bgmCheckBox.Location = new System.Drawing.Point(6, 30);
            this.bgmCheckBox.Name = "bgmCheckBox";
            this.bgmCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bgmCheckBox.Size = new System.Drawing.Size(188, 19);
            this.bgmCheckBox.TabIndex = 0;
            this.bgmCheckBox.Text = "Randomize Backgound Music?";
            this.bgmCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.walletCheckBox);
            this.groupBox1.Controls.Add(this.fastIronBootsCheckBox);
            this.groupBox1.Controls.Add(this.quickTransformCheckBox);
            this.groupBox1.Controls.Add(this.transformAnywhereCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 176);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional Settings";
            // 
            // fastIronBootsCheckBox
            // 
            this.fastIronBootsCheckBox.AutoSize = true;
            this.fastIronBootsCheckBox.Location = new System.Drawing.Point(6, 22);
            this.fastIronBootsCheckBox.Name = "fastIronBootsCheckBox";
            this.fastIronBootsCheckBox.Size = new System.Drawing.Size(104, 19);
            this.fastIronBootsCheckBox.TabIndex = 1;
            this.fastIronBootsCheckBox.Text = "Fast Iron Boots";
            this.fastIronBootsCheckBox.UseVisualStyleBackColor = true;
            // 
            // quickTransformCheckBox
            // 
            this.quickTransformCheckBox.AutoSize = true;
            this.quickTransformCheckBox.Location = new System.Drawing.Point(6, 47);
            this.quickTransformCheckBox.Name = "quickTransformCheckBox";
            this.quickTransformCheckBox.Size = new System.Drawing.Size(113, 19);
            this.quickTransformCheckBox.TabIndex = 7;
            this.quickTransformCheckBox.Text = "Quick Transform";
            this.quickTransformCheckBox.UseVisualStyleBackColor = true;
            // 
            // transformAnywhereCheckBox
            // 
            this.transformAnywhereCheckBox.AutoSize = true;
            this.transformAnywhereCheckBox.Location = new System.Drawing.Point(6, 72);
            this.transformAnywhereCheckBox.Name = "transformAnywhereCheckBox";
            this.transformAnywhereCheckBox.Size = new System.Drawing.Size(135, 19);
            this.transformAnywhereCheckBox.TabIndex = 8;
            this.transformAnywhereCheckBox.Text = "Transform Anywhere";
            this.transformAnywhereCheckBox.UseVisualStyleBackColor = true;
            // 
            // cosmeticsGroupBox
            // 
            this.cosmeticsGroupBox.Controls.Add(this.zButtonComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.zButtonLabel);
            this.cosmeticsGroupBox.Controls.Add(this.yButtonComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.yButtonLabel);
            this.cosmeticsGroupBox.Controls.Add(this.xButtonComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.xButtonLabel);
            this.cosmeticsGroupBox.Controls.Add(this.bButtonComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.bButtonLabel);
            this.cosmeticsGroupBox.Controls.Add(this.aButtonComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.aButtonLabel);
            this.cosmeticsGroupBox.Controls.Add(this.heartColorComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.tunicColorComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.heartColorLabel);
            this.cosmeticsGroupBox.Controls.Add(this.tunicColorLabel);
            this.cosmeticsGroupBox.Controls.Add(this.lanternColorComboBox);
            this.cosmeticsGroupBox.Controls.Add(this.lanternColorLabel);
            this.cosmeticsGroupBox.Controls.Add(this.midnaHairColorLabel);
            this.cosmeticsGroupBox.Controls.Add(this.midnaHairColorComboBox);
            this.cosmeticsGroupBox.Location = new System.Drawing.Point(427, 5);
            this.cosmeticsGroupBox.Name = "cosmeticsGroupBox";
            this.cosmeticsGroupBox.Size = new System.Drawing.Size(238, 306);
            this.cosmeticsGroupBox.TabIndex = 10;
            this.cosmeticsGroupBox.TabStop = false;
            this.cosmeticsGroupBox.Text = "Cosmetics";
            // 
            // zButtonComboBox
            // 
            this.zButtonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zButtonComboBox.FormattingEnabled = true;
            this.zButtonComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Orange",
            "Yellow",
            "Lime Green",
            "Dark Green",
            "Purple",
            "Black",
            "Light Blue",
            "Random"});
            this.zButtonComboBox.Location = new System.Drawing.Point(109, 264);
            this.zButtonComboBox.Name = "zButtonComboBox";
            this.zButtonComboBox.Size = new System.Drawing.Size(121, 23);
            this.zButtonComboBox.TabIndex = 20;
            // 
            // zButtonLabel
            // 
            this.zButtonLabel.AutoSize = true;
            this.zButtonLabel.Location = new System.Drawing.Point(6, 267);
            this.zButtonLabel.Name = "zButtonLabel";
            this.zButtonLabel.Size = new System.Drawing.Size(88, 15);
            this.zButtonLabel.TabIndex = 19;
            this.zButtonLabel.Text = "Z Button Color:";
            // 
            // yButtonComboBox
            // 
            this.yButtonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yButtonComboBox.FormattingEnabled = true;
            this.yButtonComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Orange",
            "Yellow",
            "Lime Green",
            "Dark Green",
            "Blue",
            "Purple",
            "Black",
            "Pink",
            "Cyan",
            "Random"});
            this.yButtonComboBox.Location = new System.Drawing.Point(109, 235);
            this.yButtonComboBox.Name = "yButtonComboBox";
            this.yButtonComboBox.Size = new System.Drawing.Size(121, 23);
            this.yButtonComboBox.TabIndex = 18;
            // 
            // yButtonLabel
            // 
            this.yButtonLabel.AutoSize = true;
            this.yButtonLabel.Location = new System.Drawing.Point(6, 238);
            this.yButtonLabel.Name = "yButtonLabel";
            this.yButtonLabel.Size = new System.Drawing.Size(88, 15);
            this.yButtonLabel.TabIndex = 17;
            this.yButtonLabel.Text = "Y Button Color:";
            // 
            // xButtonComboBox
            // 
            this.xButtonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xButtonComboBox.FormattingEnabled = true;
            this.xButtonComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Orange",
            "Yellow",
            "Lime Green",
            "Dark Green",
            "Blue",
            "Purple",
            "Black",
            "Pink",
            "Cyan",
            "Random"});
            this.xButtonComboBox.Location = new System.Drawing.Point(109, 206);
            this.xButtonComboBox.Name = "xButtonComboBox";
            this.xButtonComboBox.Size = new System.Drawing.Size(121, 23);
            this.xButtonComboBox.TabIndex = 16;
            // 
            // xButtonLabel
            // 
            this.xButtonLabel.AutoSize = true;
            this.xButtonLabel.Location = new System.Drawing.Point(6, 209);
            this.xButtonLabel.Name = "xButtonLabel";
            this.xButtonLabel.Size = new System.Drawing.Size(88, 15);
            this.xButtonLabel.TabIndex = 15;
            this.xButtonLabel.Text = "X Button Color:";
            // 
            // bButtonComboBox
            // 
            this.bButtonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bButtonComboBox.FormattingEnabled = true;
            this.bButtonComboBox.Items.AddRange(new object[] {
            "Default",
            "Orange",
            "Pink",
            "Green",
            "Blue",
            "Purple",
            "Black",
            "Teal",
            "Random"});
            this.bButtonComboBox.Location = new System.Drawing.Point(109, 177);
            this.bButtonComboBox.Name = "bButtonComboBox";
            this.bButtonComboBox.Size = new System.Drawing.Size(121, 23);
            this.bButtonComboBox.TabIndex = 14;
            // 
            // bButtonLabel
            // 
            this.bButtonLabel.AutoSize = true;
            this.bButtonLabel.Location = new System.Drawing.Point(6, 180);
            this.bButtonLabel.Name = "bButtonLabel";
            this.bButtonLabel.Size = new System.Drawing.Size(85, 15);
            this.bButtonLabel.TabIndex = 13;
            this.bButtonLabel.Text = "B ButtonColor:";
            // 
            // aButtonComboBox
            // 
            this.aButtonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aButtonComboBox.FormattingEnabled = true;
            this.aButtonComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Orange",
            "Yellow",
            "Dark Green",
            "Blue",
            "Purple",
            "Black",
            "Grey",
            "Pink",
            "Random"});
            this.aButtonComboBox.Location = new System.Drawing.Point(109, 148);
            this.aButtonComboBox.Name = "aButtonComboBox";
            this.aButtonComboBox.Size = new System.Drawing.Size(121, 23);
            this.aButtonComboBox.TabIndex = 12;
            // 
            // aButtonLabel
            // 
            this.aButtonLabel.AutoSize = true;
            this.aButtonLabel.Location = new System.Drawing.Point(6, 151);
            this.aButtonLabel.Name = "aButtonLabel";
            this.aButtonLabel.Size = new System.Drawing.Size(89, 15);
            this.aButtonLabel.TabIndex = 11;
            this.aButtonLabel.Text = "A Button Color:";
            // 
            // heartColorComboBox
            // 
            this.heartColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heartColorComboBox.FormattingEnabled = true;
            this.heartColorComboBox.Items.AddRange(new object[] {
            "Default",
            "Teal",
            "Pink",
            "Orange",
            "Blue",
            "Green",
            "Purple",
            "Black",
            "Random"});
            this.heartColorComboBox.Location = new System.Drawing.Point(109, 119);
            this.heartColorComboBox.Name = "heartColorComboBox";
            this.heartColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.heartColorComboBox.TabIndex = 10;
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
            this.tunicColorComboBox.Location = new System.Drawing.Point(109, 32);
            this.tunicColorComboBox.Name = "tunicColorComboBox";
            this.tunicColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.tunicColorComboBox.TabIndex = 2;
            // 
            // heartColorLabel
            // 
            this.heartColorLabel.AutoSize = true;
            this.heartColorLabel.Location = new System.Drawing.Point(6, 122);
            this.heartColorLabel.Name = "heartColorLabel";
            this.heartColorLabel.Size = new System.Drawing.Size(71, 15);
            this.heartColorLabel.TabIndex = 9;
            this.heartColorLabel.Text = "Heart Color:";
            // 
            // tunicColorLabel
            // 
            this.tunicColorLabel.AutoSize = true;
            this.tunicColorLabel.Location = new System.Drawing.Point(6, 35);
            this.tunicColorLabel.Name = "tunicColorLabel";
            this.tunicColorLabel.Size = new System.Drawing.Size(71, 15);
            this.tunicColorLabel.TabIndex = 0;
            this.tunicColorLabel.Text = "Tunic Color:";
            // 
            // lanternColorComboBox
            // 
            this.lanternColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lanternColorComboBox.FormattingEnabled = true;
            this.lanternColorComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Purple",
            "White",
            "Cyan",
            "Random"});
            this.lanternColorComboBox.Location = new System.Drawing.Point(109, 61);
            this.lanternColorComboBox.Name = "lanternColorComboBox";
            this.lanternColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.lanternColorComboBox.TabIndex = 4;
            // 
            // lanternColorLabel
            // 
            this.lanternColorLabel.AutoSize = true;
            this.lanternColorLabel.Location = new System.Drawing.Point(6, 65);
            this.lanternColorLabel.Name = "lanternColorLabel";
            this.lanternColorLabel.Size = new System.Drawing.Size(82, 15);
            this.lanternColorLabel.TabIndex = 3;
            this.lanternColorLabel.Text = "Lantern Color:";
            // 
            // midnaHairColorLabel
            // 
            this.midnaHairColorLabel.AutoSize = true;
            this.midnaHairColorLabel.Location = new System.Drawing.Point(6, 93);
            this.midnaHairColorLabel.Name = "midnaHairColorLabel";
            this.midnaHairColorLabel.Size = new System.Drawing.Size(101, 15);
            this.midnaHairColorLabel.TabIndex = 5;
            this.midnaHairColorLabel.Text = "Midna Hair Color:";
            // 
            // midnaHairColorComboBox
            // 
            this.midnaHairColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midnaHairColorComboBox.FormattingEnabled = true;
            this.midnaHairColorComboBox.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Blue",
            "Cyan"});
            this.midnaHairColorComboBox.Location = new System.Drawing.Point(109, 90);
            this.midnaHairColorComboBox.Name = "midnaHairColorComboBox";
            this.midnaHairColorComboBox.Size = new System.Drawing.Size(121, 23);
            this.midnaHairColorComboBox.TabIndex = 6;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(308, 489);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(82, 22);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // settingPresetsLabel
            // 
            this.settingPresetsLabel.AutoSize = true;
            this.settingPresetsLabel.Location = new System.Drawing.Point(10, 430);
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
            this.settingsPresetsComboBox.Location = new System.Drawing.Point(104, 427);
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
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(6, 517);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(679, 139);
            this.outputTextBox.TabIndex = 9;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(700, 24);
            this.MainMenuStrip.TabIndex = 10;
            this.MainMenuStrip.Text = "menuStrip1";
            this.MainMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.darkModeToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openToolStripMenuItem.Text = "&Open Settings File..";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.saveToolStripMenuItem.Text = "&Save Settings File..";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(215, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WikiMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // WikiMenuItem
            // 
            this.WikiMenuItem.Name = "WikiMenuItem";
            this.WikiMenuItem.Size = new System.Drawing.Size(116, 22);
            this.WikiMenuItem.Text = "&Wiki";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // settingsStringLabel
            // 
            this.settingsStringLabel.AutoSize = true;
            this.settingsStringLabel.Location = new System.Drawing.Point(10, 465);
            this.settingsStringLabel.Name = "settingsStringLabel";
            this.settingsStringLabel.Size = new System.Drawing.Size(86, 15);
            this.settingsStringLabel.TabIndex = 11;
            this.settingsStringLabel.Text = "Settings String:";
            // 
            // settingsStringTextbox
            // 
            this.settingsStringTextbox.Location = new System.Drawing.Point(100, 462);
            this.settingsStringTextbox.Name = "settingsStringTextbox";
            this.settingsStringTextbox.Size = new System.Drawing.Size(497, 23);
            this.settingsStringTextbox.TabIndex = 12;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(614, 462);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 13;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // seedNumberLabel
            // 
            this.seedNumberLabel.AutoSize = true;
            this.seedNumberLabel.Location = new System.Drawing.Point(245, 430);
            this.seedNumberLabel.Name = "seedNumberLabel";
            this.seedNumberLabel.Size = new System.Drawing.Size(82, 15);
            this.seedNumberLabel.TabIndex = 14;
            this.seedNumberLabel.Text = "Seed Number:";
            // 
            // seedNumberComboBox
            // 
            this.seedNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seedNumberComboBox.FormattingEnabled = true;
            this.seedNumberComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.seedNumberComboBox.Location = new System.Drawing.Point(333, 427);
            this.seedNumberComboBox.Name = "seedNumberComboBox";
            this.seedNumberComboBox.Size = new System.Drawing.Size(121, 23);
            this.seedNumberComboBox.TabIndex = 15;
            // 
            // walletCheckBox
            // 
            this.walletCheckBox.AutoSize = true;
            this.walletCheckBox.Location = new System.Drawing.Point(6, 95);
            this.walletCheckBox.Name = "walletCheckBox";
            this.walletCheckBox.Size = new System.Drawing.Size(159, 19);
            this.walletCheckBox.TabIndex = 9;
            this.walletCheckBox.Text = "Increase Wallet Capacity?";
            this.walletCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.walletCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 658);
            this.Controls.Add(this.seedNumberComboBox);
            this.Controls.Add(this.seedNumberLabel);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.settingsStringTextbox);
            this.Controls.Add(this.settingsStringLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.settingsPresetsComboBox);
            this.Controls.Add(this.settingPresetsLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.optionsMenu);
            this.Controls.Add(this.MainMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cosmeticsGroupBox.ResumeLayout(false);
            this.cosmeticsGroupBox.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl optionsMenu;
        private System.Windows.Forms.TabPage randomizationSettingsTabPage;
        private System.Windows.Forms.TabPage gameplaySettingsTabPage;
        private System.Windows.Forms.Button generateButton;
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
        private System.Windows.Forms.CheckBox poeCheckBox;
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
        private System.Windows.Forms.CheckBox skipMinorCutscenesCheckBox;
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
        private System.Windows.Forms.ComboBox foolishItemsComboBox;
        private System.Windows.Forms.Label foolishItemsLabel;
        private System.Windows.Forms.ToolTip logicTooltip;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WikiMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label settingsStringLabel;
        private System.Windows.Forms.TextBox settingsStringTextbox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox enemyBgmCheckBox;
        private System.Windows.Forms.CheckBox fanfareCheckBox;
        private System.Windows.Forms.CheckBox bgmCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox cosmeticsGroupBox;
        private System.Windows.Forms.ComboBox zButtonComboBox;
        private System.Windows.Forms.Label zButtonLabel;
        private System.Windows.Forms.ComboBox yButtonComboBox;
        private System.Windows.Forms.Label yButtonLabel;
        private System.Windows.Forms.ComboBox xButtonComboBox;
        private System.Windows.Forms.Label xButtonLabel;
        private System.Windows.Forms.ComboBox bButtonComboBox;
        private System.Windows.Forms.Label bButtonLabel;
        private System.Windows.Forms.ComboBox aButtonComboBox;
        private System.Windows.Forms.Label aButtonLabel;
        private System.Windows.Forms.ComboBox heartColorComboBox;
        private System.Windows.Forms.Label heartColorLabel;
        private System.Windows.Forms.ComboBox regionComboBox;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.CheckBox skyCharacterCheckBox;
        private System.Windows.Forms.CheckBox skillsCheckBox;
        private System.Windows.Forms.ToolTip regionTooltip;
        private System.Windows.Forms.ToolTip settingsToolTip;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip categoriesTooltip;
        private System.Windows.Forms.ToolTip foolishItemsTooltip;
        private System.Windows.Forms.ToolTip dungeonItemsTooltip;
        private System.Windows.Forms.ToolTip additionalSettingsTooltip;
        private System.Windows.Forms.ToolTip cosmeticsTooltip;
        private System.Windows.Forms.ToolTip sfxTooltip;
        private System.Windows.Forms.ToolTip twilightTooltip;
        private System.Windows.Forms.ToolTip cutsceneTooltip;
        private System.Windows.Forms.Label seedNumberLabel;
        private System.Windows.Forms.ComboBox seedNumberComboBox;
        private System.Windows.Forms.CheckBox walletCheckBox;
    }
}

