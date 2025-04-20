using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ATBM
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoleForm roleForm = new RoleForm();
            roleForm.ShowDialog();
        }

        private void thuHồiQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cấpQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GrantPrivilegeForm grantPrivilegeForm = new GrantPrivilegeForm();
            grantPrivilegeForm.ShowDialog();
        }
    }
}
