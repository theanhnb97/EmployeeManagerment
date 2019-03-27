﻿using System;
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
        public UcDepartment()
        {
            InitializeComponent();
        }

        private void UcDepartment_Load(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            dgvDepartment.DataSource = departmentBus.GetAll();
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
            rdbIsDelete.Checked = false;
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
            try
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
            DepartmentAdd frAdd = new DepartmentAdd();
            frAdd.ShowDialog();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            DepartmentBUS departmentBus = new DepartmentBUS();
            dgvDepartment.DataSource = departmentBus.GetAll();
        }
    }
}
