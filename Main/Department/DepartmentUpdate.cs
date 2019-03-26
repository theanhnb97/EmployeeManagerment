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
        private Entity.Department department;
        public Entity.Department Department
        {
            get { return department; }
            set { department = value; }
        }


        public DepartmentUpdate()
        {
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentBUS departmentBus = new DepartmentBUS();
                
                department.DepartmentName = txtDepartmentName.Text;
                department.Status = cbStatus.Checked ? 1 : 0;
                department.IsDelete = rdbIsDelete.Checked ? 1 : 0;
                department.Description = txtDescription.Text;
               
                int check = departmentBus.Update(department);
                if (check == -1)
                {
                    MessageBox.Show("Update Suscess");
                }
                else
                {
                    MessageBox.Show("Update No Suscess");
                }

            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);

            }
        }
    }
}
