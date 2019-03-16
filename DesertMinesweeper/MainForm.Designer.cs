namespace DesertMinesweeper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainBox = new System.Windows.Forms.PictureBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.bombsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.mainBox);
            this.panel1.Location = new System.Drawing.Point(5, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 259);
            this.panel1.TabIndex = 0;
            // 
            // mainBox
            // 
            this.mainBox.BackColor = System.Drawing.Color.Transparent;
            this.mainBox.Location = new System.Drawing.Point(-2, -2);
            this.mainBox.Name = "mainBox";
            this.mainBox.Size = new System.Drawing.Size(260, 260);
            this.mainBox.TabIndex = 0;
            this.mainBox.TabStop = false;
            this.mainBox.Click += new System.EventHandler(this.mainBox_Click);
            // 
            // restartButton
            // 
            this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restartButton.Location = new System.Drawing.Point(5, 5);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(90, 35);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart Game";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newGameButton.Location = new System.Drawing.Point(100, 5);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(90, 35);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // bombsLabel
            // 
            this.bombsLabel.AutoSize = true;
            this.bombsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bombsLabel.Location = new System.Drawing.Point(200, 14);
            this.bombsLabel.Name = "bombsLabel";
            this.bombsLabel.Size = new System.Drawing.Size(91, 15);
            this.bombsLabel.TabIndex = 3;
            this.bombsLabel.Text = "Bombs:  9/11";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(344, 356);
            this.Controls.Add(this.bombsLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Desert Minesweeper";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mainBox;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label bombsLabel;


    }
}

