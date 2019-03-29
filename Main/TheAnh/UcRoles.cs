using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
using Action = Entity.Action;

namespace Main
{
    public partial class UcRoles : UserControl
    {
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
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





        public UcRoles(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }
        RolesBUL myBus = new RolesBUL();
        private void UcRoles_Load(object sender, EventArgs e)
        {
            Loadd();
        }
        public void Loadd()
        {
            dgvData.DataSource = myBus.Get();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Role_Add formAdd = new Role_Add(RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                Loadd();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Role để thực hiện sửa!");
                return;
            }
            int index = dgvData.CurrentCell.RowIndex;
            Roles myObject = new Roles();
            myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
            myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            Role_Add formAdd = new Role_Add(myObject,RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                Loadd();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Role để thực hiện xoá!");
                return;
            }
            int index = int.Parse(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[0].Value.ToString());
            DialogResult myDialogResult = MessageBox.Show("Bạn thực sự muốn xoá Role này?", "Nhắc nhở",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                if (myBus.Delete(index) == -1)
                    MessageBox.Show("Xoá thành công!");
                else
                    MessageBox.Show("Xoá thất bại");
                Loadd();
            }
        }
        
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvData.CurrentCell.RowIndex;
            Roles myObject = new Roles();
            myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
            myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            Role_Add formAdd = new Role_Add(myObject, RolesID);
            if(formAdd.ShowDialog()==DialogResult.OK)
                Loadd();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = dgvData.CurrentCell.RowIndex;
                Roles myObject = new Roles();
                myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
                myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
                myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
                Role_Add formAdd = new Role_Add(myObject, RolesID);
                if (formAdd.ShowDialog() == DialogResult.OK)
                    Loadd();
            }
        }
    }
}
