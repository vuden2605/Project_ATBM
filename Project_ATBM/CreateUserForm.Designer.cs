namespace Project_ATBM
{
    partial class CreateUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel5 = new Panel();
            CanCelCreateUser = new Button();
            DoneCreateUser = new Button();
            panel3 = new Panel();
            textBox3 = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(15, 8);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(506, 314);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(CanCelCreateUser);
            panel5.Controls.Add(DoneCreateUser);
            panel5.Location = new Point(126, 243);
            panel5.Margin = new Padding(2, 2, 2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(309, 55);
            panel5.TabIndex = 2;
            // 
            // CanCelCreateUser
            // 
            CanCelCreateUser.Location = new Point(198, 11);
            CanCelCreateUser.Margin = new Padding(2, 2, 2, 2);
            CanCelCreateUser.Name = "CanCelCreateUser";
            CanCelCreateUser.Size = new Size(97, 24);
            CanCelCreateUser.TabIndex = 1;
            CanCelCreateUser.Text = "Cancel";
            CanCelCreateUser.UseVisualStyleBackColor = true;
            CanCelCreateUser.Click += CanCelCreateUser_Click;
            // 
            // DoneCreateUser
            // 
            DoneCreateUser.Location = new Point(83, 11);
            DoneCreateUser.Margin = new Padding(2, 2, 2, 2);
            DoneCreateUser.Name = "DoneCreateUser";
            DoneCreateUser.Size = new Size(97, 24);
            DoneCreateUser.TabIndex = 0;
            DoneCreateUser.Text = "OK";
            DoneCreateUser.UseVisualStyleBackColor = true;
            DoneCreateUser.Click += DoneCreateUser_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(35, 96);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 56);
            panel3.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(174, 15);
            textBox3.Margin = new Padding(2, 2, 2, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(213, 27);
            textBox3.TabIndex = 3;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 19);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "PassWord";
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(35, 166);
            panel4.Margin = new Padding(2, 2, 2, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(400, 56);
            panel4.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(174, 16);
            textBox2.Margin = new Padding(2, 2, 2, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 27);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 20);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 2;
            label3.Text = "Confirm PassWord";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(35, 22);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 56);
            panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(174, 16);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "User Name";
            // 
            // CreateUserForm
            // 
            AcceptButton = DoneCreateUser;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 326);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "CreateUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo User";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel5;
        private Button CanCelCreateUser;
        private Button DoneCreateUser;
        private Panel panel3;
        private TextBox textBox3;
        private Label label2;
        private Panel panel4;
        private TextBox textBox2;
        private Label label3;
        private Panel panel2;
        private TextBox textBox1;
        private Label label1;
    }
}