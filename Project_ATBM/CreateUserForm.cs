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
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void DoneCreateUser_Click(object sender, EventArgs e)
        {
            //bool isCreate = CreateUser();
            //if (isCreated)
            //{
            MessageBox.Show("Tạo user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Tạo user thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CanCelCreateUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
