﻿using System;
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

        private readonly EmployeeMapper mapper = new EmployeeMapper();

        public static Entity.Employee employeeForUpdate = new Entity.Employee();

        public static Entity.Employee employeeForSearch = new Entity.Employee();

        public static bool IsCreated;

        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            dgv_employee.DataSource = employeeBus.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsCreated = true;
            Employee formEmployee = new Employee();
            formEmployee.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreated = false;
            Employee frmEmployee = new Employee();
            frmEmployee.ShowDialog();
        }

        private void dgv_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_employee.CurrentCell.RowIndex;
            List<EmployeeDTO> employeeDtos = dgv_employee.DataSource as List<EmployeeDTO>;
            List<Entity.Employee> employees = mapper.CreateMappingList(employeeDtos);
            if (employees!= null)
            {
                employeeForUpdate = employees[index];
            }
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIdentity_Search.Text = "";
            txtFullName_Search.Text = "";
            txtUserName_Search.Text = "";
            dgv_employee.DataSource = employeeBus.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgv_employee.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dgv_employee.Rows[index].Cells["EMPLOYEEID"].Value.ToString());
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
            employeeForSearch.FullName = txtFullName_Search.Text.Trim();
            employeeForSearch.UserName = txtUserName_Search.Text.Trim();
            employeeForSearch.Identity = txtIdentity_Search.Text.Trim();
            // sau này sửa lấy department từ danh sách, thì chỗ này là cbb.selected value == 0
            // ccb.departmentId = cbb.selected value
            if (cbbDepartment_Search.Text == "")
            {
                employeeForSearch.DepartmentId = 0;
            }

            dgv_employee.DataSource = employeeBus.Search(employeeForSearch);
        }
    }
}
