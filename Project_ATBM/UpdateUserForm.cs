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
            string userName = textBox1.Text;//////////User đc chọn từ grid data không cần nhập
            string password = textBox3.Text;
            string confirmPassword = textBox2.Text;


            if (!string.IsNullOrWhiteSpace(password) && password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Example: Call a method to update the user
                bool isUpdated = UpdateUser(userName, password);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật user thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Example method to handle user update logic
        private bool UpdateUser(string userName, string password)
        {
            // Implement the logic to update the user here
            // This could involve database operations or other logic
            return true; // Placeholder for actual implementation
        }



        private void CanCelUpdateUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
