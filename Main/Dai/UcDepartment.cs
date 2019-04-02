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
using System.Configuration;

namespace Main.Dai
{
    
    public partial class UcDepartment : UserControl
    {

        //Create by the anh (28/3/2019)
        int item = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string ucName = base.Name + ".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(ucName)) result = true;
            if (result)
                base.OnLoad(e);
            else
                this.Hide();
        }


        int cusPage = 1;
        public UcDepartment(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        /// <summary>/// Load form Department
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>

        private void UcDepartment_Load(object sender, EventArgs e)
        {
            int  item = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
            DepartmentBUS departmentBus = new DepartmentBUS();
            
            
            int pageSize = (departmentBus.GetAll().Rows.Count) /item+1 ;
           dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);//get datagridview 

                lblPage.Text = cusPage.ToString() + '/' + pageSize;

        }
        /// <summary>/// Button search event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
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
                dgvDepartment.DataSource = departmentBus.SearchDepartment(keyword,cusPage,item,20);
                txtDepartmentName.Text = "";
            }
            
        }
        /// <summary>/// Button update event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entity.Department department = new Entity.Department();
            int index = dgvDepartment.CurrentCell.RowIndex;
            department.DepartmentID = int.Parse(dgvDepartment.Rows[index].Cells[0].Value.ToString());
            department.DepartmentName = dgvDepartment.Rows[index].Cells[1].Value.ToString();
            department.Status = int.Parse(dgvDepartment.Rows[index].Cells[2].Value.ToString());
            department.IsDelete = int.Parse(dgvDepartment.Rows[index].Cells[3].Value.ToString());
            department.Description = dgvDepartment.Rows[index].Cells[4].Value.ToString();

            DepartmentUpdate frUpdate = new DepartmentUpdate(RolesID);

            frUpdate.Department = department;

            frUpdate.ShowDialog();
        }
        /// <summary>/// Button delete event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            DepartmentBUS departmentBus = new DepartmentBUS();
                int index = dgvDepartment.CurrentCell.RowIndex;
                int id = int.Parse(dgvDepartment.Rows[index].Cells[0].Value.ToString());

                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this employee ?", "Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    int checkDelete = departmentBus.DeleteNoRemove(id);// check delete
                    if (checkDelete == -1)
                    {
                        MessageBox.Show("Delete Complete","Delete Message",MessageBoxButtons.OK);
                        
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
            DepartmentAdd frAdd = new DepartmentAdd(RolesID);
            frAdd.ShowDialog();
        }
        /// <summary>/// Button Refresh event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnClean_Click(object sender, EventArgs e)
        {
            
            DepartmentBUS departmentBus = new DepartmentBUS();
            int item = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
            int pageSize = (departmentBus.GetAll().Rows.Count) / item+1;//get Pagesize
            dgvDepartment.DataSource = departmentBus.GetAllPage(1,item,20);
            lblPage.Text =  "1/" + pageSize;
        }

        /// <summary>/// Button next event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnNext_Click(object sender, EventArgs e)
        {
        
            DepartmentBUS departmentBus=new DepartmentBUS();
            int pageSize = (departmentBus.GetAll().Rows.Count) / item+1;
            if (cusPage < pageSize)//if cusPage<pagesize
        {
            cusPage++;
            lblPage.Text = cusPage.ToString() + '/' + pageSize;
            dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);
            }
        else
        {
            lblPage.Text = pageSize+"/"+pageSize;
        }

        }

        private void lblPage_Click(object sender, EventArgs e)
        {

        }

        /// <summary>/// Button Previous
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
           
            int pageSize = (departmentBus.GetAll().Rows.Count) / item+1;

            if (cusPage>=1)
            {
                cusPage--;
                lblPage.Text = cusPage.ToString() + '/' + pageSize;
                dgvDepartment.DataSource = departmentBus.GetAllPage(cusPage, item, 20);
            } 
            if(cusPage<1)
            {
                cusPage = 1;
                lblPage.Text = "1/" + pageSize;
                dgvDepartment.DataSource = departmentBus.GetAllPage(1, item, 20);
            }

        }

        
        /// <summary>/// Format form Depaert ment cells Status,isDelete
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
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
            if (e.ColumnIndex == 3)
            {
                e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                string temp1 = dgvDepartment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                switch (temp1)
                {

                    case "0":
                        e.Value = "NoDelete";
                        break;
                    case "1":
                        e.Value = "Delete";
                        break;

                }

            }
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            
        }
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDepartment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFillall_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            dgvDepartment.DataSource=departmentBus.GetDepartmentAll();
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPage_SelectedValueChanged(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
           
            int pageSize = (departmentBus.GetAll().Rows.Count) / item + 1;//get Pagesize
            dgvDepartment.DataSource = departmentBus.GetAllPage(1, item, 20);
            lblPage.Text = "1/" + pageSize;
        }

        private void Action_Enter(object sender, EventArgs e)
        {

        }
    }
}
