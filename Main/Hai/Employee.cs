using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Entity.Employee employee = new Entity.Employee();
            employee.FullName = txtFullName.Text;
            employee.Address = txtAddress.Text;
            employee.DepartmentId = Convert.ToInt32(txtDepartment.Text);
            employee.Email = txtEmail.Text;
            employee.Identity = txtIdentity.Text;
            employee.Password = txtPassword.Text;
            employee.RolesId = Convert.ToInt32(txtRole.Text);
            employee.Phone = txtPhone.Text;
            employee.UserName = txtUserName.Text;
            employee.IsDelete = false;
            employee.Rank = Convert.ToByte(txtRank.Text);
        }
    }
}
