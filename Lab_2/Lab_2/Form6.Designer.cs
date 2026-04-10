namespace Lab_2
{
    partial class Form6
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
            this.pic0 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pic9 = new System.Windows.Forms.PictureBox();
            this.lblPlayer1Score = new System.Windows.Forms.Label();
            this.lblPlayer2Score = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.timerFlip = new System.Windows.Forms.Timer(this.components);
            this.timerRemoveMatched = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).BeginInit();
            this.SuspendLayout();
            // 
            // pic0
            // 
            this.pic0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic0.Location = new System.Drawing.Point(20, 60);
            this.pic0.Name = "pic0";
            this.pic0.Size = new System.Drawing.Size(80, 80);
            this.pic0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic0.TabIndex = 0;
            this.pic0.TabStop = false;
            this.pic0.Tag = "0";
            this.pic0.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1.Location = new System.Drawing.Point(110, 60);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(80, 80);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 1;
            this.pic1.TabStop = false;
            this.pic1.Tag = "1";
            this.pic1.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic2
            // 
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic2.Location = new System.Drawing.Point(200, 60);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(80, 80);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 2;
            this.pic2.TabStop = false;
            this.pic2.Tag = "2";
            this.pic2.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic3
            // 
            this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic3.Location = new System.Drawing.Point(290, 60);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(80, 80);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 3;
            this.pic3.TabStop = false;
            this.pic3.Tag = "3";
            this.pic3.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic4
            // 
            this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic4.Location = new System.Drawing.Point(380, 60);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(80, 80);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 4;
            this.pic4.TabStop = false;
            this.pic4.Tag = "4";
            this.pic4.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic5
            // 
            this.pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic5.Location = new System.Drawing.Point(20, 150);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(80, 80);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic5.TabIndex = 5;
            this.pic5.TabStop = false;
            this.pic5.Tag = "5";
            this.pic5.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic6
            // 
            this.pic6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic6.Location = new System.Drawing.Point(110, 150);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(80, 80);
            this.pic6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic6.TabIndex = 6;
            this.pic6.TabStop = false;
            this.pic6.Tag = "6";
            this.pic6.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic7
            // 
            this.pic7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic7.Location = new System.Drawing.Point(200, 150);
            this.pic7.Name = "pic7";
            this.pic7.Size = new System.Drawing.Size(80, 80);
            this.pic7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic7.TabIndex = 7;
            this.pic7.TabStop = false;
            this.pic7.Tag = "7";
            this.pic7.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic8
            // 
            this.pic8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic8.Location = new System.Drawing.Point(290, 150);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(80, 80);
            this.pic8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic8.TabIndex = 8;
            this.pic8.TabStop = false;
            this.pic8.Tag = "8";
            this.pic8.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pic9
            // 
            this.pic9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic9.Location = new System.Drawing.Point(380, 150);
            this.pic9.Name = "pic9";
            this.pic9.Size = new System.Drawing.Size(80, 80);
            this.pic9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic9.TabIndex = 9;
            this.pic9.TabStop = false;
            this.pic9.Tag = "9";
            this.pic9.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // lblPlayer1Score
            // 
            this.lblPlayer1Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayer1Score.Location = new System.Drawing.Point(20, 20);
            this.lblPlayer1Score.Name = "lblPlayer1Score";
            this.lblPlayer1Score.Size = new System.Drawing.Size(140, 25);
            this.lblPlayer1Score.TabIndex = 10;
            this.lblPlayer1Score.Text = "Người chơi 1: 0";
            this.lblPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayer2Score
            // 
            this.lblPlayer2Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayer2Score.Location = new System.Drawing.Point(170, 20);
            this.lblPlayer2Score.Name = "lblPlayer2Score";
            this.lblPlayer2Score.Size = new System.Drawing.Size(140, 25);
            this.lblPlayer2Score.TabIndex = 11;
            this.lblPlayer2Score.Text = "Người chơi 2: 0";
            this.lblPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTurn
            // 
            this.lblTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTurn.Location = new System.Drawing.Point(320, 20);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(230, 25);
            this.lblTurn.TabIndex = 12;
            this.lblTurn.Text = "Đến lượt: Người chơi 1";
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(470, 60);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 170);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Ván mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timerFlip
            // 
            this.timerFlip.Interval = 1000;
            this.timerFlip.Tick += new System.EventHandler(this.timerFlip_Tick);
            // 
            // timerRemoveMatched
            // 
            this.timerRemoveMatched.Interval = 2000;
            this.timerRemoveMatched.Tick += new System.EventHandler(this.timerRemoveMatched_Tick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 251);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lblPlayer2Score);
            this.Controls.Add(this.lblPlayer1Score);
            this.Controls.Add(this.pic9);
            this.Controls.Add(this.pic8);
            this.Controls.Add(this.pic7);
            this.Controls.Add(this.pic6);
            this.Controls.Add(this.pic5);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.pic0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Lật hình - 2 người chơi";
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic0;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.PictureBox pic9;
        private System.Windows.Forms.Label lblPlayer1Score;
        private System.Windows.Forms.Label lblPlayer2Score;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timerFlip;
        private System.Windows.Forms.Timer timerRemoveMatched;
    }
}
