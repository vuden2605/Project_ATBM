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
            panel1.Location = new Point(35, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 449);
            panel1.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(339, 324);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(287, 36);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Grant to columns level";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(338, 266);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(242, 36);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "With grant opition";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(338, 196);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(351, 39);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(338, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(351, 39);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(338, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 39);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 199);
            label3.Name = "label3";
            label3.Size = new Size(131, 32);
            label3.TabIndex = 2;
            label3.Text = "Tên quyền:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 110);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên bảng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 33);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 0;
            label1.Text = "Tên User:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancelGrant);
            panel2.Controls.Add(btnSucessGrant);
            panel2.Location = new Point(373, 503);
            panel2.Name = "panel2";
            panel2.Size = new Size(351, 51);
            panel2.TabIndex = 1;
            // 
            // btnCancelGrant
            // 
            btnCancelGrant.Location = new Point(216, 3);
            btnCancelGrant.Name = "btnCancelGrant";
            btnCancelGrant.Size = new Size(135, 46);
            btnCancelGrant.TabIndex = 1;
            btnCancelGrant.Text = "Cancel";
            btnCancelGrant.UseVisualStyleBackColor = true;
            btnCancelGrant.Click += btnCancelGrant_Click_1;
            // 
            // btnSucessGrant
            // 
            btnSucessGrant.Location = new Point(0, 2);
            btnSucessGrant.Name = "btnSucessGrant";
            btnSucessGrant.Size = new Size(135, 46);
            btnSucessGrant.TabIndex = 0;
            btnSucessGrant.Text = "OK";
            btnSucessGrant.UseVisualStyleBackColor = true;
            btnSucessGrant.Click += btnSucessGrant_Click_2;
            // 
            // GrantUserForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 584);
            Controls.Add(panel2);
            Controls.Add(panel1);
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