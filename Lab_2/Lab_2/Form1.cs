using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rbUocChungLonNhat.Checked = true;

        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoA.Text, out int a) || !int.TryParse(txtSoB.Text, out int b))
            {
                MessageBox.Show("Vui lòng nhập 2 số nguyên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (a == 0 && b == 0)
            {
                MessageBox.Show("Ít nhất một số phải khác 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            lstKetQua.Items.Clear();

            if (rbUocChungLonNhat.Checked)
            {
                lstKetQua.Items.Add($"USCLN({a}, {b}) = {TinhUscln(a, b)}");
                return;
            }

            foreach (int uoc in LayTatCaUocChung(a, b))
            {
                lstKetQua.Items.Add(uoc);
            }
        }

        private static int TinhUscln(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }

        private static IEnumerable<int> LayTatCaUocChung(int a, int b)
        {
            int uscln = TinhUscln(a, b);
            List<int> ketQua = new List<int>();

            for (int i = 1; i <= uscln; i++)
            {
                if (uscln % i == 0)
                {
                    ketQua.Add(i);
                }
            }

            return ketQua;
        }
    }
}
