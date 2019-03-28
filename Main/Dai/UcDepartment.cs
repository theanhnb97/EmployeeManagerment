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
using Main.Department;
using log4net;

namespace Main.Dai
{
   
    public partial class UcDepartment : UserControl
    {
        int cusPage = 1;
        
        public UcDepartment()
        {
            InitializeComponent();
        }

        private void UcDepartment_Load(object sender, EventArgs e)
        {
            
            DepartmentBUS departmentBus = new DepartmentBUS();
            //dgvDepartment.DataSource = departmentBus.GetAll();
            int item = int.Parse(this.cbPage.GetItemText(this.cbPage.SelectedItem));
           
            dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);

                lblPage.Text = cusPage.ToString() + '/' + 10;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtDepartmentName.Text;
            DepartmentBUS departmentBus = new DepartmentBUS();
            if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("You have not entered");
            }
            else
            {
                dgvDepartment.DataSource = departmentBus.SearchDepartment(keyword);
                txtDepartmentName.Text = "";
            }
            
            
            cbStatus.Checked = false;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entity.Department department = new Entity.Department();
            int index = dgvDepartment.CurrentCell.RowIndex;
            department.DepartmentID = int.Parse(dgvDepartment.Rows[index].Cells[0].Value.ToString());
            department.DepartmentName = dgvDepartment.Rows[index].Cells[1].Value.ToString();
            department.Status = int.Parse(dgvDepartment.Rows[index].Cells[2].Value.ToString());
            department.IsDelete = int.Parse(dgvDepartment.Rows[index].Cells[3].Value.ToString());
            department.Description = dgvDepartment.Rows[index].Cells[4].Value.ToString();

            DepartmentUpdate frUpdate = new DepartmentUpdate();

            frUpdate.Department = department;

            frUpdate.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            DepartmentBUS departmentBus = new DepartmentBUS();
                int index = dgvDepartment.CurrentCell.RowIndex;
                int id = int.Parse(dgvDepartment.Rows[index].Cells[0].Value.ToString());

                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this employee ?", "Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    int checkDelete = departmentBus.DeleteNoRemove(id);
                    if (checkDelete == -1)
                    {
                        MessageBox.Show("Delete Complete");
                        int item = int.Parse(this.cbPage.GetItemText(this.cbPage.SelectedItem));
                    dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage,item,20);
                    }
                    else
                    {
                        MessageBox.Show("Delete Fail");
                    }
                }
                else
                {
                    return;
                }
        
}

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentAdd frAdd = new DepartmentAdd();
            frAdd.ShowDialog();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            int item = int.Parse(this.cbPage.GetItemText(this.cbPage.SelectedItem));
            dgvDepartment.DataSource = departmentBus.GetAllPage(1,item,20);
        }
      
    private void btnNext_Click(object sender, EventArgs e)
    {
        int item = int.Parse(this.cbPage.GetItemText(this.cbPage.SelectedItem));

            DepartmentBUS departmentBus=new DepartmentBUS();
        if (cusPage < 10)
        {
            cusPage++;
            lblPage.Text = cusPage.ToString() + '/' + 10;
            dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);
            }
        else
        {
            lblPage.Text = "10/10";
        }

    }

        private void lblPage_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            int item = int.Parse(this.cbPage.GetItemText(this.cbPage.SelectedItem));

            if (cusPage>=1)
            {
                cusPage--;
                lblPage.Text = cusPage.ToString() + '/' + 10;
                dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);
            } 
            if(cusPage<1)
            {
                cusPage = 1;
                lblPage.Text = "1/" + 10;
                dgvDepartment.DataSource = departmentBus.GetAllPage(1, item, 20);
            }

        }

        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDepartment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDepartment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                string temp1 = dgvDepartment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                switch (temp1)
                {

                    case "1":
                        e.Value = "Status";
                        break;
                    case "0":
                        e.Value = "NoStatus";
                        break;

                }

            }
        }
    }
}
