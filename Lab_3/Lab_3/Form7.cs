using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form7 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        private DataTable _sanPhamTable = new DataTable();
        private int _currentIndex = -1;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadSanPham();
            ShowCurrentRecord();
        }

        private void LoadLoaiSanPham()
        {
            DataTable dtLoai = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY MaLoai", conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtLoai);
                }
            }
            catch
            {
            }

            dtLoai.Columns.Add("TenLoaiHienThi", typeof(string));
            foreach (DataRow row in dtLoai.Rows)
            {
                row["TenLoaiHienThi"] = GetLoaiHienThi(row["MaLoai"].ToString(), row["TenLoai"].ToString());
            }

            cboLoaiSP.DataSource = dtLoai;
            cboLoaiSP.DisplayMember = "TenLoaiHienThi";
            cboLoaiSP.ValueMember = "MaLoai";
        }

        private void LoadSanPham()
        {
            _sanPhamTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT MaSP, TenSP, DVTinh, DonGia, MaLoai FROM SanPham ORDER BY MaSP", conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(_sanPhamTable);
                }
            }
            catch
            {
            }

            _currentIndex = _sanPhamTable.Rows.Count > 0 ? 0 : -1;
        }

        private void ShowCurrentRecord()
        {
            if (_currentIndex < 0 || _currentIndex >= _sanPhamTable.Rows.Count)
            {
                txtMaSP.Text = string.Empty;
                txtTenSP.Text = string.Empty;
                txtDVTinh.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                if (cboLoaiSP.Items.Count > 0)
                {
                    cboLoaiSP.SelectedIndex = -1;
                }

                UpdateNavigationButtons();
                return;
            }

            DataRow row = _sanPhamTable.Rows[_currentIndex];
            txtMaSP.Text = row["MaSP"].ToString();
            txtTenSP.Text = row["TenSP"].ToString();
            txtDVTinh.Text = row["DVTinh"].ToString();
            txtDonGia.Text = row["DonGia"].ToString();

            string maLoai = row["MaLoai"].ToString();
            cboLoaiSP.SelectedValue = maLoai;

            UpdateNavigationButtons();
        }

        private void UpdateNavigationButtons()
        {
            bool hasData = _sanPhamTable.Rows.Count > 0;
            btnFirst.Enabled = hasData && _currentIndex > 0;
            btnPrev.Enabled = hasData && _currentIndex > 0;
            btnNext.Enabled = hasData && _currentIndex < _sanPhamTable.Rows.Count - 1;
            btnLast.Enabled = hasData && _currentIndex < _sanPhamTable.Rows.Count - 1;
        }

        private string GetLoaiHienThi(string maLoai, string tenLoaiGoc)
        {
            if (maLoai == "L001") return "Quần áo";
            if (maLoai == "L002") return "Văn phòng phẩm";
            if (maLoai == "L003") return "Sách CNTT";
            if (maLoai == "L004") return "Sách Kinh Tế";

            return tenLoaiGoc;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (_sanPhamTable.Rows.Count == 0)
            {
                return;
            }

            _currentIndex = 0;
            ShowCurrentRecord();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_sanPhamTable.Rows.Count == 0 || _currentIndex <= 0)
            {
                return;
            }

            _currentIndex--;
            ShowCurrentRecord();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_sanPhamTable.Rows.Count == 0 || _currentIndex >= _sanPhamTable.Rows.Count - 1)
            {
                return;
            }

            _currentIndex++;
            ShowCurrentRecord();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (_sanPhamTable.Rows.Count == 0)
            {
                return;
            }

            _currentIndex = _sanPhamTable.Rows.Count - 1;
            ShowCurrentRecord();
        }
    }
}
