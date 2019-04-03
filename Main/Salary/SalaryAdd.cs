using BusinessLayer;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Main.Salary;

namespace Main.Dong
{
    public partial class SalaryAdd : Form
    {
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private readonly SalaryBUS salaryBUS = new SalaryBUS();
        private readonly EmployeeBus employeeBus = new EmployeeBus();
        private List<Entity.Employee> cbbIdentAndNameSource = new List<Entity.Employee>();

        private void SetcbbIdentNameSource()
        {
            this.cbbIdentAndNameSource.Clear();
            string DeptNo = cbbDept.SelectedValue.ToString();
            int selectedRankKey = int.Parse(cbbRank.SelectedValue.ToString());
            this.cbbIdentAndNameSource = salaryBUS.GetByDeptIdAndRank(int.Parse(DeptNo), selectedRankKey);
        }

        public SalaryAdd()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            CbbData cbbData = new CbbData();
            //Combobox Department Source
            cbbDept.DataSource = departmentBUS.GetAll();
            cbbDept.ValueMember = "DEPARTMENTID";
            cbbDept.DisplayMember = "DEPARTMENTNAME";
            cbbDept.SelectedItem = null;
            //Combobox Rank Source
            cbbRank.DataSource = new BindingSource(cbbData.cbbRankItems, null);
            cbbRank.ValueMember = "Key";
            cbbRank.DisplayMember = "Value";
            cbbRank.SelectedItem = null;
            cbbBasic.DataSource = new BindingSource(cbbData.cbbBasicItems, null);
            cbbBasic.ValueMember = "Key";
            cbbBasic.DisplayMember = "Value";
            cbbBasic.SelectedItem = null;
            //Combobox Bussiness Source
            cbbBussiness.DataSource = new BindingSource(cbbData.cbbBussinessItems, null);
            cbbBussiness.ValueMember = "Key";
            cbbBussiness.DisplayMember = "Value";
            cbbBussiness.SelectedItem = null;
            //Combobox Coefficient Source
            cbbCoefficient.DataSource = new BindingSource(cbbData.cbbCoefficientItems, null);
            cbbCoefficient.ValueMember = "Key";
            cbbCoefficient.DisplayMember = "Value";
            cbbCoefficient.SelectedItem = null;
            //Disable other combobox while Department not selected.
            if (cbbDept.SelectedItem == null)
            {
                cbbRank.Enabled = false;
                cbbName.Enabled = false;
                cbbIdentity.Enabled = false;
            }
        }
        private void cbbDept_TextChanged(object sender, EventArgs e)
        {
            string temp = cbbDept.Text;
            cbbDept.FindString(temp);
        }
        private void cbbDept_ItemSetected(object sender, EventArgs e)
        {
            cbbRank.Enabled = true;
        }

        private void cbbRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDept.SelectedItem != null && cbbRank.SelectedItem != null)
            {
                this.SetcbbIdentNameSource();
                cbbName.Enabled = true;
                cbbIdentity.Enabled = true;
                //Combobox Identity Datasource               
                cbbIdentity.ValueMember = "EmployeeId";
                cbbIdentity.DisplayMember = "Identity";
                cbbIdentity.DataSource = this.cbbIdentAndNameSource;
                cbbIdentity.SelectedItem = null;
                //Combobox FullName Datasource                   
                cbbName.ValueMember = "EmployeeId";
                cbbName.DisplayMember = "FullName";
                cbbName.DataSource = this.cbbIdentAndNameSource;
                cbbName.SelectedItem = null;

            }
        }
        private void cbbIdentity_TextChanged(object sender, EventArgs e)
        {
            string temp = cbbIdentity.Text;
            cbbIdentity.FindString(temp);
        }

        private void cbbIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cbbIdentity.Text)) && (cbbIdentity.SelectedIndex != -1))
            {
                foreach (var item in this.cbbIdentAndNameSource)
                {
                    if (item.EmployeeId == int.Parse(cbbIdentity.SelectedValue.ToString()))
                    {
                        string name = item.FullName;
                        int i = cbbName.FindString(name);
                        cbbName.SelectedIndex = i;
                    }
                }
            }

        }
        private void cbbName_TextChanged(object sender, EventArgs e)
        {
            string temp = cbbName.Text;
            cbbName.FindString(temp);
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            this.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbbIdentity.SelectedValue== null)
            {
                MessageBox.Show("Identity value invalid, please refill identity");
            }
            else if (cbbDept.SelectedIndex != -1 && cbbRank.SelectedIndex != -1 && cbbName.SelectedIndex != -1 && cbbIdentity.SelectedIndex != -1 && cbbBasic.SelectedIndex != -1 && cbbBussiness.SelectedIndex != -1 && cbbCoefficient.SelectedIndex != -1)
            {
                Entity.Salary salary = new Entity.Salary();
                salary.CreateDate = DateTime.Now;
                salary.BasicSalary = int.Parse(cbbBasic.Text);
                salary.BussinessSalary = int.Parse(cbbBussiness.Text);
                salary.Coefficient = float.Parse(cbbCoefficient.Text);
                salary.EmployeeId = int.Parse(cbbIdentity.SelectedValue.ToString());
                salaryBUS.Add(salary);
                MessageBox.Show("Add Successful");
                this.Close();
            }
            else MessageBox.Show("Please recheck, seem some value not fill");
        }
    }

}
