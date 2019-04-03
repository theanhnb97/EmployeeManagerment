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
using Main.Salary;

namespace Main
{
    public partial class SalaryManagement : UserControl
    {
        public static SalaryView salaryForEdit = new SalaryView();
        protected int RolesID { get; set; }
        SalaryBUS salary = new SalaryBUS();        
        private int currentPage { get; set; } 
        private int lastPage { get; set; }
        // Number records paging
        private int size { get; set; }
        private int currentSearchPage { get; set; }

        public SalaryManagement(int id)
        {
            this.RolesID = id;
            InitializeComponent();
            this.currentPage = 0;
            CbbData cbbData = new CbbData();
            var firstsize = cbbData.pageSizes.First();
            this.size = firstsize.Value;  
            this.SetPaging();
            cbbRecordNum.DataSource = new BindingSource(cbbData.pageSizes, null);
            cbbRecordNum.DisplayMember = "Value";
            cbbRecordNum.ValueMember = "Key";
            currentSearchPage = 0;
        }
        private void SetPaging()
        {
            if (salary.GetData().Count % size == 0)
            {
                this.lastPage = salary.GetData().Count / size - 1;
            }
            else this.lastPage = salary.GetData().Count / size;
            lblPagingSalaryIndex.Text = (currentPage + 1).ToString();
            lblAllPageSalary.Text = (lastPage + 1).ToString();
        }

        private void Salary_Load(object sender, EventArgs e)
        {         
            panelDate.Visible = false;
            List<SalaryView> salaryViews = salary.Paging(size, currentPage);
            CbbData cbbData = new CbbData();
            foreach(var item in salaryViews)
            {
                foreach(var rank in cbbData.cbbRankItems)
                {
                    if (item.Rank == rank.Key.ToString())
                    {
                        item.Rank = rank.Value;
                    }
                }
            }
            dgvSalary.DataSource = salaryViews;
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
            if (panelDate.Visible == true)
            {
                DateTime fDate = DateTime.Parse(dateFDateFilter.Value.ToString());
                DateTime tDate = DateTime.Parse(dateTDateFilter.Value.ToString());
                List<SalaryView> salaryViews = salary.SearchSalary(nameSearch, deptSearch, fDate, tDate ,size, currentSearchPage);
                CbbData cbbData = new CbbData();
                foreach (var item in salaryViews)
                {
                    foreach (var rank in cbbData.cbbRankItems)
                    {
                        if (item.Rank == rank.Key.ToString())
                        {
                            item.Rank = rank.Value;
                        }
                    }
                }
                dgvSalary.DataSource = salaryViews;
                if (salaryViews.Count % size == 0)
                {
                    this.lastPage = salaryViews.Count / size - 1;
                }
                else this.lastPage = salaryViews.Count / size;               
                lblPagingSalaryIndex.Text = (currentSearchPage + 1).ToString();
                lblAllPageSalary.Text = (lastPage + 1).ToString();
            }
            else
            {
                DateTime fDate = DateTime.Parse("01/01/1900");
                DateTime tDate = DateTime.Parse("01/01/2100");
                List<SalaryView> salaryViews = salary.SearchSalary(nameSearch, deptSearch, fDate, tDate, size, currentSearchPage);
                CbbData cbbData = new CbbData();
                foreach (var item in salaryViews)
                {
                    foreach (var rank in cbbData.cbbRankItems)
                    {
                        if (item.Rank == rank.Key.ToString())
                        {
                            item.Rank = rank.Value;
                        }
                    }
                }
                dgvSalary.DataSource = salaryViews;
                if (salary.SearchRecords(nameSearch, deptSearch, fDate, tDate).Count % size == 0)
                {
                    this.lastPage = salary.SearchRecords(nameSearch, deptSearch, fDate, tDate).Count / size - 1;
                }
                else this.lastPage = salary.SearchRecords(nameSearch, deptSearch, fDate, tDate).Count / size;
                lblPagingSalaryIndex.Text = (currentSearchPage + 1).ToString();
                lblAllPageSalary.Text = (lastPage + 1).ToString();
                dgvSalary.DataSource = salaryViews;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SalaryAdd sa = new SalaryAdd();           
            sa.ShowDialog();
            this.Hide();
            Salary_Load(sender, e);
            this.Show();
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
            salaryForEdit.Rank = dgvSalary.Rows[index].Cells[2].Value.ToString();
            SalaryEdit salaryEdit = new SalaryEdit();
            salaryEdit.ShowDialog();
            this.Hide();
            Salary_Load(sender, e);
            this.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDeptFilter.Clear();
            txtNameFilter.Clear();
            dateFDateFilter.Refresh();
            dateTDateFilter.Refresh();
            SetPaging();
            Salary_Load(sender, e);
            currentSearchPage = 0;
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
                        Salary_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
        }

        private void btnPreSalary_Click(object sender, EventArgs e)
        {
            if(currentPage > 0)
            {
                if ((txtDeptFilter.Text.Trim() == "") && (txtNameFilter.Text.Trim() == "") && chkDate.Checked == false)
                {
                    currentPage = currentPage - 1;
                    Salary_Load(sender, e);
                    if(currentPage==0)
                    lblPagingSalaryIndex.Text = (currentPage+1).ToString();
                    else lblPagingSalaryIndex.Text = currentPage.ToString();
                }
                else
                {
                    currentSearchPage = currentSearchPage - 1;
                    btnLoadData_Click(sender, e);
                    lblPagingSalaryIndex.Text = (currentSearchPage - 1).ToString();
                    
                }
            }
        }

        private void btnNextSalary_Click(object sender, EventArgs e)
        {
            if(currentPage < lastPage)
            {             
                if ((txtDeptFilter.Text.Trim() == "") && (txtNameFilter.Text.Trim() == "") && chkDate.Checked == false)
                {
                    currentPage = currentPage + 1;
                    Salary_Load(sender, e);
                    lblPagingSalaryIndex.Text = (currentPage + 1).ToString();
                }                   
                else
                {
                    currentSearchPage = currentSearchPage + 1;
                    btnLoadData_Click(sender, e);
                    lblPagingSalaryIndex.Text = (currentSearchPage + 1).ToString();
                }
                
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (panelDate.Visible == false)
            {
                panelDate.Visible = true;
            }
            else panelDate.Visible = false;
        }

        private void cbbRecordNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.size = int.Parse(cbbRecordNum.Text);
            currentPage = 0;
            if ((txtDeptFilter.Text.Trim() == "") && (txtNameFilter.Text.Trim() == "") && chkDate.Checked == false)
            {
                SetPaging();
                Salary_Load(sender, e);
            }
            else btnLoadData_Click(sender, e);
        }
    }
}
