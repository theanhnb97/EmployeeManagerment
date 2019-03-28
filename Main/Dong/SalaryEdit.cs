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
            //Combobox Basic Source
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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
