﻿namespace Project_ATBM
{
    partial class UpdateRoleForm
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
            CanCelUpdateRole = new Button();
            DoneUpdateRole = new Button();
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
            panel1.Location = new Point(37, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 502);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(CanCelUpdateRole);
            panel5.Controls.Add(DoneUpdateRole);
            panel5.Location = new Point(205, 389);
            panel5.Name = "panel5";
            panel5.Size = new Size(502, 88);
            panel5.TabIndex = 2;
            panel5.Paint += panel5_Paint;
            // 
            // CanCelUpdateRole
            // 
            CanCelUpdateRole.Location = new Point(322, 18);
            CanCelUpdateRole.Name = "CanCelUpdateRole";
            CanCelUpdateRole.Size = new Size(158, 50);
            CanCelUpdateRole.TabIndex = 1;
            CanCelUpdateRole.Text = "Cancel";
            CanCelUpdateRole.UseVisualStyleBackColor = true;
            CanCelUpdateRole.Click += CanCelUpdateRole_Click;
            // 
            // DoneUpdateRole
            // 
            DoneUpdateRole.Location = new Point(135, 18);
            DoneUpdateRole.Name = "DoneUpdateRole";
            DoneUpdateRole.Size = new Size(158, 50);
            DoneUpdateRole.TabIndex = 0;
            DoneUpdateRole.Text = "OK";
            DoneUpdateRole.UseVisualStyleBackColor = true;
            DoneUpdateRole.Click += DoneUpdateRole_Click;
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
            textBox3.Size = new Size(344, 39);
            textBox3.TabIndex = 3;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 30);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 1;
            label2.Text = "PassWord";
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(57, 266);
            panel4.Name = "panel4";
            panel4.Size = new Size(650, 90);
            panel4.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(283, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(344, 39);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 32);
            label3.Name = "label3";
            label3.Size = new Size(208, 32);
            label3.TabIndex = 2;
            label3.Text = "Confirm PassWord";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(57, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 90);
            panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(283, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(344, 39);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 29);
            label1.Name = "label1";
            label1.Size = new Size(131, 32);
            label1.TabIndex = 0;
            label1.Text = "Role Name";
            // 
            // UpdateRoleForm
            // 
            AcceptButton = DoneUpdateRole;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 531);
            Controls.Add(panel1);
            Name = "UpdateRoleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa role";
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
        private Button CanCelUpdateRole;
        private Button DoneUpdateRole;
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