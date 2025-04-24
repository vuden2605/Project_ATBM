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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_ATBM
{
    public partial class GrantUserForm : Form
    {
        public GrantUserForm(string userName)
        {
            InitializeComponent();
            textBox1.Text = userName;
            textBox1.ReadOnly = true;
            clbDanhSachCot.Visible = false;
            clbQuyenTruyCap.Visible = false;

        }





        

        private void btnCancelGrant_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Load Danh sách đối tượng dữ liệu
        private void LoadComboBoxData()
        {
            try
            {
                // Kiểm tra và mở kết nối nếu cần
                if (LoginForm.conn.State != ConnectionState.Open)
                {
                    LoginForm.conn.Open();
                }

                // Kiểm tra xem cmbLoaiDoiTuong.Text có hợp lệ không
                if (string.IsNullOrWhiteSpace(cmbLoaiDoiTuong.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại đối tượng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = string.Empty;

                // Tùy vào loại đối tượng, xây dựng câu truy vấn SQL
                switch (cmbLoaiDoiTuong.Text)
                {
                    case "TABLE":
                        query = "SELECT table_name FROM all_tables WHERE owner = 'ADMIN_QLDH'";
                        break;
                    case "VIEW":
                        query = "SELECT view_name FROM all_views WHERE owner = 'ADMIN_QLDH'";
                        break;
                    case "PROCEDURE":
                        query = "SELECT object_name FROM all_objects WHERE object_type = 'PROCEDURE' AND owner = 'ADMIN_QLDH'";
                        break;
                    case "FUNCTION":
                        query = "SELECT object_name FROM all_objects WHERE object_type = 'FUNCTION' AND owner = 'ADMIN_QLDH'";
                        break;
                    default:
                        MessageBox.Show("Loại đối tượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Thực thi câu truy vấn
                using (OracleCommand cmd = new OracleCommand(query, LoginForm.conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    // Xóa các mục cũ trong ComboBox trước khi thêm dữ liệu mới
                    cmbTenDoiTuong.Items.Clear();

                    // Lặp qua các kết quả trả về và thêm vào ComboBox
                    while (reader.Read())
                    {
                        // Thêm tên đối tượng vào ComboBox
                        cmbTenDoiTuong.Items.Add(reader.GetString(0));  // Lấy tên đối tượng từ cột đầu tiên
                    }

                    // Nếu có dữ liệu, chọn item đầu tiên (tuỳ chọn)
                    if (cmbTenDoiTuong.Items.Count > 0)
                    {
                        cmbTenDoiTuong.SelectedIndex = 0;  // Chọn item đầu tiên trong ComboBox
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Khi chọn loại đối tượng, gọi hàm LoadComboBoxData để tải danh sách đối tượng tương ứng
        private void cmbLoaiDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDoiTuong.Text == "PROCEDURE" || cmbLoaiDoiTuong.Text == "FUNCTION")
            {
                clbQuyenTruyCap.Items.Clear();
                clbQuyenTruyCap.Visible = false;
            }
            else if (cmbLoaiDoiTuong.Text == "TABLE" || cmbLoaiDoiTuong.Text == "VIEW")
            {
                // Bạn có thể thêm các quyền mặc định nếu là TABLE hoặc VIEW
                clbQuyenTruyCap.Items.Clear();
                clbQuyenTruyCap.Items.Add("SELECT");
                clbQuyenTruyCap.Items.Add("INSERT");
                clbQuyenTruyCap.Items.Add("UPDATE");
                clbQuyenTruyCap.Items.Add("DELETE");
                clbQuyenTruyCap.Visible = true;

            }

            LoadComboBoxData();
        }


        // Phương thức để lấy thông tin về các cột của đối tượng đã chọn
        private void FetchColumnData()
        {
            try
            {
                // Kiểm tra xem có đối tượng nào được chọn không
                if (string.IsNullOrWhiteSpace(cmbTenDoiTuong.Text))
                {
                    MessageBox.Show("Vui lòng chọn đối tượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và mở kết nối nếu cần
                if (LoginForm.conn.State != ConnectionState.Open)
                {
                    LoginForm.conn.Open();
                }

                string objectName = cmbTenDoiTuong.Text;
                string query = string.Empty;

                // Tùy vào loại đối tượng, xây dựng câu truy vấn SQL
                switch (cmbLoaiDoiTuong.Text)
                {
                    case "TABLE":
                        query = "SELECT column_name FROM all_tab_columns WHERE owner = 'ADMIN_QLDH' AND table_name = :objectName ORDER BY column_id";
                        break;
                    case "VIEW":
                        query = "SELECT column_name FROM all_tab_columns WHERE owner = 'ADMIN_QLDH' AND table_name = :objectName ORDER BY column_id";
                        break;
                    default:
                        return;
                }

                using (OracleCommand cmd = new OracleCommand(query, LoginForm.conn))
                {
                    // Thêm parameter để tránh SQL Injection
                    cmd.Parameters.Add(new OracleParameter("objectName", objectName));

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Xóa tất cả các mục trong CheckedListBox trước khi thêm mới
                        clbDanhSachCot.Items.Clear();

                        // Thêm các tên cột vào CheckedListBox
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) // Kiểm tra xem cột có giá trị null không
                            {
                                string columnName = reader.GetString(0);
                                clbDanhSachCot.Items.Add(columnName);
                            }
                        }

                        // Thông báo nếu không có cột nào
                        if (clbDanhSachCot.Items.Count == 0)
                        {
                            MessageBox.Show($"Không tìm thấy thông tin cột cho {objectName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lấy thông tin cột: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clbQuyenTruyCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbQuyenTruyCap.SelectedIndex == 2)
            {
                // Nếu có quyền được chọn, gọi hàm FetchColumnData để lấy thông tin cột
                FetchColumnData();
                clbDanhSachCot.Visible = true;
            }
            else
            {
                // Nếu không có quyền nào được chọn, xóa danh sách cột
                clbDanhSachCot.Items.Clear();
                clbDanhSachCot.Visible = false;
            }
        }

        private void btnSucessGrant_Click(object sender, EventArgs e)
        {
            // Kiểm tra các điều kiện cần thiết
            if (string.IsNullOrWhiteSpace(cmbTenDoiTuong.Text))
            {
                MessageBox.Show("Vui lòng chọn đối tượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem có quyền nào được chọn không
            bool hasSelectedPrivilege = false;
            foreach (int index in clbQuyenTruyCap.CheckedIndices)
            {
                hasSelectedPrivilege = true;
                string privilege = clbQuyenTruyCap.Items[index].ToString();

                // Nếu là quyền UPDATE và có hiển thị danh sách cột
                if (privilege == "UPDATE" && clbDanhSachCot.Visible)
                {
                    // Kiểm tra xem có cột nào được chọn không
                    bool hasSelectedColumn = false;
                    bool withGrantOption = checkBox1.Checked; // Giả sử checkBox1 là WITH GRANT OPTION
                    foreach (int colIndex in clbDanhSachCot.CheckedIndices)
                    {
                        hasSelectedColumn = true;
                        string columnName = clbDanhSachCot.Items[colIndex].ToString();
                        

                        // Gọi hàm cấp quyền
                        bool success = GrantPrivilege(textBox1.Text, cmbTenDoiTuong.Text, privilege, withGrantOption, columnName);
                        if (!success)
                        {
                            MessageBox.Show($"Không thể cấp quyền {privilege} trên cột {columnName}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!hasSelectedColumn)
                    {
                        bool success = GrantPrivilege(textBox1.Text, cmbTenDoiTuong.Text, privilege, withGrantOption,null);
                        if (!success)
                        {
                            MessageBox.Show($"Không thể cấp quyền {privilege} trên bảng {cmbTenDoiTuong.Text} .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }
                }
                else // Các quyền khác không liên quan đến cột
                {
                    bool withGrantOption = checkBox1.Checked;
                    bool success = GrantPrivilege(textBox1.Text, cmbTenDoiTuong.Text, privilege, withGrantOption, null);
                    if (!success)
                    {
                        MessageBox.Show($"Không thể cấp quyền {privilege}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (!hasSelectedPrivilege && clbQuyenTruyCap.Visible==false)
            {
                string privilege = "EXECUTE";
                bool withGrantOption = checkBox1.Checked;
                bool success = GrantPrivilege(textBox1.Text, cmbTenDoiTuong.Text, privilege, withGrantOption, null);
                if (!success)
                {
                    MessageBox.Show($"Không thể cấp quyền {privilege}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else if(!hasSelectedPrivilege && clbQuyenTruyCap.Visible == true)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một quyền để cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                MessageBox.Show("Cấp quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Triển khai phương thức GrantPrivilege để gọi thủ tục PL/SQL GrantForUser
        private bool GrantPrivilege(string userName, string objectName, string privilege, bool withGrantOption, string column)
        {
            try
            {
                // Kiểm tra và mở kết nối nếu cần
                if (LoginForm.conn.State != ConnectionState.Open)
                {
                    LoginForm.conn.Open();
                }

                // Tạo command để gọi thủ tục PL/SQL
                using (OracleCommand cmd = new OracleCommand("GrantForUser", LoginForm.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("n_pri", OracleDbType.Varchar2).Value = privilege;
                    cmd.Parameters.Add("n_obj", OracleDbType.Varchar2).Value = objectName;
                    cmd.Parameters.Add("n_user", OracleDbType.Varchar2).Value = userName;

                    // Nếu column là null, truyền DBNull.Value
                    if (string.IsNullOrEmpty(column))
                        cmd.Parameters.Add("n_column", OracleDbType.Varchar2).Value ="";
                    else
                        cmd.Parameters.Add("n_column", OracleDbType.Varchar2).Value = column;

                    cmd.Parameters.Add("n_flag", OracleDbType.Char).Value = withGrantOption ? "T" : "F";

                    // Thực thi thủ tục
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấp quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

