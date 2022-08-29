namespace Labrune
{
    partial class LabruneFind
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
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.FindLabel = new System.Windows.Forms.Label();
      this.FindTextBox = new System.Windows.Forms.TextBox();
      this.CheckCase = new System.Windows.Forms.CheckBox();
      this.CheckAlsoHash = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(424, 62);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 4;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelButton.Location = new System.Drawing.Point(505, 62);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 3;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      // 
      // FindLabel
      // 
      this.FindLabel.AutoSize = true;
      this.FindLabel.Location = new System.Drawing.Point(13, 13);
      this.FindLabel.Name = "FindLabel";
      this.FindLabel.Size = new System.Drawing.Size(69, 13);
      this.FindLabel.TabIndex = 5;
      this.FindLabel.Text = "Value to find:";
      // 
      // FindTextBox
      // 
      this.FindTextBox.Location = new System.Drawing.Point(88, 10);
      this.FindTextBox.Name = "FindTextBox";
      this.FindTextBox.Size = new System.Drawing.Size(493, 20);
      this.FindTextBox.TabIndex = 6;
      // 
      // CheckCase
      // 
      this.CheckCase.AutoSize = true;
      this.CheckCase.Location = new System.Drawing.Point(13, 43);
      this.CheckCase.Name = "CheckCase";
      this.CheckCase.Size = new System.Drawing.Size(94, 17);
      this.CheckCase.TabIndex = 7;
      this.CheckCase.Text = "Case sensitive";
      this.CheckCase.UseVisualStyleBackColor = true;
      this.CheckCase.CheckedChanged += new System.EventHandler(this.CheckCase_CheckedChanged);
      // 
      // CheckAlsoHash
      // 
      this.CheckAlsoHash.AutoSize = true;
      this.CheckAlsoHash.Location = new System.Drawing.Point(12, 66);
      this.CheckAlsoHash.Name = "CheckAlsoHash";
      this.CheckAlsoHash.Size = new System.Drawing.Size(167, 17);
      this.CheckAlsoHash.TabIndex = 8;
      this.CheckAlsoHash.Text = "Find also in hashes and labels";
      this.CheckAlsoHash.UseVisualStyleBackColor = true;
      this.CheckAlsoHash.CheckedChanged += new System.EventHandler(this.CheckAlsoHash_CheckedChanged);
      // 
      // LabruneFind
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(593, 97);
      this.Controls.Add(this.CheckAlsoHash);
      this.Controls.Add(this.CheckCase);
      this.Controls.Add(this.FindTextBox);
      this.Controls.Add(this.FindLabel);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.CancelButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LabruneFind";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Find";
      this.Shown += new System.EventHandler(this.LabruneFind_Shown);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LabruneFind_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label FindLabel;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.CheckBox CheckCase;
        private System.Windows.Forms.CheckBox CheckAlsoHash;
    }
}