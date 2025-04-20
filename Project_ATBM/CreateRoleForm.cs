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
            //bool isCreate = CreateRole();
            //if (isCreated)
            //{
            MessageBox.Show("Tạo role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Tạo role thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CancelCreateRole_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
