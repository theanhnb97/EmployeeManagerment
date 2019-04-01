using System;
using System.Data;
using System.Drawing;
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
        private readonly TaskBus objTaskBus = new TaskBus();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
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
                //Validate befor add Task
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
                else if (Convert.ToInt64(cmbAssign.SelectedValue) <= 0)
                {
                    MessageBox.Show("Assign Empty", "Warning");
                }
                else
                {
                    //create new object Task
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
                    if (objTaskBus.Insert(objTask) != 0)
                    {
                        MessageBox.Show("Success!", "Status");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Fail!", "Status");
                    }

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
                this.Close();
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
                //check result return must > 0 and different null
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


                //  check result return must > 0 and different null
                var levels = objTaskBus.GetAlLevel();
                if (levels.Count > 0)
                {
                    cmbLevel.DataSource = levels;
                    cmbLevel.ValueMember = "Id";
                    cmbLevel.DisplayMember = "Name";
                    if (Convert.ToInt64(cmbDepartment.SelectedValue) > 0)
                    {
                        lbLevel.ForeColor = Color.DarkGreen;
                    }

                }
                else
                {
                    MessageBox.Show("Priority have not data", "Status");
                }
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
                //DataRowView id = (DataRowView)cmbDepartment.SelectedValue;
                //DataRowView i = (DataRowView)cmbDepartment.SelectedValue;
                //var tempid = (DataRowView)cmbDepartment.SelectedValue;
                //int id = Convert.ToInt32(tempid.Row[0].ToString());

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
                //  throw;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog a = new OpenFileDialog())
            {
                a.ShowDialog();
            }
        }
    }
}
