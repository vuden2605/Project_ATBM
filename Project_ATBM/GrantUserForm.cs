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
        public GrantUserForm()
        {
            InitializeComponent();
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


    }
}
