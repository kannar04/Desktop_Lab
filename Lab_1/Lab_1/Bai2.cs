using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void Bai2_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy ngày tháng và ép định dạng thành: Năm-Tháng-Ngày (vd: 2026-03-25)
            string ngayThang = dtpThoiGian.Value.ToString("yyyy-MM-dd");

            // Lấy nội dung người dùng nhập và xóa khoảng trắng thừa ở 2 đầu (Trim)
            string noiDung = txtNoiDung.Text.Trim();

            // Nếu người dùng chưa nhập nội dung thì báo lỗi và dừng lại
            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý yêu cầu: Chỉ lấy "10 ký tự đầu ND"
            string noiDungNgan = noiDung;
            if (noiDung.Length > 10)
            {
                // Cắt từ vị trí số 0, lấy 10 ký tự, sau đó nối thêm dấu "..."
                noiDungNgan = noiDung.Substring(0, 10) + "...";
            }

            // Ghép chuỗi theo đúng format trên bảng
            string ketQua = $"{ngayThang} : <{noiDungNgan}>";

            // Thêm chuỗi vừa tạo vào ListBox
            lstDanhSach.Items.Add(ketQua);

            // Tùy chọn: Xóa trắng ô nội dung để tiện nhập cái mới và đưa con trỏ chuột về đó
            txtNoiDung.Clear();
            txtNoiDung.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có đang bấm chọn dòng nào trong ListBox không (-1 nghĩa là chưa chọn gì)
            if (lstDanhSach.SelectedIndex != -1)
            {
                // Xóa dòng đang được chọn
                lstDanhSach.Items.RemoveAt(lstDanhSach.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng bên dưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
