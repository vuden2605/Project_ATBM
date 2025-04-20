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
    public partial class UpdateRoleForm : Form
    {
        public UpdateRoleForm()
        {
            InitializeComponent();
        }

        private void DoneUpdateRole_Click(object sender, EventArgs e)
        {
            //bool isUpdated = UpdateRole();
            //if (isUpdated)
            //{
            MessageBox.Show("Cập nhật role thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật role thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CanCelUpdateRole_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
