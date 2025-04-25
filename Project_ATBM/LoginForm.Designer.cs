namespace Project_ATBM
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblLoginTitle = new Label();
            btnCancelLogIn = new Button();
            btnLogIn = new Button();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            ptbLogin = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbLogin).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(lblLoginTitle);
            panel1.Controls.Add(btnCancelLogIn);
            panel1.Controls.Add(btnLogIn);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(366, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 423);
            panel1.TabIndex = 0;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginTitle.ForeColor = Color.IndianRed;
            lblLoginTitle.Location = new Point(24, 11);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(161, 38);
            lblLoginTitle.TabIndex = 4;
            lblLoginTitle.Text = "Đăng nhập";
            // 
            // btnCancelLogIn
            // 
            btnCancelLogIn.BackColor = Color.Red;
            btnCancelLogIn.ForeColor = SystemColors.ButtonHighlight;
            btnCancelLogIn.Location = new Point(154, 365);
            btnCancelLogIn.Margin = new Padding(0);
            btnCancelLogIn.Name = "btnCancelLogIn";
            btnCancelLogIn.Size = new Size(96, 41);
            btnCancelLogIn.TabIndex = 3;
            btnCancelLogIn.Text = "Thoát";
            btnCancelLogIn.UseVisualStyleBackColor = false;
            btnCancelLogIn.Click += btnCancelLogIn_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.FromArgb(128, 128, 255);
            btnLogIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = SystemColors.ButtonHighlight;
            btnLogIn.Location = new Point(27, 304);
            btnLogIn.Margin = new Padding(0);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(342, 50);
            btnLogIn.TabIndex = 2;
            btnLogIn.Text = "Đăng nhập";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(24, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(358, 115);
            panel3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 70);
            textBox2.MaxLength = 50000;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(342, 27);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(3, 32);
            label2.Name = "label2";
            label2.Size = new Size(97, 24);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(24, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(358, 113);
            panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(3, 29);
            label1.Name = "label1";
            label1.Size = new Size(152, 24);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            label1.Click += label1_Click;
            // 
            // ptbLogin
            // 
            ptbLogin.Image = Properties.Resources.login;
            ptbLogin.Location = new Point(-3, 12);
            ptbLogin.Name = "ptbLogin";
            ptbLogin.Size = new Size(370, 423);
            ptbLogin.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbLogin.TabIndex = 1;
            ptbLogin.TabStop = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogIn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            CancelButton = btnCancelLogIn;
            ClientSize = new Size(800, 450);
            Controls.Add(ptbLogin);
            Controls.Add(panel1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang đăng nhập";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnCancelLogIn;
        private Button btnLogIn;
        private PictureBox ptbLogin;
        private Label lblLoginTitle;
    }
}
