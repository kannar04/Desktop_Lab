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
    public partial class Form2 : Form
    {
        private const string ConnectionString = "Data Source=KANNAR;Initial Catalog=QLBH;Integrated Security=True;";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDanhMucSanPham();
        }

        private void LoadDanhMucSanPham()
        {
            comboBoxSP.Items.Clear();

            string[] queries =
            {
                "SELECT TenSP FROM SanPham"
            };

            foreach (string query in queries)
            {
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
                                comboBoxSP.Items.Add(reader[0].ToString());
                            }
                        }
                    }

                    if (comboBoxSP.Items.Count > 0)
                    {
                        comboBoxSP.SelectedIndex = 0;
                        return;
                    }
                }
                catch
                {
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
