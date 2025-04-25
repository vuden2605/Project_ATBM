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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void load_data_users()
        {
            try
            {
                string query = "select distinct username,user_id,last_login, drp.granted_role, du.created " +
                               "from dba_users du " +
                               "left join dba_role_privs drp ON drp.grantee = du.username " +
                               "where du.created > TO_DATE('09-29-2021', 'MM-DD-YYYY') and username != 'ADMIN_QLDH' " +
                               "order by du.created desc";

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
                        load_data_users();

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
                        load_data_roles();

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
            CreateUserForm createUserForm = new CreateUserForm(this);
            createUserForm.ShowDialog();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            CreateRoleForm createRoleForm = new CreateRoleForm(this);
            createRoleForm.ShowDialog();
        }



        private void GrantRoleToUser_Click(object sender, EventArgs e)
        {
            string userName = dataGridView1.CurrentRow.Cells["USERNAME"].Value.ToString();
            GrantRoleToUserForm grantRoleToUserForm = new GrantRoleToUserForm(userName,this);
            grantRoleToUserForm.ShowDialog();
        }

       public void load_data_roles()
        {
            try
            {
                string query = "select * from dba_roles where role_id > 107 and role_id < 1279991 "
                    +"order by role_id desc";
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
                string query = "select distinct username,user_id,last_login, drp.granted_role " +
                               "from dba_users du " +
                               "left join dba_role_privs drp ON drp.grantee = du.username " +
                               "where du.created > TO_DATE('09-29-2021', 'MM-DD-YYYY') and username != 'ADMIN_QLDH' and  username LIKE : username " +
                               "order by du.created";
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

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void load_info_privilege_user()
        {
            try
            {
                string query = " SELECT * FROM DBA_TAB_PRIVS WHERE GRANTEE IN (SELECT USERNAME FROM DBA_USERS) AND OWNER = 'ADMIN_QLDH' ";
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
        private void load_info_privilege_col_user()
        {
            try
            {
                string query = " SELECT * FROM DBA_COL_PRIVS WHERE GRANTEE IN (SELECT USERNAME FROM DBA_USERS) AND OWNER = 'ADMIN_QLDH' ";
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
                string query = " SELECT * FROM ROLE_TAB_PRIVS WHERE OWNER = 'ADMIN_QLDH'";
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

            if (tabControl1.SelectedIndex == 1)
            {
                load_info_privilege_user();
            }



        }
        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            load_info_privilege_user();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            load_info_privilege_col_user();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            load_info_privilege_role();

        }

        private void load_role()
        {
            try
            {
                string ROLE = textBox2.Text.ToUpper();
                string query = "";

                query = $"SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE :ROLE AND OWNER = 'ADMIN_QLDH' ";

                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":ROLE", "%" + ROLE + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }


        private void btnSearchRole_Click(object sender, EventArgs e)
        {
            load_role();
        }
        private void load_user()
        {

            try
            {
                string GRANTEE = textBox1.Text.ToUpper();
                string query = "";
                if (radioButton1.Checked)
                {
                    query = $"SELECT * FROM DBA_TAB_PRIVS WHERE GRANTEE IN (SELECT USERNAME FROM DBA_USERS) AND GRANTEE LIKE :GRANTEE AND OWNER = 'ADMIN_QLDH'";
                }
                else { query = $"SELECT * FROM DBA_COL_PRIVS WHERE GRANTEE IN (SELECT USERNAME FROM DBA_USERS) AND GRANTEE LIKE :GRANTEE AND OWNER = 'ADMIN_QLDH' "; }
                ;
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":GRANTEE", "%" + GRANTEE + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView5.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            load_user();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow != null)
            {
                try
                {
                    // Lấy giá trị từ các cột "GRANTEE", "TABLE_NAME", và "PRIVILEGE"
                    string grantee = dataGridView5.CurrentRow.Cells["GRANTEE"].Value.ToString();
                    string tableName = dataGridView5.CurrentRow.Cells["TABLE_NAME"].Value.ToString();
                    string privilege = dataGridView5.CurrentRow.Cells["PRIVILEGE"].Value.ToString();

                    // Hiển thị thông báo xác nhận
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn thu hồi quyền '{privilege}' trên bảng '{tableName}' từ '{grantee}' không?",
                        "Xác nhận thu hồi quyền",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Gọi thủ tục RevokeFromUser
                        OracleCommand cmd = new OracleCommand("RevokeFromUser", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("n_pri", OracleDbType.Varchar2).Value = privilege;
                        cmd.Parameters.Add("n_obj", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("n_user", OracleDbType.Varchar2).Value = grantee;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // gọi lại tìm kiếm
            load_info_privilege_user();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow != null)
            {
                try
                {
                    // Lấy giá trị từ các cột "GRANTEE" và "TABLE_NAME"
                    string grantee = dataGridView5.CurrentRow.Cells["GRANTEE"].Value.ToString();
                    string tableName = dataGridView5.CurrentRow.Cells["TABLE_NAME"].Value.ToString();

                    // Hiển thị thông báo xác nhận
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn thu hồi tất cả quyền trên bảng '{tableName}' từ '{grantee}' không?",
                        "Xác nhận thu hồi tất cả quyền",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Gọi thủ tục RevokeAllFromUser
                        OracleCommand cmd = new OracleCommand("RevokeAllFromUser", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("n_obj", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("n_user", OracleDbType.Varchar2).Value = grantee;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thu hồi tất cả quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Gọi lại tìm kiếm để làm mới dữ liệu
            load_info_privilege_user();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView6.CurrentRow != null)
            {
                try
                {
                    // Lấy giá trị từ các cột "GRANTEE", "TABLE_NAME", và "PRIVILEGE"
                    string grantee = dataGridView6.CurrentRow.Cells["ROLE"].Value.ToString();
                    string tableName = dataGridView6.CurrentRow.Cells["TABLE_NAME"].Value.ToString();
                    string privilege = dataGridView6.CurrentRow.Cells["PRIVILEGE"].Value.ToString();

                    // Hiển thị thông báo xác nhận
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn thu hồi quyền '{privilege}' trên bảng '{tableName}' của  '{grantee}' không?",
                        "Xác nhận thu hồi quyền",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Gọi thủ tục RevokeFromUser
                        OracleCommand cmd = new OracleCommand("RevokeFromRole", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("n_pri", OracleDbType.Varchar2).Value = privilege;
                        cmd.Parameters.Add("n_obj", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("n_user", OracleDbType.Varchar2).Value = grantee;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //làm mới data
            load_info_privilege_role();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView6.CurrentRow != null)
            {
                try
                {
                    // Lấy giá trị từ các cột "GRANTEE" và "TABLE_NAME"
                    string grantee = dataGridView6.CurrentRow.Cells["ROLE"].Value.ToString();
                    string tableName = dataGridView6.CurrentRow.Cells["TABLE_NAME"].Value.ToString();

                    // Hiển thị thông báo xác nhận
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn thu hồi tất cả quyền trên bảng '{tableName}' từ '{grantee}' không?",
                        "Xác nhận thu hồi tất cả quyền",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Gọi thủ tục RevokeAllFromUser
                        OracleCommand cmd = new OracleCommand("RevokeAllFromRole", LoginForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("n_obj", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("n_user", OracleDbType.Varchar2).Value = grantee;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thu hồi tất cả quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            load_info_privilege_role();

        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            string userName = dataGridView1.CurrentRow.Cells["USERNAME"].Value.ToString();
            GrantUserForm grantUserForm = new GrantUserForm(userName);
            grantUserForm.ShowDialog();
        }

        private void btnCapQuyenRole_Click(object sender, EventArgs e)
        {
            string role = dataGridView2.CurrentRow.Cells["ROLE"].Value.ToString();
            GrantRoleForm grantRoleForm = new GrantRoleForm(role);
            grantRoleForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rolename = textBox4.Text.ToUpper();
                string query = "select * from dba_roles where role_id > 107 and role_id < 1279991 and role LIKE :rolename";
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
