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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            load_data_users();
        }
        private OracleConnection conNow;

        private void thuHồiQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        private void load_data_users()
        {
            try
            {
                string query = "SELECT username,user_id,password,created FROM dba_users";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
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
                // hàm delete chuyền vào user muốn xóa đã được chọn trong griddata
                //DeleteUser();
                MessageBox.Show("Đã xóa user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // hàm delete chuyền vào role muốn xóa đã được chọn trong griddata
                //DeleteRole();
                MessageBox.Show("Đã xóa role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void GrantUser_Click(object sender, EventArgs e)
        {
            GrantUserForm grantUserForm = new GrantUserForm();
            grantUserForm.ShowDialog();
        }

        private void GrantRoleToUser_Click(object sender, EventArgs e)
        {
            GrantRoleToUserForm grantRoleToUserForm = new GrantRoleToUserForm();
            grantRoleToUserForm.ShowDialog();
        }

        private void RevokeUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thu hồi quyền của user này không?",
                "Xác nhận thu hồi quyền",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isRevokeSuccessful = RevokeUserPrivileges();

                    if (isRevokeSuccessful)
                    {
                        MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thu hồi quyền thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool RevokeUserPrivileges()
        {

            return true;
        }

        private void btnGrantToRole_Click(object sender, EventArgs e)
        {
            GrantRoleForm grantRoleForm = new GrantRoleForm();
            grantRoleForm.ShowDialog();
        }

        private void btnRevokeToRole_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thu hồi quyền của role này không?",
                "Xác nhận thu hồi quyền",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Example: Call a method to handle the revocation logic
                    bool isRevokeSuccessful = RevokeRolePrivileges();

                    if (isRevokeSuccessful)
                    {
                        MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thu hồi quyền thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Example method to handle role privilege revocation logic
        private bool RevokeRolePrivileges()
        {
            // Implement the logic to revoke role privileges here
            // This could involve database operations or other logic
            return true; // Placeholder for actual implementation
        }
        private void load_data_roles()
        {
            try
            {
                string query = "SELECT * FROM dba_roles";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data_roles();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFilterUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox3.Text.ToUpper();
                string query = $"SELECT * FROM dba_users WHERE username LIKE :username";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":username", "%" + username + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void btnFilterRole_Click(object sender, EventArgs e)
        {
            try
            {
                string rolename = textBox4.Text.ToUpper();
                string query = "SELECT * FROM dba_roles WHERE role LIKE :rolename";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":rolename", "%" + rolename + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}
