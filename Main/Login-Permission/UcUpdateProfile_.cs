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
        private string userName;

        private EmployeeBus myEmployeeBus;

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
            var myEmployee = myEmployeeBus.GetByUsername(userName);
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
            var textBox = (BunifuMaterialTextbox)sender;
            textBox.Enabled = true;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
                var myEmployee = new Entity.Employee();
                myEmployee.FullName = txtFullName.Text;
                myEmployee.Email = txtEmail.Text;
                myEmployee.Address = txtAddress.Text;
                myEmployee.Identity = txtIdentity.Text;
                myEmployee.Phone = txtPhone.Text;
                myEmployee.UserName = userName;
                if (myEmployeeBus.UpdateProfile(myEmployee) != 0)
                {
                    MessageBox.Show("Thành công!"); 
                    this.SendToBack();
                }

                else
                    MessageBox.Show("Thất bại!");
            }
        }

        /// <summary>
        /// The IsEmail
        /// </summary>
        /// <param name="emailAddress">The emailaddress<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsEmail(string emailAddress)
        {
            try
            {
                var checkAddress = new MailAddress(emailAddress);
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
