using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLayer;
using CommonLibrary.Model;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Main.Bang
{
    public partial class frmEditTask : Form
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










        public frmEditTask(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        private readonly TaskBus objTaskBus = new TaskBus();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTask_Load(object sender, System.EventArgs e)
        {
            try
            {

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


                txtTaskName.Text = TaskDTO.TaskName;
                txtDescription.Text = TaskDTO.Description;
                cmbAssign.SelectedValue = TaskDTO.Assign;
                cmbDepartment.SelectedValue = TaskDTO.Department;
                cmbLevel.SelectedValue = TaskDTO.Priority;
                dtpDueDate.Value = Convert.ToDateTime(TaskDTO.DueDate);

            }
            catch (Exception exception)
            {
                MessageBox.Show("some thing wrong");
                logger.Debug(exception);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                cmbAssign.DataSource = objTaskBus.LoadEmployeeByDpt(Int32.Parse(cmbDepartment.SelectedValue.ToString()));
                cmbAssign.ValueMember = "EMPLOYEEID";
                cmbAssign.DisplayMember = "FULLNAME";
            }
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtTaskName.Text.Trim()))
                {
                    MessageBox.Show("Enter Task Name!", "Warning");
                }
                else if (string.Empty.Equals(txtDescription.Text.Trim()))
                {
                    MessageBox.Show("Enter Description!", "Warning");
                }
                else if (Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,}") == false)
                {
                    MessageBox.Show(" Task Name must more than 2 characters!", "Warning");
                }
                else if (Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,}") == false)
                {
                    MessageBox.Show("Description must more than 2 characters!!", "Warning");
                }
                else
                {
                    TaskDTO.TaskName = txtTaskName.Text.Trim();
                    TaskDTO.Description = txtDescription.Text.Trim();
                    TaskDTO.Assign = Convert.ToInt32(cmbAssign.SelectedValue);
                    TaskDTO.Department = Convert.ToInt32(cmbDepartment.SelectedValue);
                    TaskDTO.Priority = Convert.ToInt32(cmbLevel.SelectedValue);
                    TaskDTO.DueDate = dtpDueDate.Value.ToString("dd/MMM/yyyy");
                    objTaskBus.Update(TaskDTO.TaskId, TaskDTO.TaskName, TaskDTO.Assign,
                    TaskDTO.DueDate, TaskDTO.Priority, TaskDTO.Files, TaskDTO.Status, TaskDTO.IsDelete, TaskDTO.Description);
                    Hide();
                }
            }
            catch (Exception exception)
            {
                logger.Debug(exception);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdate_Click(btnUpdate, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCacncel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
