using System;
using System.Windows.Forms;

namespace Labrune
{
    public partial class LabruneFind : Form
    {
        public String ValueToFind { get; set; }
        public bool IsCaseSensitive { get; set; }
        public bool AlsoSearchInHashesAndLabels { get; set; }

        public LabruneFind()
        {
            InitializeComponent();
        }

        private void LabruneFind_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = this.FindTextBox;
        }

        private void LabruneFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                DialogResult = DialogResult.Cancel;
                Close(); 
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ValueToFind = FindTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CheckCase_CheckedChanged(object sender, EventArgs e)
        {
            IsCaseSensitive = CheckCase.Checked;
        }

        private void CheckAlsoHash_CheckedChanged(object sender, EventArgs e)
        {
            AlsoSearchInHashesAndLabels = CheckAlsoHash.Checked;
        }
  }
}
