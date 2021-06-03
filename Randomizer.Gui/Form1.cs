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

//Settings string based on code by DigShake https://bitbucket.org/digshake/z2randomizer/src/master/WindowsFormsApplication1/Form1.cs

namespace TPRandomizer
{
    public partial class Form1 : Form
    {
        Randomizer randomizer = new Randomizer();
        bool dontrunhandler;
        private readonly String flags = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz1234567890!@#$";
        private String oldFlags;

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
            randoProgressBar.Maximum = 100;

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
                String flagStr = "";
                BitArray v = new BitArray(6);
                int[] array = new int[1];

                BitArray w = new BitArray(new int[] { logicRulesBox.SelectedIndex });
                v[0] = w[0];
                v[1] = w[1];
                v[2] = w[2];
                w = new BitArray(new int[] { castleLogicComboBox.SelectedIndex });
                v[3] = w[0];
                v[4] = w[1];
                v[5] = w[2];

                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];
                v[0] = w[3];
                v[1] = w[4];
                v[2] = w[5];
                w = new BitArray(new int[] { palaceLogicComboBox.SelectedIndex });
                v[3] = w[0];
                v[4] = w[1];
                v[5] = w[2];

                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = w[3];
                w = new BitArray(new int[] { faronWoodsLogicComboBox.SelectedIndex });
                v[1] = w[0];
                v[2] = w[1];
                v[3] = mdhCheckBox.Checked;
                w = new BitArray(new int[] { smallKeyShuffleComboBox.SelectedIndex });
                v[4] = w[0];
                v[5] = w[1];

                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = w[2];
                v[1] = w[3];
                v[2] = w[4];
                v[3] = w[5];
                w = new BitArray(new int[] { bossKeyShuffleComboBox.SelectedIndex });
                v[4] = w[0];
                v[5] = w[1];

                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];
                v[0] = w[2];
                v[1] = w[3];
                v[2] = w[4];
                v[3] = w[5];
                w = new BitArray(new int[] { mapsAndCompassesComboBox.SelectedIndex });
                v[4] = w[0];
                v[5] = w[1];
                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = w[2];
                v[1] = w[3];
                v[2] = w[4];
                v[3] = w[5];
                v[4] = goldenBugsCheckBox.Checked;
                v[5] = giftFromNPCsCheckBox.Checked;
                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = treasureChestCheckBox.Checked;
                v[1] = shopItemsCheckBox.Checked;
                v[2] = faronTwilightClearedCheckBox.Checked;
                v[3] = eldinTwilightClearedCheckBox.Checked;
                v[4] = lanayruTwilightClearedCheckBox.Checked;
                v[5] = skipMinorCutscenesCheckBox.Checked;
                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = skipMasterSwordPuzzleCheckBox.Checked;
                v[1] = fastIronBootsCheckBox.Checked;
                v[2] = quickTransformCheckBox.Checked;
                v[3] = transformAnywhereCheckBox.Checked;
                v[4] = skipIntroCheckBox.Checked;
                w = new BitArray(new int[] { foolishItemsComboBox.SelectedIndex });
                v[5] = w[0];
                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                v[0] = w[1];
                v[1] = w[2];
                v[2] = w[3];
                v[3] = w[4];
                v[4] = false;
                v[5] = false;
                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                settingsStringTextBox.Text = BackendFunctions.Base64Encode(flagStr);
            }
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
            dontrunhandler = true;
            try
            {
                String flagText = BackendFunctions.Base64Decode(settingsStringTextBox.Text);

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
                logicRulesBox.SelectedIndex = array[0];
                w = new BitArray(6);
                w[0] = v[3];
                w[1] = v[4];
                w[2] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[1]) });
                w[3] = v[0];
                w[4] = v[1];
                w[5] = v[2];
                w.CopyTo(array, 0);
                castleLogicComboBox.SelectedIndex = array[0];
                w = new BitArray(4);
                w[0] = v[3];
                w[1] = v[4];
                w[2] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[2]) });

                w[3] = v[0];
                w.CopyTo(array, 0);
                palaceLogicComboBox.SelectedIndex = array[0];
                w = new BitArray(2);
                w[0] = v[1];
                w[1] = v[2];
                w.CopyTo(array, 0);
                faronWoodsLogicComboBox.SelectedIndex = array[0];
                mdhCheckBox.Checked = v[3];
                w = new BitArray(6);
                w[0] = v[4];
                w[1] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[3]) });

                w[2] = v[0];
                w[3] = v[1];
                w[4] = v[2];
                w[5] = v[3];
                w.CopyTo(array, 0);
                smallKeyShuffleComboBox.SelectedIndex = array[0];
                w = new BitArray(6);
                w[0] = v[4];
                w[1] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[4]) });

                w[2] = v[0];
                w[3] = v[1];
                w[4] = v[2];
                w[5] = v[3];
                w.CopyTo(array, 0);
                bossKeyShuffleComboBox.SelectedIndex = array[0];
                w = new BitArray(6);
                w[0] = v[4];
                w[1] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[5]) });

                w[2] = v[0];
                w[3] = v[1];
                w[4] = v[2];
                w[5] = v[3];
                w.CopyTo(array, 0);
                mapsAndCompassesComboBox.SelectedIndex = array[0];
                goldenBugsCheckBox.Checked = v[4];
                giftFromNPCsCheckBox.Checked = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[6]) });

                treasureChestCheckBox.Checked = v[0];
                shopItemsCheckBox.Checked = v[1];
                faronTwilightClearedCheckBox.Checked = v[2];
                eldinTwilightClearedCheckBox.Checked = v[3];
                lanayruTwilightClearedCheckBox.Checked = v[4];
                skipMinorCutscenesCheckBox.Checked = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[7]) });

                skipMasterSwordPuzzleCheckBox.Checked = v[0];
                fastIronBootsCheckBox.Checked = v[1];
                quickTransformCheckBox.Checked = v[2];
                transformAnywhereCheckBox.Checked = v[3];
                skipIntroCheckBox.Checked = v[4];
                w = new BitArray(6);
                w[0] = v[5];

                v = new BitArray(new int[] { flags.IndexOf(flagText[8]) });

                w[1] = v[0];
                w[2] = v[1];
                w[3] = v[2];
                w[4] = v[3];
                w.CopyTo(array, 0);
                foolishItemsComboBox.SelectedIndex = array[0];

                oldFlags = settingsStringTextBox.Text;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Invalid flags entered!");
            }
            dontrunhandler = false;
        }

        

        private void generateButton_Click(object sender, EventArgs e)
        {
            randomizer.start(settingsStringTextBox.Text);
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

        public static void SetProgress(int progress)
        {
            randoProgressBar.Value = progress;
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
    }
}
