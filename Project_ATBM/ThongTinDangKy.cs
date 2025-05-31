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
    public partial class ThongTinDangKy : Form
    {
        public ThongTinDangKy()
        {
            InitializeComponent();
        }
        public ThongTinDangKy(string mssv, string mamon, string diemQT, string diemCK, string diemTH, string diemTK)
            : this()
        {
            textBox1.Text = mssv;
            textBox2.Text = mamon;
            textBox4.Text = diemQT;
            textBox5.Text = diemCK;
            textBox3.Text = diemTH;
            textBox6.Text = diemTK;
        }
        public event EventHandler DangKyUpdated;




        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal diemTH = 0, diemQT = 0, diemCK = 0;

                // Kiểm tra điểm thực hành
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    if (!decimal.TryParse(textBox3.Text, out diemTH) || diemTH < 0 || diemTH > 10)
                    {
                        MessageBox.Show("Điểm thực hành phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Kiểm tra điểm quá trình
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    if (!decimal.TryParse(textBox4.Text, out diemQT) || diemQT < 0 || diemQT > 10)
                    {
                        MessageBox.Show("Điểm quá trình phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Kiểm tra điểm cuối kỳ
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    if (!decimal.TryParse(textBox5.Text, out diemCK) || diemCK < 0 || diemCK > 10)
                    {
                        MessageBox.Show("Điểm cuối kỳ phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("admin_qldh.sua_dangky", LoginForm.conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_masv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                    cmd.Parameters.Add("p_mamm", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2).Value = textBox2.Text.Trim();
                    cmd.Parameters.Add("p_diemth", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal).Value = string.IsNullOrWhiteSpace(textBox3.Text) ? (object)DBNull.Value : diemTH;
                    cmd.Parameters.Add("p_diemqt", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal).Value = string.IsNullOrWhiteSpace(textBox4.Text) ? (object)DBNull.Value : diemQT;
                    cmd.Parameters.Add("p_diemck", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal).Value = string.IsNullOrWhiteSpace(textBox5.Text) ? (object)DBNull.Value : diemCK;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DangKyUpdated?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
