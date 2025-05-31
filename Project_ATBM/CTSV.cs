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
    public partial class CTSV : Form
    {
        public CTSV()
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
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox7.Focus();
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
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông báo: " + ex.Message);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {

            }
            if (tabControl1.SelectedIndex == 1)
            {

                LoadThongBao();

            }
            if (tabControl1.SelectedIndex == 2)
            {
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
