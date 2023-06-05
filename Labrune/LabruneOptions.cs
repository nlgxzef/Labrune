using System;
using System.IO;
using System.Windows.Forms;

namespace Labrune
{
    public partial class LabruneOptions : Form
    {
        public String FileName { get; set; }
        public LanguageFileVersion Version { get; set; }
        public bool IncludeHistogram { get; set; } // Only export the selected chunk
        public bool AlsoSaveLabels { get; set; } // Only export the selected chunk
        public bool CreateBackups { get; set; } // Only export the selected chunk

        public LabruneOptions()
        {
            InitializeComponent();
        }
        public void EnableLabelsOption(bool HasLabels)
        {
            CheckSaveLabels.Enabled = HasLabels;
        }

        public void LoadSettings()
        {
            textFilePath.Text = FileName;

            // set defaults (buttons)
            CheckSaveLabels.Checked = true; // Current language only
            CheckBackups.Checked = true; // add_or_update

            // Set version
            switch (Version)
            {
                case LanguageFileVersion.Old:
                    Version = LanguageFileVersion.Old;
                    rbOld.Checked = true; // Old format
                    rbNew.Checked = false;
                    break;

                case LanguageFileVersion.New:
                default:
                    Version = LanguageFileVersion.New;
                    rbNew.Checked = true;
                    rbOld.Checked = false; // New format
                    break;
            }
        }

        public void SaveSettings()
        {
            FileName = textFilePath.Text;
            Version = rbNew.Checked ? LanguageFileVersion.New : LanguageFileVersion.Old;
            CreateBackups = CheckBackups.Checked;
            AlsoSaveLabels = CheckSaveLabels.Checked;
        }

        private void LabruneOptions_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void LabruneOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void rbOld_CheckedChanged(object sender, EventArgs e)
        {
            Version = LanguageFileVersion.Old;
        }

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            Version = LanguageFileVersion.New;
        }

        private void CheckBackups_CheckedChanged(object sender, EventArgs e)
        {
            CreateBackups = CheckBackups.Checked;
        }

        private void CheckSaveLabels_CheckedChanged(object sender, EventArgs e)
        {
            AlsoSaveLabels = CheckSaveLabels.Checked;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Path.GetDirectoryName(FileName);

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = SaveFileDialog.FileName;
                textFilePath.Text = FileName;
            }
        }
    }
}
