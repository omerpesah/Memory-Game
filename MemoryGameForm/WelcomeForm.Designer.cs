namespace MemoryGameForm
{
    partial class WelcomeForm
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
            this.firstPlayerLable = new System.Windows.Forms.Label();
            this.secondPlayerLable = new System.Windows.Forms.Label();
            this.firstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.boardSizeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPlayerLable
            // 
            this.firstPlayerLable.AutoSize = true;
            this.firstPlayerLable.Location = new System.Drawing.Point(35, 33);
            this.firstPlayerLable.Name = "firstPlayerLable";
            this.firstPlayerLable.Size = new System.Drawing.Size(128, 17);
            this.firstPlayerLable.TabIndex = 0;
            this.firstPlayerLable.Text = "First Player Name: ";
            this.firstPlayerLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // secondPlayerLable
            // 
            this.secondPlayerLable.AutoSize = true;
            this.secondPlayerLable.Location = new System.Drawing.Point(35, 106);
            this.secondPlayerLable.Name = "secondPlayerLable";
            this.secondPlayerLable.Size = new System.Drawing.Size(149, 17);
            this.secondPlayerLable.TabIndex = 1;
            this.secondPlayerLable.Text = "Second Player Name: ";
            // 
            // firstPlayerTextBox
            // 
            this.firstPlayerTextBox.Location = new System.Drawing.Point(205, 28);
            this.firstPlayerTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.firstPlayerTextBox.Name = "firstPlayerTextBox";
            this.firstPlayerTextBox.Size = new System.Drawing.Size(141, 22);
            this.firstPlayerTextBox.TabIndex = 2;
            // 
            // secondPlayerTextBox
            // 
            this.secondPlayerTextBox.Enabled = false;
            this.secondPlayerTextBox.Location = new System.Drawing.Point(205, 101);
            this.secondPlayerTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.secondPlayerTextBox.Name = "secondPlayerTextBox";
            this.secondPlayerTextBox.Size = new System.Drawing.Size(141, 22);
            this.secondPlayerTextBox.TabIndex = 3;
            this.secondPlayerTextBox.Text = "-Computer-";
            // 
            // secondPlayerButton
            // 
            this.secondPlayerButton.Location = new System.Drawing.Point(353, 97);
            this.secondPlayerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.secondPlayerButton.Name = "secondPlayerButton";
            this.secondPlayerButton.Size = new System.Drawing.Size(143, 31);
            this.secondPlayerButton.TabIndex = 4;
            this.secondPlayerButton.Text = "Against a Friend";
            this.secondPlayerButton.UseVisualStyleBackColor = true;
            this.secondPlayerButton.Click += new System.EventHandler(this.secondPlayerButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.BackColor = System.Drawing.Color.YellowGreen;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startButton.Location = new System.Drawing.Point(353, 278);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(143, 43);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardSizeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boardSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.boardSizeButton.Location = new System.Drawing.Point(37, 198);
            this.boardSizeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(200, 123);
            this.boardSizeButton.TabIndex = 6;
            this.boardSizeButton.Text = "4 x 4";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // boardSizeLable
            // 
            this.boardSizeLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardSizeLable.AutoSize = true;
            this.boardSizeLable.Location = new System.Drawing.Point(35, 178);
            this.boardSizeLable.Name = "boardSizeLable";
            this.boardSizeLable.Size = new System.Drawing.Size(81, 17);
            this.boardSizeLable.TabIndex = 7;
            this.boardSizeLable.Text = "Board Size:";
            // 
            // WelcomeForm
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 366);
            this.Controls.Add(this.boardSizeLable);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.secondPlayerButton);
            this.Controls.Add(this.secondPlayerTextBox);
            this.Controls.Add(this.firstPlayerTextBox);
            this.Controls.Add(this.secondPlayerLable);
            this.Controls.Add(this.firstPlayerLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - settings";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerLable;
        private System.Windows.Forms.Label secondPlayerLable;
        private System.Windows.Forms.TextBox firstPlayerTextBox;
        private System.Windows.Forms.TextBox secondPlayerTextBox;
        private System.Windows.Forms.Button secondPlayerButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button boardSizeButton;
        private System.Windows.Forms.Label boardSizeLable;
    }
}