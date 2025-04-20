namespace Project_ATBM
{
    partial class GrantPrivilegeForm
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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(54, 59);
            radioButton1.Margin = new Padding(5, 5, 5, 5);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(92, 36);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "User";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(250, 59);
            radioButton2.Margin = new Padding(5, 5, 5, 5);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(91, 36);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Role";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(474, 59);
            radioButton3.Margin = new Padding(5, 5, 5, 5);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(189, 36);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Role cho user";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(54, 150);
            comboBox1.Margin = new Padding(5, 5, 5, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(243, 40);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "User";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(408, 150);
            comboBox2.Margin = new Padding(5, 5, 5, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(243, 40);
            comboBox2.TabIndex = 4;
            comboBox2.Text = "Role";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(54, 240);
            comboBox3.Margin = new Padding(5, 5, 5, 5);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(243, 40);
            comboBox3.TabIndex = 5;
            comboBox3.Text = "Chọn quyền";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(54, 333);
            comboBox4.Margin = new Padding(5, 5, 5, 5);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(243, 40);
            comboBox4.TabIndex = 6;
            comboBox4.Text = "Đối tượng dữ liệu";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(54, 419);
            comboBox5.Margin = new Padding(5, 5, 5, 5);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(243, 40);
            comboBox5.TabIndex = 7;
            comboBox5.Text = "Đối tượng";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(54, 512);
            checkBox1.Margin = new Padding(5, 5, 5, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(280, 36);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "WITH GRANT OPTION";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(54, 608);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(153, 46);
            button1.TabIndex = 9;
            button1.Text = "Cấp quyền";
            button1.UseVisualStyleBackColor = true;
            // 
            // GrantPrivilegeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "GrantPrivilegeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GrantPrivilegeForm";
            Load += GrantPrivilegeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private CheckBox checkBox1;
        private Button button1;
    }
}