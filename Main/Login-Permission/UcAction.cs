namespace Main
{
    using BusinessLayer;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Action = Entity.Action;

    /// <summary>
    /// Defines the <see cref="UcAction" />
    /// </summary>
    public partial class UcAction : UserControl
    {
        /// <summary>
        /// Defines the myRolesActionBus
        /// </summary>
        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();

        /// <summary>
        /// Gets or sets the RolesID
        /// </summary>
        protected int RolesID { get; set; }

        /// <summary>
        /// The OnLoad
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="UcAction"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public UcAction(int id)
        {
            this.RolesID = id;
            InitializeComponent();
        }

        /// <summary>
        /// Defines the myAction
        /// </summary>
        internal ActionBUS myAction = new ActionBUS();

        /// <summary>
        /// The ActionManagement_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void ActionManagement_Load(object sender, EventArgs e)
        {
            Loadd();
        }

        /// <summary>
        /// The Loadd
        /// </summary>
        public void Loadd()
        {
            dgvData.DataSource = myAction.GetList();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Action_Add formAdd = new Action_Add(RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                Loadd();
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
                MessageBox.Show("Chọn 1 trong số các Action để thực hiện xoá!");
                return;
            }
            int index = int.Parse(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells[0].Value.ToString());
            DialogResult myDialogResult = MessageBox.Show("Bạn thực sự muốn xoá Action này?", "Nhắc nhở",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                if (myAction.Delete(index) == -1)
                    MessageBox.Show("Xoá thành công!");
                else
                    MessageBox.Show("Xoá thất bại");
                Loadd();
            }
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
                MessageBox.Show("Chọn 1 trong số các Action để thực hiện sửa!");
                return;
            }
            int index = dgvData.CurrentCell.RowIndex;
            Action myActionEdit = new Action();
            myActionEdit.ActionID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
            myActionEdit.ActionName = dgvData.Rows[index].Cells[1].Value.ToString();
            myActionEdit.Description = dgvData.Rows[index].Cells[3].Value.ToString();
            Action_Add formAdd = new Action_Add(myActionEdit, RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                Loadd();
        }

        /// <summary>
        /// The btnScan_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Bạn có thực sự muốn quét lại chức năng của hệ thống?", "Nguy hiểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                if (myRolesActionBus.DeleteAll() != 0)
                {
                    Type formType = typeof(Form);
                    Type ucType = typeof(UserControl);
                    foreach (Type item in Assembly.GetExecutingAssembly().GetTypes())
                    {
                        if (formType.IsAssignableFrom(item) || ucType.IsAssignableFrom(item))
                        {
                            var name = item.Name + ".";
                            if (!(name.Contains("_.")))
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

        /// <summary>
        /// The dgvData_CellDoubleClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            Action_Add formAdd = new Action_Add(myActionEdit, RolesID);
            if (formAdd.ShowDialog() == DialogResult.OK)
                Loadd();
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
                Action myActionEdit = new Action();
                myActionEdit.ActionID = int.Parse(dgvData.Rows[index].Cells[0].Value.ToString());
                myActionEdit.ActionName = dgvData.Rows[index].Cells[1].Value.ToString();
                myActionEdit.Description = dgvData.Rows[index].Cells[3].Value.ToString();
                Action_Add formAdd = new Action_Add(myActionEdit, RolesID);
                if (formAdd.ShowDialog() == DialogResult.OK)
                    Loadd();
            }
        }
    }
}
