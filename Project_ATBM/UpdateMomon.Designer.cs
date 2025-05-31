namespace Project_ATBM
{
    partial class UpdateMomon
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
            label15 = new Label();
            textBox10 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(94, 74);
            label15.Name = "label15";
            label15.Size = new Size(265, 32);
            label15.TabIndex = 1;
            label15.Text = "Nhập mã giáo viên mới";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(94, 133);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(311, 39);
            textBox10.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.LimeGreen;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(313, 222);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(163, 53);
            button2.TabIndex = 14;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(94, 222);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(163, 51);
            button1.TabIndex = 15;
            button1.Text = "Hủy";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UpdateMomon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 385);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox10);
            Controls.Add(label15);
            Name = "UpdateMomon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateMomon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label15;
        private TextBox textBox10;
        private Button button2;
        private Button button1;
    }
}