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

namespace Main
{
    public partial class Role_Add : Form
    {
        private RolesBUL myBul=new RolesBUL();
        private Roles myObjectEdit;
        public Role_Add()
        {
            myObjectEdit=new Roles();
            InitializeComponent();
        }

        public Role_Add(Roles myObjectEdit)
        {
            InitializeComponent();
            this.myObjectEdit = myObjectEdit;
        }

        private void Role_Add_Load(object sender, EventArgs e)
        {
            if (myObjectEdit.RolesID != 0)
            {
                txtName.Text = myObjectEdit.RolesName;
                txtDescription.Text = myObjectEdit.Description;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool IsValid()
        {
            if (myObjectEdit.RolesID != 0)
            {
                if (txtName.Text == myObjectEdit.RolesName && txtDescription.Text == myObjectEdit.Description)
                    return false;
            }
            if (txtName.Text == "" || txtDescription.Text == "") return false;
            return true;
        }

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
    }
}
