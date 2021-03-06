﻿namespace Main
{
    using Bunifu.Framework.UI;
    using BusinessLayer;
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Login_" />
    /// </summary>
    public partial class Login_ : Form
    {
        /// <summary>
        /// Defines the myEmployeeBus
        /// </summary>
        internal EmployeeBus employeeBus = new EmployeeBus();

        /// <summary>
        /// Defines the result
        /// </summary>
        private int result = 0;

        /// <summary>
        /// Defines the username
        /// </summary>
        private string username;


        /// <summary>
        /// Initializes a new instance of the <see cref="Login_"/> class.
        /// </summary>
        public Login_()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// The btnCancel_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblExit_Click(lblExit, e);
        }

        /// <summary>
        /// The lblExit_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void lblExit_Click(object sender, EventArgs e)
        {
            var myDialogResult = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
                Application.Exit();
        }
        

        /// <summary>
        /// The btnOk_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            lblNotify.Text = String.Empty;
            if (String.IsNullOrWhiteSpace(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                lblNotify.Text = "Vui lòng nhập đầy đủ thông tin đăng nhập.";
                txtUserName.Focus();
                return;
            }
            result = employeeBus.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (result>0)
            {
                username = txtUserName.Text.Trim();
                var threadMainForm = new Thread(new ThreadStart(ShowFormMain));
                threadMainForm.SetApartmentState(ApartmentState.STA);
                threadMainForm.Start();
                Application.Exit();
            }
            else if(result==-1)
            {
                lblNotify.Text = "Có lỗi xảy ra trong hệ thống.";
            }
            else if(result==0)
            {
                lblNotify.Text = "Tên tài khoản hoặc mật khẩu không chính xác.";
                txtPassword.Focus();
                txtPassword.Text=String.Empty;
            }
        }

        /// <summary>
        /// The ShowFormMain
        /// </summary>
        private void ShowFormMain()
        {
            var f = new FormMain_(result,username);
            f.ShowDialog();
        }

        /// <summary>
        /// The login_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtLoginInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(btnOk,e);
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = txtPassword.Text != String.Empty;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            ((BunifuMaterialTextbox) sender).Text = String.Empty;
        }
    }
}
