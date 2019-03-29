using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly RolesBUL rolesBul = new RolesBUL();

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
                    if (CheckValidEmail(txtEmail.Text))
                    {
                        Entity.Employee employee = new Entity.Employee();
                        employee.FullName = txtFullName.Text;
                        employee.Address = txtAddress.Text;
                        employee.DepartmentId = Convert.ToInt64(cbbDepartment.SelectedValue);
                        employee.Email = txtEmail.Text;
                        employee.Identity = txtIdentity.Text;
                        employee.Password = txtPassword.Text;
                        employee.RolesId = Convert.ToInt64(cbbRole.SelectedValue);
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
                                MessageBox.Show("Thêm nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi.Thêm nhân viên không thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // update employee
                        else
                        {
                            employee.EmployeeId = Employees.employeeForUpdate.EmployeeId;
                            if (employeeBus.Update(employee) == -1)
                            {
                                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi. Cập nhật thông tin nhân viên không thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Định dạng email không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("Các trường thông tin với (*) là bắt buộc nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            cbbRole.DataSource = rolesBul.Get();
            cbbRole.DisplayMember = "ROLESNAME";
            cbbRole.ValueMember = "ROLESID";

            // for update employee
            if (Employees.IsCreated == false && Employees.employeeForUpdate.EmployeeId != 0)
            {
                txtFullName.Text = Employees.employeeForUpdate.FullName;
                txtAddress.Text = Employees.employeeForUpdate.Address;
                txtEmail.Text = Employees.employeeForUpdate.Email;
                txtIdentity.Text = Employees.employeeForUpdate.Identity;
                txtPassword.Text = Employees.employeeForUpdate.Password;
                txtPhone.Text = Employees.employeeForUpdate.Phone;
                txtUserName.Text = Employees.employeeForUpdate.UserName;
                cbbStatus.SelectedIndex = cbbStatus.FindString(Enumerator.GetDescription((Enumeration.Status)Employees.employeeForUpdate.Status));
                cbbRank.SelectedIndex = cbbRank.FindString(Enumerator.GetDescription((Enumeration.Rank)Employees.employeeForUpdate.Rank));
                cbbDepartment.SelectedValue = Employees.employeeForUpdate.DepartmentId;
                cbbRole.SelectedValue = Employees.employeeForUpdate.RolesId;
            }
        }

        public bool CheckValidForm()
        {
            if (txtFullName.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        public bool CheckValidEmail(string email)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email);
        }

        public bool CheckValidIdentity(string identity)
        {
            return true;
        }

        public bool CheckValidUserName(string userName)
        {
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //    (e.KeyChar != '.'))
            // cho phép nhập .
            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
