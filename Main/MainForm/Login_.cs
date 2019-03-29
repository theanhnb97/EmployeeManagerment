using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using BusinessLayer;

namespace Main
{
    public partial class Login_ : Form
    {
        EmployeeBus myEmployeeBus = new EmployeeBus();

        public Login_()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblExit_Click(lblExit, e);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button3);
            if (myDialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private int result = 0;
        private string username;
        private void btnOk_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                lblNotify.Text = "Please input username/password.";
                lblNotify.Visible = true;
                txtUserName.Focus();
                return;
            }
            result = myEmployeeBus.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (result!=0)
            {
                username = txtUserName.Text.Trim();
                Thread threadMainForm = new Thread(new ThreadStart(ShowFormMain));
                threadMainForm.Start();
                Application.Exit();
            }
            else
            {
                lblNotify.Text = "UserName or Password is not correct.";
                lblNotify.Visible = true;
                txtPassword.Focus();
                txtPassword.Text="";
            }
        }
        private void ShowFormMain()
        {
            FormMain_ f = new FormMain_(result,username);
            f.ShowDialog();
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(btnOk,e);
        }
    }
}
