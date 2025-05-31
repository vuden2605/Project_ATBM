using Oracle.ManagedDataAccess.Client;

namespace Project_ATBM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static OracleConnection conn;

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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username==null)
            {
                MessageBox.Show("Tên đăng nhập không được để trống.");
                return;
            }
            if (password==null)
            {
                MessageBox.Show("Mật khẩu không được để trống.");
                return;
            }

            string connectionString = $"User Id={username};Password={password};Data Source=localhost:1521/QLDH";

            conn = new OracleConnection(connectionString);

            try
            {
                conn.Open();
                //OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\"=TRUE", LoginForm.conn);
                //cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                string uname = username.ToLower();

                if (uname.StartsWith("admin"))
                {
                    UserSession.maUser = username.ToUpper();
                    new AdminForm().ShowDialog();
                }
                else if (uname.StartsWith("sv"))
                {
                    UserSession.maUser = username.ToUpper();
                    new SinhVienForm().ShowDialog();
                }
                else if (uname.StartsWith("gv"))
                {
                    UserSession.maUser = username.ToUpper();
                    new GV().ShowDialog();
                }
                else if (uname.StartsWith("nvcb"))
                {
                    UserSession.maUser = username.ToUpper();
                    new NVCB().ShowDialog();
                }
                else if (uname.StartsWith("nvpdt"))
                {
                    UserSession.maUser = username.ToUpper();
                    new NVPDT().ShowDialog();
                }
                else if (uname.StartsWith("nvpkt"))
                {
                    UserSession.maUser = username.ToUpper();
                    new NVPKT().ShowDialog();
                }
                else if (uname.StartsWith("nvtchc"))
                {
                    UserSession.maUser = username.ToUpper();
                    new NVTCHC().ShowDialog();
                }
                else if (uname.StartsWith("nvctsv"))
                {
                    UserSession.maUser = username.ToUpper();
                    new CTSV().ShowDialog();
                }
                else if (uname.StartsWith("tdv"))
                {
                    UserSession.maUser = username.ToUpper();
                    new TRGDV().ShowDialog();
                }
                else
                {
                    // Load form khác theo role nếu cần
                }

                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelLogIn_Click(object sender, EventArgs e)
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
