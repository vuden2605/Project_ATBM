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
                //load_data_dangky();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            load_data_dangky();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string maMon = dataGridView2.CurrentRow.Cells["MAMON"].Value.ToString();
                string tenMon = dataGridView2.CurrentRow.Cells["TENMON"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có muốn đăng ký môn học: {tenMon} (Mã: {maMon}) không?",
                    "Xác nhận đăng ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Thực hiện đăng ký tại đây
                    MessageBox.Show("Đăng ký thành công!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách môn học.", "Thông báo");
            }
        }

    }
}
