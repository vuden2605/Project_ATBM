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
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(36, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 384);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(497, 140);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(397, 140);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(37, 83);
            panel3.Name = "panel3";
            panel3.Size = new Size(599, 51);
            panel3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(212, 10);
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
            label2.Location = new Point(41, 13);
            label2.Name = "label2";
            label2.Size = new Size(110, 24);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu :";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(37, 26);
            panel2.Name = "panel2";
            panel2.Size = new Size(599, 51);
            panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 18);
            label1.Name = "label1";
            label1.Size = new Size(165, 24);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập :";
            label1.Click += label1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang đăng nhập";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Button button2;
        private Button button1;
    }
}
