namespace Project_ATBM
{
    partial class AdminForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button4 = new Button();
            tabControl2 = new TabControl();
            tabPage8 = new TabPage();
            panel1 = new Panel();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            btnCreateUser = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            tabPage10 = new TabPage();
            btnDeleteRole = new Button();
            btnUpdateRole = new Button();
            btnCreateRole = new Button();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage8.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1570, 889);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Margin = new Padding(3, 3, 6, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1554, 835);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "User & Role";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1242, 757);
            button4.Name = "button4";
            button4.Size = new Size(266, 72);
            button4.TabIndex = 5;
            button4.Text = "Đăng xuất";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage8);
            tabControl2.Controls.Add(tabPage10);
            tabControl2.Location = new Point(21, 19);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1527, 743);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.TabIndex = 2;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(panel1);
            tabPage8.Controls.Add(dataGridView1);
            tabPage8.Location = new Point(8, 46);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(1511, 689);
            tabPage8.TabIndex = 0;
            tabPage8.Text = "USER";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteUser);
            panel1.Controls.Add(btnUpdateUser);
            panel1.Controls.Add(btnCreateUser);
            panel1.Location = new Point(1140, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(363, 377);
            panel1.TabIndex = 5;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(64, 145);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(266, 72);
            btnDeleteUser.TabIndex = 4;
            btnDeleteUser.Text = "Xóa User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(64, 281);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(266, 72);
            btnUpdateUser.TabIndex = 3;
            btnUpdateUser.Text = "Sửa User";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(64, 26);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(266, 72);
            btnCreateUser.TabIndex = 2;
            btnCreateUser.Text = "Tạo User";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(0, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1084, 655);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "USER_NAME";
            Column1.MinimumWidth = 10;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "USER_ID";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            Column2.Width = 200;
            // 
            // Column3
            // 
            Column3.HeaderText = "PASS_WORD";
            Column3.MinimumWidth = 10;
            Column3.Name = "Column3";
            Column3.Width = 200;
            // 
            // Column4
            // 
            Column4.HeaderText = "ACCOUNT_ST";
            Column4.MinimumWidth = 10;
            Column4.Name = "Column4";
            Column4.Width = 200;
            // 
            // Column5
            // 
            Column5.HeaderText = "LOCK_DATE";
            Column5.MinimumWidth = 10;
            Column5.Name = "Column5";
            Column5.Width = 200;
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(btnDeleteRole);
            tabPage10.Controls.Add(btnUpdateRole);
            tabPage10.Controls.Add(btnCreateRole);
            tabPage10.Controls.Add(dataGridView2);
            tabPage10.Location = new Point(8, 46);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(1511, 689);
            tabPage10.TabIndex = 2;
            tabPage10.Text = "ROLE";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRole
            // 
            btnDeleteRole.Location = new Point(1204, 164);
            btnDeleteRole.Name = "btnDeleteRole";
            btnDeleteRole.Size = new Size(266, 72);
            btnDeleteRole.TabIndex = 4;
            btnDeleteRole.Text = "Xóa Role";
            btnDeleteRole.UseVisualStyleBackColor = true;
            btnDeleteRole.Click += btnDeleteRole_Click;
            // 
            // btnUpdateRole
            // 
            btnUpdateRole.Location = new Point(1204, 300);
            btnUpdateRole.Name = "btnUpdateRole";
            btnUpdateRole.Size = new Size(266, 72);
            btnUpdateRole.TabIndex = 3;
            btnUpdateRole.Text = "Sửa Role";
            btnUpdateRole.UseVisualStyleBackColor = true;
            btnUpdateRole.Click += btnUpdateRole_Click;
            // 
            // btnCreateRole
            // 
            btnCreateRole.Location = new Point(1204, 45);
            btnCreateRole.Name = "btnCreateRole";
            btnCreateRole.Size = new Size(266, 72);
            btnCreateRole.TabIndex = 2;
            btnCreateRole.Text = "Tạo Role";
            btnCreateRole.UseVisualStyleBackColor = true;
            btnCreateRole.Click += btnCreateRole_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridView2.Location = new Point(0, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(1084, 655);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "ROLE";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "ROLE_ID";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "PASSWORD";
            dataGridViewTextBoxColumn3.MinimumWidth = 10;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "AUTHENTICATION";
            dataGridViewTextBoxColumn4.MinimumWidth = 10;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "COMMON";
            dataGridViewTextBoxColumn5.MinimumWidth = 10;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 200;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1554, 835);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1554, 835);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(8, 46);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1554, 835);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(8, 46);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1554, 835);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(8, 46);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1554, 835);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "tabPage6";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(8, 46);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1554, 835);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "tabPage7";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1570, 889);
            Controls.Add(tabControl1);
            Margin = new Padding(5);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang admin";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private TabControl tabControl2;
        private TabPage tabPage8;
        private Button button4;
        private TabPage tabPage10;
        private DataGridView dataGridView2;
        private Button btnDeleteRole;
        private Button btnUpdateRole;
        private Button btnCreateRole;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Panel panel1;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private Button btnCreateUser;
    }
}