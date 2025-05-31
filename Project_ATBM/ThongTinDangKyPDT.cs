using Oracle.ManagedDataAccess.Client;
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
    public partial class ThongTinDangKyPDT : Form
    {
        public ThongTinDangKyPDT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string masv = textBox1.Text;
                string mamm = textBox2.Text;
                OracleCommand cmd = new OracleCommand("admin_qldh.nvpdt_insert_dangky", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = masv;
                cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = mamm;
                int result = cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }
        }
            
    }
}
