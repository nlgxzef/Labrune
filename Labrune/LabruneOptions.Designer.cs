namespace Labrune
{
    partial class LabruneOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CheckSaveLabels = new System.Windows.Forms.CheckBox();
            this.CheckBackups = new System.Windows.Forms.CheckBox();
            this.gbVersion = new System.Windows.Forms.GroupBox();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbOld = new System.Windows.Forms.RadioButton();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.gbFileProperties = new System.Windows.Forms.GroupBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbVersion.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.gbFileProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(513, 159);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(432, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CheckSaveLabels
            // 
            this.CheckSaveLabels.AutoSize = true;
            this.CheckSaveLabels.Checked = true;
            this.CheckSaveLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSaveLabels.Location = new System.Drawing.Point(6, 22);
            this.CheckSaveLabels.Name = "CheckSaveLabels";
            this.CheckSaveLabels.Size = new System.Drawing.Size(127, 17);
            this.CheckSaveLabels.TabIndex = 2;
            this.CheckSaveLabels.Text = "Also Save Labels File";
            this.CheckSaveLabels.UseVisualStyleBackColor = true;
            this.CheckSaveLabels.CheckedChanged += new System.EventHandler(this.CheckSaveLabels_CheckedChanged);
            // 
            // CheckBackups
            // 
            this.CheckBackups.AutoSize = true;
            this.CheckBackups.Checked = true;
            this.CheckBackups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBackups.Location = new System.Drawing.Point(6, 45);
            this.CheckBackups.Name = "CheckBackups";
            this.CheckBackups.Size = new System.Drawing.Size(102, 17);
            this.CheckBackups.TabIndex = 3;
            this.CheckBackups.Text = "Create Backups";
            this.CheckBackups.UseVisualStyleBackColor = true;
            this.CheckBackups.CheckedChanged += new System.EventHandler(this.CheckBackups_CheckedChanged);
            // 
            // gbVersion
            // 
            this.gbVersion.Controls.Add(this.rbNew);
            this.gbVersion.Controls.Add(this.rbOld);
            this.gbVersion.Location = new System.Drawing.Point(15, 82);
            this.gbVersion.Name = "gbVersion";
            this.gbVersion.Size = new System.Drawing.Size(278, 71);
            this.gbVersion.TabIndex = 4;
            this.gbVersion.TabStop = false;
            this.gbVersion.Text = "Language File Version";
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Enabled = false;
            this.rbNew.Location = new System.Drawing.Point(7, 44);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(116, 17);
            this.rbNew.TabIndex = 1;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New (Carbon && Up)";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // rbOld
            // 
            this.rbOld.AutoSize = true;
            this.rbOld.Enabled = false;
            this.rbOld.Location = new System.Drawing.Point(7, 21);
            this.rbOld.Name = "rbOld";
            this.rbOld.Size = new System.Drawing.Size(208, 17);
            this.rbOld.TabIndex = 0;
            this.rbOld.TabStop = true;
            this.rbOld.Text = "Old (Underground 1/2 && Most Wanted)";
            this.rbOld.UseVisualStyleBackColor = true;
            this.rbOld.CheckedChanged += new System.EventHandler(this.rbOld_CheckedChanged);
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.CheckSaveLabels);
            this.gbOther.Controls.Add(this.CheckBackups);
            this.gbOther.Location = new System.Drawing.Point(310, 82);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(278, 71);
            this.gbOther.TabIndex = 4;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other Options";
            // 
            // gbFileProperties
            // 
            this.gbFileProperties.Controls.Add(this.labelPath);
            this.gbFileProperties.Controls.Add(this.BrowseButton);
            this.gbFileProperties.Controls.Add(this.textFilePath);
            this.gbFileProperties.Location = new System.Drawing.Point(15, 12);
            this.gbFileProperties.Name = "gbFileProperties";
            this.gbFileProperties.Size = new System.Drawing.Size(574, 64);
            this.gbFileProperties.TabIndex = 6;
            this.gbFileProperties.TabStop = false;
            this.gbFileProperties.Text = "File";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(6, 27);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Path:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(467, 23);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(93, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(64, 24);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(397, 20);
            this.textFilePath.TabIndex = 3;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "txt";
            this.SaveFileDialog.Filter = "NFS Language Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
            this.SaveFileDialog.Title = "Save";
            // 
            // LabruneOptions
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 198);
            this.Controls.Add(this.gbFileProperties);
            this.Controls.Add(this.gbOther);
            this.Controls.Add(this.gbVersion);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabruneOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Options";
            this.Shown += new System.EventHandler(this.LabruneOptions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LabruneOptions_KeyDown);
            this.gbVersion.ResumeLayout(false);
            this.gbVersion.PerformLayout();
            this.gbOther.ResumeLayout(false);
            this.gbOther.PerformLayout();
            this.gbFileProperties.ResumeLayout(false);
            this.gbFileProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox CheckSaveLabels;
        private System.Windows.Forms.CheckBox CheckBackups;
        private System.Windows.Forms.GroupBox gbVersion;
        private System.Windows.Forms.GroupBox gbOther;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbOld;
        private System.Windows.Forms.GroupBox gbFileProperties;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}