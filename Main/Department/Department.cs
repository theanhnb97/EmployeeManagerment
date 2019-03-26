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
using log4net;

namespace Main.Department
{
    public partial class Department : Form
    {
        
        public Department()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Department_Load(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus=new DepartmentBUS();
            dgvDepartment.DataSource = departmentBus.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentBUS departmentBus = new DepartmentBUS();
                int index = dgvDepartment.CurrentCell.RowIndex;
                int id = int.Parse(dgvDepartment.Rows[index].Cells[0].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this employee ?", "Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    int check = departmentBus.Delete(id);
                    if (check==-1)
                    {
                        MessageBox.Show("Delete Complete");
                        dgvDepartment.DataSource = departmentBus.GetAll();
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
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);

            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentAdd frAdd=new DepartmentAdd();
            frAdd.ShowDialog();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            dgvDepartment.DataSource = departmentBus.GetAll();
        }
    }
}
