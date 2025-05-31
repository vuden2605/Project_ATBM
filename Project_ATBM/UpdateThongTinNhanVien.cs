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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Project_ATBM
{
    public partial class UpdateThongTinNhanVien : Form
    {
        public UpdateThongTinNhanVien(string MANLD, string HOTEN, string PHAI, string NGSINH, string LUONG, string PHUCAP, string DT, string VAITRO, string MADV)
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            comboBox1.Items.Add("Khác");

            comboBox2.Items.Clear();
            comboBox2.Items.Add("CNTT");
            comboBox2.Items.Add("VL");
            comboBox2.Items.Add("HH");
            comboBox2.Items.Add("KT");
            comboBox2.Items.Add("PĐT");
            comboBox2.Items.Add("PKT");
            comboBox2.Items.Add("PTCHC");
            comboBox2.Items.Add("PCTSV");

            textBox1.Text = MANLD;
            textBox2.Text = HOTEN;
            comboBox1.Text = PHAI;
            textBox5.Text = LUONG;
            textBox6.Text = PHUCAP;
            textBox7.Text = DT;
            textBox8.Text = VAITRO;
            comboBox2.Text = MADV;


            // Định dạng lại ngày sinh chỉ hiển thị ngày
            DateTime ngaySinhDate;
            if (DateTime.TryParse(NGSINH, out ngaySinhDate))
            {
                textBox4.Text = ngaySinhDate.ToString("dd/MM/yyyy");
            }
            else
            {
                textBox4.Text = NGSINH;
            }
        }
        public event EventHandler SVUpdate;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("ADMIN_QLDH.SUA_NHANVIEN", LoginForm.conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_manld", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                    cmd.Parameters.Add("p_hoten", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox2.Text.Trim();
                    cmd.Parameters.Add("p_phai", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = comboBox1.Text.Trim();

                    // Xử lý ngày sinh
                    DateTime ngsinh;
                    if (!DateTime.TryParseExact(textBox4.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngsinh))
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ. Định dạng đúng: dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.Parameters.Add("p_ngsinh", Oracle.ManagedDataAccess.Client.OracleDbType.Date).Value = ngsinh;

                    // Lương
                    decimal luong;
                    if (!decimal.TryParse(textBox5.Text.Trim(), out luong))
                    {
                        MessageBox.Show("Lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.Parameters.Add("p_luong", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal).Value = luong;

                    // Phụ cấp
                    decimal phucap;
                    if (!decimal.TryParse(textBox6.Text.Trim(), out phucap))
                    {
                        MessageBox.Show("Phụ cấp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.Parameters.Add("p_phucap", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal).Value = phucap;

                    cmd.Parameters.Add("p_dt", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox7.Text.Trim();
                    cmd.Parameters.Add("p_vaitro", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox8.Text.Trim();
                    cmd.Parameters.Add("p_madv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = comboBox2.Text.Trim();

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SVUpdate?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
