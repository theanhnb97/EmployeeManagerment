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
            //Combobox Department Source
            cbbDept.DataSource = departmentBUS.GetAll();
            cbbDept.ValueMember = "DEPARTMENTID";
            cbbDept.DisplayMember = "DEPARTMENTNAME";
            cbbDept.SelectedItem = null;          
            //Combobox Rank Source
            Dictionary<int, string> cbbRankItems = new Dictionary<int, string>();
            cbbRankItems.Add(1, "Giam Doc");
            cbbRankItems.Add(2, "Truong Phong");
            cbbRankItems.Add(3, "Nhan Vien");
            cbbRank.DataSource= new BindingSource(cbbRankItems, null);
            cbbRank.ValueMember = "Key";
            cbbRank.DisplayMember = "Value";
            cbbRank.SelectedItem = null;
            Dictionary<int, string> cbbBasicItems = new Dictionary<int, string>();
            cbbBasicItems.Add(3, "3");
            cbbBasicItems.Add(4, "4");
            cbbBasicItems.Add(5, "5");
            cbbBasicItems.Add(6, "6");
            cbbBasic.DataSource = new BindingSource(cbbBasicItems, null);
            cbbBasic.ValueMember = "Key";
            cbbBasic.DisplayMember = "Value";
            cbbBasic.SelectedItem = null;
            //Combobox Bussiness Source
            Dictionary<int, string> cbbBussinessItems = new Dictionary<int, string>();
            cbbBussinessItems.Add(5, "5");
            cbbBussinessItems.Add(6, "6");
            cbbBussinessItems.Add(7, "7");
            cbbBussinessItems.Add(8, "8");
            cbbBussiness.DataSource = new BindingSource(cbbBussinessItems, null);
            cbbBussiness.ValueMember = "Key";
            cbbBussiness.DisplayMember = "Value";
            cbbBussiness.SelectedItem = null;
            //Combobox Coefficient Source
            Dictionary<int, string> cbbCoefficientItems = new Dictionary<int, string>();
            cbbCoefficientItems.Add(1, "2.34");
            cbbCoefficientItems.Add(2, "2.67");
            cbbCoefficientItems.Add(3, "3.0");
            cbbCoefficientItems.Add(4, "3.33");
            cbbCoefficient.DataSource = new BindingSource(cbbCoefficientItems, null);
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
        private void cbbDept_ItemSetected(object sender,EventArgs e)
        {
            cbbRank.Enabled = true;
        }

        private void cbbRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDept.SelectedItem != null && cbbRank.SelectedItem != null)
            {
                SetcbbIdentNameSource();
                cbbName.Enabled = true;
                cbbIdentity.Enabled = true;
                //Combobox Identity Datasource               
                cbbIdentity.ValueMember = "EmployeeId";
                cbbIdentity.DisplayMember = "Identity";               
                cbbIdentity.DataSource = this.cbbIdentAndNameSource;
                cbbIdentity.SelectedItem = null;
                //Combobox FullName Datasource     
                cbbName.DataSource = this.cbbIdentAndNameSource;
                cbbName.ValueMember = "EmployeeId";
                cbbName.DisplayMember = "FullName";
                cbbName.SelectedItem = null;

            }
        }

        private void cbbIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {        
            if ((!string.IsNullOrEmpty(cbbIdentity.Text)) && (cbbIdentity.SelectedIndex != -1))
            {
                foreach(var item in this.cbbIdentAndNameSource)
                {
                    if(item.EmployeeId == int.Parse(cbbIdentity.SelectedValue.ToString()))
                    {
                        string name = item.FullName;
                        int i = cbbName.FindString(name);
                        cbbName.SelectedIndex = i;
                    }
                }                        
            }
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((!string.IsNullOrEmpty(cbbName.Text)) && (cbbName.SelectedIndex != -1))
            //{
            //    if ((!string.IsNullOrEmpty(cbbName.Text)) && (cbbName.SelectedIndex != -1))
            //    {
            //        foreach (var item in this.cbbIdentAndNameSource)
            //        {
            //            if (item.EmployeeId == int.Parse(cbbName.SelectedValue.ToString()))
            //            {
            //                string name = item.FullName;
            //                int i = cbbIdentity.FindString(name);
            //                cbbIdentity.SelectedIndex = i;
            //            }
            //        }
            //    }
            //}
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
            Salary salary = new Salary();
            salary.CreateDate = DateTime.Now;
            salary.BasicSalary = int.Parse(cbbBasic.Text);
            salary.BussinessSalary = int.Parse(cbbBussiness.Text);
            salary.Coefficient = float.Parse(cbbCoefficient.Text);
            salary.EmployeeId = int.Parse(cbbIdentity.SelectedValue.ToString());
            salaryBUS.Add(salary);
            this.Close();
        }
    }

}
