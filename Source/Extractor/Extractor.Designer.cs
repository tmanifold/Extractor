#region Copyright
/*
  Copyright (C) 2015 Tyler Manifold
  
  This file is part of Extractor.
  
  Extractor is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Extractor is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Extractor.  If not, see <http://www.gnu.org/licenses/>.

  Extractor is a simple, recursive file extraction program.
 
  Email: tdmanifold@gmail.com

*/
#endregion

namespace Extractor
{
    partial class Form_Extractor
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
            this.btnExtract_Button = new System.Windows.Forms.Button();
            this.lblSource_Label = new System.Windows.Forms.Label();
            this.lblDestination_Label = new System.Windows.Forms.Label();
            this.txtSource_TextBox = new System.Windows.Forms.TextBox();
            this.txtDestination_TextBox = new System.Windows.Forms.TextBox();
            this.btnSourceDialogButton = new System.Windows.Forms.Button();
            this.btnDestinationDialogButton = new System.Windows.Forms.Button();
            this.chkDeleteZipsCheckBox = new System.Windows.Forms.CheckBox();
            this.chkFixNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.chkViewFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnExtract_Button
            // 
            this.btnExtract_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExtract_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract_Button.Location = new System.Drawing.Point(244, 188);
            this.btnExtract_Button.Name = "btnExtract_Button";
            this.btnExtract_Button.Size = new System.Drawing.Size(94, 35);
            this.btnExtract_Button.TabIndex = 0;
            this.btnExtract_Button.Text = "Extract";
            this.btnExtract_Button.UseVisualStyleBackColor = true;
            this.btnExtract_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSource_Label
            // 
            this.lblSource_Label.AutoSize = true;
            this.lblSource_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource_Label.Location = new System.Drawing.Point(12, 13);
            this.lblSource_Label.Name = "lblSource_Label";
            this.lblSource_Label.Size = new System.Drawing.Size(61, 16);
            this.lblSource_Label.TabIndex = 1;
            this.lblSource_Label.Text = "Source:";
            // 
            // lblDestination_Label
            // 
            this.lblDestination_Label.AutoSize = true;
            this.lblDestination_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination_Label.Location = new System.Drawing.Point(12, 62);
            this.lblDestination_Label.Name = "lblDestination_Label";
            this.lblDestination_Label.Size = new System.Drawing.Size(90, 16);
            this.lblDestination_Label.TabIndex = 2;
            this.lblDestination_Label.Text = "Destination:";
            // 
            // txtSource_TextBox
            // 
            this.txtSource_TextBox.Location = new System.Drawing.Point(38, 32);
            this.txtSource_TextBox.Name = "txtSource_TextBox";
            this.txtSource_TextBox.Size = new System.Drawing.Size(262, 20);
            this.txtSource_TextBox.TabIndex = 3;
            this.txtSource_TextBox.TextChanged += new System.EventHandler(this.txtSource_TextBox_TextChanged);
            // 
            // txtDestination_TextBox
            // 
            this.txtDestination_TextBox.Location = new System.Drawing.Point(38, 81);
            this.txtDestination_TextBox.Name = "txtDestination_TextBox";
            this.txtDestination_TextBox.Size = new System.Drawing.Size(262, 20);
            this.txtDestination_TextBox.TabIndex = 4;
            this.txtDestination_TextBox.TextChanged += new System.EventHandler(this.txtDestination_TextBox_TextChanged);
            // 
            // btnSourceDialogButton
            // 
            this.btnSourceDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceDialogButton.Location = new System.Drawing.Point(306, 31);
            this.btnSourceDialogButton.Name = "btnSourceDialogButton";
            this.btnSourceDialogButton.Size = new System.Drawing.Size(32, 23);
            this.btnSourceDialogButton.TabIndex = 5;
            this.btnSourceDialogButton.Text = "...";
            this.btnSourceDialogButton.UseVisualStyleBackColor = true;
            this.btnSourceDialogButton.Click += new System.EventHandler(this.btnSourceDialogButton_Click);
            // 
            // btnDestinationDialogButton
            // 
            this.btnDestinationDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestinationDialogButton.Location = new System.Drawing.Point(306, 80);
            this.btnDestinationDialogButton.Name = "btnDestinationDialogButton";
            this.btnDestinationDialogButton.Size = new System.Drawing.Size(32, 23);
            this.btnDestinationDialogButton.TabIndex = 6;
            this.btnDestinationDialogButton.Text = "...";
            this.btnDestinationDialogButton.UseVisualStyleBackColor = true;
            this.btnDestinationDialogButton.Click += new System.EventHandler(this.btnDestinationDialogButton_Click);
            // 
            // chkDeleteZipsCheckBox
            // 
            this.chkDeleteZipsCheckBox.AutoSize = true;
            this.chkDeleteZipsCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkDeleteZipsCheckBox.Location = new System.Drawing.Point(15, 121);
            this.chkDeleteZipsCheckBox.Name = "chkDeleteZipsCheckBox";
            this.chkDeleteZipsCheckBox.Size = new System.Drawing.Size(81, 44);
            this.chkDeleteZipsCheckBox.TabIndex = 8;
            this.chkDeleteZipsCheckBox.Text = "Delete .zips\r\nafter extracting";
            this.chkDeleteZipsCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDeleteZipsCheckBox.UseVisualStyleBackColor = true;
            this.chkDeleteZipsCheckBox.CheckedChanged += new System.EventHandler(this.chkDeleteZipsCheckBox_CheckedChanged);
            // 
            // chkFixNamesCheckBox
            // 
            this.chkFixNamesCheckBox.AutoSize = true;
            this.chkFixNamesCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkFixNamesCheckBox.Location = new System.Drawing.Point(126, 121);
            this.chkFixNamesCheckBox.Name = "chkFixNamesCheckBox";
            this.chkFixNamesCheckBox.Size = new System.Drawing.Size(88, 44);
            this.chkFixNamesCheckBox.TabIndex = 9;
            this.chkFixNamesCheckBox.Text = "Fix \r\ndirectory names:";
            this.chkFixNamesCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkFixNamesCheckBox.UseVisualStyleBackColor = true;
            this.chkFixNamesCheckBox.CheckedChanged += new System.EventHandler(this.chkFixNamesCheckBox_CheckedChanged);
            // 
            // chkViewFilesCheckBox
            // 
            this.chkViewFilesCheckBox.AutoSize = true;
            this.chkViewFilesCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkViewFilesCheckBox.Location = new System.Drawing.Point(244, 121);
            this.chkViewFilesCheckBox.Name = "chkViewFilesCheckBox";
            this.chkViewFilesCheckBox.Size = new System.Drawing.Size(84, 44);
            this.chkViewFilesCheckBox.TabIndex = 10;
            this.chkViewFilesCheckBox.Text = "View files\r\nafter extraction:";
            this.chkViewFilesCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkViewFilesCheckBox.UseVisualStyleBackColor = true;
            this.chkViewFilesCheckBox.CheckedChanged += new System.EventHandler(this.chkViewFilesCheckBox_CheckedChanged);
            // 
            // Form_Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 235);
            this.Controls.Add(this.chkViewFilesCheckBox);
            this.Controls.Add(this.chkFixNamesCheckBox);
            this.Controls.Add(this.chkDeleteZipsCheckBox);
            this.Controls.Add(this.btnDestinationDialogButton);
            this.Controls.Add(this.btnSourceDialogButton);
            this.Controls.Add(this.txtDestination_TextBox);
            this.Controls.Add(this.txtSource_TextBox);
            this.Controls.Add(this.lblDestination_Label);
            this.Controls.Add(this.lblSource_Label);
            this.Controls.Add(this.btnExtract_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Extractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor";
            this.Load += new System.EventHandler(this.Form_Unzipper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtract_Button;
        private System.Windows.Forms.Label lblSource_Label;
        private System.Windows.Forms.Label lblDestination_Label;
        private System.Windows.Forms.TextBox txtSource_TextBox;
        private System.Windows.Forms.TextBox txtDestination_TextBox;
        private System.Windows.Forms.Button btnSourceDialogButton;
        private System.Windows.Forms.Button btnDestinationDialogButton;
        private System.Windows.Forms.CheckBox chkFixNamesCheckBox;
        private System.Windows.Forms.CheckBox chkDeleteZipsCheckBox;
        private System.Windows.Forms.CheckBox chkViewFilesCheckBox;
    }
}

