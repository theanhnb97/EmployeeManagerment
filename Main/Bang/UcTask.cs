using System;
using System.Windows.Forms;
using BusinessLayer;

namespace Main
{
    public partial class UcTask : UserControl
    {
        public UcTask()
        {
            InitializeComponent();
        }

        private void Task_Load(object sender, EventArgs e)
        {
            TaskBus objTaskBus = new TaskBus();
            dgvTask.DataSource = objTaskBus.GetAll();

            if (dgvTask.DataSource == null)
            {
                MessageBox.Show("Data Not Found!");
            }
            else
            {
                dgvTask.Columns[0].HeaderCell.Value = "Số Định Danh";
                dgvTask.Columns[1].HeaderCell.Value = "Nhiệm Vụ";
                dgvTask.Columns[2].HeaderCell.Value = "Người Thực Hiện";
                dgvTask.Columns[3].HeaderCell.Value = "Hạn Chót";
                dgvTask.Columns[4].HeaderCell.Value = "Mô Tả";
                dgvTask.Columns[5].HeaderCell.Value = "Tệp Đính Kèm";
                dgvTask.Columns[6].HeaderCell.Value = "Trạng Thái";
            }
        }

        private void btnLoadData_Click(object sender, System.EventArgs e)
        {
            TaskBus objTaskBus = new TaskBus();
            dgvTask.DataSource = objTaskBus.Filter(txtNameFilter.Text, Convert.ToInt32(cmbDepartment.selectedValue), dtpDeuDateFilter.Value);
        }


    }
}
