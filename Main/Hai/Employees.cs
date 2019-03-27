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

namespace Main
{
    public partial class Employees : UserControl
    {
        EmployeeBus employeeBus = new EmployeeBus();

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
            Employee formEmployee = new Employee();
            formEmployee.Show();
        }
    }
}
