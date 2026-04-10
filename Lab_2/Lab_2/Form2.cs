using System;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;

            if (radLowerCase.Checked)
            {
                txtOutput.Text = input.ToLower();
            }
            else if (radUpperCase.Checked)
            {
                txtOutput.Text = input.ToUpper();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            txtInput.Focus();
        }
    }
}
