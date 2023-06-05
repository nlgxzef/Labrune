using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labrune
{
    public partial class LabruneRestore : Form
    {
        public String BackupDirectory { get; set; }
        public List<FileInfo> FilesToRestore { get; set; }
        public List<String> FilesToRestoreSelected { get; set; }

        public LabruneRestore()
        {
            InitializeComponent();
        }

        public void InitBackups()
        {
            FilesToRestore = new DirectoryInfo(BackupDirectory).GetFiles()
                .Where(s => s.Name.EndsWith(".bin_", StringComparison.OrdinalIgnoreCase)
                         || s.Name.EndsWith(".bak", StringComparison.OrdinalIgnoreCase)
                         || s.Name.EndsWith(".BACC", StringComparison.OrdinalIgnoreCase)
                         || s.Name.EndsWith(".edbackup", StringComparison.OrdinalIgnoreCase)
                         || s.Name.EndsWith(".labrunebackup", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f.LastWriteTime).ToList();
        }

        public void RefreshBackupsView()
        {
            BackupFilesList.Items.Clear(); // Clear the list first
            BackupFilesList.BeginUpdate();

            int ItemID = 1;

            foreach (var i in FilesToRestore)
            {
                var FItm = new ListViewItem();

                FItm.Text = ItemID++.ToString();
                FItm.SubItems.Add(i.FullName);
                FItm.SubItems.Add(i.LastWriteTime.ToString());

                BackupFilesList.Items.Add(FItm);
            }

            BackupFilesList.EndUpdate();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            // Get selected items from the list and add them to the filestorestore list
            FilesToRestoreSelected.Clear();

            foreach (ListViewItem i in BackupFilesList.SelectedItems)
            {
                FilesToRestoreSelected.Add(i.SubItems[1].Text); // File name
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LabruneRestore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void LabruneRestore_Shown(object sender, EventArgs e)
        {
            FilesToRestoreSelected = new List<string>();
            RefreshBackupsView();
        }
    }
}
