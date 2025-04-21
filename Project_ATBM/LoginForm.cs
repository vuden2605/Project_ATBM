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
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == null)
            {
                MessageBox.Show("Tên đăng nhập không được để trống.");
            }
            if (password == null)
            {
                MessageBox.Show("Mật khẩu không được để trống.");
            }

            string connectionString = $"User Id= {username};Password={password};Data Source=localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (username == "admin_qldh")
                    {
                        adminForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                                
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đăng nhập thất bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            
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
