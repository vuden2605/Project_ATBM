using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ATBM
{
    public partial class ThongTinSinhVienPDT : Form
    {
        public ThongTinSinhVienPDT(string masv, string hoten, string phai, string ngsinh, string dchi, string dt, string khoa, string tinhtrang)
        {
            InitializeComponent();
            textBox1.Text = masv;
            textBox5.Text = hoten;
            comboBox2.Text = phai;
            comboBox3.Text = khoa;
            comboBox1.Text = tinhtrang;
            textBox4.Text = dchi;
            textBox6.Text = dt;
            textBox8.Text = ngsinh;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
