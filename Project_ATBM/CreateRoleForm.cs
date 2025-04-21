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
    public partial class CreateRoleForm : Form
    {
        public CreateRoleForm()
        {
            InitializeComponent();
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
                // Example: Call a method to create the role
                bool isCreated = CreateRole(roleName);

                if (isCreated)
                {
                    MessageBox.Show("Tạo role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo role thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CreateRole(string roleName)
        {

            return true;
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
