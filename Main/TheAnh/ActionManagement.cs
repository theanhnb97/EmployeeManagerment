using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Action = Entity.Action;

namespace Main
{
    public partial class ActionManagement:UserControl
    {

        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string ucName = base.Name+ ".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(ucName)) result = true;
            if (result)
                base.OnLoad(e);
            else
                this.Hide();
        }

        



       
        public ActionManagement(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        ActionBUS myAction = new ActionBUS();
        private void ActionManagement_Load(object sender, EventArgs e)
        {
            Loadd();
        }

        public void Loadd()
        {
            dgvData.DataSource = myAction.Get();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Action_Add formAdd = new Action_Add(RolesID);
            formAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Action để thực hiện xoá!");
                return;
            }
            int index = int.Parse(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[0].Value.ToString());
            DialogResult myDialogResult = MessageBox.Show("Bạn thực sự muốn xoá Action này?", "Nhắc nhở",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                if (myAction.Delete(index) == -1)
                    MessageBox.Show("Xoá thành công!");
                else
                    MessageBox.Show("Xoá thất bại");
                Loadd();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Action để thực hiện sửa!");
                return;
            }
            int index = dgvData.CurrentCell.RowIndex;
            Action myActionEdit = new Action();
            myActionEdit.ActionID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myActionEdit.ActionName = dgvData.Rows[index].Cells[1].Value.ToString();
            myActionEdit.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            Action_Add formAdd = new Action_Add(myActionEdit,RolesID);
            formAdd.ShowDialog();
        }

        private void ActionManagement_Click(object sender, EventArgs e)
        {
            Loadd();
        }

        private void ActionManagement_Enter(object sender, EventArgs e)
        {
            Loadd();
        }

        private void dgvData_Enter(object sender, EventArgs e)
        {
            Loadd();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Bạn có thực sự muốn quét lại chức năng của hệ thống?", "Nguy hiểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                myRolesActionBus.DeleteAll();
                Type formType = typeof(Form);
                Type ucType = typeof(UserControl);
                foreach (Type item in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (formType.IsAssignableFrom(item) || ucType.IsAssignableFrom(item))
                    {
                        {
                            Action myActionAdd = new Action();
                            myActionAdd.ActionID = 0;
                            myActionAdd.ActionName = item.Name;
                            myActionAdd.Description = item.Name;
                            myActionAdd.IsDelete = 0;
                            myAction.Add(myActionAdd);
                        }
                    }
                }
            }
            
        }

    }
}
