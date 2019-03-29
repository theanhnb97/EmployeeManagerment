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
using Entity.DTO;

namespace Main
{


    public partial class SalaryManagement : UserControl
    {
        public static SalaryView salaryForEdit = new SalaryView();
        protected int RolesID { get; set; }
        SalaryBUS salary = new SalaryBUS();
        public SalaryManagement(int id)
        {
            this.RolesID = id;
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
                dgvSalary.Columns[8].HeaderCell.Value = "SalaryId";
                dgvSalary.Columns[8].Visible = true;
            }
        }



        private void btnLoadData_Click(object sender, System.EventArgs e)
        {
            string nameSearch = txtNameFilter.Text;
            string deptSearch = txtDeptFilter.Text;
            DateTime fDate = DateTime.Parse(dateFDateFilter.Value.ToString());
            DateTime tDate = DateTime.Parse(dateTDateFilter.Value.ToString());
            dgvSalary.DataSource = salary.SearchSalary(nameSearch, deptSearch, fDate, tDate);
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
            int index = int.Parse(dgvSalary.CurrentCell.RowIndex.ToString());
            salaryForEdit.SalaryId = int.Parse(dgvSalary.Rows[index].Cells[8].Value.ToString());
            salaryForEdit.Basic = int.Parse(dgvSalary.Rows[index].Cells[4].Value.ToString());
            salaryForEdit.Bussiness = int.Parse(dgvSalary.Rows[index].Cells[5].Value.ToString());
            salaryForEdit.Coefficient = float.Parse(dgvSalary.Rows[index].Cells[6].Value.ToString());
            salaryForEdit.Identity = dgvSalary.Rows[index].Cells[1].Value.ToString();
            salaryForEdit.FullName = dgvSalary.Rows[index].Cells[0].Value.ToString();
            salaryForEdit.Dept = dgvSalary.Rows[index].Cells[3].Value.ToString();
            salaryForEdit.Rank = int.Parse(dgvSalary.Rows[index].Cells[2].Value.ToString());
            SalaryEdit salaryEdit = new SalaryEdit();
            salaryEdit.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDeptFilter.Clear();
            txtNameFilter.Clear();
            dateFDateFilter.Refresh();
            dateTDateFilter.Refresh();
            dgvSalary.DataSource = salary.GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You Want Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!string.Empty.Equals(dgvSalary.CurrentRow.Cells[8].Value.ToString()) && Convert.ToInt32(dgvSalary.CurrentRow.Cells[8].Value.ToString()) >= 0)
                {
                    int id = Convert.ToInt32(dgvSalary.CurrentRow.Cells[8].Value.ToString());
                    if (salary.Delete(id) != 0)
                    {
                        MessageBox.Show("Success");
                        dgvSalary.DataSource = salary.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }

            }
        }

    }
}
