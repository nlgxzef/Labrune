namespace Labrune
{
    partial class LabruneRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabruneRestore));
            this.RestoreButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BackupLabel1 = new System.Windows.Forms.Label();
            this.BackupLabel2 = new System.Windows.Forms.Label();
            this.BackupFilesList = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(632, 264);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(75, 23);
            this.RestoreButton.TabIndex = 0;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(713, 264);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BackupLabel1
            // 
            this.BackupLabel1.AutoSize = true;
            this.BackupLabel1.Location = new System.Drawing.Point(8, 18);
            this.BackupLabel1.Name = "BackupLabel1";
            this.BackupLabel1.Size = new System.Drawing.Size(284, 13);
            this.BackupLabel1.TabIndex = 1;
            this.BackupLabel1.Text = "Backups found next to the language file you have opened:";
            // 
            // BackupLabel2
            // 
            this.BackupLabel2.AutoSize = true;
            this.BackupLabel2.Location = new System.Drawing.Point(8, 248);
            this.BackupLabel2.Name = "BackupLabel2";
            this.BackupLabel2.Size = new System.Drawing.Size(477, 39);
            this.BackupLabel2.TabIndex = 1;
            this.BackupLabel2.Text = resources.GetString("BackupLabel2.Text");
            // 
            // BackupFilesList
            // 
            this.BackupFilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FileName,
            this.FileDate});
            this.BackupFilesList.FullRowSelect = true;
            this.BackupFilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.BackupFilesList.HideSelection = false;
            this.BackupFilesList.Location = new System.Drawing.Point(11, 34);
            this.BackupFilesList.Name = "BackupFilesList";
            this.BackupFilesList.Size = new System.Drawing.Size(777, 201);
            this.BackupFilesList.TabIndex = 2;
            this.BackupFilesList.UseCompatibleStateImageBehavior = false;
            this.BackupFilesList.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File Name";
            this.FileName.Width = 500;
            // 
            // FileDate
            // 
            this.FileDate.Text = "Date Modified";
            this.FileDate.Width = 200;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // LabruneRestore
            // 
            this.AcceptButton = this.RestoreButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(800, 299);
            this.Controls.Add(this.BackupFilesList);
            this.Controls.Add(this.BackupLabel2);
            this.Controls.Add(this.BackupLabel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RestoreButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LabruneRestore";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Backups";
            this.Shown += new System.EventHandler(this.LabruneRestore_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LabruneRestore_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label BackupLabel1;
        private System.Windows.Forms.Label BackupLabel2;
        private System.Windows.Forms.ListView BackupFilesList;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileDate;
        private System.Windows.Forms.ColumnHeader ID;
    }
}