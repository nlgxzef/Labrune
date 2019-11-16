namespace Labrune
{
    partial class LabruneEdit
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
            this.EditStringTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.LabelTextBox = new System.Windows.Forms.TextBox();
            this.HashTextBox = new System.Windows.Forms.TextBox();
            this.HashLabel = new System.Windows.Forms.Label();
            this.LabelLabel = new System.Windows.Forms.Label();
            this.CheckUseCustomHash = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // EditStringTextBox
            // 
            this.EditStringTextBox.Location = new System.Drawing.Point(16, 52);
            this.EditStringTextBox.Multiline = true;
            this.EditStringTextBox.Name = "EditStringTextBox";
            this.EditStringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EditStringTextBox.Size = new System.Drawing.Size(775, 176);
            this.EditStringTextBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(712, 234);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(631, 234);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // LabelTextBox
            // 
            this.LabelTextBox.Location = new System.Drawing.Point(280, 15);
            this.LabelTextBox.Name = "LabelTextBox";
            this.LabelTextBox.Size = new System.Drawing.Size(371, 20);
            this.LabelTextBox.TabIndex = 3;
            this.LabelTextBox.TextChanged += new System.EventHandler(this.LabelTextBox_TextChanged);
            // 
            // HashTextBox
            // 
            this.HashTextBox.Location = new System.Drawing.Point(50, 15);
            this.HashTextBox.MaxLength = 8;
            this.HashTextBox.Name = "HashTextBox";
            this.HashTextBox.Size = new System.Drawing.Size(166, 20);
            this.HashTextBox.TabIndex = 4;
            // 
            // HashLabel
            // 
            this.HashLabel.AutoSize = true;
            this.HashLabel.Location = new System.Drawing.Point(13, 18);
            this.HashLabel.Name = "HashLabel";
            this.HashLabel.Size = new System.Drawing.Size(35, 13);
            this.HashLabel.TabIndex = 5;
            this.HashLabel.Text = "Hash:";
            // 
            // LabelLabel
            // 
            this.LabelLabel.AutoSize = true;
            this.LabelLabel.Location = new System.Drawing.Point(242, 18);
            this.LabelLabel.Name = "LabelLabel";
            this.LabelLabel.Size = new System.Drawing.Size(36, 13);
            this.LabelLabel.TabIndex = 6;
            this.LabelLabel.Text = "Label:";
            // 
            // CheckUseCustomHash
            // 
            this.CheckUseCustomHash.AutoSize = true;
            this.CheckUseCustomHash.Location = new System.Drawing.Point(680, 17);
            this.CheckUseCustomHash.Name = "CheckUseCustomHash";
            this.CheckUseCustomHash.Size = new System.Drawing.Size(111, 17);
            this.CheckUseCustomHash.TabIndex = 7;
            this.CheckUseCustomHash.Text = "Use Custom Hash";
            this.CheckUseCustomHash.UseVisualStyleBackColor = true;
            this.CheckUseCustomHash.CheckedChanged += new System.EventHandler(this.CheckUseCustomHash_CheckedChanged);
            // 
            // LabruneEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 269);
            this.Controls.Add(this.CheckUseCustomHash);
            this.Controls.Add(this.LabelLabel);
            this.Controls.Add(this.HashLabel);
            this.Controls.Add(this.HashTextBox);
            this.Controls.Add(this.LabelTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditStringTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabruneEdit";
            this.ShowIcon = false;
            this.Text = "Labrune";
            this.Load += new System.EventHandler(this.LabruneEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EditStringTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox LabelTextBox;
        private System.Windows.Forms.TextBox HashTextBox;
        private System.Windows.Forms.Label HashLabel;
        private System.Windows.Forms.Label LabelLabel;
        public System.Windows.Forms.CheckBox CheckUseCustomHash;
    }
}