using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
using log4net;

namespace Main
{
    public partial class AddTask : Form
    {
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        private TaskBus objTaskBus = new TaskBus();
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
       //private readonly TaskBus objTaskBus = new TaskBus();

       protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

                    Task objTask = new Task
                    {
                        TaskName = txtTaskName.Text.Trim(),
                        Assign = Convert.ToInt32(cmbAssign.SelectedValue.ToString()),
                        DueDate = Convert.ToDateTime(dtpDueDate.Value).ToString("dd/MMM/yyyy"),
                        Description = txtDescription.Text.Trim(),
                        Files = "",
                        Status = 1,
                        Priority = Convert.ToInt32(cmbLevel.SelectedValue.ToString()),
                    };
                    objTaskBus.Insert(objTask);
                    Hide();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Some thing wrong");
                logger.Debug(exception);
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
                MessageBox.Show("some thing wrong");
                logger.Debug(exception);
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
