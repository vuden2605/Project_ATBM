using Oracle.ManagedDataAccess.Client;

namespace Project_ATBM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            this.Hide();
            string connectionString = "User Id=sys;Password=viet123456;Data Source=localhost:1521/XEPDB1;DBA Privilege=SYSDBA;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu Oracle thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể kết nối đến cơ sở dữ liệu. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            adminForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel= true;
            }
        }
    }
}
