using BusinessLayer;
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
using log4net;

namespace Main.Department
{
    public partial class DepartmentUpdate : Form
    {
        //Created by (The anh) in (28/3/2019)
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string formName = base.Name + ".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(formName)) result = true;
            if (result)
                base.OnLoad(e);
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào hành động này!");
                this.Close();
            }
        }
        //Entity DepartMent get  data to form Department
        private Entity.Department department;
        public Entity.Department Department
        {
            get { return department; }
            set { department = value; }
        }
        public DepartmentUpdate(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DepartmentUpdate_Load(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            txtDepartmentName.Text = department.DepartmentName;
            txtDescription.Text = department.Description;
            if (department.Status == 1) cbStatus.Checked = true;
            if (department.Status == 0) cbStatus.Checked = false;
            if (department.IsDelete == 1) rdbIsDelete.Checked = true;
            if (department.IsDelete == 0) rdbIsDelete.Checked = false;

        }
        //Button update event click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentBUS departmentBus = new DepartmentBUS();
                
                department.DepartmentName = txtDepartmentName.Text;
                department.Status = cbStatus.Checked ? 1 : 0;
                department.IsDelete = rdbIsDelete.Checked ? 1 : 0;
                department.Description = txtDescription.Text;
                if (txtDepartmentName.Text != "" && txtDescription.Text != "")
                {
                    int check = departmentBus.Update(department);
                    if (check == -1)
                    {
                        MessageBox.Show("You have successfully updated the refresh to change");

                    }
                    else
                    {
                        MessageBox.Show("Update No Suscess");
                    }
                }
                else
                {
                    MessageBox.Show("You can enter data");
                }

            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);

            }
        }
        //Button Cannel
        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
