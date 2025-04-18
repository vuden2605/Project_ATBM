namespace Project_ATBM
{
    partial class RoleForm
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
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            btnadd = new Button();
            panel1 = new Panel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            button5 = new Button();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnadd);
            panel2.Location = new Point(43, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(597, 70);
            panel2.TabIndex = 7;
            // 
            // button4
            // 
            button4.Location = new Point(463, 23);
            button4.Name = "button4";
            button4.Size = new Size(97, 29);
            button4.TabIndex = 3;
            button4.Text = "Xem";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(338, 23);
            button3.Name = "button3";
            button3.Size = new Size(106, 29);
            button3.TabIndex = 2;
            button3.Text = "Sửa";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(181, 23);
            button2.Name = "button2";
            button2.Size = new Size(111, 29);
            button2.TabIndex = 1;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnadd
            // 
            btnadd.Location = new Point(25, 23);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(111, 29);
            btnadd.TabIndex = 0;
            btnadd.Text = "Thêm";
            btnadd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(43, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(674, 307);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 15);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 1;
            label1.Text = "Danh sách role";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(630, 224);
            dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(button5);
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(674, 55);
            panel3.Name = "panel3";
            panel3.Size = new Size(358, 70);
            panel3.TabIndex = 9;
            // 
            // button5
            // 
            button5.Location = new Point(244, 24);
            button5.Name = "button5";
            button5.Size = new Size(98, 29);
            button5.TabIndex = 1;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 27);
            textBox1.TabIndex = 0;
            // 
            // RoleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "RoleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoleForm";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnadd;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Button button5;
        private TextBox textBox1;
    }
}