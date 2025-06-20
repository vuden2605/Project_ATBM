﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ATBM
{
    public partial class ThongTinNhanVien : Form
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string manld = textBox1.Text;
                string hoten = textBox2.Text;
                string phai = comboBox1.Text;
                string luong = textBox5.Text;
                string phucap = textBox6.Text;
                string sdt = textBox7.Text;
                string vaitro = textBox8.Text;
                string dv = comboBox2.Text;
                DateTime ngaysinh = DateTime.ParseExact(textBox4.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                OracleCommand cmd = new OracleCommand("admin_qldh.nvtchc_insert_nhanvien", LoginForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = manld;
                cmd.Parameters.Add("p_hoten", OracleDbType.Varchar2).Value = hoten;
                cmd.Parameters.Add("p_phai", OracleDbType.Varchar2).Value = phai;
                cmd.Parameters.Add("p_ngaysinh", OracleDbType.Date).Value = ngaysinh;
                cmd.Parameters.Add("p_luong", OracleDbType.Decimal).Value = luong;
                cmd.Parameters.Add("p_phucap", OracleDbType.Decimal).Value = phucap;
                cmd.Parameters.Add("p_sdt", OracleDbType.Varchar2).Value = sdt;
                cmd.Parameters.Add("p_vaitro", OracleDbType.Varchar2).Value = vaitro;
                cmd.Parameters.Add("p_dv", OracleDbType.Varchar2).Value = dv;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
