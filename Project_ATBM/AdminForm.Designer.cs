﻿namespace Project_ATBM
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
            tabPage3 = new TabPage();
            button2 = new Button();
            tabControl4 = new TabControl();
            tabPage12 = new TabPage();
            panel10 = new Panel();
            button8 = new Button();
            button7 = new Button();
            panel8 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            btnSearchUser = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView5 = new DataGridView();
            tabPage13 = new TabPage();
            panel11 = new Panel();
            button9 = new Button();
            button10 = new Button();
            panel9 = new Panel();
            radioButton4 = new RadioButton();
            panel3 = new Panel();
            btnSearchRole = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            dataGridView6 = new DataGridView();
            tabPage1 = new TabPage();
            button4 = new Button();
            tabControl2 = new TabControl();
            tabPage8 = new TabPage();
            panel4 = new Panel();
            btnFilterUser = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            button3 = new Button();
            btnRoleToUser = new Button();
            btnCapQuyen = new Button();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            btnCreateUser = new Button();
            dataGridView1 = new DataGridView();
            tabPage10 = new TabPage();
            btnCapQuyenRole = new Button();
            panel5 = new Panel();
            button1 = new Button();
            textBox4 = new TextBox();
            label4 = new Label();
            btnDeleteRole = new Button();
            btnUpdateRole = new Button();
            btnCreateRole = new Button();
            dataGridView2 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage3.SuspendLayout();
            tabControl4.SuspendLayout();
            tabPage12.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            tabPage13.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView6).BeginInit();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage8.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage10.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.ActiveCaption;
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(tabControl4);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(982, 544);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Thông tin quyền";
            // 
            // button2
            // 
            button2.BackColor = Color.LightCoral;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(773, 486);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(164, 45);
            button2.TabIndex = 7;
            button2.Text = "Đăng xuất";
            button2.UseVisualStyleBackColor = false;
            // 
            // tabControl4
            // 
            tabControl4.Controls.Add(tabPage12);
            tabControl4.Controls.Add(tabPage13);
            tabControl4.ItemSize = new Size(120, 25);
            tabControl4.Location = new Point(13, 12);
            tabControl4.Margin = new Padding(2);
            tabControl4.Name = "tabControl4";
            tabControl4.SelectedIndex = 0;
            tabControl4.Size = new Size(952, 498);
            tabControl4.TabIndex = 0;
            tabControl4.SelectedIndexChanged += tabControl4_SelectedIndexChanged;
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(panel10);
            tabPage12.Controls.Add(panel8);
            tabPage12.Controls.Add(panel2);
            tabPage12.Controls.Add(dataGridView5);
            tabPage12.Location = new Point(4, 29);
            tabPage12.Margin = new Padding(2);
            tabPage12.Name = "tabPage12";
            tabPage12.Padding = new Padding(2);
            tabPage12.Size = new Size(944, 465);
            tabPage12.TabIndex = 0;
            tabPage12.Text = "User";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            panel10.Controls.Add(button8);
            panel10.Controls.Add(button7);
            panel10.Location = new Point(658, 287);
            panel10.Margin = new Padding(2);
            panel10.Name = "panel10";
            panel10.Size = new Size(282, 166);
            panel10.TabIndex = 3;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.ButtonHighlight;
            button8.Location = new Point(87, 78);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(178, 48);
            button8.TabIndex = 1;
            button8.Text = "Xóa tất cả quyền";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ButtonHighlight;
            button7.Location = new Point(86, 13);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(178, 48);
            button7.TabIndex = 0;
            button7.Text = "Xóa quyền được chọn";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(radioButton2);
            panel8.Controls.Add(radioButton1);
            panel8.Location = new Point(657, 11);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(281, 97);
            panel8.TabIndex = 2;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(33, 58);
            radioButton2.Margin = new Padding(2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(111, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Trên column";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(33, 15);
            radioButton1.Margin = new Padding(2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Trên object";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSearchUser);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(657, 112);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(280, 171);
            panel2.TabIndex = 1;
            // 
            // btnSearchUser
            // 
            btnSearchUser.BackColor = Color.LimeGreen;
            btnSearchUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchUser.ForeColor = SystemColors.ButtonHighlight;
            btnSearchUser.Location = new Point(173, 105);
            btnSearchUser.Margin = new Padding(2);
            btnSearchUser.Name = "btnSearchUser";
            btnSearchUser.Size = new Size(92, 35);
            btnSearchUser.TabIndex = 2;
            btnSearchUser.Text = "Tìm kiếm";
            btnSearchUser.UseVisualStyleBackColor = false;
            btnSearchUser.Click += btnSearchUser_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 56);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(258, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập tên User:";
            label1.Click += label1_Click;
            // 
            // dataGridView5
            // 
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(4, 0);
            dataGridView5.Margin = new Padding(2);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.RowHeadersWidth = 82;
            dataGridView5.Size = new Size(642, 444);
            dataGridView5.TabIndex = 0;
            dataGridView5.CellContentClick += dataGridView5_CellContentClick;
            // 
            // tabPage13
            // 
            tabPage13.Controls.Add(panel11);
            tabPage13.Controls.Add(panel9);
            tabPage13.Controls.Add(panel3);
            tabPage13.Controls.Add(dataGridView6);
            tabPage13.Location = new Point(4, 29);
            tabPage13.Margin = new Padding(2);
            tabPage13.Name = "tabPage13";
            tabPage13.Padding = new Padding(2);
            tabPage13.Size = new Size(944, 465);
            tabPage13.TabIndex = 1;
            tabPage13.Text = "Role";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            panel11.Controls.Add(button9);
            panel11.Controls.Add(button10);
            panel11.Location = new Point(658, 287);
            panel11.Margin = new Padding(2);
            panel11.Name = "panel11";
            panel11.Size = new Size(282, 141);
            panel11.TabIndex = 4;
            // 
            // button9
            // 
            button9.BackColor = Color.Red;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button9.ForeColor = SystemColors.ButtonHighlight;
            button9.Location = new Point(87, 78);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(178, 48);
            button9.TabIndex = 1;
            button9.Text = "Xóa tất cả quyền";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Red;
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button10.ForeColor = SystemColors.ButtonHighlight;
            button10.Location = new Point(86, 13);
            button10.Margin = new Padding(2);
            button10.Name = "button10";
            button10.Size = new Size(178, 48);
            button10.TabIndex = 0;
            button10.Text = "Xóa quyền được chọn";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(radioButton4);
            panel9.Location = new Point(657, 11);
            panel9.Margin = new Padding(2);
            panel9.Name = "panel9";
            panel9.Size = new Size(281, 72);
            panel9.TabIndex = 3;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Checked = true;
            radioButton4.Location = new Point(33, 15);
            radioButton4.Margin = new Padding(2);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(104, 24);
            radioButton4.TabIndex = 0;
            radioButton4.TabStop = true;
            radioButton4.Text = "Trên object";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSearchRole);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(657, 112);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 180);
            panel3.TabIndex = 1;
            // 
            // btnSearchRole
            // 
            btnSearchRole.BackColor = Color.LimeGreen;
            btnSearchRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchRole.ForeColor = SystemColors.ButtonHighlight;
            btnSearchRole.Location = new Point(173, 105);
            btnSearchRole.Margin = new Padding(2);
            btnSearchRole.Name = "btnSearchRole";
            btnSearchRole.Size = new Size(92, 35);
            btnSearchRole.TabIndex = 3;
            btnSearchRole.Text = "Tìm kiếm";
            btnSearchRole.UseVisualStyleBackColor = false;
            btnSearchRole.Click += btnSearchRole_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 56);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(259, 27);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 23);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập tên Role:";
            // 
            // dataGridView6
            // 
            dataGridView6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView6.Location = new Point(4, 0);
            dataGridView6.Margin = new Padding(2);
            dataGridView6.Name = "dataGridView6";
            dataGridView6.RowHeadersWidth = 82;
            dataGridView6.Size = new Size(642, 444);
            dataGridView6.TabIndex = 0;
            dataGridView6.CellContentClick += dataGridView6_CellContentClick;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ActiveCaption;
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(2, 2, 4, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(982, 544);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "User & Role";
            // 
            // button4
            // 
            button4.BackColor = Color.LightCoral;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(773, 486);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(164, 45);
            button4.TabIndex = 5;
            button4.Text = "Đăng xuất";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage8);
            tabControl2.Controls.Add(tabPage10);
            tabControl2.Location = new Point(13, 12);
            tabControl2.Margin = new Padding(2);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(952, 498);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.TabIndex = 2;
            tabControl2.SelectedIndexChanged += tabControl2_SelectedIndexChanged;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(panel4);
            tabPage8.Controls.Add(panel1);
            tabPage8.Controls.Add(dataGridView1);
            tabPage8.Location = new Point(4, 29);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(2);
            tabPage8.Size = new Size(944, 465);
            tabPage8.TabIndex = 0;
            tabPage8.Text = "USER";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnFilterUser);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(675, 321);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(262, 120);
            panel4.TabIndex = 6;
            // 
            // btnFilterUser
            // 
            btnFilterUser.BackColor = Color.LimeGreen;
            btnFilterUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilterUser.ForeColor = SystemColors.ButtonHighlight;
            btnFilterUser.Location = new Point(168, 76);
            btnFilterUser.Margin = new Padding(2);
            btnFilterUser.Name = "btnFilterUser";
            btnFilterUser.Size = new Size(92, 35);
            btnFilterUser.TabIndex = 2;
            btnFilterUser.Text = "Tìm kiếm";
            btnFilterUser.UseVisualStyleBackColor = false;
            btnFilterUser.Click += btnFilterUser_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(7, 45);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(253, 27);
            textBox3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 13);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 0;
            label3.Text = "Nhập tên User:";
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnRoleToUser);
            panel1.Controls.Add(btnCapQuyen);
            panel1.Controls.Add(btnDeleteUser);
            panel1.Controls.Add(btnUpdateUser);
            panel1.Controls.Add(btnCreateUser);
            panel1.Location = new Point(677, 18);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 299);
            panel1.TabIndex = 5;
            // 
            // button3
            // 
            button3.BackColor = Color.LimeGreen;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(51, 251);
            button3.Name = "button3";
            button3.Size = new Size(164, 45);
            button3.TabIndex = 7;
            button3.Text = "Thu hồi role";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnRoleToUser
            // 
            btnRoleToUser.BackColor = Color.LimeGreen;
            btnRoleToUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRoleToUser.ForeColor = SystemColors.ButtonHighlight;
            btnRoleToUser.Location = new Point(51, 201);
            btnRoleToUser.Name = "btnRoleToUser";
            btnRoleToUser.Size = new Size(164, 45);
            btnRoleToUser.TabIndex = 6;
            btnRoleToUser.Text = "Cấp role";
            btnRoleToUser.UseVisualStyleBackColor = false;
            btnRoleToUser.Click += GrantRoleToUser_Click;
            // 
            // btnCapQuyen
            // 
            btnCapQuyen.BackColor = Color.LimeGreen;
            btnCapQuyen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapQuyen.ForeColor = SystemColors.ButtonHighlight;
            btnCapQuyen.Location = new Point(51, 150);
            btnCapQuyen.Name = "btnCapQuyen";
            btnCapQuyen.Size = new Size(164, 45);
            btnCapQuyen.TabIndex = 5;
            btnCapQuyen.Text = "Cấp quyền";
            btnCapQuyen.UseVisualStyleBackColor = false;
            btnCapQuyen.Click += btnCapQuyen_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.LimeGreen;
            btnDeleteUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteUser.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteUser.Location = new Point(51, 51);
            btnDeleteUser.Margin = new Padding(2);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(164, 45);
            btnDeleteUser.TabIndex = 4;
            btnDeleteUser.Text = "Xóa User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BackColor = Color.LimeGreen;
            btnUpdateUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateUser.ForeColor = SystemColors.ButtonHighlight;
            btnUpdateUser.Location = new Point(51, 100);
            btnUpdateUser.Margin = new Padding(2);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(164, 45);
            btnUpdateUser.TabIndex = 3;
            btnUpdateUser.Text = "Sửa User";
            btnUpdateUser.UseVisualStyleBackColor = false;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.BackColor = Color.LimeGreen;
            btnCreateUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateUser.ForeColor = SystemColors.ButtonHighlight;
            btnCreateUser.Location = new Point(51, 2);
            btnCreateUser.Margin = new Padding(2);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(164, 45);
            btnCreateUser.TabIndex = 2;
            btnCreateUser.Text = "Tạo User";
            btnCreateUser.UseVisualStyleBackColor = false;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(4, 0);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(667, 409);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage10
            // 
            tabPage10.BackColor = SystemColors.ButtonFace;
            tabPage10.Controls.Add(btnCapQuyenRole);
            tabPage10.Controls.Add(panel5);
            tabPage10.Controls.Add(btnDeleteRole);
            tabPage10.Controls.Add(btnUpdateRole);
            tabPage10.Controls.Add(btnCreateRole);
            tabPage10.Controls.Add(dataGridView2);
            tabPage10.Location = new Point(4, 29);
            tabPage10.Margin = new Padding(2);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(2);
            tabPage10.Size = new Size(944, 465);
            tabPage10.TabIndex = 2;
            tabPage10.Text = "ROLE";
            // 
            // btnCapQuyenRole
            // 
            btnCapQuyenRole.BackColor = Color.LimeGreen;
            btnCapQuyenRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapQuyenRole.ForeColor = SystemColors.ButtonHighlight;
            btnCapQuyenRole.Location = new Point(728, 169);
            btnCapQuyenRole.Name = "btnCapQuyenRole";
            btnCapQuyenRole.Size = new Size(164, 45);
            btnCapQuyenRole.TabIndex = 9;
            btnCapQuyenRole.Text = "Cấp quyền";
            btnCapQuyenRole.UseVisualStyleBackColor = false;
            btnCapQuyenRole.Click += btnCapQuyenRole_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(button1);
            panel5.Controls.Add(textBox4);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(675, 275);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(262, 157);
            panel5.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(170, 98);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 35);
            button1.TabIndex = 3;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(7, 45);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(253, 27);
            textBox4.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(7, 13);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 0;
            label4.Text = "Nhập tên Role:";
            // 
            // btnDeleteRole
            // 
            btnDeleteRole.BackColor = Color.LimeGreen;
            btnDeleteRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteRole.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteRole.Location = new Point(728, 70);
            btnDeleteRole.Margin = new Padding(2);
            btnDeleteRole.Name = "btnDeleteRole";
            btnDeleteRole.Size = new Size(164, 45);
            btnDeleteRole.TabIndex = 4;
            btnDeleteRole.Text = "Xóa Role";
            btnDeleteRole.UseVisualStyleBackColor = false;
            btnDeleteRole.Click += btnDeleteRole_Click;
            // 
            // btnUpdateRole
            // 
            btnUpdateRole.BackColor = Color.LimeGreen;
            btnUpdateRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateRole.ForeColor = SystemColors.ButtonHighlight;
            btnUpdateRole.Location = new Point(728, 119);
            btnUpdateRole.Margin = new Padding(2);
            btnUpdateRole.Name = "btnUpdateRole";
            btnUpdateRole.Size = new Size(164, 45);
            btnUpdateRole.TabIndex = 3;
            btnUpdateRole.Text = "Sửa Role";
            btnUpdateRole.UseVisualStyleBackColor = false;
            btnUpdateRole.Click += btnUpdateRole_Click;
            // 
            // btnCreateRole
            // 
            btnCreateRole.BackColor = Color.LimeGreen;
            btnCreateRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateRole.ForeColor = SystemColors.ButtonHighlight;
            btnCreateRole.Location = new Point(728, 21);
            btnCreateRole.Margin = new Padding(2);
            btnCreateRole.Name = "btnCreateRole";
            btnCreateRole.Size = new Size(164, 45);
            btnCreateRole.TabIndex = 2;
            btnCreateRole.Text = "Tạo Role";
            btnCreateRole.UseVisualStyleBackColor = false;
            btnCreateRole.Click += btnCreateRole_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(4, 0);
            dataGridView2.Margin = new Padding(2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(667, 409);
            dataGridView2.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(990, 577);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 577);
            Controls.Add(tabControl1);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang admin";
            Load += AdminForm_Load;
            tabPage3.ResumeLayout(false);
            tabControl4.ResumeLayout(false);
            tabPage12.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            tabPage13.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView6).EndInit();
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage10.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage3;
        private Button button2;
        private TabControl tabControl4;
        private TabPage tabPage12;
        private Panel panel10;
        private Button button8;
        private Button button7;
        private Panel panel8;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private Button btnSearchUser;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView5;
        private TabPage tabPage13;
        private Panel panel11;
        private Button button9;
        private Button button10;
        private Panel panel9;
        private RadioButton radioButton4;
        private Panel panel3;
        private Button btnSearchRole;
        private TextBox textBox2;
        private Label label2;
        private DataGridView dataGridView6;
        private TabPage tabPage1;
        private Button button4;
        private TabControl tabControl2;
        private TabPage tabPage8;
        private Panel panel4;
        private Button btnFilterUser;
        private TextBox textBox3;
        private Label label3;
        private Panel panel1;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private Button btnCreateUser;
        private DataGridView dataGridView1;
        private TabPage tabPage10;
        private Panel panel5;
        private TextBox textBox4;
        private Label label4;
        private Button btnDeleteRole;
        private Button btnUpdateRole;
        private Button btnCreateRole;
        private DataGridView dataGridView2;
        private TabControl tabControl1;
        private Button btnCapQuyen;
        private Button btnCapQuyenRole;
        private Button btnRoleToUser;
        private Button button1;
        private Button button3;
    }
}