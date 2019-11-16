namespace Labrune
{
    partial class Labrune
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labrune));
            this.LangMenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labruneTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edConfigurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reCompilerConfigurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reCompilerOldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langEdDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileModifiedEntriesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditStrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PrevModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.fontSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLabruneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LangStringView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LangChunkSelector = new System.Windows.Forms.ComboBox();
            this.LangStatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenLanguageFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.FontSettingsDlg = new System.Windows.Forms.FontDialog();
            this.OpenLangEdDumpDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenLabruneDumpDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenReCompilerIniDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveLanguageFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.LangMenuBar.SuspendLayout();
            this.LangStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // LangMenuBar
            // 
            this.LangMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.LangMenuBar.Location = new System.Drawing.Point(0, 0);
            this.LangMenuBar.Name = "LangMenuBar";
            this.LangMenuBar.Size = new System.Drawing.Size(800, 24);
            this.LangMenuBar.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.ImportToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator4,
            this.saveToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // ImportToolStripMenuItem
            // 
            this.ImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labruneTextFileToolStripMenuItem,
            this.edConfigurationsToolStripMenuItem,
            this.reCompilerConfigurationsToolStripMenuItem,
            this.reCompilerOldToolStripMenuItem,
            this.langEdDumpToolStripMenuItem});
            this.ImportToolStripMenuItem.Enabled = false;
            this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            this.ImportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImportToolStripMenuItem.Text = "Import";
            // 
            // labruneTextFileToolStripMenuItem
            // 
            this.labruneTextFileToolStripMenuItem.Name = "labruneTextFileToolStripMenuItem";
            this.labruneTextFileToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.labruneTextFileToolStripMenuItem.Text = "Text File...";
            this.labruneTextFileToolStripMenuItem.Click += new System.EventHandler(this.LabruneTextFileToolStripMenuItem_Click);
            // 
            // edConfigurationsToolStripMenuItem
            // 
            this.edConfigurationsToolStripMenuItem.Name = "edConfigurationsToolStripMenuItem";
            this.edConfigurationsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.edConfigurationsToolStripMenuItem.Text = "Ed Config Folder...";
            this.edConfigurationsToolStripMenuItem.Click += new System.EventHandler(this.EdConfigurationsToolStripMenuItem_Click);
            // 
            // reCompilerConfigurationsToolStripMenuItem
            // 
            this.reCompilerConfigurationsToolStripMenuItem.Name = "reCompilerConfigurationsToolStripMenuItem";
            this.reCompilerConfigurationsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.reCompilerConfigurationsToolStripMenuItem.Text = "ReCompiler Language Folder (New)...";
            this.reCompilerConfigurationsToolStripMenuItem.Click += new System.EventHandler(this.ReCompilerConfigurationsToolStripMenuItem_Click);
            // 
            // reCompilerOldToolStripMenuItem
            // 
            this.reCompilerOldToolStripMenuItem.Name = "reCompilerOldToolStripMenuItem";
            this.reCompilerOldToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.reCompilerOldToolStripMenuItem.Text = "ReCompiler Config.ini (Old)...";
            this.reCompilerOldToolStripMenuItem.Click += new System.EventHandler(this.ReCompilerOldToolStripMenuItem_Click);
            // 
            // langEdDumpToolStripMenuItem
            // 
            this.langEdDumpToolStripMenuItem.Name = "langEdDumpToolStripMenuItem";
            this.langEdDumpToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.langEdDumpToolStripMenuItem.Text = "LangEd Dump...";
            this.langEdDumpToolStripMenuItem.Click += new System.EventHandler(this.LangEdDumpToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFileToolStripMenuItem,
            this.textFileModifiedEntriesOnlyToolStripMenuItem});
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.textFileToolStripMenuItem.Text = "Text File (All)...";
            this.textFileToolStripMenuItem.Click += new System.EventHandler(this.TextFileToolStripMenuItem_Click);
            // 
            // textFileModifiedEntriesOnlyToolStripMenuItem
            // 
            this.textFileModifiedEntriesOnlyToolStripMenuItem.Enabled = false;
            this.textFileModifiedEntriesOnlyToolStripMenuItem.Name = "textFileModifiedEntriesOnlyToolStripMenuItem";
            this.textFileModifiedEntriesOnlyToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.textFileModifiedEntriesOnlyToolStripMenuItem.Text = "Text File (Modified entries only)...";
            this.textFileModifiedEntriesOnlyToolStripMenuItem.Click += new System.EventHandler(this.TextFileModifiedEntriesOnlyToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.EditStrToolStripMenuItem,
            this.RemoveToolStripMenuItem,
            this.toolStripSeparator1,
            this.SearchToolStripMenuItem,
            this.FindPreviousToolStripMenuItem,
            this.FindNextToolStripMenuItem,
            this.toolStripSeparator2,
            this.PrevModifiedToolStripMenuItem,
            this.NextModifiedToolStripMenuItem,
            this.toolStripSeparator6,
            this.fontSettingsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Enabled = false;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.AddToolStripMenuItem.Text = "Add...";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // EditStrToolStripMenuItem
            // 
            this.EditStrToolStripMenuItem.Enabled = false;
            this.EditStrToolStripMenuItem.Name = "EditStrToolStripMenuItem";
            this.EditStrToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.EditStrToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.EditStrToolStripMenuItem.Text = "Edit...";
            this.EditStrToolStripMenuItem.Click += new System.EventHandler(this.EditStrToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Enabled = false;
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.RemoveToolStripMenuItem.Text = "Remove";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Enabled = false;
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.SearchToolStripMenuItem.Text = "Find...";
            this.SearchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // FindPreviousToolStripMenuItem
            // 
            this.FindPreviousToolStripMenuItem.Enabled = false;
            this.FindPreviousToolStripMenuItem.Name = "FindPreviousToolStripMenuItem";
            this.FindPreviousToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.FindPreviousToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.FindPreviousToolStripMenuItem.Text = "Find Previous";
            this.FindPreviousToolStripMenuItem.Click += new System.EventHandler(this.FindPreviousToolStripMenuItem_Click);
            // 
            // FindNextToolStripMenuItem
            // 
            this.FindNextToolStripMenuItem.Enabled = false;
            this.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem";
            this.FindNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.FindNextToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.FindNextToolStripMenuItem.Text = "Find Next";
            this.FindNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // PrevModifiedToolStripMenuItem
            // 
            this.PrevModifiedToolStripMenuItem.Enabled = false;
            this.PrevModifiedToolStripMenuItem.Name = "PrevModifiedToolStripMenuItem";
            this.PrevModifiedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.PrevModifiedToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.PrevModifiedToolStripMenuItem.Text = "Go to Previous Modified";
            this.PrevModifiedToolStripMenuItem.Click += new System.EventHandler(this.PrevModifiedToolStripMenuItem_Click);
            // 
            // NextModifiedToolStripMenuItem
            // 
            this.NextModifiedToolStripMenuItem.Enabled = false;
            this.NextModifiedToolStripMenuItem.Name = "NextModifiedToolStripMenuItem";
            this.NextModifiedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.NextModifiedToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.NextModifiedToolStripMenuItem.Text = "Go to Next Modified";
            this.NextModifiedToolStripMenuItem.Click += new System.EventHandler(this.NextModifiedToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // fontSettingsToolStripMenuItem
            // 
            this.fontSettingsToolStripMenuItem.Name = "fontSettingsToolStripMenuItem";
            this.fontSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fontSettingsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.fontSettingsToolStripMenuItem.Text = "Font Settings...";
            this.fontSettingsToolStripMenuItem.Click += new System.EventHandler(this.fontSettingsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutLabruneToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutLabruneToolStripMenuItem
            // 
            this.aboutLabruneToolStripMenuItem.Name = "aboutLabruneToolStripMenuItem";
            this.aboutLabruneToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutLabruneToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutLabruneToolStripMenuItem.Text = "About Labrune...";
            this.aboutLabruneToolStripMenuItem.Click += new System.EventHandler(this.AboutLabruneToolStripMenuItem_Click);
            // 
            // LangStringView
            // 
            this.LangStringView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LangStringView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LangStringView.FullRowSelect = true;
            this.LangStringView.HideSelection = false;
            this.LangStringView.Location = new System.Drawing.Point(12, 54);
            this.LangStringView.Name = "LangStringView";
            this.LangStringView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LangStringView.Size = new System.Drawing.Size(776, 361);
            this.LangStringView.TabIndex = 1;
            this.LangStringView.UseCompatibleStateImageBehavior = false;
            this.LangStringView.View = System.Windows.Forms.View.Details;
            this.LangStringView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LangStringView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hash";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Label";
            this.columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Text";
            this.columnHeader4.Width = 360;
            // 
            // LangChunkSelector
            // 
            this.LangChunkSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LangChunkSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangChunkSelector.Enabled = false;
            this.LangChunkSelector.FormattingEnabled = true;
            this.LangChunkSelector.Location = new System.Drawing.Point(12, 27);
            this.LangChunkSelector.Name = "LangChunkSelector";
            this.LangChunkSelector.Size = new System.Drawing.Size(776, 21);
            this.LangChunkSelector.TabIndex = 2;
            this.LangChunkSelector.SelectedIndexChanged += new System.EventHandler(this.LangChunkSelector_SelectedIndexChanged);
            // 
            // LangStatusBar
            // 
            this.LangStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarText});
            this.LangStatusBar.Location = new System.Drawing.Point(0, 428);
            this.LangStatusBar.Name = "LangStatusBar";
            this.LangStatusBar.Size = new System.Drawing.Size(800, 22);
            this.LangStatusBar.TabIndex = 3;
            // 
            // StatusBarText
            // 
            this.StatusBarText.Name = "StatusBarText";
            this.StatusBarText.Size = new System.Drawing.Size(0, 17);
            // 
            // OpenLanguageFileDlg
            // 
            this.OpenLanguageFileDlg.Filter = "NFS Language Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
            this.OpenLanguageFileDlg.Title = "Open NFS Language File";
            // 
            // OpenLangEdDumpDialog
            // 
            this.OpenLangEdDumpDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.OpenLangEdDumpDialog.Title = "Import NFS-LangEd Text File";
            // 
            // ExportFileDialog
            // 
            this.ExportFileDialog.DefaultExt = "txt";
            this.ExportFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.ExportFileDialog.Title = "Export Strings to a Text File";
            // 
            // OpenLabruneDumpDialog
            // 
            this.OpenLabruneDumpDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.OpenLabruneDumpDialog.Title = "Import Labrune Text File";
            // 
            // OpenReCompilerIniDialog
            // 
            this.OpenReCompilerIniDialog.Filter = "Configuration Files (*.ini)|*.ini|All Files (*.*)|*.*";
            this.OpenReCompilerIniDialog.Title = "Import ReCompiler Config.ini (Old)";
            // 
            // SaveLanguageFileDlg
            // 
            this.SaveLanguageFileDlg.Filter = "NFS Language Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
            this.SaveLanguageFileDlg.Title = "Save NFS Language File";
            // 
            // Labrune
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LangStatusBar);
            this.Controls.Add(this.LangChunkSelector);
            this.Controls.Add(this.LangStringView);
            this.Controls.Add(this.LangMenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.LangMenuBar;
            this.Name = "Labrune";
            this.Text = "Labrune - The Language Editor for NFS Games!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Labrune_FormClosing);
            this.LangMenuBar.ResumeLayout(false);
            this.LangMenuBar.PerformLayout();
            this.LangStatusBar.ResumeLayout(false);
            this.LangStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip LangMenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ListView LangStringView;
        private System.Windows.Forms.ComboBox LangChunkSelector;
        private System.Windows.Forms.StatusStrip LangStatusBar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.OpenFileDialog OpenLanguageFileDlg;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSettingsToolStripMenuItem;
        private System.Windows.Forms.FontDialog FontSettingsDlg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langEdDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edConfigurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labruneTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditStrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindPreviousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reCompilerConfigurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutLabruneToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel StatusBarText;
        private System.Windows.Forms.OpenFileDialog OpenLangEdDumpDialog;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenLabruneDumpDialog;
        private System.Windows.Forms.ToolStripMenuItem reCompilerOldToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenReCompilerIniDialog;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveLanguageFileDlg;
        private System.Windows.Forms.ToolStripMenuItem PrevModifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextModifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem textFileModifiedEntriesOnlyToolStripMenuItem;
    }
}

