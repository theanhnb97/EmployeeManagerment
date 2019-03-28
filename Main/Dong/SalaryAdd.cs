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
        DepartmentBUS departmentBUS = new DepartmentBUS();
        SalaryBUS salaryBUS = new SalaryBUS();
        EmployeeBus employeeBus = new EmployeeBus();
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
            //Disable other combobox while Department not selected.
            if (cbbDept.SelectedItem == null)
            {
                cbbRank.Enabled = false;
                cbbName.Enabled = false;
                cbbIdentity.Enabled = false;
                cbbBussiness.Enabled = false;
                cbbBasic.Enabled = false;
                cbbCoefficient.Enabled = false;
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
                cbbName.Enabled = true;
                cbbIdentity.Enabled = true;
                string DeptNo = cbbDept.SelectedValue.ToString();
                int selectedRankKey = int.Parse(cbbRank.SelectedValue.ToString());               
                //Combobox Identity Datasource
                cbbIdentity.DataSource = salaryBUS.GetByDeptIdAndRank(int.Parse(DeptNo), selectedRankKey);
                cbbIdentity.ValueMember = "EmployeeId";
                cbbIdentity.DisplayMember = "Identity";
                cbbIdentity.SelectedItem = null;
                //Combobox FullName Datasource
                cbbName.DataSource = salaryBUS.GetByDeptIdAndRank(int.Parse(DeptNo), selectedRankKey);
                cbbName.ValueMember = "EmployeeId";
                cbbName.DisplayMember = "FullName";
                cbbName.SelectedItem = null;
            }
        }

        private void cbbIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbIdentity.SelectedItem != null)
            {
                int selectedIdentKey = int.Parse(cbbRank.SelectedValue.ToString());
                cbbName.SelectedIndex = cbbIdentity.SelectedIndex;
            }
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbName.SelectedItem != null)
            {
               
            }
        }
    }

}
