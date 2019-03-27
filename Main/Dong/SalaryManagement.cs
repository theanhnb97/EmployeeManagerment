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
using Main.Dong;
using System.Threading;

namespace Main
{
    
    public partial class SalaryManagement : UserControl
    {
        SalaryBUS salary = new SalaryBUS();
        public SalaryManagement()
        {
            InitializeComponent();
        }
        private void Salary_Load(object sender, EventArgs e)
        {
            dgvSalary.DataSource = salary.GetData();
            if (dgvSalary.DataSource == null)
            {
                MessageBox.Show("Data Not Found!");
            }
            else
            {
                dgvSalary.Columns[0].HeaderCell.Value = "Full Name";
                dgvSalary.Columns[1].HeaderCell.Value = "Identity";
                dgvSalary.Columns[2].HeaderCell.Value = "Rank";
                dgvSalary.Columns[3].HeaderCell.Value = "Department";
                dgvSalary.Columns[4].HeaderCell.Value = "Basic Salary";
                dgvSalary.Columns[5].HeaderCell.Value = "Bussiness";
                dgvSalary.Columns[6].HeaderCell.Value = "Coefficient";
                dgvSalary.Columns[7].HeaderCell.Value = "Total";
            }
        }



        private void btnLoadData_Click(object sender, System.EventArgs e)
        {
            string nameSearch = txtNameFilter.ToString();
            string deptSearch = txtDeptFilter.ToString();
            DateTime fDate = DateTime.Parse(dateFDateFilter.ToString());
            DateTime tDate = DateTime.Parse(dateTDateFilter.ToString());
            dgvSalary.DataSource = salary.SearchSalary(nameSearch,deptSearch,fDate,tDate);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Thread myth;
            myth = new Thread(new System.Threading.ThreadStart(CallSaveDialog));
            myth.ApartmentState = ApartmentState.STA;
            myth.Start();
            dgvSalary.DataSource = salary.GetData();
        }
        private void CallSaveDialog()
        {
            SalaryAdd sa = new SalaryAdd();
            sa.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            SalaryEdit salaryEdit = new SalaryEdit();
            salaryEdit.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

    }
}
