namespace Lab_2
{
    partial class Form4
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
            this.lblNhapHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblTieuDeKetQua = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnInLoiGioiThieu = new System.Windows.Forms.Button();
            this.btnHoLot = new System.Windows.Forms.Button();
            this.btnTen = new System.Windows.Forms.Button();
            this.btnDemTu = new System.Windows.Forms.Button();
            this.btnHoaDauTu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNhapHoTen
            // 
            this.lblNhapHoTen.AutoSize = true;
            this.lblNhapHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapHoTen.Location = new System.Drawing.Point(21, 9);
            this.lblNhapHoTen.Name = "lblNhapHoTen";
            this.lblNhapHoTen.Size = new System.Drawing.Size(131, 17);
            this.lblNhapHoTen.TabIndex = 0;
            this.lblNhapHoTen.Text = "Nhập Họ và Tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(24, 29);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(302, 20);
            this.txtHoTen.TabIndex = 1;
            // 
            // lblTieuDeKetQua
            // 
            this.lblTieuDeKetQua.AutoSize = true;
            this.lblTieuDeKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeKetQua.Location = new System.Drawing.Point(21, 52);
            this.lblTieuDeKetQua.Name = "lblTieuDeKetQua";
            this.lblTieuDeKetQua.Size = new System.Drawing.Size(69, 17);
            this.lblTieuDeKetQua.TabIndex = 2;
            this.lblTieuDeKetQua.Text = "Kết quả:";
            // 
            // lblKetQua
            // 
            this.lblKetQua.BackColor = System.Drawing.Color.LightYellow;
            this.lblKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKetQua.Location = new System.Drawing.Point(24, 69);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(302, 51);
            this.lblKetQua.TabIndex = 3;
            // 
            // btnInLoiGioiThieu
            // 
            this.btnInLoiGioiThieu.Location = new System.Drawing.Point(24, 123);
            this.btnInLoiGioiThieu.Name = "btnInLoiGioiThieu";
            this.btnInLoiGioiThieu.Size = new System.Drawing.Size(50, 79);
            this.btnInLoiGioiThieu.TabIndex = 4;
            this.btnInLoiGioiThieu.Text = "In Lời giới thiệu";
            this.btnInLoiGioiThieu.UseVisualStyleBackColor = true;
            this.btnInLoiGioiThieu.Click += new System.EventHandler(this.btnInLoiGioiThieu_Click);
            // 
            // btnHoLot
            // 
            this.btnHoLot.Location = new System.Drawing.Point(80, 123);
            this.btnHoLot.Name = "btnHoLot";
            this.btnHoLot.Size = new System.Drawing.Size(72, 32);
            this.btnHoLot.TabIndex = 5;
            this.btnHoLot.Text = "Họ lót";
            this.btnHoLot.UseVisualStyleBackColor = true;
            this.btnHoLot.Click += new System.EventHandler(this.btnHoLot_Click);
            // 
            // btnTen
            // 
            this.btnTen.Location = new System.Drawing.Point(80, 170);
            this.btnTen.Name = "btnTen";
            this.btnTen.Size = new System.Drawing.Size(72, 32);
            this.btnTen.TabIndex = 6;
            this.btnTen.Text = "Tên";
            this.btnTen.UseVisualStyleBackColor = true;
            this.btnTen.Click += new System.EventHandler(this.btnTen_Click);
            // 
            // btnDemTu
            // 
            this.btnDemTu.Location = new System.Drawing.Point(158, 123);
            this.btnDemTu.Name = "btnDemTu";
            this.btnDemTu.Size = new System.Drawing.Size(81, 32);
            this.btnDemTu.TabIndex = 7;
            this.btnDemTu.Text = "Đếm từ";
            this.btnDemTu.UseVisualStyleBackColor = true;
            this.btnDemTu.Click += new System.EventHandler(this.btnDemTu_Click);
            // 
            // btnHoaDauTu
            // 
            this.btnHoaDauTu.Location = new System.Drawing.Point(158, 170);
            this.btnHoaDauTu.Name = "btnHoaDauTu";
            this.btnHoaDauTu.Size = new System.Drawing.Size(81, 32);
            this.btnHoaDauTu.TabIndex = 8;
            this.btnHoaDauTu.Text = "Hoa Đầu Từ";
            this.btnHoaDauTu.UseVisualStyleBackColor = true;
            this.btnHoaDauTu.Click += new System.EventHandler(this.btnHoaDauTu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(245, 123);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 32);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDung
            // 
            this.btnDung.Location = new System.Drawing.Point(245, 170);
            this.btnDung.Name = "btnDung";
            this.btnDung.Size = new System.Drawing.Size(81, 32);
            this.btnDung.TabIndex = 10;
            this.btnDung.Text = "Dừng";
            this.btnDung.UseVisualStyleBackColor = true;
            this.btnDung.Click += new System.EventHandler(this.btnDung_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 216);
            this.Controls.Add(this.btnDung);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnHoaDauTu);
            this.Controls.Add(this.btnDemTu);
            this.Controls.Add(this.btnTen);
            this.Controls.Add(this.btnHoLot);
            this.Controls.Add(this.btnInLoiGioiThieu);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lblTieuDeKetQua);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblNhapHoTen);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Họ Tên - OOP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhapHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblTieuDeKetQua;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnInLoiGioiThieu;
        private System.Windows.Forms.Button btnHoLot;
        private System.Windows.Forms.Button btnTen;
        private System.Windows.Forms.Button btnDemTu;
        private System.Windows.Forms.Button btnHoaDauTu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDung;
    }
}
