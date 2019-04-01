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

    /// <summary>
    /// Defines the <see cref="Role_Add" />
    /// </summary>
    public partial class Role_Add : Form
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
        /// Defines the myBul
        /// </summary>
        private RolesBUL myBul=new RolesBUL();

        /// <summary>
        /// Defines the myObjectEdit
        /// </summary>
        private Roles myObjectEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Role_Add"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public Role_Add(int id)
        {
            this.RolesID = id;
            myObjectEdit=new Roles();
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role_Add"/> class.
        /// </summary>
        /// <param name="myObjectEdit">The myObjectEdit<see cref="Roles"/></param>
        /// <param name="id">The id<see cref="int"/></param>
        public Role_Add(Roles myObjectEdit,int id)
        {
            this.RolesID = id;
            InitializeComponent();
            this.myObjectEdit = myObjectEdit;
        }

        /// <summary>
        /// The Role_Add_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Role_Add_Load(object sender, EventArgs e)
        {
            if (myObjectEdit.RolesID != 0)
            {
                txtName.Text = myObjectEdit.RolesName;
                txtDescription.Text = myObjectEdit.Description;
            }
        }

        /// <summary>
        /// The btnCancel_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The IsValid
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        internal bool IsValid()
        {
            if (myObjectEdit.RolesID != 0)
            {
                if (txtName.Text == myObjectEdit.RolesName && txtDescription.Text == myObjectEdit.Description)
                    return false;
            }
            if (txtName.Text == "" || txtDescription.Text == "") return false;
            return true;
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
                Roles myAdd = new Roles();
                myAdd.RolesID = myObjectEdit.RolesID;
                myAdd.RolesName = txtName.Text;
                myAdd.Description = txtDescription.Text;
                myAdd.IsDelete = 0;
                bool result = false;
                if (myObjectEdit.RolesID == 0)
                    result = myBul.Add(myAdd) == -1;
                else
                    result = myBul.Update(myAdd) == -1;
                if (result)
                {
                    MessageBox.Show("Thành công!");
                    lblNotify.Visible = false;
                    this.DialogResult=DialogResult.OK;
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
        /// The txtName_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(btnAdd,e);
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
