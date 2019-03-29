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
using Bunifu.Framework.UI;
using BusinessLayer;

namespace Main
{
    public partial class UcUpdateProfile : UserControl
    {
        private string userName;
        private EmployeeBus myEmployeeBus;
        public UcUpdateProfile(string username)
        {
            myEmployeeBus = new EmployeeBus();
            this.userName = username;
            InitializeComponent();
        }

        private void UcUpdateProfile_Load(object sender, EventArgs e)
        {
            Entity.Employee myEmployee = myEmployeeBus.GetByUsername(userName);
            txtFullName.Text = myEmployee.FullName;
            txtEmail.Text = myEmployee.Email;
            txtAddress.Text = myEmployee.Address;
            txtIdentity.Text = myEmployee.Identity;
            txtPhone.Text = myEmployee.Phone;
        }

        private void txtEdit_Click(object sender, EventArgs e)
        {
            BunifuMaterialTextbox myTextbox = (BunifuMaterialTextbox)sender;
            myTextbox.Enabled = true;
        }
        private void txtEditLeave_Click(object sender, EventArgs e)
        {

        }
        private void Key_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }
        }


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
