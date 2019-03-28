﻿using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;
using Entity;

namespace Main
{
    public partial class AddTask : Form
    {
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
        




        public AddTask(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtTaskName.Text = "";
            dtpDueDate.Value = DateTime.Now;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TaskBus objTaskBus = new TaskBus();
                Task objTask = new Task
                {
                    TaskName = txtTaskName.Text,
                    Assign = Convert.ToInt32(cmbAssign.SelectedValue.ToString()),
                    DueDate = Convert.ToDateTime(dtpDueDate.Value).ToString("dd/MMM/yyyy"),
                    Description = txtDescription.Text,
                    Files = "",
                    Status = 1,
                    Priority = Convert.ToInt32(cmbLevel.SelectedValue.ToString()),
                };
                objTaskBus.Insert(objTask);
                Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Some thing wrong");
            }



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(btnAdd, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTask_Load(object sender, EventArgs e)
        {
            try
            {

                TaskBus objTaskBus = new TaskBus();
                cmbDepartment.DataSource = objTaskBus.LoadDepartment();

                if (cmbDepartment.DataSource != null)
                {
                    cmbDepartment.ValueMember = "DEPARTMENTID";
                    cmbDepartment.DisplayMember = "DEPARTMENTNAME";
                }
                else
                {
                    MessageBox.Show("Department have not data");
                }


                cmbAssign.DataSource = objTaskBus.LoadEmployeeByDpt(Int32.Parse(cmbDepartment.SelectedValue.ToString()));
                if (cmbAssign.DataSource != null)
                {
                    cmbAssign.ValueMember = "EMPLOYEEID";
                    cmbAssign.DisplayMember = "FULLNAME";
                }
                else
                {
                    MessageBox.Show("Assign have not data");
                }

                cmbLevel.DataSource = objTaskBus.GetAlLevel();
                cmbLevel.ValueMember = "Id";
                cmbLevel.DisplayMember = "Name";
            }
            catch (Exception exception)
            {
                MessageBox.Show("some thing wrong" + exception);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TaskBus objTaskBus = new TaskBus();
                cmbAssign.DataSource = objTaskBus.LoadEmployeeByDpt(Int32.Parse(cmbDepartment.SelectedValue.ToString()));
                cmbAssign.ValueMember = "EMPLOYEEID";
                cmbAssign.DisplayMember = "FULLNAME";
            }
            catch
            {
            }

        }
    }
}