namespace Project_ATBM
{
    partial class UpdateUserForm
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
            CanCelUpdateUser = new Button();
            DoneUpdateUser = new Button();
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
            panel1.Location = new Point(17, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 503);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(CanCelUpdateUser);
            panel5.Controls.Add(DoneUpdateUser);
            panel5.Location = new Point(205, 389);
            panel5.Name = "panel5";
            panel5.Size = new Size(502, 88);
            panel5.TabIndex = 2;
            // 
            // CanCelUpdateUser
            // 
            CanCelUpdateUser.Location = new Point(321, 18);
            CanCelUpdateUser.Name = "CanCelUpdateUser";
            CanCelUpdateUser.Size = new Size(157, 39);
            CanCelUpdateUser.TabIndex = 1;
            CanCelUpdateUser.Text = "Cancel";
            CanCelUpdateUser.UseVisualStyleBackColor = true;
            CanCelUpdateUser.Click += CanCelUpdateUser_Click;
            // 
            // DoneUpdateUser
            // 
            DoneUpdateUser.Location = new Point(135, 18);
            DoneUpdateUser.Name = "DoneUpdateUser";
            DoneUpdateUser.Size = new Size(157, 39);
            DoneUpdateUser.TabIndex = 0;
            DoneUpdateUser.Text = "OK";
            DoneUpdateUser.UseVisualStyleBackColor = true;
            DoneUpdateUser.Click += DoneUpdateUser_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(57, 154);
            panel3.Name = "panel3";
            panel3.Size = new Size(650, 90);
            panel3.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(283, 24);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(343, 39);
            textBox3.TabIndex = 3;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 31);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 1;
            label2.Text = "PassWord";
            label2.Click += label2_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(57, 265);
            panel4.Name = "panel4";
            panel4.Size = new Size(650, 90);
            panel4.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(283, 25);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(343, 39);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 32);
            label3.Name = "label3";
            label3.Size = new Size(208, 32);
            label3.TabIndex = 2;
            label3.Text = "Confirm PassWord";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(57, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 90);
            panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(283, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 39);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 28);
            label1.Name = "label1";
            label1.Size = new Size(132, 32);
            label1.TabIndex = 0;
            label1.Text = "User Name";
            label1.Click += label1_Click;
            // 
            // UpdateUserForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 528);
            Controls.Add(panel1);
            Name = "UpdateUserForm";
            Text = "Chỉnh sửa User";
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
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button CanCelUpdateUser;
        private Button DoneUpdateUser;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}