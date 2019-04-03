using System;
using System.Configuration;
using System.Data;
using System.Security.Policy;
using System.Text.RegularExpressions;
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


        private int pageSize;
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
            pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
            DataTable allData = objTaskBus.GetAll(0);
            DataTable firstPage = objTaskBus.GetAll(1);

            if (firstPage.Rows.Count > 0)
            {
                dgvTask.DataSource = firstPage;
                dgvTask.Columns[9].Visible = false;
                dgvTask.Columns[10].Visible = false;
                dgvTask.Columns[11].Visible = false;

                lblPage.Text = (allData.Rows.Count % pageSize == 0)
                    ? (allData.Rows.Count / pageSize).ToString()
                    : ((allData.Rows.Count / pageSize) + 1).ToString();
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
            try
            {
                string cvDueDate = Convert.ToDateTime(dtpDeuDateFilter.Value).ToString("dd/MMM/yyyy");

                DataTable allData = objTaskBus.Filter(txtNameFilter.Text, Convert.ToInt32(cmbDepartment.SelectedValue),
                    cvDueDate, 0);
                DataTable firstPage = objTaskBus.Filter(txtNameFilter.Text, Convert.ToInt32(cmbDepartment.SelectedValue),
                    cvDueDate, 1);
                lblCurent.Text = "1";
                pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);


                if (firstPage.Rows.Count > 0)
                {
                    dgvTask.DataSource = firstPage;
                    dgvTask.Columns[9].Visible = false;
                    dgvTask.Columns[10].Visible = false;
                    dgvTask.Columns[11].Visible = false;

                    lblPage.Text = (allData.Rows.Count % pageSize == 0)
                        ? (allData.Rows.Count / pageSize).ToString()
                        : ((allData.Rows.Count / pageSize) + 1).ToString();

                }
                else
                {
                    dgvTask.DataSource = firstPage;
                    MessageBox.Show("Task Table Not Data!");
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameFilter.Text = "";
            dtpDeuDateFilter.Value = DateTime.Now;
            cmbDepartment.SelectedValue = 1;
            lblCurent.Text = "1";
            DataTable allData = objTaskBus.GetAll(0);
            DataTable firstPage = objTaskBus.GetAll(1);
            if (firstPage.Rows.Count > 0)
            {
                dgvTask.DataSource = firstPage;
                dgvTask.Columns[9].Visible = false;
                dgvTask.Columns[10].Visible = false;
                dgvTask.Columns[11].Visible = false;

                lblPage.Text = (allData.Rows.Count % pageSize == 0)
                    ? (allData.Rows.Count / pageSize).ToString()
                    : ((allData.Rows.Count / pageSize) + 1).ToString();

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

            try
            {


                //set value of column Priority
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

                //set  value of column Status
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

                // format date column DueDate is day/month/year
                if (e.ColumnIndex == 4)
                {
                    e.FormattingApplied = true; // <===VERY, VERY important tell it you've taken care of it.
                    var temp = dgvTask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string cvDate = DateTime.Parse(temp).ToString("dd/MM/yyyy");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        e.Value = cvDate;
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
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("You Want Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //check null, space, id <=0
                if (dgvTask.CurrentRow != null && (!string.Empty.Equals(dgvTask.CurrentRow.Cells["Mã"].Value.ToString()) || Convert.ToInt32(dgvTask.CurrentRow.Cells["Mã"].Value.ToString()) <= 0))
                {
                    int id = Convert.ToInt32(dgvTask.CurrentRow.Cells["Mã"].Value.ToString());
                    if (objTaskBus.Delete(id) != 0)
                    {
                        MessageBox.Show("Success", "Status");
                        if (objTaskBus.GetAll(0).Rows.Count > 0 && objTaskBus.GetAll(0) != null)
                        {
                            dgvTask.DataSource = objTaskBus.GetAll(0);

                        }
                        else
                        {
                            MessageBox.Show("Fail!", "Status");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTask.CurrentRow != null && dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString() == "1")
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else if (dgvTask.CurrentRow != null && dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString() == "2")
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }


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

                if (Convert.ToInt32(dgvTask.CurrentRow.Cells["Mã"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Mã Không Tồn Tại!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["Tên Nhiệm Vụ"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Tên Không Tồn Tại!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString()) <= 0
                         || string.Empty.Equals(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Nhân Viên Không Tồn Tại!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString()))
                {
                    MessageBox.Show("Tiến Độ Trống!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Tiến Độ Không Hợp Lệ!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["Hạn Chót"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Hạn Chót Trống!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["Mức Độ"].Value.ToString().Trim())
                         || Convert.ToInt32(dgvTask.CurrentRow.Cells["Mức Độ"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Mức Độ Không Hợp Lệ!");
                }
                else if (string.Empty.Equals(dgvTask.CurrentRow.Cells["Mô Tả"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Mô Tả Trống!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString()) <= 0
                         || string.Empty.Equals(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString().Trim()))
                {
                    MessageBox.Show("Phòng / Ban Không Tồn Tại!");
                }
                else if (Convert.ToInt32(dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString()) == 3)
                {
                    MessageBox.Show("Không Thể Xóa Nhiệm Vụ Khi Đã Hoàn Thành!");
                }
                else
                {
                    //assign value for variable 
                    int taskId = Convert.ToInt32(dgvTask.CurrentRow.Cells["Mã"].Value.ToString());
                    string taskName = dgvTask.CurrentRow.Cells["Tên Nhiệm Vụ"].Value.ToString().Trim();
                    int assign = Convert.ToInt32(dgvTask.CurrentRow.Cells["EMPLOYEEID"].Value.ToString());
                    int status = Convert.ToInt32(dgvTask.CurrentRow.Cells["Tiến Độ"].Value.ToString());
                    string files = dgvTask.CurrentRow.Cells["Tệp"].Value.ToString();
                    string dueDate = DateTime.Parse(dgvTask.CurrentRow.Cells["Hạn Chót"].Value.ToString()).ToString("dd/MMM/yyyy");
                    int priority = Convert.ToInt32(dgvTask.CurrentRow.Cells["Mức Độ"].Value.ToString());
                    string description = dgvTask.CurrentRow.Cells["Mô Tả"].Value.ToString();
                    int department = Convert.ToInt32(dgvTask.CurrentRow.Cells["DEPARTMENTID"].Value.ToString());
                    int isDelete = 0;

                    // assign value for data transfer object 
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

                    //call frm follow roles
                    frmEditTask objFrmEditTask = new frmEditTask(RolesID);
                    objFrmEditTask.ShowDialog();
                }
            }
        }



        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblCurent.Text);
            page--;
            if (page > 0)
            {
                lblCurent.Text = page.ToString();
                dgvTask.DataSource = objTaskBus.GetAll(page);
                if (page != 0)
                    dgvTask.Columns["RN"].Visible = false;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblCurent.Text);
            int max = int.Parse(lblPage.Text);
            page++;
            if (page > max) return;
            lblCurent.Text = page.ToString();
            dgvTask.DataSource = objTaskBus.GetAll(page);
            dgvTask.Columns["RN"].Visible = false;
        }

        private void dgvTask_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTask.CurrentRow != null)
            {
                string link = dgvTask.CurrentRow.Cells["Tệp"].Value.ToString();
                if (!string.Empty.Equals(link))
                {
                    DialogResult dialog = MessageBox.Show("Bạn Có Muốn Xem Hoặc Tải Tệp?", "Xác Nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        if (Regex.IsMatch(link, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
                        {
                            System.Diagnostics.Process.Start(link);
                        }
                        else
                        {
                            MessageBox.Show("Đường Dẫn Không Đúng Định Dạng");
                        }
                    }
                }
            }
        }
    }
}
