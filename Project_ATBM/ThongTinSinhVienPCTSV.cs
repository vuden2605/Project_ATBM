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
    public partial class ThongTinSinhVien : Form
    {
        public ThongTinSinhVien(string masv, string hoten, string phai, string ngsinh, string dchi, string dt, string khoa, string tinhtrang)
        {
            InitializeComponent();
            textBox1.Text = masv;
            textBox5.Text = hoten;
            
            textBox4.Text = dchi;
            textBox6.Text = dt;
            textBox8.Text = ngsinh;  
        }
    }
}
