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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_ATBM
{
    public partial class UpdateRoleForm : Form
    {
        public UpdateRoleForm(string roleName)
        {
            InitializeComponent();
            textBox1.Text = roleName;
            textBox1.ReadOnly = true;
        }

        private void DoneUpdateRole_Click(object sender, EventArgs e)
        {
            string roleName = textBox1.Text;////role được chọn từ grid data không cần nhập
            string password = textBox3.Text;
            string confirmPassword = textBox2.Text;

            // Validate input fields


            if (!string.IsNullOrWhiteSpace(password) && password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Example: Call a method to update the role
                OracleCommand cmd = new OracleCommand("UpdateRole", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_rolename", OracleDbType.NVarchar2).Value = roleName;
                cmd.Parameters.Add("p_password", password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Example method to handle role update logic
       

        private void CanCelUpdateRole_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
