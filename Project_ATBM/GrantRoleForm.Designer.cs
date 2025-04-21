namespace Project_ATBM
{
    partial class GrantRoleForm
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
            checkBox2 = new CheckBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel5 = new Panel();
            CanCelGrantToRole = new Button();
            DoneGrantToRole = new Button();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(26, 8);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 269);
            panel1.TabIndex = 1;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(208, 177);
            checkBox2.Margin = new Padding(2, 2, 2, 2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(179, 24);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Grant to columns level";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(208, 122);
            textBox3.Margin = new Padding(2, 2, 2, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(208, 64);
            textBox2.Margin = new Padding(2, 2, 2, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(208, 16);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 124);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên quyền:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 69);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên bảng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Role:";
            // 
            // panel5
            // 
            panel5.Controls.Add(CanCelGrantToRole);
            panel5.Controls.Add(DoneGrantToRole);
            panel5.Location = new Point(150, 280);
            panel5.Margin = new Padding(2, 2, 2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(309, 55);
            panel5.TabIndex = 3;
            // 
            // CanCelGrantToRole
            // 
            CanCelGrantToRole.Location = new Point(204, 11);
            CanCelGrantToRole.Margin = new Padding(2, 2, 2, 2);
            CanCelGrantToRole.Name = "CanCelGrantToRole";
            CanCelGrantToRole.Size = new Size(97, 24);
            CanCelGrantToRole.TabIndex = 1;
            CanCelGrantToRole.Text = "Cancel";
            CanCelGrantToRole.UseVisualStyleBackColor = true;
            CanCelGrantToRole.Click += CanCelGrantToRole_Click;
            // 
            // DoneGrantToRole
            // 
            DoneGrantToRole.Location = new Point(84, 11);
            DoneGrantToRole.Margin = new Padding(2, 2, 2, 2);
            DoneGrantToRole.Name = "DoneGrantToRole";
            DoneGrantToRole.Size = new Size(97, 24);
            DoneGrantToRole.TabIndex = 0;
            DoneGrantToRole.Text = "OK";
            DoneGrantToRole.UseVisualStyleBackColor = true;
            DoneGrantToRole.Click += DoneGrantToRole_Click;
            // 
            // GrantRoleForm
            // 
            AcceptButton = DoneGrantToRole;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 342);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "GrantRoleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GrantRoleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CheckBox checkBox2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel5;
        private Button CanCelGrantToRole;
        private Button DoneGrantToRole;
    }
}