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
        private AdminForm adminForm;
        public GrantRoleToUserForm(string userName, AdminForm adminForm)
        {
            InitializeComponent();
            textBox1.Text = userName;
            LoadComboBoxData();
            this.adminForm = adminForm;
        }
        private void LoadComboBoxData()
        {
            try
            {
                // Kiểm tra và mở kết nối nếu cần
                if (LoginForm.conn.State != ConnectionState.Open)
                {
                    LoginForm.conn.Open();
                }


                string query = string.Empty;

                query = "select * from dba_roles where role_id > 107 and role_id < 1279991";

                // Thực thi câu truy vấn
                using (OracleCommand cmd = new OracleCommand(query, LoginForm.conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    // Xóa các mục cũ trong ComboBox trước khi thêm dữ liệu mới
                    cmbRoles.Items.Clear();

                    // Lặp qua các kết quả trả về và thêm vào ComboBox
                    while (reader.Read())
                    {
                        // Thêm tên đối tượng vào ComboBox
                        cmbRoles.Items.Add(reader.GetString(0));  // Lấy tên đối tượng từ cột đầu tiên
                    }

                    // Nếu có dữ liệu, chọn item đầu tiên (tuỳ chọn)
                    if (cmbRoles.Items.Count > 0)
                    {
                        cmbRoles.SelectedIndex = 0;  // Chọn item đầu tiên trong ComboBox
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSuccessGrantR_U_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string roleName = cmbRoles.Text;

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
                cmd.Parameters.Add("n_role", roleName);
                cmd.Parameters.Add("n_user", userName);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adminForm.load_data_users();
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

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
