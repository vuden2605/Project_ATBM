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
        public GrantRoleToUserForm()
        {
            InitializeComponent();
        }

        private void btnSuccessGrantR_U_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string roleName = textBox2.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin User và Role!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Logic to grant the role to the user
                GrantRoleToUser(userName, roleName);
                MessageBox.Show("Cấp role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GrantRoleToUser(string userName, string roleName)
        {
            // Implement the logic to grant the role to the user here
            // This could involve database operations or other logic
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
