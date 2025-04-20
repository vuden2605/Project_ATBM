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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoleForm roleForm = new RoleForm();
            roleForm.ShowDialog();
        }

        private void thuHồiQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cấpQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GrantPrivilegeForm grantPrivilegeForm = new GrantPrivilegeForm();
            grantPrivilegeForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {

        }



        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa user này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                //DeleteUser();
                MessageBox.Show("Đã xóa user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // có thể bỏ thông báo vào hàm delete
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa role này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                //DeleteRole();
                MessageBox.Show("Đã xóa role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // có thể bỏ thông báo vào hàm delete
            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            UpdateRoleForm updateRoleForm = new UpdateRoleForm();
            updateRoleForm.ShowDialog();

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm();
            updateUserForm.ShowDialog();
        }



        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            CreateRoleForm createRoleForm = new CreateRoleForm();
            createRoleForm.ShowDialog();
        }
    }
}
