namespace Main
{
    using BusinessLayer;
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Action = Entity.Action;

    /// <summary>
    /// Defines the <see cref="UcRoles" />
    /// </summary>
    public partial class UcRoles : UserControl
    {

        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();

        private readonly RolesBUL myBus = new RolesBUL();

        protected int RolesID { get; set; }


        /// <summary>
        /// The OnLoad
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected override void OnLoad(EventArgs e)
        {
            var myDataTable = myRolesActionBus.GetTrue(RolesID);
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

        /// <summary>
        /// Initializes a new instance of the <see cref="UcRoles"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public UcRoles(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }


        /// <summary>
        /// The UcRoles_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void UcRoles_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// The Loadd
        /// </summary>
        public void LoadData()
        {
            dgvData.DataSource = myBus.Get();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Role_Add formAdd = new Role_Add(RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        /// <summary>
        /// The btnEdit_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Role để thực hiện sửa!");
                return;
            }
            int index = dgvData.CurrentCell.RowIndex;
            var myObject = new Roles();
            myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
            myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            var formAdd = new Role_Add(myObject, RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        /// <summary>
        /// The btnDelete_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount < 1)
            {
                MessageBox.Show("Chọn 1 trong số các Role để thực hiện xoá!");
                return;
            }
            int index = int.Parse(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[0].Value.ToString());
            var myDialogResult = MessageBox.Show("Bạn thực sự muốn xoá Role này?", "Nhắc nhở",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                MessageBox.Show(myBus.Delete(index) == -1 ? "Thành công." : "Thất bại.");
                LoadData();
            }
        }

        /// <summary>
        /// The dgvData_CellDoubleClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvData.CurrentCell.RowIndex;
            var myObject = new Roles();
            myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
            myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            var formAdd = new Role_Add(myObject, RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        /// <summary>
        /// The dgvData_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = dgvData.CurrentCell.RowIndex;
                var myObject = new Roles();
                myObject.RolesID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
                myObject.RolesName = dgvData.Rows[index].Cells[1].Value.ToString();
                myObject.Description = dgvData.Rows[index].Cells[3].Value.ToString();
                var formAdd = new Role_Add(myObject, RolesID);
                if (formAdd.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }
    }
}
