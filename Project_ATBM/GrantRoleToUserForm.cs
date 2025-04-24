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
    public partial class GrantRoleToUserForm : Form
    {
        public GrantRoleToUserForm(string userName)
        {
            InitializeComponent();
            textBox1.Text = userName;

        }

        private void btnSuccessGrantR_U_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string roleName = textBox2.Text;

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Logic to grant the role to the user
                OracleCommand cmd = new OracleCommand("GrantRoleForUser", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("n_role",roleName);
                cmd.Parameters.Add("n_user",userName);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrantRoleToUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
