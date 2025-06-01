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
    public partial class ThongTinMoMon : Form
    {
        public ThongTinMoMon()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("admin_qldh.nvpdt_insert_momon", LoginForm.conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_mamm", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                    cmd.Parameters.Add("p_mahp", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox3.Text.Trim();
                    cmd.Parameters.Add("p_magv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox2.Text.Trim();
                    cmd.Parameters.Add("p_nam", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox8.Text.Trim();

                    // Xử lý ngày bắt đầu
                    if (!DateTime.TryParseExact(textBox4.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaybd))
                    {
                        MessageBox.Show("Ngày bắt đầu không hợp lệ. Định dạng đúng: dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.Parameters.Add("p_ngaybd", Oracle.ManagedDataAccess.Client.OracleDbType.Date).Value = ngaybd;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm mở môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
