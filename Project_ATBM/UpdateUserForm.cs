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
    public partial class UpdateUserForm : Form
    {
        public UpdateUserForm()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DoneUpdateUser_Click(object sender, EventArgs e)
        {
            //bool isUpdated = UpdateUser();
            //if (isUpdated)
            //{
            MessageBox.Show("Cập nhật user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật user thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CanCelUpdateUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
