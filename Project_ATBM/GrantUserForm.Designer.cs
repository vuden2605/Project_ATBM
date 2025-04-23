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
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
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
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 20);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 281);
            panel1.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(209, 202);
            checkBox2.Margin = new Padding(2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(179, 24);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Grant to columns level";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(208, 166);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(153, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "With grant opition";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(208, 122);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(208, 64);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(208, 16);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
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
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên User:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancelGrant);
            panel2.Controls.Add(btnSucessGrant);
            panel2.Location = new Point(230, 314);
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
            btnSucessGrant.Click += btnSucessGrant_Click_2;
            // 
            // GrantUserForm
            // 
            AcceptButton = btnSucessGrant;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 365);
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
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnCancelGrant;
        private Button btnSucessGrant;
        private CheckBox checkBox2;
    }
}