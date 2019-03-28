﻿using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;
using CommonLibrary.Model;
using log4net;
using Main.Bang;

namespace Main
{
    public partial class UcTask : UserControl
    {
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly TaskBus objTaskBus = new TaskBus();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
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

        public UcTask(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Task_Load(object sender, EventArgs e)
        {
            if (objTaskBus.GetAll().Rows.Count > 0 && objTaskBus.GetAll() != null)
            {
                dgvTask.DataSource = objTaskBus.GetAll();
                dgvTask.Columns[9].Visible = false;
                dgvTask.Columns[10].Visible = false;
            }
            else
            {
                MessageBox.Show("Task Table Not Data!");
            }


            cmbDepartment.DataSource = objTaskBus.LoadDepartment();
            if (cmbDepartment.DataSource != null)
            {
                cmbDepartment.ValueMember = "DEPARTMENTID";
                cmbDepartment.DisplayMember = "DEPARTMENTNAME";
            }
            else
            {
                MessageBox.Show("Department Not Data!");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadData_Click(object sender, EventArgs e)
        {

            string cvDueDate = Convert.ToDateTime(dtpDeuDateFilter.Value).ToString("dd/MMM/yyyy");
            dgvTask.DataSource = objTaskBus.Filter(txtNameFilter.Text, Convert.ToInt32(cmbDepartment.SelectedValue),
               cvDueDate);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameFilter.Text = "";
            dtpDeuDateFilter.Value = DateTime.Now;
            cmbDepartment.SelectedValue = 1;
            if (objTaskBus.GetAll().Rows.Count > 0 && objTaskBus.GetAll() != null)
            {
                dgvTask.DataSource = objTaskBus.GetAll();
                dgvTask.Columns[9].Visible = false;
                dgvTask.Columns[10].Visible = false;
            }
            else
            {
                MessageBox.Show("Task Table Not Data!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTask objAddTask = new AddTask(RolesID);
            objAddTask.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                string temp1 = dgvTask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                switch (temp1)
                {

                    case "1":
                        e.Value = "High";
                        break;
                    case "2":
                        e.Value = "Medium";
                        break;
                    case "3":
                        e.Value = "Low";
                        break;
                }

            }

            if (e.ColumnIndex == 8)
            {
                e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                string temp = dgvTask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                switch (temp)
                {

                    case "1":
                        e.Value = "Todo";
                        break;
                    case "2":
                        e.Value = "Process";
                        break;
                    case "3":
                        e.Value = "Done";
                        break;
                }

            }

            if (e.ColumnIndex == 4)
            {
                e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                var temp = dgvTask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string cvdate = DateTime.Parse(temp).ToString("dd/MM/yyyy");
                for (int i = 0; i < temp.Length; i++)
                {
                    e.Value = cvdate;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("You Want Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!string.Empty.Equals(dgvTask.CurrentRow.Cells["ID"].Value.ToString()) || Convert.ToInt32(dgvTask.CurrentRow.Cells["ID"].Value.ToString()) <= 0)
                {
                    int id = Convert.ToInt32(dgvTask.CurrentRow.Cells["ID"].Value.ToString());
                    if (objTaskBus.Delete(id) != 0)
                    {
                        MessageBox.Show("Success");
                        objTaskBus.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }

            }
        }

        private void dgvTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTask.CurrentRow != null)
            {
                int taskId;
                string taskName;
                int assign;
                int status;
                string files;
                string dueDate;
                int priority;
                string description;
                int department;
                int isDelete;

                if (Convert.ToInt32(dgvTask.CurrentRow.Cells["ID"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Id not exist!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["TASKNAME"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Task name not exist!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString()) <= 0 || string.Empty.Equals(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Employee not exist!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["STATUS"].Value.ToString()))
                {
                    MessageBox.Show("Status empty!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["STATUS"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Status Fail!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["DUEDATE"].Value.ToString().Trim()))
                {
                    MessageBox.Show("DUEDATE empty!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["PRIORITY"].Value.ToString().Trim()) || Convert.ToInt32(dgvTask.CurrentRow.Cells["PRIORITY"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("PRIORITY Fail!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["DESCRIPTION"].Value.ToString().Trim()))
                {
                    MessageBox.Show("DESCRIPTION empty!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString()) <= 0 || string.Empty.Equals(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString().Trim()))
                {

                }
                else
                {
                    taskId = Convert.ToInt32(dgvTask.CurrentRow.Cells["ID"].Value.ToString());
                    taskName = dgvTask.CurrentRow.Cells["TASKNAME"].Value.ToString().Trim();
                    assign = Convert.ToInt32(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString());
                    status = Convert.ToInt32(dgvTask.CurrentRow.Cells["STATUS"].Value.ToString());
                    files = dgvTask.CurrentRow.Cells["FILES"].Value.ToString();
                    dueDate = DateTime.Parse(dgvTask.CurrentRow.Cells["DUEDATE"].Value.ToString()).ToString("dd/MMM/yyyy");
                    priority = Convert.ToInt32(dgvTask.CurrentRow.Cells["PRIORITY"].Value.ToString());
                    description = dgvTask.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
                    department = Convert.ToInt32(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString());
                    isDelete = 0;

                    //
                    TaskDTO.TaskId = taskId;
                    TaskDTO.TaskName = taskName;
                    TaskDTO.Assign = assign;
                    TaskDTO.Status = status;
                    TaskDTO.Files = files;
                    TaskDTO.DueDate = dueDate;
                    TaskDTO.Priority = priority;
                    TaskDTO.Description = description;
                    TaskDTO.Department = department;
                    TaskDTO.IsDelete = isDelete;

                    //
                    frmEditTask objFrmEditTask = new frmEditTask(RolesID);
                    objFrmEditTask.ShowDialog();
                }
            }
        }
    }
}
