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
    public partial class Form6 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
        }

        private void LoadLoaiSanPham()
        {
            var tenHienThi = new Dictionary<string, string>
            {
                { "L001", "Quần áo" },
                { "L002", "Văn phòng phẩm" },
                { "L003", "Sách CNTT" },
                { "L004", "Sách Kinh Tế" }
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT MaLoai, TenLoai FROM LoaiSanPham", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maLoai = reader[0].ToString();
                            string tenLoaiDb = reader[1].ToString();
                            string textNode = tenHienThi.ContainsKey(maLoai) ? tenHienThi[maLoai] : tenLoaiDb;

                            TreeNode node = new TreeNode(textNode);
                            node.Tag = maLoai;
                            treeView1.Nodes.Add(node);
                        }
                    }
                }

                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }
            }
            catch
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
            {
                return;
            }

            LoadSanPhamTheoLoai(e.Node.Tag.ToString());
        }

        private void LoadSanPhamTheoLoai(string maLoai)
        {
            dataGridView1.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT MaSP, TenSP, DVTinh, DonGia FROM SanPham WHERE MaLoai = @MaLoai", conn))
                {
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString());
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
