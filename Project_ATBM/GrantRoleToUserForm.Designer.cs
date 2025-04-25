namespace Project_ATBM
{
    partial class GrantRoleToUserForm
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
            cmbRoles = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSuccessGrantR_U = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbRoles);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(28, 28);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(439, 128);
            panel1.TabIndex = 0;
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(179, 71);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(242, 28);
            cmbRoles.TabIndex = 3;
            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 15);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 75);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên Role";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên User";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSuccessGrantR_U);
            panel2.Location = new Point(207, 176);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(241, 41);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(137, 3);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 33);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSuccessGrantR_U
            // 
            btnSuccessGrantR_U.Location = new Point(4, 3);
            btnSuccessGrantR_U.Margin = new Padding(2);
            btnSuccessGrantR_U.Name = "btnSuccessGrantR_U";
            btnSuccessGrantR_U.Size = new Size(102, 33);
            btnSuccessGrantR_U.TabIndex = 0;
            btnSuccessGrantR_U.Text = "Ok";
            btnSuccessGrantR_U.UseVisualStyleBackColor = true;
            btnSuccessGrantR_U.Click += btnSuccessGrantR_U_Click;
            // 
            // GrantRoleToUserForm
            // 
            AcceptButton = btnSuccessGrantR_U;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 242);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "GrantRoleToUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GrantRoleToUserForm";
            Load += GrantRoleToUserForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox1;
        private Label label2;
        private Button btnCancel;
        private Button btnSuccessGrantR_U;
        private ComboBox cmbRoles;
    }
}