namespace Extractor
{
    partial class frmProgressForm
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
            this.lstProgressListBox = new System.Windows.Forms.ListBox();
            this.btnCloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstProgressListBox
            // 
            this.lstProgressListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProgressListBox.FormattingEnabled = true;
            this.lstProgressListBox.HorizontalScrollbar = true;
            this.lstProgressListBox.Location = new System.Drawing.Point(12, 12);
            this.lstProgressListBox.Name = "lstProgressListBox";
            this.lstProgressListBox.Size = new System.Drawing.Size(660, 186);
            this.lstProgressListBox.TabIndex = 0;
            this.lstProgressListBox.SelectedIndexChanged += new System.EventHandler(this.lstProgressListBox_SelectedIndexChanged);
            // 
            // btnCloseButton
            // 
            this.btnCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseButton.Location = new System.Drawing.Point(597, 216);
            this.btnCloseButton.Name = "btnCloseButton";
            this.btnCloseButton.Size = new System.Drawing.Size(75, 33);
            this.btnCloseButton.TabIndex = 1;
            this.btnCloseButton.Text = "Close";
            this.btnCloseButton.UseVisualStyleBackColor = true;
            this.btnCloseButton.Click += new System.EventHandler(this.btnCloseButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Files:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFileCountLabel
            // 
            this.lblFileCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCountLabel.Location = new System.Drawing.Point(61, 225);
            this.lblFileCountLabel.Name = "lblFileCountLabel";
            this.lblFileCountLabel.Size = new System.Drawing.Size(280, 16);
            this.lblFileCountLabel.TabIndex = 3;
            this.lblFileCountLabel.Text = "0";
            // 
            // frmProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.lblFileCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCloseButton);
            this.Controls.Add(this.lstProgressListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.frmProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lstProgressListBox;
        private System.Windows.Forms.Button btnCloseButton;
        public System.Windows.Forms.Label lblFileCountLabel;
        public System.Windows.Forms.Label label1;

    }
}