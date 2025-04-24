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
    public partial class GrantUserForm : Form
    {
        public GrantUserForm(string userName)
        {
            InitializeComponent();
            textBox1.Text = userName;
            textBox1.ReadOnly = true;
            LoadAllTableNames();
            lsbTable1.Visible = false;
        }
        private void btnSucessGrant_Click_2(object sender, EventArgs e)
        {
            string userOrRole = textBox1.Text;
            string tableName = textBox2.Text;
            string privilege = textBox3.Text;
            bool withGrantOption = checkBox1.Checked;

            // Get the selected column from the dropdown (if it exists and is visible)
            string selectedColumn = columnDropdown != null && columnDropdown.Visible ? columnDropdown.SelectedItem?.ToString() : null;

            if (string.IsNullOrWhiteSpace(userOrRole) || string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(privilege))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkBox2.Checked && string.IsNullOrWhiteSpace(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột cần cấp quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Pass the selected column as an additional parameter
                bool isGrantSuccessful = GrantPrivilege(userOrRole, tableName, privilege, withGrantOption, selectedColumn);

                if (isGrantSuccessful)
                {
                    MessageBox.Show("Cấp quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cấp quyền thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Updated GrantPrivilege method to include the column parameter
        private bool GrantPrivilege(string userOrRole, string tableName, string privilege, bool withGrantOption, string column)
        {
            // Implement the logic to grant the privilege here
            // Use the 'column' parameter if needed
            return true; // Placeholder for actual implementation
        }

        private void btnCancelGrant_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private ComboBox columnDropdown; // Declare at the class level to reuse the dropdown

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // Create the dropdown if it doesn't already exist
                if (columnDropdown == null)
                {
                    columnDropdown = new ComboBox
                    {
                        Location = new Point(338, 370), // Adjust position to fit within the form
                        Size = new Size(351, 40),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    // Add sample column names (replace with actual column names from your data source)
                    columnDropdown.Items.AddRange(new string[] { "Column1", "Column2", "Column3" });

                    // Add the dropdown to the form
                    panel1.Controls.Add(columnDropdown);
                    columnDropdown.BringToFront();

                    // Handle selection change
                    columnDropdown.SelectedIndexChanged += (s, args) =>
                    {
                        MessageBox.Show($"Selected Column: {columnDropdown.SelectedItem}");
                    };
                }
            }
            else
            {
                // Remove the dropdown if it exists
                if (columnDropdown != null)
                {
                    panel1.Controls.Remove(columnDropdown);
                    columnDropdown.Dispose();
                    columnDropdown = null;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        List<string> tableNames = new List<string>();


        private void LoadAllTableNames()
        {
            try
            {
                // Kiểm tra và mở kết nối nếu cần
                if (LoginForm.conn.State != ConnectionState.Open)
                {
                    LoginForm.conn.Open();
                }

                // Truy vấn có thể được sửa để lọc các bảng của người dùng hiện tại thay vì tất cả các bảng
                string query = "SELECT table_name FROM all_tables ORDER BY table_name";

                using (OracleCommand cmd = new OracleCommand(query, LoginForm.conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    tableNames.Clear();
                    while (reader.Read())
                    {
                        tableNames.Add(reader.GetString(0));
                    }
                }

                if (tableNames.Count > 0)
                {
                    lsbTable1.DataSource = new List<string>(tableNames); // Tạo một bản sao để tránh lỗi binding
                    lsbTable1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Không có bảng nào được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        // Add this method to handle the SelectedIndexChanged event for lsbTable1



        private void lsbTable1_Click(object sender, EventArgs e)
        {
            if (lsbTable1.SelectedItem != null)
            {
                textBox2.Text = lsbTable1.SelectedItem.ToString();
                // Không ẩn danh sách ngay lập tức để người dùng có thể thấy đã chọn mục nào

                // Đặt focus vào control tiếp theo trong form
                SelectNextControl(textBox2, true, true, true, true);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string input = textBox2.Text.Trim().ToUpper();

            // Chỉ lọc kết quả khi textBox2 đang nhận focus
            if (textBox2.Focused)
            {
                if (string.IsNullOrEmpty(input))
                {
                    lsbTable1.DataSource = new List<string>(tableNames);
                    lsbTable1.Visible = true;
                }
                else
                {
                    var filtered = tableNames.Where(t => t.Contains(input)).ToList();
                    if (filtered.Count > 0)
                    {
                        lsbTable1.DataSource = filtered;
                        lsbTable1.Visible = true;
                    }
                    else
                    {
                        lsbTable1.Visible = false;
                    }
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (lsbTable1.Visible && lsbTable1.Items.Count > 0)
                {
                    // Chọn mục đầu tiên nếu danh sách đang hiển thị
                    lsbTable1.SelectedIndex = 0;
                    textBox2.Text = lsbTable1.SelectedItem.ToString();
                }
                lsbTable1.Visible = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200; // 200ms
            timer.Tick += (s, args) => {
                // Kiểm tra nếu focus không phải là lsbTable1 thì ẩn đi
                if (!lsbTable1.Focused)
                {
                    lsbTable1.Visible = false;
                }
                ((System.Windows.Forms.Timer)s).Stop();
                ((System.Windows.Forms.Timer)s).Dispose();
            };
            timer.Start();
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            // Hiển thị danh sách khi focus vào textBox2
            if (tableNames.Count > 0)
            {
                // Hiển thị tất cả nếu chưa có văn bản nhập, hoặc hiển thị kết quả lọc nếu đã có
                if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    lsbTable1.DataSource = new List<string>(tableNames);
                }
                else
                {
                    string input = textBox2.Text.Trim().ToUpper();
                    var filtered = tableNames.Where(t => t.Contains(input)).ToList();
                    if (filtered.Count > 0)
                    {
                        lsbTable1.DataSource = filtered;
                    }
                    else
                    {
                        return; // Không hiển thị nếu không có kết quả lọc
                    }
                }

                lsbTable1.Visible = true;

                // Đặt vị trí của lsbTable1 ngay dưới textBox2
                lsbTable1.Location = new Point(
                    textBox2.Location.X,
                    textBox2.Location.Y + textBox2.Height
                );
            }
        }
    }
}

