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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_ATBM
{
    public partial class SinhVienForm : Form
    {
        public SinhVienForm()
        {
            InitializeComponent();
            LoadTTSV();

        }
        // sửa dia chi
        private void label10_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            textBox4.Focus();

        }
        // sửa sdt
        private void label11_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            textBox6.Focus();

        }
        private void LoadThongBao()
        {
            try
            {
                string query = @"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY ngaytao DESC) AS ""STT"",
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
        private void LoadTTSV()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.SINHVIEN";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["MASV"].ToString();
                    textBox5.Text = reader["HOTEN"].ToString();
                    DateTime ngsinh = (DateTime)reader["NGSINH"];
                    textBox8.Text = ngsinh.ToString("dd/MM/yyyy");
                    textBox2.Text = reader["PHAI"].ToString();
                    textBox4.Text = reader["DCHI"].ToString();
                    textBox6.Text = reader["DT"].ToString();
                    textBox3.Text = reader["KHOA"].ToString();
                    textBox7.Text = reader["TINHTRANG"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message);
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                LoadTTSV();

            }
            if (tabControl1.SelectedIndex == 1)
            {

                load_data_momon();
                load_data_dangky();

            }
            if (tabControl1.SelectedIndex == 2)
            {
                LoadThongBao();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("admin_qldh.update_address", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("p_dchimoi", OracleDbType.Varchar2).Value = textBox4.Text.Trim();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật địa chỉ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTTSV();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật địa chỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTTSV();
            textBox4.Enabled = false;
        }
        public void load_data_momon()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.v_sv_momon";

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
        public void load_data_dangky()
        {
            try
            {
                string query = "SELECT * FROM admin_qldh.dangky";

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string maMm = dataGridView1.CurrentRow.Cells["MAMM"].Value.ToString();
                string tenHp = dataGridView1.CurrentRow.Cells["TENHP"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có muốn đăng ký môn học: {tenHp} (Mã: {maMm}) không?",
                    "Xác nhận đăng ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (OracleCommand cmd = new OracleCommand("admin_qldh.sv_dk_monhoc", LoginForm.conn))
                        {
                            Console.WriteLine(UserSession.maUser);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("p_masv", OracleDbType.NVarchar2).Value = UserSession.maUser;
                            cmd.Parameters.Add("p_mamm", OracleDbType.NVarchar2).Value = maMm;

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Đăng ký môn học thành công!", "Thông báo");
                            load_data_dangky();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách môn học.", "Thông báo");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                string maMm = dataGridView2.CurrentRow.Cells["MAMM"].Value.ToString();
                string tenHp = dataGridView1.CurrentRow.Cells["TENHP"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có muốn hủy đăng ký môn học: {tenHp} (Mã: {maMm}) không?",
                    "Xác nhận đăng ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (OracleCommand cmd = new OracleCommand("admin_qldh.sv_delete_dk", LoginForm.conn))
                        {
                            Console.WriteLine(UserSession.maUser);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("p_masv", OracleDbType.NVarchar2).Value = UserSession.maUser;
                            cmd.Parameters.Add("p_mamm", OracleDbType.NVarchar2).Value = maMm;

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Hủy đăng ký môn học thành công!", "Thông báo");
                            load_data_dangky();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách đăng ký.", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("admin_qldh.update_phone", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("p_sdtmoi", OracleDbType.Varchar2).Value = textBox6.Text.Trim();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật số điện thoại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTTSV();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật  số điện thoại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTTSV();
            textBox6.Enabled = false;
        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            try
            {
                string tenHp = textBox9.Text;
                string query = "SELECT * FROM admin_qldh.v_sv_momon WHERE tenhp LIKE : tenHp";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":username", "%" + tenHp + "%");
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi." + ex.Message);
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

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
      
