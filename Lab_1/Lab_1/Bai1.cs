using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void Bai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you really want to close?", "Demo Form",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua không kiểm tra nếu ô nhập đang trống hoặc người dùng chỉ mới gõ dấu trừ
            if (string.IsNullOrEmpty(txtNum1.Text) || txtNum1.Text == "-")
            {
                return;
            }

            double giaTriTam;

            if (!double.TryParse(txtNum1.Text, out giaTriTam))
            {
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Xóa ký tự cuối cùng vừa gõ sai
                txtNum1.Text = txtNum1.Text.Remove(txtNum1.Text.Length - 1);

                // Đưa con trỏ chuột về lại cuối dòng
                txtNum1.SelectionStart = txtNum1.Text.Length;
            }
            else
            {
                TinhToan();
            }
        }

        private void txtNum2_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua không kiểm tra nếu ô nhập đang trống hoặc người dùng chỉ mới gõ dấu trừ
            if (string.IsNullOrEmpty(txtNum2.Text) || txtNum2.Text == "-")
            {
                return;
            }

            double giaTriTam;

            if (!double.TryParse(txtNum2.Text, out giaTriTam))
            {
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Xóa ký tự cuối cùng vừa gõ sai
                txtNum2.Text = txtNum2.Text.Remove(txtNum2.Text.Length - 1);

                // Đưa con trỏ chuột về lại cuối dòng
                txtNum2.SelectionStart = txtNum2.Text.Length;
            }
            else
            {
                TinhToan();
            }
        }

        private void TinhToan()
        {
            // Kiểm tra: Nếu 1 trong 2 ô đang trống hoặc chỉ có dấu "-" thì chưa tính
            if (string.IsNullOrEmpty(txtNum1.Text) || txtNum1.Text == "-" ||
                string.IsNullOrEmpty(txtNum2.Text) || txtNum2.Text == "-")
            {
                return;
            }

            // Khai báo biến để hứng giá trị số từ 2 ô nhập
            double num1, num2;

            // Chuyển chuỗi thành số thực (double)
            if (double.TryParse(txtNum1.Text, out num1) && double.TryParse(txtNum2.Text, out num2))
            {
                double result = 0;
                string phepToan = "";

                if (radCong.Checked)
                {
                    result = num1 + num2;
                    phepToan = "+";
                }
                else if (radTru.Checked)
                {
                    result = num1 - num2;
                    phepToan = "-";
                }
                else if (radNhan.Checked)
                {
                    result = num1 * num2;
                    phepToan = "*";
                }
                else if (radChia.Checked)
                {
                    // Xử lý yêu cầu: Cảnh báo khi chia cho 0
                    if (num2 == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtKetQua.Text = "Không thể chia cho 0. Vui lòng kiểm tra lại!!!";
                        return;
                    }
                    result = num1 / num2;
                    phepToan = "/";
                }

                // Hiển thị kết quả đúng định dạng trên bảng
                txtKetQua.Text = $"{num1} {phepToan} {num2} = {result}";
            }
        }

        private void radCong_CheckedChanged(object sender, EventArgs e) { if (radCong.Checked) TinhToan(); }
        private void radTru_CheckedChanged(object sender, EventArgs e) { if (radTru.Checked) TinhToan(); }
        private void radNhan_CheckedChanged(object sender, EventArgs e) { if (radNhan.Checked) TinhToan(); }
        private void radChia_CheckedChanged(object sender, EventArgs e) { if (radChia.Checked) TinhToan(); }
    }
}
