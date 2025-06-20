﻿using Oracle.ManagedDataAccess.Client;
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
    public partial class TRGDV : Form
    {
        public TRGDV()
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
                string query = "SELECT * FROM admin_qldh.v_trgdv_mm ";

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
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông báo: " + ex.Message);
            }
        }
        private void LoadNhanVien()
        {
            try
            {
                string query = @"
            SELECT * FROM ADMIN_QLDH.v_trgdv_nv";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                LoadTTNV();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                LoadThongBao();

            }
            if (tabControl1.SelectedIndex == 2)
            {
                LoadNhanVien();

            }
            if (tabControl1.SelectedIndex == 3)
            {
                LoadDsMoMon();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string maGv = textBox11.Text.Trim().ToUpper();
                string query = "SELECT * FROM admin_qldh.v_trgdv_mm WHERE UPPER(MAGV) LIKE :maGv";

                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":maGv", maGv + "%");

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = textBox10.Text.Trim().ToUpper();
                string query = "SELECT * FROM admin_qldh.v_trgdv_nv WHERE UPPER(HOTEN) LIKE : hoten";
                OracleCommand cmd = new OracleCommand(query, LoginForm.conn);
                cmd.Parameters.Add(":maNV", "%" + hoten + "%");
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
