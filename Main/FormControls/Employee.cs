using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using BusinessLayer;
using CommonLibrary.Enumerator;
using DataAccessLayer.Enum;
using log4net;

namespace Main
{
    public partial class Employee : Form
    {
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        private readonly DepartmentBUS departmentBus = new DepartmentBUS();
        private readonly EmployeeBus employeeBus = new EmployeeBus();

        protected int RolesID { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string formName = base.Name + ".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(formName)) result = true;
            if (result)
                base.OnLoad(e);
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào hành động này!");
                this.Close();
            }
        }

        public Employee(int id)
        {
            RolesID = id;
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
                    employee.DepartmentId = Convert.ToInt64(cbbDepartment.SelectedValue);
                    employee.Email = txtEmail.Text;
                    employee.Identity = txtIdentity.Text;
                    employee.Password = txtPassword.Text;
                    // tạm fix =1 vì chưa merge role functions
                    employee.RolesId = 1;
                    employee.Phone = txtPhone.Text;
                    employee.UserName = txtUserName.Text;
                    employee.IsDelete = 0;
                    employee.Status = Convert.ToInt16(cbbStatus.SelectedValue);
                    employee.Rank = Convert.ToInt16(cbbRank.SelectedValue);

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
            cbbStatus.DataSource = Enumerator.BindEnumToCombobox<Enumeration.Status>(cbbStatus, Enumeration.Status.AMember);
            cbbRank.DataSource = Enumerator.BindEnumToCombobox<Enumeration.Rank>(cbbRank, Enumeration.Rank.AMember);
            cbbDepartment.DataSource = departmentBus.GetDepartmentByStatusAndIsDelete(1, 0);
            cbbDepartment.DisplayMember = "DEPARTMENTNAME";
            cbbDepartment.ValueMember = "DEPARTMENTID";

            // for update employee
            if (Employees.IsCreated == false && Employees.employeeForUpdate.EmployeeId != 0)
            {
                txtFullName.Text = Employees.employeeForUpdate.FullName;
                txtAddress.Text = Employees.employeeForUpdate.Address;
                txtEmail.Text = Employees.employeeForUpdate.Email;
                txtIdentity.Text = Employees.employeeForUpdate.Identity;
                txtPassword.Text = Employees.employeeForUpdate.Password;
                //txtRole.Text = Employees.employeeForUpdate.RolesId.ToString();
                txtPhone.Text = Employees.employeeForUpdate.Phone;
                txtUserName.Text = Employees.employeeForUpdate.UserName;
                cbbStatus.SelectedIndex = cbbStatus.FindString(Enumerator.GetDescription((Enumeration.Status)Employees.employeeForUpdate.Status));
                cbbRank.SelectedIndex = cbbRank.FindString(Enumerator.GetDescription((Enumeration.Rank)Employees.employeeForUpdate.Rank));
                cbbDepartment.SelectedValue = Employees.employeeForUpdate.DepartmentId;
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
