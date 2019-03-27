using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using log4net;

namespace Main
{
    public partial class Employee : Form
    {
        EmployeeBus employeeBus = new EmployeeBus();

        public Employee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check valid form
                if (CheckValidForm())
                {
                    Entity.Employee employee = new Entity.Employee();
                    employee.FullName = txtFullName.Text;
                    employee.Address = txtAddress.Text;
                    employee.DepartmentId = Convert.ToInt64(txtDepartment.Text);
                    employee.Email = txtEmail.Text;
                    employee.Identity = txtIdentity.Text;
                    employee.Password = txtPassword.Text;
                    employee.RolesId = Convert.ToInt64(txtRole.Text);
                    employee.Phone = txtPhone.Text;
                    employee.UserName = txtUserName.Text;
                    employee.IsDelete = 0;
                    employee.Status = Convert.ToInt16(txtStatus.Text);
                    employee.Rank = Convert.ToInt16(txtRank.Text);

                    //create employee
                    if (Employees.IsCreated)
                    {
                        if (employeeBus.Insert(employee) == -1)
                        {
                            MessageBox.Show("Add employee successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error. Add employee unsuccessfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // update employee
                    else
                    {
                        employee.EmployeeId = Employees.employeeForUpdate.EmployeeId;
                        if (employeeBus.Update(employee) == -1)
                        {
                            MessageBox.Show("Update employee successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error. Update employee unsuccessfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error. All field is required!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception exception)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(exception.Message);
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // for update employee
            if (Employees.IsCreated == false && Employees.employeeForUpdate.EmployeeId != 0)
            {
                txtFullName.Text = Employees.employeeForUpdate.FullName;
                txtAddress.Text = Employees.employeeForUpdate.Address;
                txtDepartment.Text = Employees.employeeForUpdate.DepartmentId.ToString();
                txtEmail.Text = Employees.employeeForUpdate.Email;
                txtIdentity.Text = Employees.employeeForUpdate.Identity;
                txtPassword.Text = Employees.employeeForUpdate.Password;
                txtRole.Text = Employees.employeeForUpdate.RolesId.ToString();
                txtPhone.Text = Employees.employeeForUpdate.Phone;
                txtUserName.Text = Employees.employeeForUpdate.UserName;
                txtStatus.Text = Employees.employeeForUpdate.Status.ToString();
                txtRank.Text = Employees.employeeForUpdate.Rank.ToString();
            }
        }

        public bool CheckValidForm()
        {
            if (txtFullName.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
