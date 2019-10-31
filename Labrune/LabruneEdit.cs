using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labrune
{
    public partial class LabruneEdit : Form
    {
        public String ID { get; set; }
        public String Hash { get; set; }
        public String Label { get; set; }
        public String Value { get; set; }

        public String NewHash { get; set; }
        public String NewValue { get; set; }
        public String NewLabel { get; set; }

        public bool IsNewString { get; set; } = false;

        public LabruneEdit()
        {
            InitializeComponent();
        }

        private void LabruneEdit_Load(object sender, EventArgs e)
        {
            HashTextBox.Enabled = false;

            HashTextBox.Text = Hash;
            LabelTextBox.Text = Label;
            EditStringTextBox.Text = Value;

            if (IsNewString) Text = ProductName + " " + "|" + " " + "Add New String";
            else Text = ProductName + " " + "|" + " " + "Editing Item" + " " + "#" + ID + " " + "with Hash" + " " + Hash;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CheckUseCustomHash_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckUseCustomHash.Checked)
            {
                HashTextBox.Enabled = true;
                LabelTextBox.Enabled = false;
            }
            else
            {
                HashTextBox.Enabled = false;
                LabelTextBox.Enabled = true;
                LabelTextBox_TextChanged(sender, new EventArgs());
            }
        }

        private void LabelTextBox_TextChanged(object sender, EventArgs e)
        {
            HashTextBox.Text = BinHash.Hash(LabelTextBox.Text).ToString("X8");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            NewHash = HashTextBox.Text;
            NewValue = EditStringTextBox.Text;
            NewLabel = LabelTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
