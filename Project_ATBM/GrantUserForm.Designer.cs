namespace Project_ATBM
{
    partial class GrantUserForm
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
            cmbTenDoiTuong = new ComboBox();
            cmbLoaiDoiTuong = new ComboBox();
            lblTenDoiTuong = new Label();
            clbDanhSachCot = new CheckedListBox();
            clbQuyenTruyCap = new CheckedListBox();
            lblLoaiDoiTuong = new Label();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            btnCancelGrant = new Button();
            btnSucessGrant = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbTenDoiTuong);
            panel1.Controls.Add(cmbLoaiDoiTuong);
            panel1.Controls.Add(lblTenDoiTuong);
            panel1.Controls.Add(clbDanhSachCot);
            panel1.Controls.Add(clbQuyenTruyCap);
            panel1.Controls.Add(lblLoaiDoiTuong);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 20);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(708, 330);
            panel1.TabIndex = 0;
            // 
            // cmbTenDoiTuong
            // 
            cmbTenDoiTuong.FormattingEnabled = true;
            cmbTenDoiTuong.Location = new Point(119, 195);
            cmbTenDoiTuong.Name = "cmbTenDoiTuong";
            cmbTenDoiTuong.Size = new Size(218, 28);
            cmbTenDoiTuong.TabIndex = 15;
            // 
            // cmbLoaiDoiTuong
            // 
            cmbLoaiDoiTuong.FormattingEnabled = true;
            cmbLoaiDoiTuong.Items.AddRange(new object[] { "TABLE", "VIEW", "PROCEDURE", "FUNCTION" });
            cmbLoaiDoiTuong.Location = new Point(119, 102);
            cmbLoaiDoiTuong.Name = "cmbLoaiDoiTuong";
            cmbLoaiDoiTuong.Size = new Size(218, 28);
            cmbLoaiDoiTuong.TabIndex = 14;
            cmbLoaiDoiTuong.SelectedIndexChanged += cmbLoaiDoiTuong_SelectedIndexChanged;
            // 
            // lblTenDoiTuong
            // 
            lblTenDoiTuong.AutoSize = true;
            lblTenDoiTuong.Location = new Point(6, 198);
            lblTenDoiTuong.Name = "lblTenDoiTuong";
            lblTenDoiTuong.Size = new Size(105, 20);
            lblTenDoiTuong.TabIndex = 13;
            lblTenDoiTuong.Text = "Tên đối tượng:";
            // 
            // clbDanhSachCot
            // 
            clbDanhSachCot.FormattingEnabled = true;
            clbDanhSachCot.Location = new Point(365, 138);
            clbDanhSachCot.Name = "clbDanhSachCot";
            clbDanhSachCot.Size = new Size(320, 158);
            clbDanhSachCot.TabIndex = 12;
            // 
            // clbQuyenTruyCap
            // 
            clbQuyenTruyCap.FormattingEnabled = true;
            clbQuyenTruyCap.Items.AddRange(new object[] { "SELECT", "INSERT", "UPDATE", "DELETE" });
            clbQuyenTruyCap.Location = new Point(365, 18);
            clbQuyenTruyCap.Name = "clbQuyenTruyCap";
            clbQuyenTruyCap.Size = new Size(320, 114);
            clbQuyenTruyCap.TabIndex = 11;
            clbQuyenTruyCap.SelectedIndexChanged += clbQuyenTruyCap_SelectedIndexChanged;
            // 
            // lblLoaiDoiTuong
            // 
            lblLoaiDoiTuong.AutoSize = true;
            lblLoaiDoiTuong.Location = new Point(6, 105);
            lblLoaiDoiTuong.Name = "lblLoaiDoiTuong";
            lblLoaiDoiTuong.Size = new Size(110, 20);
            lblLoaiDoiTuong.TabIndex = 8;
            lblLoaiDoiTuong.Text = "Loại đối tượng:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(119, 272);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(153, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "With grant opition";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 18);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên User:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancelGrant);
            panel2.Controls.Add(btnSucessGrant);
            panel2.Location = new Point(484, 354);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(216, 32);
            panel2.TabIndex = 1;
            // 
            // btnCancelGrant
            // 
            btnCancelGrant.Location = new Point(133, 2);
            btnCancelGrant.Margin = new Padding(2);
            btnCancelGrant.Name = "btnCancelGrant";
            btnCancelGrant.Size = new Size(83, 29);
            btnCancelGrant.TabIndex = 1;
            btnCancelGrant.Text = "Cancel";
            btnCancelGrant.UseVisualStyleBackColor = true;
            btnCancelGrant.Click += btnCancelGrant_Click_1;
            // 
            // btnSucessGrant
            // 
            btnSucessGrant.Location = new Point(0, 1);
            btnSucessGrant.Margin = new Padding(2);
            btnSucessGrant.Name = "btnSucessGrant";
            btnSucessGrant.Size = new Size(83, 29);
            btnSucessGrant.TabIndex = 0;
            btnSucessGrant.Text = "OK";
            btnSucessGrant.UseVisualStyleBackColor = true;
            btnSucessGrant.Click += btnSucessGrant_Click;
            // 
            // GrantUserForm
            // 
            AcceptButton = btnSucessGrant;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 395);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "GrantUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấp quyền cho User";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Button btnCancelGrant;
        private Button btnSucessGrant;
        private Label lblLoaiDoiTuong;
        private CheckedListBox clbDanhSachCot;
        private CheckedListBox clbQuyenTruyCap;
        private Label lblTenDoiTuong;
        private ComboBox cmbTenDoiTuong;
        private ComboBox cmbLoaiDoiTuong;
    }
}