using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project_ATBM
{
    public partial class GrantRoleForm : Form
    {
        public GrantRoleForm()
        {
            InitializeComponent();
        }
        private bool GranToRoleFunc(string userOrRole, string tableName, string privilege, string column)
        {
            // Implement the logic to grant the privilege here
            // Use the 'column' parameter if needed
            return true; // Placeholder for actual implementation
        }
        private void DoneGrantToRole_Click(object sender, EventArgs e)
        {
            string userOrRole = textBox1.Text;
            string tableName = textBox2.Text;
            string privilege = textBox3.Text;

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
                // Pass the selected column and the 'withGrantOption' parameter
                bool isGrantSuccessful = GranToRoleFunc(userOrRole, tableName, privilege, selectedColumn);

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



        private void CanCelGrantToRole_Click(object sender, EventArgs e)
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
