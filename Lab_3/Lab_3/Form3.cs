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
    public partial class Form3 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadDanhMucSanPham();
        }

        private void LoadDanhMucSanPham()
        {
            dataGridView1.Rows.Clear();

            const string query = "SELECT MaSP, TenSP, DVTinh, DonGia, MaLoai FROM SanPham";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
