using System;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string s1 = txtS1.Text;
            string s2 = txtS2.Text;
            int ketQuaSoSanh = string.Compare(s1, s2, StringComparison.Ordinal);

            if (ketQuaSoSanh == 0)
            {
                lblKQ.Text = "Hai chuỗi giống nhau";
            }
            else
            {
                lblKQ.Text = "Hai chuỗi khác nhau";
            }
        }

        private void btnCOMPARE_IgnoreCase_Click(object sender, EventArgs e)
        {
            string s1 = txtS1.Text;
            string s2 = txtS2.Text;
            int ketQuaSoSanh = string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);

            if (ketQuaSoSanh == 0)
            {
                lblKQ.Text = "Hai chuỗi giống nhau (không phân biệt hoa thường)";
            }
            else
            {
                lblKQ.Text = "Hai chuỗi khác nhau (không phân biệt hoa thường)";
            }
        }

        private void btnConcat_Click(object sender, EventArgs e)
        {
            string s1 = txtS1.Text;
            string s2 = txtS2.Text;
            string chuoiNoi = string.Concat(s1, s2);
            lblKQ.Text = chuoiNoi;
        }

        private void btnIndexOf_Click(object sender, EventArgs e)
        {
            string s1 = txtS1.Text;
            string s2 = txtS2.Text;
            int viTri = s1.IndexOf(s2, StringComparison.Ordinal);

            if (viTri >= 0)
            {
                string chuoiSauThayThe = s1.Replace(s2, "CHỖ NÀY");
                lblKQ.Text = "Tìm thấy tại vị trí: " + viTri + ". Sau khi thay thế: " + chuoiSauThayThe;
            }
            else
            {
                lblKQ.Text = "Không tìm thấy";
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string s1 = txtS1.Text;
            string s2 = txtS2.Text;
            int viTriKhoangTrangDau = s1.IndexOf(' ');
            int viTriKhoangTrangCuoi = s1.LastIndexOf(' ');

            if (viTriKhoangTrangDau < 0)
            {
                lblKQ.Text = "Chuỗi S1 không có khoảng trắng để chèn.";
                return;
            }

            string chenVaoViTriDau = s1.Insert(viTriKhoangTrangDau, " " + s2);
            string chenVaoViTriCuoi = s1.Insert(viTriKhoangTrangCuoi, " " + s2);

            lblKQ.Text = "Chèn trước từ thứ hai: " + chenVaoViTriDau + Environment.NewLine
                + "Chèn trước từ cuối: " + chenVaoViTriCuoi;
        }

        private void btnSubstring_Click(object sender, EventArgs e)
        {
            string tieuDe = lblTieuDe.Text;
            string chuoiCanXoa = "TRÌNH XỬ LÝ";
            int viTri = tieuDe.IndexOf(chuoiCanXoa, StringComparison.Ordinal);

            if (viTri >= 0)
            {
                lblTieuDe.Text = tieuDe.Remove(viTri, chuoiCanXoa.Length);
                lblKQ.Text = "Đã xóa chuỗi con 'TRÌNH XỬ LÝ' khỏi tiêu đề.";
            }
            else
            {
                lblKQ.Text = "Không tìm thấy chuỗi con 'TRÌNH XỬ LÝ' trong tiêu đề.";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtS1.Text = string.Empty;
            txtS2.Text = string.Empty;
            lblKQ.Text = string.Empty;
            txtS1.Focus();
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
