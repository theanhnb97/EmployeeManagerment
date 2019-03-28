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
    public partial class Login : Form
    {
        EmployeeBus myEmployeeBus = new EmployeeBus();

        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Do you want exit?", "Question",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button3);
            if (myDialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private int result = 0;
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
            FormMain f = new FormMain(result);
            f.ShowDialog();
        }


        private void textBox_Leave(object sender, EventArgs e)
        {
            BunifuMaterialTextbox myTextBox = (BunifuMaterialTextbox)sender;
            if (myTextBox.Text == "")
            {
                myTextBox.Text = "Username";
                myTextBox.ForeColor = Color.Silver;
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            BunifuMaterialTextbox myTextBox = (BunifuMaterialTextbox)sender;
            if (myTextBox.Text == "Username")
            {
                myTextBox.Text = "";
                myTextBox.ForeColor = Color.Black;
            }
        }
        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(btnOk,e);
        }
    }
}
