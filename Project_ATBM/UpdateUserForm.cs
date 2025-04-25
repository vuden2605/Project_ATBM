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
    public partial class UpdateUserForm : Form
    {
        public UpdateUserForm(string userName)
        {
            InitializeComponent();
            textBox1.Text = userName;
            textBox1.ReadOnly = true;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DoneUpdateUser_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox2.Text;


            if (!string.IsNullOrWhiteSpace(password) && password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                OracleCommand cmd = new OracleCommand("UpdateUser", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_username", OracleDbType.NVarchar2).Value = userName;
                cmd.Parameters.Add("p_new_password", password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CanCelUpdateUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
