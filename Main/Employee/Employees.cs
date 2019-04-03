using System.Threading;
using Main.Dong;

namespace Main
{
    using BusinessLayer;
    using System;
    using System.Data;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Employees" />
    /// </summary>
    public partial class Employees : UserControl
    {
        /// <summary>
        /// Defines the employeeBus
        /// </summary>
        private readonly EmployeeBus employeeBus = new EmployeeBus();

        /// <summary>
        /// Defines the departmentBus
        /// </summary>
        private readonly DepartmentBUS departmentBus = new DepartmentBUS();

        /// <summary>
        /// Defines the employeeForUpdate
        /// </summary>
        public static Entity.Employee EmployeeForUpdate = new Entity.Employee();

        /// <summary>
        /// Defines the IsCreated
        /// </summary>
        public static bool IsCreated;

        /// <summary>
        /// Defines the myRolesActionBus
        /// </summary>
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();

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
            var ucName = Name + ".";
            var action = "";
            foreach (DataRow item in myDataTable.Rows)
                action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (action.Contains(ucName)) result = true;
            if (result)
                base.OnLoad(e);
            else
                Hide();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employees"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public Employees(int id)
        {
            RolesId = id;
            InitializeComponent();
        }

        /// <summary>
        /// The Employees_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Employees_Load(object sender, EventArgs e)
        {
            dgv_employee.DataSource = employeeBus.GetAll();
            dgv_employee.Columns["RANK"].Visible = false;
            dgv_employee.Columns["DEPARTMENTID"].Visible = false;
            dgv_employee.Columns["PHONE"].Visible = false;


            cbbDepartment_Search.DataSource = departmentBus.GetDepartmentsForSearch();
            cbbDepartment_Search.DisplayMember = "DepartmentName";
            cbbDepartment_Search.ValueMember = "DepartmentID";
            cbbDepartment_Search.SelectedValue = 0;
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsCreated = true;
            Thread thread = new Thread((CallSaveDialog)) {ApartmentState = ApartmentState.STA};
            thread.Start();
            Employees_Load(sender, e);
        }

        private void CallSaveDialog()
        {
            Employee formEmployee = new Employee(RolesId);
            formEmployee.ShowDialog();
        }

        /// <summary>
        /// The btnEdit_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreated = false;
            Employee frmEmployee = new Employee(RolesId);
            frmEmployee.ShowDialog();
        }

        /// <summary>
        /// The dgv_employee_CellClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dgv_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_employee.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dgv_employee.Rows[index].Cells["ID"].Value.ToString());
            EmployeeForUpdate = employeeBus.GetByEmployeeId(employeeId);
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        /// <summary>
        /// The btnClear_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIdentity_Search.Text = "";
            txtFullName_Search.Text = "";
            txtUserName_Search.Text = "";
            dgv_employee.DataSource = employeeBus.GetAll();
            cbbDepartment_Search.SelectedValue = 0;
        }

        /// <summary>
        /// The btnDelete_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgv_employee.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dgv_employee.Rows[index].Cells["ID"].Value.ToString());
            var confirm = MessageBox.Show("Are you sure to delete this employee?", "Notification",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.OK)
            {
                if (employeeBus.Delete(employeeId) == -1)
                {
                    MessageBox.Show("Delete employee sucessfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(this, e);
                }
                else
                {
                    MessageBox.Show("Delete employee unsucessfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// The btnLoadData_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            Entity.Employee employeeForSearch = new Entity.Employee
            {
                FullName = txtFullName_Search.Text.Trim(),
                UserName = txtUserName_Search.Text.Trim(),
                Identity = txtIdentity_Search.Text.Trim(),
                DepartmentId = Convert.ToInt64(cbbDepartment_Search.SelectedValue)
            };
            dgv_employee.DataSource = employeeBus.Search(employeeForSearch);
        }
    }
}
