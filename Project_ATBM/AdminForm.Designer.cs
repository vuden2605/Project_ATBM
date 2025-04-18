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
            menuStrip1 = new MenuStrip();
            userToolStripMenuItem = new ToolStripMenuItem();
            roleToolStripMenuItem = new ToolStripMenuItem();
            cấpQuyềnToolStripMenuItem = new ToolStripMenuItem();
            thuHồiQuyềnToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { userToolStripMenuItem, roleToolStripMenuItem, cấpQuyềnToolStripMenuItem, thuHồiQuyềnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(52, 24);
            userToolStripMenuItem.Text = "User";
            userToolStripMenuItem.Click += userToolStripMenuItem_Click;
            // 
            // roleToolStripMenuItem
            // 
            roleToolStripMenuItem.Name = "roleToolStripMenuItem";
            roleToolStripMenuItem.Size = new Size(53, 24);
            roleToolStripMenuItem.Text = "Role";
            roleToolStripMenuItem.Click += roleToolStripMenuItem_Click;
            // 
            // cấpQuyềnToolStripMenuItem
            // 
            cấpQuyềnToolStripMenuItem.Name = "cấpQuyềnToolStripMenuItem";
            cấpQuyềnToolStripMenuItem.Size = new Size(93, 24);
            cấpQuyềnToolStripMenuItem.Text = "Cấp quyền";
            cấpQuyềnToolStripMenuItem.Click += cấpQuyềnToolStripMenuItem_Click;
            // 
            // thuHồiQuyềnToolStripMenuItem
            // 
            thuHồiQuyềnToolStripMenuItem.Name = "thuHồiQuyềnToolStripMenuItem";
            thuHồiQuyềnToolStripMenuItem.Size = new Size(116, 24);
            thuHồiQuyềnToolStripMenuItem.Text = "Thu hồi quyền";
            thuHồiQuyềnToolStripMenuItem.Click += thuHồiQuyềnToolStripMenuItem_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang admin";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem roleToolStripMenuItem;
        private ToolStripMenuItem cấpQuyềnToolStripMenuItem;
        private ToolStripMenuItem thuHồiQuyềnToolStripMenuItem;
    }
}