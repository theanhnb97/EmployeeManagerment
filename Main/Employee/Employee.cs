namespace Main
{
    using BusinessLayer;
    using CommonLibrary.Enumerator;
    using DataAccessLayer.Enum;
    using log4net;
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Employee" />
    /// </summary>
    public partial class Employee : Form
    {
        /// <summary>
        /// Defines the myRolesActionBus
        /// </summary>
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();

        /// <summary>
        /// Defines the departmentBus
        /// </summary>
        private readonly DepartmentBUS departmentBus = new DepartmentBUS();

        /// <summary>
        /// Defines the employeeBus
        /// </summary>
        private readonly EmployeeBus employeeBus = new EmployeeBus();

        /// <summary>
        /// Defines the rolesBul
        /// </summary>
        private readonly RolesBUL rolesBul = new RolesBUL();

        /// <summary>
        /// Gets or sets the RolesID
        /// </summary>
        protected int RolesId { get; set; }

        /// <summary>
        /// The OnLoad
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected override void OnLoad(EventArgs e)
        {
            var myDataTable = myRolesActionBus.GetTrue(RolesId);
            var result = RolesId == 1;
            var formName = base.Name + ".";
            string action = "";
            foreach (DataRow item in myDataTable.Rows)
                action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (action.Contains(formName)) result = true;
            if (result)
                base.OnLoad(e);
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào hành động này!");
                this.Close();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public Employee(int id)
        {
            RolesId = id;
            InitializeComponent();
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check valid form
                if (CheckValidForm())
                {
                    if (CheckValidEmail(txtEmail.Text))
                    {
                        var employee = new Entity.Employee
                        {
                            FullName = txtFullName.Text,
                            Address = txtAddress.Text,
                            DepartmentId = Convert.ToInt64(cbbDepartment.SelectedValue),
                            Email = txtEmail.Text,
                            Identity = txtIdentity.Text,
                            Password = txtPassword.Text,
                            RolesId = Convert.ToInt64(cbbRole.SelectedValue),
                            Phone = txtPhone.Text,
                            UserName = txtUserName.Text,
                            IsDelete = 0,
                            Status = Convert.ToInt16(cbbStatus.SelectedValue),
                            Rank = Convert.ToInt16(cbbRank.SelectedValue)
                        };
                        if (Employees.IsCreated == false)
                        {
                            employee.EmployeeId = Employees.EmployeeForUpdate.EmployeeId;
                        }

                        if (CheckValidUserName(Convert.ToInt32(employee.EmployeeId), Employees.IsCreated,
                            employee.UserName))
                        {
                            if (CheckValidIdentity(Convert.ToInt32(employee.EmployeeId), Employees.IsCreated,
                                employee.Identity))
                            {
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
                                MessageBox.Show("Lỗi. Số CMTND đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Lỗi. Tên tài khoản đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        /// <summary>
        /// The Employee_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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
            if (Employees.IsCreated == false && Employees.EmployeeForUpdate.EmployeeId != 0)
            {
                txtFullName.Text = Employees.EmployeeForUpdate.FullName;
                txtAddress.Text = Employees.EmployeeForUpdate.Address;
                txtEmail.Text = Employees.EmployeeForUpdate.Email;
                txtIdentity.Text = Employees.EmployeeForUpdate.Identity;
                txtPassword.Text = Employees.EmployeeForUpdate.Password;
                txtPhone.Text = Employees.EmployeeForUpdate.Phone;
                txtUserName.Text = Employees.EmployeeForUpdate.UserName;
                cbbStatus.SelectedIndex = cbbStatus.FindString(Enumerator.GetDescription((Enumeration.Status)Employees.EmployeeForUpdate.Status));
                cbbRank.SelectedIndex = cbbRank.FindString(Enumerator.GetDescription((Enumeration.Rank)Employees.EmployeeForUpdate.Rank));
                cbbDepartment.SelectedValue = Employees.EmployeeForUpdate.DepartmentId;
                cbbRole.SelectedValue = Employees.EmployeeForUpdate.RolesId;
            }
        }

        /// <summary>
        /// The CheckValidForm
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool CheckValidForm()
        {
            if (txtFullName.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtPhone.Text.Trim() == "" || txtAddress.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// The CheckValidEmail
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool CheckValidEmail(string email)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email);
        }

        /// <summary>
        /// The CheckValidIdentity
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <param name="isCreated">The isCreated<see cref="bool"/></param>
        /// <param name="identity">The identity<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool CheckValidIdentity(int employeeId, bool isCreated, string identity)
        {
            var employee = employeeBus.GetByIdentity(identity);
            if (isCreated && employee.EmployeeId != 0)
            {
                return false;
            }

            if (isCreated || employee.EmployeeId == 0) return true;
            return employee.EmployeeId == employeeId;
        }

        /// <summary>
        /// The CheckValidUserName
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <param name="isCreated">The isCreated<see cref="bool"/></param>
        /// <param name="userName">The userName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool CheckValidUserName(int employeeId, bool isCreated, string userName)
        {
            var employee = employeeBus.GetByUsername(userName);
            if (isCreated && employee.EmployeeId != 0) return false;
            if (isCreated == false && employee.EmployeeId != 0)
            {
                return employee.EmployeeId == employeeId;
            }

            return true;

        }

        /// <summary>
        /// The btnCancel_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// The label12_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void label12_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The txtIdentity_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// The txtPhone_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
