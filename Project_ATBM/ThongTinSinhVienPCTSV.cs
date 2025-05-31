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
    public partial class ThongTinSinhVien : Form
    {
        public ThongTinSinhVien(string masv, string hoten, string phai, string ngsinh, string dchi, string dt, string khoa, string tinhtrang)
        {
            InitializeComponent();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Nam");
            comboBox2.Items.Add("Nữ");
            comboBox2.Items.Add("Khác");

            comboBox3.Items.Clear();
            comboBox3.Items.Add("CNTT");
            comboBox3.Items.Add("VL");
            comboBox3.Items.Add("HH");
            comboBox3.Items.Add("KT");

            textBox1.Text = masv;
            textBox5.Text = hoten;
            comboBox2.Text = phai;
            comboBox3.Text = khoa;
            comboBox1.Text = tinhtrang;
            textBox4.Text = dchi;
            textBox6.Text = dt;

            // Định dạng lại ngày sinh chỉ hiển thị ngày
            DateTime ngaySinhDate;
            if (DateTime.TryParse(ngsinh, out ngaySinhDate))
            {
                textBox8.Text = ngaySinhDate.ToString("dd/MM/yyyy");
            }
            else
            {
                textBox8.Text = ngsinh;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public event EventHandler SVUpdate;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("admin_qldh.CAPNHAT_SINHVIEN", LoginForm.conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_masv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                    cmd.Parameters.Add("p_hoten", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox5.Text.Trim();
                    cmd.Parameters.Add("p_phai", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = comboBox2.Text.Trim();

                    // Chuyển ngày sinh về DateTime
                    DateTime ngsinh;
                    if (!DateTime.TryParseExact(textBox8.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngsinh))
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ. Định dạng đúng: dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.Parameters.Add("p_ngsinh", Oracle.ManagedDataAccess.Client.OracleDbType.Date).Value = ngsinh;

                    cmd.Parameters.Add("p_dchi", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox4.Text.Trim();
                    cmd.Parameters.Add("p_dt", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox6.Text.Trim();
                    cmd.Parameters.Add("p_khoa", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = comboBox3.Text.Trim();

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SVUpdate?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
