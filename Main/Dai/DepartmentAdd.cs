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
        public DepartmentAdd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void DepartmentAdd_Load(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentBUS departmentBus = new DepartmentBUS();
                Entity.Department department = new Entity.Department();
                department.DepartmentName = txtDepartmentName.Text;
                department.Status = cbStatus.Checked ? 1 : 0;
                department.IsDelete = rdbIsDelete.Checked ? 1 : 0;
                department.Description = txtDescription.Text;
                if (txtDepartmentName.Text != "" && txtDescription.Text != "")
                {
                    int check = departmentBus.Add(department);
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
                    txtMessager.Text = "You can enter data";
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);

            }
        }
        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
