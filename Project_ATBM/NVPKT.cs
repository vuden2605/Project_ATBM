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
    public partial class NVPKT : Form
    {
        public NVPKT()
        {
            InitializeComponent();
            LoadTTNV();
        }
        public void LoadTTNV()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.v_nvcb";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["MANLD"].ToString();
                    textBox2.Text = reader["HOTEN"].ToString();
                    textBox3.Text = reader["PHAI"].ToString();
                    DateTime ngsinh = (DateTime)reader["Ngsinh"];
                    textBox4.Text = ngsinh.ToString("dd/MM/yyyy");
                    textBox5.Text = reader["Luong"].ToString();
                    textBox6.Text = reader["Phucap"].ToString();
                    textBox7.Text = reader["DT"].ToString();
                    textBox8.Text = reader["Vaitro"].ToString();
                    textBox9.Text = reader["MaDV"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("admin_qldh.update_phone_nhanvien", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = UserSession.maUser;
                cmd.Parameters.Add("p_sdt", OracleDbType.Varchar2).Value = textBox7.Text.Trim();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật số điện thoại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTTNV();
                textBox7.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox7.Focus();
        }
        private void LoadThongBao()
        {
            try
            {
                string query = @"
            SELECT 
                ID AS ""Mã thông báo"",
                noidung AS ""Nội dung"",
                ngaytao AS ""Ngày tạo""
            FROM ADMIN_QLDH.THONGBAO";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView4.DataSource = dt;
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông báo: " + ex.Message);
            }
        }
        private void LoadDangKy()
        {
            try
            {
                string query = @"
            SELECT * FROM ADMIN_QLDH.DANGKY";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông báo: " + ex.Message);
            }
        }
        private void tbcThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcThongTin.SelectedIndex == 0)
            {
                LoadTTNV();
            }
            if (tbcThongTin.SelectedIndex == 1)
            {
                LoadDangKy();

            }
            if (tbcThongTin.SelectedIndex == 2)
            {
                LoadThongBao();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = textBox12.Text.Trim().ToUpper();
                string maMm = textBox13.Text.Trim().ToUpper();
                string query = "SELECT * FROM admin_qldh.DANGKY WHERE UPPER(MASV) LIKE : maSV AND UPPER(mamm) LIKE : maMm";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":maSV", maSV + "%");
                cmd.Parameters.Add(":mamm", maMm + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi." + ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ dòng được chọn
            var row = dataGridView3.CurrentRow;
            string mssv = row.Cells["MASV"].Value?.ToString();
            string mamon = row.Cells["MAMM"].Value?.ToString();
            string diemQT = row.Cells["DIEMQT"].Value?.ToString();
            string diemCK = row.Cells["DIEMCK"].Value?.ToString();
            string diemTH = row.Cells["DIEMTH"].Value?.ToString();
            string diemTK = row.Cells["DIEMTK"].Value?.ToString();

            // Truyền dữ liệu sang form ThongTinDangKy (giả sử có constructor phù hợp)
            ThongTinDangKy form = new ThongTinDangKy(mssv, mamon, diemQT, diemCK, diemTH, diemTK);
            form.DangKyUpdated += (s, args) => LoadDangKy();

            form.ShowDialog();
        }
    }
}
