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
    public partial class SinhVienForm : Form
    {
        public SinhVienForm()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

            }
            if (tabControl1.SelectedIndex == 1)
            {
                load_data_momon();
                load_data_dangky();
            }
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
                            Console.WriteLine(UserSession.maSV);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("p_masv", OracleDbType.NVarchar2).Value = UserSession.maSV;
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
                            Console.WriteLine(UserSession.maSV);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("p_masv", OracleDbType.NVarchar2).Value = UserSession.maSV;
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
    }
}
