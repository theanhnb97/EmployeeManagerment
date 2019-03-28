using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            BunifuMaterialTextbox myTextbox = (BunifuMaterialTextbox) sender;
            myTextbox.Enabled = true;
        }
        private void txtEditLeave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
