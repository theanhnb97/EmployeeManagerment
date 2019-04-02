namespace Main
{
    using Bunifu.Framework.UI;
    using BusinessLayer;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="UcUpdateProfile_" />
    /// </summary>
    public partial class UcUpdateProfile_ : UserControl
    {
        /// <summary>
        /// Defines the userName
        /// </summary>
        private string userName;

        /// <summary>
        /// Defines the myEmployeeBus
        /// </summary>
        private EmployeeBus myEmployeeBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="UcUpdateProfile_"/> class.
        /// </summary>
        /// <param name="username">The username<see cref="string"/></param>
        public UcUpdateProfile_(string username)
        {
            myEmployeeBus = new EmployeeBus();
            this.userName = username;
            InitializeComponent();
        }

        /// <summary>
        /// The UcUpdateProfile_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void UcUpdateProfile_Load(object sender, EventArgs e)
        {
            Entity.Employee myEmployee = myEmployeeBus.GetByUsername(userName);
            txtFullName.Text = myEmployee.FullName;
            txtEmail.Text = myEmployee.Email;
            txtAddress.Text = myEmployee.Address;
            txtIdentity.Text = myEmployee.Identity;
            txtPhone.Text = myEmployee.Phone;
        }

        /// <summary>
        /// The txtEdit_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtEdit_Click(object sender, EventArgs e)
        {
            BunifuMaterialTextbox myTextbox = (BunifuMaterialTextbox)sender;
            myTextbox.Enabled = true;
        }

        /// <summary>
        /// The txtEditLeave_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtEditLeave_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The Key_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void Key_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsEmail(txtEmail.Text))
            {
                Entity.Employee myEmployee = new Entity.Employee();
                myEmployee.FullName = txtFullName.Text;
                myEmployee.Email = txtEmail.Text;
                myEmployee.Address = txtAddress.Text;
                myEmployee.Identity = txtIdentity.Text;
                myEmployee.Phone = txtPhone.Text;
                myEmployee.UserName = userName;
                if (myEmployeeBus.UpdateProfile(myEmployee) != 0)
                    MessageBox.Show("Thành công!");
                else
                    MessageBox.Show("Thất bại!");
            }
        }

        /// <summary>
        /// The IsEmail
        /// </summary>
        /// <param name="emailaddress">The emailaddress<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Email sai định dạng.");
                return false;
            }
        }
    }
}
