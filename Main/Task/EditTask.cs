using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
                    MessageBox.Show("Phòng/Ban Không Có Dữ Liệu!", "Cảnh Báo");
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
                    MessageBox.Show("Mức Độ Không Có Dữ Liệu!", "Cảnh Báo");
                }

                //assign file from data transfer object
                txtTaskName.Text = TaskDTO.TaskName;
                txtDescription.Text = TaskDTO.Description;
                cmbAssign.SelectedValue = TaskDTO.Assign;
                cmbDepartment.SelectedValue = TaskDTO.Department;
                cmbLevel.SelectedValue = TaskDTO.Priority;
                dtpDueDate.Value = Convert.ToDateTime(TaskDTO.DueDate);
                linkFile.Text = TaskDTO.Files;


            }
            catch (Exception exception)
            {
                MessageBox.Show("Lỗi Bất Thường");
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
                    MessageBox.Show("Phòng/Ban Không Có Nhân Viên", "Cảnh Báo");

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
                    MessageBox.Show("Nhập Tên Nhiệm Vụ!", "Cảnh Báo");
                }
                else if (string.Empty.Equals(txtDescription.Text.Trim()))
                {
                    MessageBox.Show("Nhập Mô Tả!", "WarnCảnh Báo");
                }
                else if (Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,200}") == false)
                {
                    MessageBox.Show(" Tên Nhiệm Vụ Phải Có Ít Nhất 2 Ký Tự!", "Cảnh Báo");
                }
                else if (Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,2000}") == false)
                {
                    MessageBox.Show("Mô Tả Phải Có Ít Nhất 2 Ký Tự!", "Cảnh Báo");
                }
                else if (Convert.ToDateTime(dtpDueDate.Value) < DateTime.Today)
                {
                    MessageBox.Show("Hạn Chót Phải ' > ' Hoặc ' = ' Ngày Hiện Tại", "Cảnh Báo");
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
                    TaskDTO.Files = linkFile.Text;
                    //check result
                    if (objTaskBus.Update(TaskDTO.TaskId, TaskDTO.TaskName, TaskDTO.Assign,
                        TaskDTO.DueDate, TaskDTO.Priority, TaskDTO.Files, TaskDTO.Status, TaskDTO.IsDelete,
                        TaskDTO.Description) != 0)
                    {
                        MessageBox.Show("Thành Công!", "Trạng Thái");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại!", "Trạng Thái");
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
                Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,200}") == false)
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
                MessageBox.Show("Nhập Tên Nhiệm Vụ!", "Cảnh Báo");
                txtTaskName.Focus();
            }
            else if (Regex.IsMatch(txtTaskName.Text.Trim(), "\\w{2,200}") == false)
            {
                MessageBox.Show("Tên Nhiệm Vụ Phải Có Ít Nhất 2 Ký Tự!", "Cảnh Báo");
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
                Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,2000}") == false)
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
                MessageBox.Show("Nhập Mô Tả!", "Cảnh Báo");
                txtDescription.Focus();
            }
            else if (Regex.IsMatch(txtDescription.Text.Trim(), "\\w{2,2000}") == false)
            {
                MessageBox.Show(" Mô Tả Phải Có Ít Nhất 2 Ký Tự! ", "Cảnh Báo");
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
                MessageBox.Show("Hạn Chót Phải ' > ' Hoặc ' = ' Ngày Hiện Tại", "Cảnh Báo");
                dtpDueDate.Focus();
                lbDate.ForeColor = Color.Red;
            }
            else
            {
                lbDate.ForeColor = Color.DarkGreen;
            }

        }

        private void btnSelectfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog myDialog = new OpenFileDialog())
            {
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                myDialog.Title = "Chọn Tệp Đính Kèm";
                myDialog.Filter = "Image|*.png; *.jpg; *.jpeg | Word file| *.docx| Excel file |*.xlsx";

                if (myDialog.ShowDialog() == DialogResult.OK)
                {

                    FileInfo fiArr = new FileInfo(myDialog.FileName);
                    MessageBox.Show(fiArr.Length.ToString());
                    if (fiArr.Length > long.Parse(ConfigurationManager.AppSettings["sizeFile"]))
                    {
                        MessageBox.Show("Dung lượng tệp lớn hơn 6MB", "Cảnh Báo");
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
                        linkFile.Text = CommonLibrary.FPTFile.UploadFtpFile("", myDialog.FileName);
                        lbWaiting.Text = "Tệp Tải Lên Thành Công";
                        btnUpdate.Enabled = true;
                    }
                }
            }
        }

        private void linkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.Empty.Equals(linkFile.Text))
            {
                DialogResult dialog = MessageBox.Show("Bạn Có Muốn Xem Tệp Hoặc Tải?", "Xác Nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (Regex.IsMatch(linkFile.Text, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
                    {
                        System.Diagnostics.Process.Start(linkFile.Text);
                    }
                    else
                    {
                        MessageBox.Show("Đường Dẫn Định Dạng Không Hợp Lệ!");
                    }
                }
            }
        }
    }
}

