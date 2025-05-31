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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Project_ATBM
{
    public partial class NVTCHC : Form
    {
        public NVTCHC()
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
        public void LoadAllTTNV()
        {
            try
            {
                string query = "select * from admin_qldh.nhanvien";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

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
        private void tbcThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbcThongTin.SelectedIndex == 0)
            {
                LoadTTNV();
            }
            if (tbcThongTin.SelectedIndex == 1)
            {
                LoadAllTTNV();
            }
            if (tbcThongTin.SelectedIndex == 2)
            {
                LoadThongBao();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    //string manld = 

                    //string hoten = textBox1.Text;
                    //string phai = textBox2.Text;
                    //string ngsinh = textBox3.Text;
                    //string luong = textBox4.Text;
                    //string phucap = textBox5.Text;
                    //string dt = textBox6.Text;
                    //string vaitro = 
                    //string madv = 
                    ThongTinNhanVien ttnv = new ThongTinNhanVien();
                    ttnv.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa nhân viên này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    string manld = dataGridView1.CurrentRow.Cells["MANLD"].Value.ToString();

                    OracleCommand cmd = new OracleCommand("admin_qldh.nvtchc_delete_nhanvien", LoginForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = manld;
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllTTNV();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string manld = textBox11.Text.ToUpper();
                string query = "select * from admin_qldh.nhanvien WHERE UPPER (MANLD) = : manld ";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":manld", manld);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string MANLD = dataGridView1.CurrentRow.Cells["MANLD"].Value.ToString();
                    string HOTEN = dataGridView1.CurrentRow.Cells["HOTEN"].Value.ToString();
                    string PHAI = dataGridView1.CurrentRow.Cells["PHAI"].Value.ToString();
                    string NGSINH = dataGridView1.CurrentRow.Cells["NGSINH"].Value.ToString();
                    string LUONG = dataGridView1.CurrentRow.Cells["LUONG"].Value.ToString();
                    string PHUCAP = dataGridView1.CurrentRow.Cells["PHUCAP"].Value.ToString();
                    string DT = dataGridView1.CurrentRow.Cells["DT"].Value.ToString();
                    string VAITRO = dataGridView1.CurrentRow.Cells["VAITRO"].Value.ToString();
                    string MADV = dataGridView1.CurrentRow.Cells["MADV"].Value.ToString();

                    UpdateThongTinNhanVien ttsv = new UpdateThongTinNhanVien(MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, VAITRO, MADV);
                    ttsv.SVUpdate += (s, args) => LoadAllTTNV();
                    ttsv.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                this.Hide();

            }
        }
    }
}
