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
    public partial class NVPDT : Form
    {
        public NVPDT()
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
        public void LoadDsMoMon()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.V_nvpdt_mm";

                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
        public void LoadDsSV()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.SINHVIEN";

                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
        public void LoadDsDK()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.DANGKY";

                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void tbcThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcThongTin.SelectedIndex == 0)
            {
                LoadTTNV();
            }
            if (tbcThongTin.SelectedIndex == 1)
            {
                LoadDsMoMon();
            }
            if (tbcThongTin.SelectedIndex == 2)
            {
                LoadDsSV();
            }
            if (tbcThongTin.SelectedIndex == 3)
            {
                LoadDsDK();
            }
            if (tbcThongTin.SelectedIndex == 4)
            {
                LoadThongBao();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string tenHp = textBox10.Text.Trim().ToUpper();
                string query = "SELECT * FROM admin_qldh.V_nvpdt_mm WHERE UPPER(TENHP) LIKE : tenHp";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":tenHp", "%" + tenHp + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi." + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string masv = dataGridView1.CurrentRow.Cells["MASV"].Value.ToString();

                    string hoten = dataGridView1.CurrentRow.Cells["HOTEN"].Value.ToString();
                    string phai = dataGridView1.CurrentRow.Cells["PHAI"].Value.ToString();
                    string ngsinh = dataGridView1.CurrentRow.Cells["NGSINH"].Value.ToString();
                    string dchi = dataGridView1.CurrentRow.Cells["DCHI"].Value.ToString();
                    string dt = dataGridView1.CurrentRow.Cells["DT"].Value.ToString();
                    string khoa = dataGridView1.CurrentRow.Cells["KHOA"].Value.ToString();
                    string tinhtrang = dataGridView1.CurrentRow.Cells["TINHTRANG"].Value.ToString();
                    ThongTinSinhVienPDT ttsv = new ThongTinSinhVienPDT(masv, hoten, phai, ngsinh, dchi, dt, khoa, tinhtrang);
                    ttsv.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa mở môn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    string mamm = dataGridView2.CurrentRow.Cells["MAMM"].Value.ToString();
                    DateTime ngaybd = Convert.ToDateTime(dataGridView2.CurrentRow.Cells["NGAYBD"].Value);
                    string nam = dataGridView2.CurrentRow.Cells["NAM"].Value.ToString();

                    OracleCommand cmd = new OracleCommand("admin_qldh.nvpdt_delete_momon", LoginForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = mamm;
                    cmd.Parameters.Add("p_ngaybd", OracleDbType.Date).Value = ngaybd;
                    cmd.Parameters.Add("p_nam", OracleDbType.Varchar2).Value = nam;

                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa mở môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsMoMon();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

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
                cmd.Parameters.Add(":maMm", maMm + "%");
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

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa đăng ký này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    string masv = dataGridView3.CurrentRow.Cells["MASV"].Value.ToString();
                    string mamm = dataGridView3.CurrentRow.Cells["MAMM"].Value.ToString();

                    OracleCommand cmd = new OracleCommand("admin_qldh.nvpdt_delete_dangky", LoginForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = masv;
                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = mamm;
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsDK();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
