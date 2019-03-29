using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLayer;
using CommonLibrary.Model;
using log4net;

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

                var departTable = objTaskBus.LoadDepartment();

                if (departTable.Rows.Count > 0)
                {
                    cmbDepartment.DataSource = departTable;
                    cmbDepartment.ValueMember = "DEPARTMENTID";
                    cmbDepartment.DisplayMember = "DEPARTMENTNAME";
                    if (Convert.ToInt64(cmbDepartment.SelectedValue) > 0)
                    {
                        lbDepartment.ForeColor = Color.DarkGreen;
                    }

                }
                else
                {
                    MessageBox.Show("Department have not data", "Status");
                }


                var levels = objTaskBus.GetAlLevel();
                if (levels.Count > 0)
                {
                    cmbLevel.DataSource = levels;
                    cmbLevel.ValueMember = "Id";
                    cmbLevel.DisplayMember = "Name";
                    if (Convert.ToInt64(cmbLevel.SelectedValue) > 0)
                    {
                        lbLevel.ForeColor = Color.DarkGreen;
                    }

                }
                else
                {
                    MessageBox.Show("Priority have not data", "Status");
                }

                //assign file from data transfer object
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
                DataTable dtDepartment = new DataTable();
                dtDepartment = objTaskBus.LoadEmployeeByDpt(Convert.ToInt32(cmbDepartment.SelectedValue));
                if (dtDepartment.Rows.Count > 0)
                {
                    cmbAssign.ValueMember = "EMPLOYEEID";
                    cmbAssign.DisplayMember = "FULLNAME";
                    cmbAssign.DataSource = dtDepartment;
                    lbAssign.ForeColor = Color.DarkGreen;

                }
                else
                {
                    cmbAssign.DataSource = dtDepartment;
                    lbAssign.ForeColor = Color.Red;
                    MessageBox.Show("Assign have not data", "Status");

                }
            }
            catch
            {
                //
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
                // validate 
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
                else if (Convert.ToDateTime(dtpDueDate.Value) < DateTime.Today)
                {
                    MessageBox.Show("Due Date must ' > ' or ' = ' Today", "Warning");
                }
                else
                {
                    // assign value for data transfer object
                    TaskDTO.TaskName = txtTaskName.Text.Trim();
                    TaskDTO.Description = txtDescription.Text.Trim();
                    TaskDTO.Assign = Convert.ToInt32(cmbAssign.SelectedValue);
                    TaskDTO.Department = Convert.ToInt32(cmbDepartment.SelectedValue);
                    TaskDTO.Priority = Convert.ToInt32(cmbLevel.SelectedValue);
                    TaskDTO.DueDate = dtpDueDate.Value.ToString("dd/MMM/yyyy");
                    //check result
                    if (objTaskBus.Update(TaskDTO.TaskId, TaskDTO.TaskName, TaskDTO.Assign,
                        TaskDTO.DueDate, TaskDTO.Priority, TaskDTO.Files, TaskDTO.Status, TaskDTO.IsDelete,
                        TaskDTO.Description) != 0)
                    {
                        MessageBox.Show("Succes", "Status");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Status");
                    }
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
                this.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCacncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTaskName_TextChanged(object sender, EventArgs e)
        {
            if (string.Empty.Equals(txtTaskName.Text.Trim()) ||
                Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,}") == false)
            {
                lbTaskName.ForeColor = Color.Red;
            }
            else
            {
                lbTaskName.ForeColor = Color.DarkGreen;
            }
        }

        private void txtTaskName_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(txtTaskName.Text.Trim()))
            {
                MessageBox.Show("Enter Task Name!", "Warning");
                txtTaskName.Focus();
            }
            else if (Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,}") == false)
            {
                MessageBox.Show(" Task Name must more than 2 characters!", "Warning");
                txtTaskName.Focus();
            }
            else
            {
                lbTaskName.ForeColor = Color.DarkGreen;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.Empty.Equals(txtDescription.Text.Trim()) ||
                Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,}") == false)
            {
                lbDescription.ForeColor = Color.Red;
            }
            else
            {
                lbDescription.ForeColor = Color.DarkGreen;
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(txtDescription.Text.Trim()))
            {
                MessageBox.Show("Enter Description!", "Warning");
                txtDescription.Focus();
            }
            else if (Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,}") == false)
            {
                MessageBox.Show(" Description must more than 2 characters!", "Warning");
                txtDescription.Focus();
            }
            else
            {
                lbDescription.ForeColor = Color.DarkGreen;
            }
        }

        private void dtpDueDate_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpDueDate.Value) < DateTime.Today)
            {
                MessageBox.Show("Due Date must ' > ' or ' = ' Today", "Warning");
                dtpDueDate.Focus();
                lbDate.ForeColor = Color.Red;
            }
            else
            {
                lbDate.ForeColor = Color.DarkGreen;
            }

        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpDueDate.Value) < DateTime.Today)
            {
                MessageBox.Show("Due Date must ' > ' or ' = ' Today", "Warning");
                dtpDueDate.Focus();
                lbDate.ForeColor = Color.Red;
            }
            else
            {
                lbDate.ForeColor = Color.DarkGreen;
            }
        }
    }
}
