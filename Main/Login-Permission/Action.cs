namespace Main
{
    using BusinessLayer;
    using System;
    using System.Data;
    using System.Windows.Forms;
    using Action = Entity.Action;

    /// <summary>
    /// Defines the <see cref="Action_Add" />
    /// </summary>
    public partial class Action_Add : Form
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
            var myDataTable = myRolesActionBus.GetTrue(RolesID);
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
        /// Defines the myActionEdit
        /// </summary>
        private Entity.Action myActionEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Action_Add"/> class.
        /// </summary>
        /// <param name="myActionEdit">The myActionEdit<see cref="Action"/></param>
        /// <param name="id">The id<see cref="int"/></param>
        public Action_Add(Action myActionEdit, int id)
        {
            this.RolesID = id;
            this.myActionEdit = myActionEdit;
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action_Add"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public Action_Add(int id)
        {
            this.RolesID = id;
            this.myActionEdit = new Action();
            InitializeComponent();
        }

        /// <summary>
        /// Defines the myAction
        /// </summary>
        internal ActionBUS myAction = new ActionBUS();

        /// <summary>
        /// The Action_Add_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Action_Add_Load(object sender, EventArgs e)
        {
            if (myActionEdit.ActionID != 0)
            {
                txtName.Text = myActionEdit.ActionName;
                txtName.Enabled = false;
                txtDescription.Text = myActionEdit.Description;
            }
        }

        /// <summary>
        /// The btnCancel_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var myDialogResult = MessageBox.Show("Bạn có thực sự muốn huỷ bỏ thay đổi?", "Huỷ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var myActionAdd = new Action();
                myActionAdd.ActionID = myActionEdit.ActionID;
                myActionAdd.ActionName = txtName.Text;
                myActionAdd.Description = txtDescription.Text;
                myActionAdd.IsDelete = 0;
                bool result = false;
                if (myActionEdit.ActionID == 0)
                    result = myAction.Add(myActionAdd) == -1;
                else
                    result = myAction.Update(myActionAdd) == -1;
                if (result)
                {
                    MessageBox.Show("Thành công!");
                    lblNotify.Visible = false;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Thất bại!");
            }
            else
            {
                lblNotify.Text = "Xin vui lòng xem lại thông tin.";
                lblNotify.Visible = true;
            }
        }

        /// <summary>
        /// The IsValid
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool IsValid()
        {
            //if (myActionEdit.ActionID != 0)
            //{
            //    if (txtName.Text == myActionEdit.ActionName && txtDescription.Text == myActionEdit.Description)
            //        return false;
            //}
            if (txtName.Text == "" || txtDescription.Text == "") return false;
            return true;
        }

        /// <summary>
        /// The txtDescription_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(btnAdd, e);
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var myDialogResult = MessageBox.Show("Bạn có thực sự muốn huỷ bỏ thay đổi?", "Huỷ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
