using BusinessLayer;
using Entity;
using Main.Salary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main.Dong
{
    public partial class SalaryEdit : Form
    {
        private readonly SalaryBUS salaryBUS = new SalaryBUS();
        public SalaryEdit()
        {
            InitializeComponent();
        }
        private void Edit_Load(object obj, EventArgs e)
        {
            lblDept.Text = SalaryManagement.salaryForEdit.Dept;
            lblIdent.Text = SalaryManagement.salaryForEdit.Identity;
            lblRank.Text = SalaryManagement.salaryForEdit.Rank.ToString();
            lblName.Text = SalaryManagement.salaryForEdit.FullName;
            CbbData cbbData = new CbbData();
            //Combobox Basic Source
            cbbBasic.DataSource = new BindingSource(cbbData.cbbBasicItems, null);
            cbbBasic.ValueMember = "Key";
            cbbBasic.DisplayMember = "Value";
            cbbBasic.SelectedText = SalaryManagement.salaryForEdit.Basic.ToString();
            //Combobox Bussiness Source
            cbbBussiness.DataSource = new BindingSource(cbbData.cbbBussinessItems, null);
            cbbBussiness.ValueMember = "Key";
            cbbBussiness.DisplayMember = "Value";
            cbbBussiness.SelectedText = SalaryManagement.salaryForEdit.Bussiness.ToString();
            //Combobox Coefficient Source
            cbbCoefficient.DataSource = new BindingSource(cbbData.cbbCoefficientItems, null);
            cbbCoefficient.ValueMember = "Key";
            cbbCoefficient.DisplayMember = "Value";
            cbbCoefficient.SelectedText = SalaryManagement.salaryForEdit.Coefficient.ToString();
 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entity.Salary salary = new Entity.Salary();
            salary.SalaryId = SalaryManagement.salaryForEdit.SalaryId;
            salary.BasicSalary = int.Parse(cbbBasic.Text);
            salary.BussinessSalary = int.Parse(cbbBussiness.Text);
            salary.Coefficient = float.Parse(cbbCoefficient.Text);
            salaryBUS.Update(salary);
            MessageBox.Show("Update Successfull");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
