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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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
                v[4] = false;
                v[5] = false;

                v.CopyTo(array, 0);
                flagStr = flagStr + flags[array[0]];

                settingsStringTextBox.Text = flagStr;
                Console.WriteLine(flagStr);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
                String flagText = settingsStringTextBox.Text;

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

                oldFlags = settingsStringTextBox.Text;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid flags entered!");
            }
            dontrunhandler = false;
        }
    }
}
