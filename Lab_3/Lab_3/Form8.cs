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
    public partial class Form8 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        private enum EditMode
        {
            None,
            Add,
            Edit
        }

        private EditMode _mode = EditMode.None;
        private DataTable _sanPhamTable = new DataTable();

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadSanPham();
            SetMode(EditMode.None);
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

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _sanPhamTable;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                PopulateInputsFromGrid();
            }
            else
            {
                ClearInputs();
            }
        }

        private void PopulateInputsFromGrid()
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            txtMaSP.Text = dataGridView1.CurrentRow.Cells["MaSP"].Value != null ? dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString() : string.Empty;
            txtTenSP.Text = dataGridView1.CurrentRow.Cells["TenSP"].Value != null ? dataGridView1.CurrentRow.Cells["TenSP"].Value.ToString() : string.Empty;
            txtDVTinh.Text = dataGridView1.CurrentRow.Cells["DVTinh"].Value != null ? dataGridView1.CurrentRow.Cells["DVTinh"].Value.ToString() : string.Empty;
            txtDonGia.Text = dataGridView1.CurrentRow.Cells["DonGia"].Value != null ? dataGridView1.CurrentRow.Cells["DonGia"].Value.ToString() : string.Empty;

            object maLoaiObj = dataGridView1.CurrentRow.Cells["MaLoai"].Value;
            if (maLoaiObj != null)
            {
                cboLoaiSP.SelectedValue = maLoaiObj.ToString();
            }
        }

        private void ClearInputs()
        {
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtDVTinh.Text = string.Empty;
            txtDonGia.Text = string.Empty;

            if (cboLoaiSP.Items.Count > 0)
            {
                cboLoaiSP.SelectedIndex = 0;
            }
        }

        private void SetMode(EditMode mode)
        {
            _mode = mode;
            bool editing = mode != EditMode.None;

            txtMaSP.ReadOnly = mode != EditMode.Add;
            txtTenSP.ReadOnly = !editing;
            txtDVTinh.ReadOnly = !editing;
            txtDonGia.ReadOnly = !editing;
            cboLoaiSP.Enabled = editing;

            btnLuu.Enabled = editing;
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing && dataGridView1.CurrentRow != null;
            btnXoa.Enabled = !editing && dataGridView1.CurrentRow != null;
            dataGridView1.Enabled = !editing;
        }

        private string GetLoaiHienThi(string maLoai, string tenLoaiGoc)
        {
            if (maLoai == "L001") return "Quần áo";
            if (maLoai == "L002") return "Văn phòng phẩm";
            if (maLoai == "L003") return "Sách CNTT";
            if (maLoai == "L004") return "Sách Kinh Tế";

            return tenLoaiGoc;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.Add);
            ClearInputs();
            txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            SetMode(EditMode.Edit);
            txtTenSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int donGia;
            if (!int.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string dvTinh = txtDVTinh.Text.Trim();
            string maLoai = cboLoaiSP.SelectedValue != null ? cboLoaiSP.SelectedValue.ToString() : string.Empty;

            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP) || string.IsNullOrWhiteSpace(maLoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    if (_mode == EditMode.Add)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO SanPham(MaSP, TenSP, DVTinh, DonGia, MaLoai) VALUES(@MaSP, @TenSP, @DVTinh, @DonGia, @MaLoai)", conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@TenSP", tenSP);
                            cmd.Parameters.AddWithValue("@DVTinh", dvTinh);
                            cmd.Parameters.AddWithValue("@DonGia", donGia);
                            cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (_mode == EditMode.Edit)
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE SanPham SET TenSP = @TenSP, DVTinh = @DVTinh, DonGia = @DonGia, MaLoai = @MaLoai WHERE MaSP = @MaSP", conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@TenSP", tenSP);
                            cmd.Parameters.AddWithValue("@DVTinh", dvTinh);
                            cmd.Parameters.AddWithValue("@DonGia", donGia);
                            cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                LoadSanPham();
                SelectRowByMaSP(maSP);
                SetMode(EditMode.None);
            }
            catch
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSP))
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM SanPham WHERE MaSP = @MaSP", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadSanPham();
                SetMode(EditMode.None);
            }
            catch
            {
            }
        }

        private void SelectRowByMaSP(string maSP)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSP)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    break;
                }
            }

            PopulateInputsFromGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode != EditMode.None)
            {
                return;
            }

            PopulateInputsFromGrid();
            btnSua.Enabled = dataGridView1.CurrentRow != null;
            btnXoa.Enabled = dataGridView1.CurrentRow != null;
        }
    }
}
