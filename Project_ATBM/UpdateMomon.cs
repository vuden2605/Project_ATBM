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
    public partial class UpdateMomon : Form
    {
        private string _mamm;

        public UpdateMomon(string mamm)
        {
            InitializeComponent();
            _mamm = mamm;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public event EventHandler SVUpdate;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("admin_qldh.SUA_MAGV_MOMON", LoginForm.conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_mamm", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = _mamm;
                    cmd.Parameters.Add("p_magv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox10.Text.Trim();

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật giảng viên cho mở môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SVUpdate?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
