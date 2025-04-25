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
    public partial class CreateRoleForm : Form
    {
        private AdminForm adminForm;

        public CreateRoleForm(AdminForm adminForm)
        {
            InitializeComponent();
            this.adminForm = adminForm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roleName = textBox1.Text;

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Vui lòng nhập tên Role!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OracleCommand cmd = new OracleCommand("CreateRole",LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_rolename", OracleDbType.NVarchar2).Value = roleName;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adminForm.load_data_roles();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CancelCreateRole_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateRoleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
