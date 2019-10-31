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
    public partial class LabruneOptions : Form
    {
        public LabruneOptions()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            CheckSaveLabels.Checked = Properties.Settings.Default.AlsoSaveLabels;
            CheckBackups.Checked = Properties.Settings.Default.CreateBackups;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.AlsoSaveLabels = CheckSaveLabels.Checked;
            Properties.Settings.Default.CreateBackups = CheckBackups.Checked;
        }

        private void LabruneOptions_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
