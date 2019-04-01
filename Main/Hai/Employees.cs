using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Entity.DTO;

namespace Main
{
    public partial class Employees : UserControl
    {
        private readonly EmployeeBus employeeBus = new EmployeeBus();

        private readonly DepartmentBUS departmentBus = new DepartmentBUS();

        public static Entity.Employee employeeForUpdate = new Entity.Employee();

        public static bool IsCreated;

        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();

        protected int RolesID { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string ucName = base.Name + ".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(ucName)) result = true;
            if (result)
                base.OnLoad(e);
            else
                this.Hide();
        }

        public Employees(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsCreated = true;
            Employee formEmployee = new Employee(RolesID);
            formEmployee.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreated = false;
            Employee frmEmployee = new Employee(RolesID);
            frmEmployee.ShowDialog();
        }

        private void dgv_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_employee.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dgv_employee.Rows[index].Cells["ID"].Value.ToString());
            employeeForUpdate = employeeBus.GetByEmployeeId(employeeId);
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIdentity_Search.Text = "";
            txtFullName_Search.Text = "";
            txtUserName_Search.Text = "";
            dgv_employee.DataSource = employeeBus.GetAll();
            cbbDepartment_Search.SelectedValue = 0;
        }

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
