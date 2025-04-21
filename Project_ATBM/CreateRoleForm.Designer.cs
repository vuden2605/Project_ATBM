namespace Project_ATBM
{
    partial class CreateRoleForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            CancelCreateRole = new Button();
            DoneCreateRole = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(41, 59);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 64);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(121, 18);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(261, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 22);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Role Name";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(CancelCreateRole);
            panel2.Controls.Add(DoneCreateRole);
            panel2.Location = new Point(153, 132);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 44);
            panel2.TabIndex = 1;
            // 
            // CancelCreateRole
            // 
            CancelCreateRole.Location = new Point(168, 10);
            CancelCreateRole.Margin = new Padding(2, 2, 2, 2);
            CancelCreateRole.Name = "CancelCreateRole";
            CancelCreateRole.Size = new Size(100, 32);
            CancelCreateRole.TabIndex = 1;
            CancelCreateRole.Text = "Cancel";
            CancelCreateRole.UseVisualStyleBackColor = true;
            CancelCreateRole.Click += CancelCreateRole_Click;
            // 
            // DoneCreateRole
            // 
            DoneCreateRole.Location = new Point(9, 10);
            DoneCreateRole.Margin = new Padding(2, 2, 2, 2);
            DoneCreateRole.Name = "DoneCreateRole";
            DoneCreateRole.Size = new Size(100, 32);
            DoneCreateRole.TabIndex = 0;
            DoneCreateRole.Text = "Ok";
            DoneCreateRole.UseVisualStyleBackColor = true;
            DoneCreateRole.Click += button1_Click;
            // 
            // CreateRoleForm
            // 
            AcceptButton = DoneCreateRole;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 222);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "CreateRoleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Role";
            Load += CreateRoleForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Panel panel2;
        private Button DoneCreateRole;
        private Button CancelCreateRole;
    }
}