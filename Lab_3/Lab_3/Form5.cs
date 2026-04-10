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
    public partial class Form5 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        public Form5()
        {
            InitializeComponent();
            this.Load += Form5_Load;
            btnFilter.Click += btnFilter_Click;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadSanPhamByLoai(null);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string maLoai = cBoxFilter.SelectedValue != null ? cBoxFilter.SelectedValue.ToString() : null;

            if (string.IsNullOrWhiteSpace(maLoai))
            {
                LoadSanPhamByLoai(null);
                return;
            }

            LoadSanPhamByLoai(maLoai);
        }

        private void LoadLoaiSanPham()
        {
            DataTable dt = new DataTable();

            const string query = @"SELECT '' AS MaLoai, N'Tất cả' AS TenLoai
                                   UNION ALL
                                   SELECT MaLoai, TenLoai FROM LoaiSanPham";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                cBoxFilter.DataSource = dt;
                cBoxFilter.DisplayMember = "TenLoai";
                cBoxFilter.ValueMember = "MaLoai";
                cBoxFilter.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void LoadSanPhamByLoai(string maLoai)
        {
            dataGridView1.Rows.Clear();

            const string query = @"SELECT MaSP, TenSP, DVTinh, DonGia, MaLoai
                                   FROM SanPham
                                   WHERE (@MaLoai = '' OR MaLoai = @MaLoai)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai ?? string.Empty);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString());
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
