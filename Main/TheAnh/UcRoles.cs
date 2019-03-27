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
        public UcRoles()
        {
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
            Role_Add formAdd = new Role_Add();
            formAdd.ShowDialog();
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
            Role_Add formAdd = new Role_Add(myObject);
            formAdd.ShowDialog();
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

        private void UcRoles_Click(object sender, EventArgs e)
        {
            Loadd();
        }

        private void dgvData_Enter(object sender, EventArgs e)
        {
            Loadd();
        }

        private void UcRoles_Enter(object sender, EventArgs e)
        {
            Loadd();
        }
    }
}
