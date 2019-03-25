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
using BusinessLayer;

namespace Main
{
    public partial class Login : Form
    {
        EmployeeBus myEmployeeBus=new EmployeeBus();

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
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = myEmployeeBus.Login1(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            //if (myEmployeeBus.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
            //{
            //    Thread threadMainForm = new Thread(new ThreadStart(ShowFormMain));
            //    threadMainForm.Start();
            //    Application.Exit();
            //}
            //else
            //{
            //    MessageBox.Show("UserName or Password is not correct!");
            //}
        }
        private void ShowFormMain()
        {
            FormMain f = new FormMain();
            f.ShowDialog();
        }

    }
}
