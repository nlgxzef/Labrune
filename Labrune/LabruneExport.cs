using System;
using System.IO;
using System.Windows.Forms;

namespace Labrune
{
    public partial class LabruneExport : Form
    {
        public String FileName { get; set; }
        public int FileFormat{ get; set; }
        public bool SelectedOnly { get; set; } // Only export the selected chunk
        public int EntriesToExport { get; set; } // -1 = Unmodified, 0 = All, 1 = Modified
        public int EndScriptLang { get; set; } // 0 = Current Only, 1 = All
        public bool UseAddOrUpdate { get; set; } // use add_or_update_string command instead of if string_exists ...

        public LabruneExport()
        {
            InitializeComponent();
        }

        public void SetFileName(String fileName)
        {
            FileName = fileName;
            textFilePath.Text = fileName;
            ExportFileDialog.FileName = fileName;
        }

        public void SetFileFormat(String fileName)
        {
            if (fileName.EndsWith(".end")) FileFormat = 1;
            else FileFormat = 0;

            cbExportAs.SelectedIndex = FileFormat;
        }

        public void SetChunkInfo(int SelectedChunk, int NumChunks)
        {
            rbSelectedChunks.Text = "Selected" + " (" + SelectedChunk + ")";

            if (NumChunks > 1)
            {
                // Enable chunk selector
                rbSelectedChunks.Enabled = true;
            }
            else
            {
                // Disable chunk selector
                rbSelectedChunks.Enabled = false;
            }
        }

        public void SetEntryInfo(int NumModifiedEntries)
        {
            if (NumModifiedEntries > 0)
            {
                rbModifiedEntries.Enabled = true;
                rbUnmodifiedEntries.Enabled = true;
            }
            else
            {
                rbModifiedEntries.Enabled = false;
                rbUnmodifiedEntries.Enabled = false;
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SetFileName(FileName);
            SetFileFormat(FileName);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (ExportFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetFileName(ExportFileDialog.FileName);
                SetFileFormat(ExportFileDialog.FileName);
            }
        }

        private void LabruneExport_Shown(object sender, EventArgs e)
        {
            SetFileName(FileName);
            SetFileFormat(FileName);

            // set defaults (buttons)
            rbAllChunks.Checked = true; // All chunks
            rbAllEntries.Checked = true; // All entries
            rbCurrLang.Checked = true; // Current language only
            cbUseAddOrUpdate.Checked = true; // add_or_update

            // set defaults (vars)
            SelectedOnly = false;
            EntriesToExport = 0;
            EndScriptLang = 0;
            UseAddOrUpdate = true;

            // set to modified if it's enabled
            if (rbModifiedEntries.Enabled)
            {
                rbAllEntries.Checked = false;
                rbModifiedEntries.Checked = true;
                EntriesToExport = 1;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbExportAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileFormat = cbExportAs.SelectedIndex;

            switch (FileFormat)
            {
                case 0: //.txt
                default:
                    SetFileName(Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName) + ".txt"));
                    gbEndScriptOptions.Enabled = false;
                    break;
                case 1: //.end
                    SetFileName(Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName) + ".end"));
                    gbEndScriptOptions.Enabled = true;
                    break;
            }
        }

        private void rbAllChunks_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOnly = false;
        }

        private void rbSelectedChunks_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOnly = true;
        }

        private void rbAllEntries_CheckedChanged(object sender, EventArgs e)
        {
            EntriesToExport = 0;
        }

        private void rbModifiedEntries_CheckedChanged(object sender, EventArgs e)
        {
            EntriesToExport = 1;
        }

        private void rbUnmodifiedEntries_CheckedChanged(object sender, EventArgs e)
        {
            EntriesToExport = -1;
        }

        private void rbCurrLang_CheckedChanged(object sender, EventArgs e)
        {
            EndScriptLang = 0;
        }

        private void rbAllLangs_CheckedChanged(object sender, EventArgs e)
        {
            EndScriptLang = 1;
            SetFileName(Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName) + ".end"));
        }

        private void cbUseAddOrUpdate_CheckedChanged(object sender, EventArgs e)
        {
            UseAddOrUpdate = cbUseAddOrUpdate.Checked;
        }

        private void LabruneExport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
