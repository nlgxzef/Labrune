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
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(462, 99);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(381, 99);
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
            this.CheckSaveLabels.Location = new System.Drawing.Point(13, 13);
            this.CheckSaveLabels.Name = "CheckSaveLabels";
            this.CheckSaveLabels.Size = new System.Drawing.Size(183, 17);
            this.CheckSaveLabels.TabIndex = 2;
            this.CheckSaveLabels.Text = "Also save Labels file while saving";
            this.CheckSaveLabels.UseVisualStyleBackColor = true;
            // 
            // CheckBackups
            // 
            this.CheckBackups.AutoSize = true;
            this.CheckBackups.Location = new System.Drawing.Point(13, 37);
            this.CheckBackups.Name = "CheckBackups";
            this.CheckBackups.Size = new System.Drawing.Size(102, 17);
            this.CheckBackups.TabIndex = 3;
            this.CheckBackups.Text = "Create Backups";
            this.CheckBackups.UseVisualStyleBackColor = true;
            // 
            // LabruneOptions
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(549, 134);
            this.Controls.Add(this.CheckBackups);
            this.Controls.Add(this.CheckSaveLabels);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabruneOptions";
            this.ShowIcon = false;
            this.Text = "Labrune Options";
            this.Load += new System.EventHandler(this.LabruneOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox CheckSaveLabels;
        private System.Windows.Forms.CheckBox CheckBackups;
    }
}