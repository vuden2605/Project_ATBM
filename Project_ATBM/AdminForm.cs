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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                if (dataGridView1.CurrentRow != null)
                {
                    try
                    {
                        // Lấy giá trị từ cột "username" trong dòng đang được chọn
                        string userName = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
                        OracleCommand cmd = new OracleCommand("DeleteUser", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_username", OracleDbType.NVarchar2).Value = userName;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                if (dataGridView1.CurrentRow != null)
                {
                    try
                    {
                        // Lấy giá trị từ cột "username" trong dòng đang được chọn
                        string roleName = dataGridView2.CurrentRow.Cells["role"].Value.ToString();
                        OracleCommand cmd = new OracleCommand("DeleteRole", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_rolename", OracleDbType.NVarchar2).Value = roleName;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            string roleName = dataGridView2.CurrentRow.Cells["role"].Value.ToString();
            UpdateRoleForm updateRoleForm = new UpdateRoleForm(roleName);
            updateRoleForm.ShowDialog();

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string userName = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
            UpdateUserForm updateUserForm = new UpdateUserForm(userName);
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
            if (tabControl2.SelectedIndex == 0)
            {
                load_data_users();
            }
            if (tabControl2.SelectedIndex == 1)
            {
                load_data_roles();
            }
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

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void load_info_privilege_user()
        {
            try
            {
                string query = " SELECT grantee, owner, table_name, grantor, privilege FROM DBA_TAB_PRIVS WHERE GRANTEE IN(SELECT USERNAME FROM DBA_USERS) ORDER BY GRANTEE ";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void load_info_privilege_role()
        {
            try
            {
                string query = " SELECT grantee, owner, table_name, grantor, privilege FROM DBA_TAB_PRIVS WHERE GRANTEE IN(SELECT ROLE FROM DBA_ROLES) ORDER BY GRANTEE ";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl4.SelectedIndex == 0)
            {
                load_info_privilege_user();
            }
            else if (tabControl4.SelectedIndex == 1)
            {
                load_info_privilege_role();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                load_data_users();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                load_info_privilege_user();
            }
           
                
           

        }
    }
}
