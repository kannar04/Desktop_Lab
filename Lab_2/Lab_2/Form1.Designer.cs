namespace Lab_2
{
    partial class Form1
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
            this.lblSoA = new System.Windows.Forms.Label();
            this.lblSoB = new System.Windows.Forms.Label();
            this.txtSoA = new System.Windows.Forms.TextBox();
            this.txtSoB = new System.Windows.Forms.TextBox();
            this.rbUocChungLonNhat = new System.Windows.Forms.RadioButton();
            this.rbTatCaUocChung = new System.Windows.Forms.RadioButton();
            this.btnTinh = new System.Windows.Forms.Button();
            this.lstKetQua = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblSoA
            // 
            this.lblSoA.AutoSize = true;
            this.lblSoA.Location = new System.Drawing.Point(26, 24);
            this.lblSoA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoA.Name = "lblSoA";
            this.lblSoA.Size = new System.Drawing.Size(57, 13);
            this.lblSoA.TabIndex = 0;
            this.lblSoA.Text = "Nhập số A";
            // 
            // lblSoB
            // 
            this.lblSoB.AutoSize = true;
            this.lblSoB.Location = new System.Drawing.Point(26, 57);
            this.lblSoB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoB.Name = "lblSoB";
            this.lblSoB.Size = new System.Drawing.Size(57, 13);
            this.lblSoB.TabIndex = 1;
            this.lblSoB.Text = "Nhập số B";
            // 
            // txtSoA
            // 
            this.txtSoA.Location = new System.Drawing.Point(90, 22);
            this.txtSoA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoA.Name = "txtSoA";
            this.txtSoA.Size = new System.Drawing.Size(136, 20);
            this.txtSoA.TabIndex = 2;
            // 
            // txtSoB
            // 
            this.txtSoB.Location = new System.Drawing.Point(90, 54);
            this.txtSoB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoB.Name = "txtSoB";
            this.txtSoB.Size = new System.Drawing.Size(136, 20);
            this.txtSoB.TabIndex = 3;
            // 
            // rbUocChungLonNhat
            // 
            this.rbUocChungLonNhat.AutoSize = true;
            this.rbUocChungLonNhat.Location = new System.Drawing.Point(28, 89);
            this.rbUocChungLonNhat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbUocChungLonNhat.Name = "rbUocChungLonNhat";
            this.rbUocChungLonNhat.Size = new System.Drawing.Size(61, 17);
            this.rbUocChungLonNhat.TabIndex = 4;
            this.rbUocChungLonNhat.TabStop = true;
            this.rbUocChungLonNhat.Text = "USCLN";
            this.rbUocChungLonNhat.UseVisualStyleBackColor = true;
            // 
            // rbTatCaUocChung
            // 
            this.rbTatCaUocChung.AutoSize = true;
            this.rbTatCaUocChung.Location = new System.Drawing.Point(112, 89);
            this.rbTatCaUocChung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbTatCaUocChung.Name = "rbTatCaUocChung";
            this.rbTatCaUocChung.Size = new System.Drawing.Size(110, 17);
            this.rbTatCaUocChung.TabIndex = 5;
            this.rbTatCaUocChung.TabStop = true;
            this.rbTatCaUocChung.Text = "Tất cả ước chung";
            this.rbTatCaUocChung.UseVisualStyleBackColor = true;
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(28, 118);
            this.btnTinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(196, 26);
            this.btnTinh.TabIndex = 6;
            this.btnTinh.Text = "Thực hiện";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // lstKetQua
            // 
            this.lstKetQua.FormattingEnabled = true;
            this.lstKetQua.Location = new System.Drawing.Point(28, 156);
            this.lstKetQua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstKetQua.Name = "lstKetQua";
            this.lstKetQua.Size = new System.Drawing.Size(198, 147);
            this.lstKetQua.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 325);
            this.Controls.Add(this.lstKetQua);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.rbTatCaUocChung);
            this.Controls.Add(this.rbUocChungLonNhat);
            this.Controls.Add(this.txtSoB);
            this.Controls.Add(this.txtSoA);
            this.Controls.Add(this.lblSoB);
            this.Controls.Add(this.lblSoA);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USCLN và ước chung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoA;
        private System.Windows.Forms.Label lblSoB;
        private System.Windows.Forms.TextBox txtSoA;
        private System.Windows.Forms.TextBox txtSoB;
        private System.Windows.Forms.RadioButton rbUocChungLonNhat;
        private System.Windows.Forms.RadioButton rbTatCaUocChung;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.ListBox lstKetQua;
    }
}
