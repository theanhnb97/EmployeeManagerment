using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
using log4net;

namespace Main.Department
{
    public partial class DepartmentAdd : Form
    {
        DepartmentBUS departmentBus = new DepartmentBUS();
        //Created by The anh (28/3/2019)
        DepartmentBUS departmentBus = new DepartmentBUS();
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


        public DepartmentAdd(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void DepartmentAdd_Load(object sender, EventArgs e)
        {
            var actives = departmentBus.GetAllActive();
            if (actives.Count > 0)
            {
                cmbActive.DataSource = actives;
                cmbActive.ValueMember = "Id";
                cmbActive.DisplayMember = "Name";
                

            }
            else
            {
                MessageBox.Show("Priority have not data", "Status");
            }
        }
        /// <summary>/// Button add event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                Entity.Department department = new Entity.Department();
                department.DepartmentName = txtDepartmentName.Text;
                department.Status = int.Parse(cmbActive.SelectedValue.ToString());
                department.IsDelete = 0;
                department.Description = txtDescription.Text;
                if (txtDepartmentName.Text != "" && txtDescription.Text != "")
                {
                    int check = departmentBus.Add(department);// check add
                    if (check == -1)
                    {
                        MessageBox.Show("You have successfully updated the refresh to change");

                    }
                    else
                    {
                        MessageBox.Show("Add No Suscess");
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
        /// <summary>///Button cannel event click
        /// </summary>
        /// <param name=”sender”>sender</param>
        /// <param name=”e”>e</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartmentName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
