namespace Labrune
{
    partial class LabruneExport
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
            this.components = new System.ComponentModel.Container();
            this.labelExport = new System.Windows.Forms.Label();
            this.cbExportAs = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.gbFileProperties = new System.Windows.Forms.GroupBox();
            this.gbExportOptions = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAllEntries = new System.Windows.Forms.RadioButton();
            this.rbUnmodifiedEntries = new System.Windows.Forms.RadioButton();
            this.rbModifiedEntries = new System.Windows.Forms.RadioButton();
            this.gbChunks = new System.Windows.Forms.GroupBox();
            this.rbAllChunks = new System.Windows.Forms.RadioButton();
            this.rbSelectedChunks = new System.Windows.Forms.RadioButton();
            this.gbEndScriptOptions = new System.Windows.Forms.GroupBox();
            this.cbUseAddOrUpdate = new System.Windows.Forms.CheckBox();
            this.labelEndScriptGenerateFor = new System.Windows.Forms.Label();
            this.rbAllLangs = new System.Windows.Forms.RadioButton();
            this.rbCurrLang = new System.Windows.Forms.RadioButton();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.RangeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbFileProperties.SuspendLayout();
            this.gbExportOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbChunks.SuspendLayout();
            this.gbEndScriptOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelExport
            // 
            this.labelExport.AutoSize = true;
            this.labelExport.Location = new System.Drawing.Point(6, 55);
            this.labelExport.Name = "labelExport";
            this.labelExport.Size = new System.Drawing.Size(54, 13);
            this.labelExport.TabIndex = 0;
            this.labelExport.Text = "Export as:";
            // 
            // cbExportAs
            // 
            this.cbExportAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportAs.FormattingEnabled = true;
            this.cbExportAs.Items.AddRange(new object[] {
            "Labrune Dump (*.txt)",
            "End Script VERSN2 for Binary v2+ (*.end)"});
            this.cbExportAs.Location = new System.Drawing.Point(64, 52);
            this.cbExportAs.Name = "cbExportAs";
            this.cbExportAs.Size = new System.Drawing.Size(496, 21);
            this.cbExportAs.TabIndex = 1;
            this.cbExportAs.SelectedIndexChanged += new System.EventHandler(this.cbExportAs_SelectedIndexChanged);
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
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(64, 24);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(397, 20);
            this.textFilePath.TabIndex = 3;
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
            // gbFileProperties
            // 
            this.gbFileProperties.Controls.Add(this.labelPath);
            this.gbFileProperties.Controls.Add(this.BrowseButton);
            this.gbFileProperties.Controls.Add(this.labelExport);
            this.gbFileProperties.Controls.Add(this.textFilePath);
            this.gbFileProperties.Controls.Add(this.cbExportAs);
            this.gbFileProperties.Location = new System.Drawing.Point(15, 12);
            this.gbFileProperties.Name = "gbFileProperties";
            this.gbFileProperties.Size = new System.Drawing.Size(574, 87);
            this.gbFileProperties.TabIndex = 5;
            this.gbFileProperties.TabStop = false;
            this.gbFileProperties.Text = "File";
            // 
            // gbExportOptions
            // 
            this.gbExportOptions.Controls.Add(this.groupBox1);
            this.gbExportOptions.Controls.Add(this.gbChunks);
            this.gbExportOptions.Controls.Add(this.gbEndScriptOptions);
            this.gbExportOptions.Location = new System.Drawing.Point(13, 106);
            this.gbExportOptions.Name = "gbExportOptions";
            this.gbExportOptions.Size = new System.Drawing.Size(576, 153);
            this.gbExportOptions.TabIndex = 6;
            this.gbExportOptions.TabStop = false;
            this.gbExportOptions.Text = "Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAllEntries);
            this.groupBox1.Controls.Add(this.rbUnmodifiedEntries);
            this.groupBox1.Controls.Add(this.rbModifiedEntries);
            this.groupBox1.Location = new System.Drawing.Point(196, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entries";
            // 
            // rbAllEntries
            // 
            this.rbAllEntries.AutoSize = true;
            this.rbAllEntries.Location = new System.Drawing.Point(9, 21);
            this.rbAllEntries.Name = "rbAllEntries";
            this.rbAllEntries.Size = new System.Drawing.Size(36, 17);
            this.rbAllEntries.TabIndex = 0;
            this.rbAllEntries.Text = "All";
            this.rbAllEntries.UseVisualStyleBackColor = true;
            this.rbAllEntries.CheckedChanged += new System.EventHandler(this.rbAllEntries_CheckedChanged);
            // 
            // rbUnmodifiedEntries
            // 
            this.rbUnmodifiedEntries.AutoSize = true;
            this.rbUnmodifiedEntries.Location = new System.Drawing.Point(9, 69);
            this.rbUnmodifiedEntries.Name = "rbUnmodifiedEntries";
            this.rbUnmodifiedEntries.Size = new System.Drawing.Size(78, 17);
            this.rbUnmodifiedEntries.TabIndex = 0;
            this.rbUnmodifiedEntries.Text = "Unmodified";
            this.rbUnmodifiedEntries.UseVisualStyleBackColor = true;
            this.rbUnmodifiedEntries.CheckedChanged += new System.EventHandler(this.rbUnmodifiedEntries_CheckedChanged);
            // 
            // rbModifiedEntries
            // 
            this.rbModifiedEntries.AutoSize = true;
            this.rbModifiedEntries.Checked = true;
            this.rbModifiedEntries.Location = new System.Drawing.Point(9, 45);
            this.rbModifiedEntries.Name = "rbModifiedEntries";
            this.rbModifiedEntries.Size = new System.Drawing.Size(65, 17);
            this.rbModifiedEntries.TabIndex = 0;
            this.rbModifiedEntries.TabStop = true;
            this.rbModifiedEntries.Text = "Modified";
            this.rbModifiedEntries.UseVisualStyleBackColor = true;
            this.rbModifiedEntries.CheckedChanged += new System.EventHandler(this.rbModifiedEntries_CheckedChanged);
            // 
            // gbChunks
            // 
            this.gbChunks.Controls.Add(this.rbAllChunks);
            this.gbChunks.Controls.Add(this.rbSelectedChunks);
            this.gbChunks.Location = new System.Drawing.Point(11, 20);
            this.gbChunks.Name = "gbChunks";
            this.gbChunks.Size = new System.Drawing.Size(179, 123);
            this.gbChunks.TabIndex = 5;
            this.gbChunks.TabStop = false;
            this.gbChunks.Text = "Chunks";
            // 
            // rbAllChunks
            // 
            this.rbAllChunks.AutoSize = true;
            this.rbAllChunks.Checked = true;
            this.rbAllChunks.Location = new System.Drawing.Point(9, 21);
            this.rbAllChunks.Name = "rbAllChunks";
            this.rbAllChunks.Size = new System.Drawing.Size(36, 17);
            this.rbAllChunks.TabIndex = 0;
            this.rbAllChunks.TabStop = true;
            this.rbAllChunks.Text = "All";
            this.rbAllChunks.UseVisualStyleBackColor = true;
            this.rbAllChunks.CheckedChanged += new System.EventHandler(this.rbAllChunks_CheckedChanged);
            // 
            // rbSelectedChunks
            // 
            this.rbSelectedChunks.AutoSize = true;
            this.rbSelectedChunks.Location = new System.Drawing.Point(9, 44);
            this.rbSelectedChunks.Name = "rbSelectedChunks";
            this.rbSelectedChunks.Size = new System.Drawing.Size(82, 17);
            this.rbSelectedChunks.TabIndex = 0;
            this.rbSelectedChunks.Text = "Selected (0)";
            this.rbSelectedChunks.UseVisualStyleBackColor = true;
            this.rbSelectedChunks.CheckedChanged += new System.EventHandler(this.rbSelectedChunks_CheckedChanged);
            // 
            // gbEndScriptOptions
            // 
            this.gbEndScriptOptions.Controls.Add(this.cbUseAddOrUpdate);
            this.gbEndScriptOptions.Controls.Add(this.labelEndScriptGenerateFor);
            this.gbEndScriptOptions.Controls.Add(this.rbAllLangs);
            this.gbEndScriptOptions.Controls.Add(this.rbCurrLang);
            this.gbEndScriptOptions.Enabled = false;
            this.gbEndScriptOptions.Location = new System.Drawing.Point(317, 19);
            this.gbEndScriptOptions.Name = "gbEndScriptOptions";
            this.gbEndScriptOptions.Size = new System.Drawing.Size(253, 124);
            this.gbEndScriptOptions.TabIndex = 4;
            this.gbEndScriptOptions.TabStop = false;
            this.gbEndScriptOptions.Text = "End Script Specific Options";
            this.RangeToolTip.SetToolTip(this.gbEndScriptOptions, "These options are only available if you choose to export as End Script VERSN2 for" +
        " Binary v2+ (*.end).");
            // 
            // cbUseAddOrUpdate
            // 
            this.cbUseAddOrUpdate.AutoSize = true;
            this.cbUseAddOrUpdate.Checked = true;
            this.cbUseAddOrUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseAddOrUpdate.Location = new System.Drawing.Point(9, 94);
            this.cbUseAddOrUpdate.Name = "cbUseAddOrUpdate";
            this.cbUseAddOrUpdate.Size = new System.Drawing.Size(200, 17);
            this.cbUseAddOrUpdate.TabIndex = 4;
            this.cbUseAddOrUpdate.Text = "Use add_or_update_string command";
            this.cbUseAddOrUpdate.UseVisualStyleBackColor = true;
            this.cbUseAddOrUpdate.CheckedChanged += new System.EventHandler(this.cbUseAddOrUpdate_CheckedChanged);
            // 
            // labelEndScriptGenerateFor
            // 
            this.labelEndScriptGenerateFor.AutoSize = true;
            this.labelEndScriptGenerateFor.Location = new System.Drawing.Point(6, 24);
            this.labelEndScriptGenerateFor.Name = "labelEndScriptGenerateFor";
            this.labelEndScriptGenerateFor.Size = new System.Drawing.Size(126, 13);
            this.labelEndScriptGenerateFor.TabIndex = 3;
            this.labelEndScriptGenerateFor.Text = "Generate End Scripts for:";
            // 
            // rbAllLangs
            // 
            this.rbAllLangs.AutoSize = true;
            this.rbAllLangs.Location = new System.Drawing.Point(9, 62);
            this.rbAllLangs.Name = "rbAllLangs";
            this.rbAllLangs.Size = new System.Drawing.Size(133, 17);
            this.rbAllLangs.TabIndex = 0;
            this.rbAllLangs.Text = "All available languages";
            this.rbAllLangs.UseVisualStyleBackColor = true;
            this.rbAllLangs.CheckedChanged += new System.EventHandler(this.rbAllLangs_CheckedChanged);
            // 
            // rbCurrLang
            // 
            this.rbCurrLang.AutoSize = true;
            this.rbCurrLang.Checked = true;
            this.rbCurrLang.Location = new System.Drawing.Point(9, 42);
            this.rbCurrLang.Name = "rbCurrLang";
            this.rbCurrLang.Size = new System.Drawing.Size(128, 17);
            this.rbCurrLang.TabIndex = 0;
            this.rbCurrLang.TabStop = true;
            this.rbCurrLang.Text = "Current language only";
            this.rbCurrLang.UseVisualStyleBackColor = true;
            this.rbCurrLang.CheckedChanged += new System.EventHandler(this.rbCurrLang_CheckedChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(514, 264);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Close";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(433, 264);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // RangeToolTip
            // 
            this.RangeToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.RangeToolTip.ToolTipTitle = "Information";
            // 
            // ExportFileDialog
            // 
            this.ExportFileDialog.DefaultExt = "txt";
            this.ExportFileDialog.Filter = "Labrune Dump (*.txt)|*.txt|End Script VERSN2 for Binary v2+ (*.end)|*.end|All Fil" +
    "es (*.*)|*.*";
            this.ExportFileDialog.Title = "Export";
            // 
            // LabruneExport
            // 
            this.AcceptButton = this.ExportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 299);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.gbExportOptions);
            this.Controls.Add(this.gbFileProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabruneExport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Options";
            this.Shown += new System.EventHandler(this.LabruneExport_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LabruneExport_KeyDown);
            this.gbFileProperties.ResumeLayout(false);
            this.gbFileProperties.PerformLayout();
            this.gbExportOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbChunks.ResumeLayout(false);
            this.gbChunks.PerformLayout();
            this.gbEndScriptOptions.ResumeLayout(false);
            this.gbEndScriptOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelExport;
        private System.Windows.Forms.ComboBox cbExportAs;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.GroupBox gbFileProperties;
        private System.Windows.Forms.GroupBox gbExportOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAllEntries;
        private System.Windows.Forms.RadioButton rbUnmodifiedEntries;
        private System.Windows.Forms.RadioButton rbModifiedEntries;
        private System.Windows.Forms.GroupBox gbChunks;
        private System.Windows.Forms.RadioButton rbAllChunks;
        private System.Windows.Forms.ToolTip RangeToolTip;
        private System.Windows.Forms.RadioButton rbSelectedChunks;
        private System.Windows.Forms.GroupBox gbEndScriptOptions;
        private System.Windows.Forms.CheckBox cbUseAddOrUpdate;
        private System.Windows.Forms.Label labelEndScriptGenerateFor;
        private System.Windows.Forms.RadioButton rbAllLangs;
        private System.Windows.Forms.RadioButton rbCurrLang;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
    }
}