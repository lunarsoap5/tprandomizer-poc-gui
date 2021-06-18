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
                try
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
                    settings.ExcludedChecks = excludedChecksListBox.Items.OfType<string>().ToList();
                }
                catch (NullReferenceException ex)
                {

                }

            }
        }
        public string getSettingsString()
        {
            BitArray bits = null;
            // WiP of new settings string formula - Bools are padded to 1 bit, strings to 1
            RandomizerSetting parseSetting = Singleton.getInstance().RandoSetting;
			PropertyInfo[] properties = parseSetting.GetType().GetProperties();
			foreach (PropertyInfo property in properties)
			{
                var value = property.GetValue(parseSetting, null);
                BitArray i_bits = null;
                if (property.PropertyType == typeof(bool))
                {
                    if ((bool)value == true)
                    {
                        i_bits.Set(1,true);
                    }
                    else
                    {
                        i_bits.Set(1,false);
                    } 
                }
                if (property.PropertyType == typeof(int))
                {
                    value = (int)value;
                    i_bits = new BitArray(new byte[] { (byte)value });
                }
                if (property.PropertyType == typeof(List<>))
                {
                    if (property.PropertyType == typeof(List<Item>))
                    {
                        List<byte> excludedItems = new List<byte>();
                        List<Item> itemList = new List<Item>();
                        itemList.AddRange((List<Item>)value);
                        foreach (Item item in itemList)
                        {
                            if(Singleton.getInstance().Items.ImportantItems.Contains(item))
                            {
                                //We will use the item ID in the bit array as it takes less memory and is easier to append
                                excludedItems.Add((byte)item);
                            }
                        }
                        byte[] itemBytes = excludedItems.ToArray();
                        i_bits = new BitArray(itemBytes);
                    }
                }
                BackendFunctions.Append(i_bits, bits);
            }
            return BackendFunctions.bitStringToText(bits);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void moveCheckToExcludedButton_Click(object sender, EventArgs e)
        {
            excludedChecksListBox.Items.Add(listofChecksListBox.SelectedItem);
            listofChecksListBox.Items.Remove(listofChecksListBox.SelectedItem);
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

        

        private void settingsStringTextBox_TextChanged(object sender, EventArgs e)
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}
