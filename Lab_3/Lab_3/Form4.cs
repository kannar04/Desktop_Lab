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
    public partial class Form4 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        public Form4()
        {
            InitializeComponent();
            this.Load += Form4_Load;
            btnFInd.Click += btnFInd_Click;
            txtInput.KeyDown += txtInput_KeyDown;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TimKiemSanPham(string.Empty);
        }

        private void btnFInd_Click(object sender, EventArgs e)
        {
            TimKiemSanPham(txtInput.Text.Trim());
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TimKiemSanPham(txtInput.Text.Trim());
            }
        }

        private void TimKiemSanPham(string tenSanPham)
        {
            dataGridView1.Rows.Clear();

            const string query = @"SELECT MaSP, TenSP, DVTinh, DonGia, MaLoai
                                   FROM SanPham
                                   WHERE (@TenSP = N'' OR TenSP LIKE N'%' + @TenSP + N'%')";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", tenSanPham);
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
