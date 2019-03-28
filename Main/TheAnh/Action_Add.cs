using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
using Action = Entity.Action;

namespace Main
{
    public partial class Action_Add : Form
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



        private Entity.Action myActionEdit;
        public Action_Add(Action myActionEdit,int id)
        {
            this.myActionEdit = myActionEdit;
            InitializeComponent();
        }
        public Action_Add(int id)
        {
            this.myActionEdit = new Action();
            InitializeComponent();
        }
        ActionBUS myAction=new ActionBUS();

        private void Action_Add_Load(object sender, EventArgs e)
        {
            if (myActionEdit.ActionID != 0)
            {
                txtName.Text = myActionEdit.ActionName;
                txtDescription.Text = myActionEdit.Description;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Action myActionAdd=new Action();
                myActionAdd.ActionID = myActionEdit.ActionID;
                myActionAdd.ActionName = txtName.Text;
                myActionAdd.Description = txtDescription.Text;
                myActionAdd.IsDelete = 0;
                bool result = false;
                if (myActionEdit.ActionID == 0)
                    result =myAction.Add(myActionAdd) == -1;
                else
                    result = myAction.Update(myActionAdd) == -1;
                if (result)
                {
                    MessageBox.Show("Thành công!");
                    lblNotify.Visible = false;
                    this.Close();
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

        bool IsValid()
        {
            if (myActionEdit.ActionID != 0)
            {
                if (txtName.Text == myActionEdit.ActionName && txtDescription.Text == myActionEdit.Description)
                    return false;
            }
            if (txtName.Text == "" || txtDescription.Text == "") return false;
            return true;
        }
    }
}
