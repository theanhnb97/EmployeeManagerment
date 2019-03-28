using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using BusinessLayer;
using Entity;

namespace Main
{
    public partial class UcRolesAction : UserControl
    {
        RolesBUL myRoles = new RolesBUL();
        ActionBUS myAction = new ActionBUS();
        RolesActionBUS myRolesActionBus = new RolesActionBUS();
        private TableLayoutPanel tlpnData;
        public UcRolesAction()
        {
            CreateTable();
            InitializeComponent();
            this.Controls.Add(tlpnData);
        }

        private DataTable rolesTable, actionTable, allData;
        private int m, n, x;
        void CreateTable()
        {
            tlpnData = new TableLayoutPanel();
            tlpnData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpnData.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpnData.Location = new Point(7, 50);
            tlpnData.Name = "tlpnData";
            tlpnData.AutoScroll = true;
            tlpnData.MaximumSize = new Size(793, 479);
            tlpnData.Size = new Size(793, 479);
        }

        Label Getlabel(String Text)
        {
            Label obj = new Label();
            obj.Text = Text;
            obj.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            obj.ForeColor = SystemColors.HotTrack;
            return obj;
        }

        /*BunifuFlatButton GetButton(String Text)
        {
            BunifuFlatButton btnReturn=new BunifuFlatButton();
            btnReturn.Activecolor = Color.SteelBlue;
            btnReturn.BackColor = Color.SteelBlue;
            btnReturn.BackgroundImageLayout = ImageLayout.Stretch;
            btnReturn.BorderRadius = 0;
            btnReturn.ButtonText = Text;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.DisabledColor = Color.Gray;
            btnReturn.Iconcolor = Color.Transparent;
            btnReturn.Iconimage = null;
            btnReturn.Iconimage_right = null;
            btnReturn.Iconimage_right_Selected = null;
            btnReturn.Iconimage_Selected = null;
            btnReturn.IconMarginLeft = 0;
            btnReturn.IconMarginRight = 0;
            btnReturn.IconRightVisible = true;
            btnReturn.IconRightZoom = 0D;
            btnReturn.IconVisible = true;
            btnReturn.IconZoom = 90D;
            btnReturn.IsTab = false;
            btnReturn.Location = new Point(729, 544);
            btnReturn.Name = "btnReturn";
            btnReturn.Normalcolor = Color.SteelBlue;
            btnReturn.OnHovercolor = Color.SteelBlue;
            btnReturn.OnHoverTextColor = Color.White;
            btnReturn.selected = false;
            btnReturn.Size = new Size(71, 36);
            btnReturn.TabIndex = 11;
            btnReturn.Text = Text;
            btnReturn.TextAlign = ContentAlignment.MiddleCenter;
            btnReturn.Textcolor = Color.White;
            btnReturn.TextFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            return btnReturn;
        }*/

        void LoadForm()
        {
            tlpnData.Controls.Clear();
            rolesTable = myRoles.Get();
            actionTable = myAction.Get();
            allData = myRolesActionBus.Get();
            m = rolesTable.Rows.Count;
            n = actionTable.Rows.Count;
            x = allData.Rows.Count;
            if (m * n != x) MessageBox.Show("Có lỗi về dữ liệu của bảng ma trận phân quyền!");
            LoadDataTable();
        }
        void LoadDataTable()
        {
            //tlpnData.Controls.Add(Getlabel("."), 0, 0);
            int start = 0;
            foreach (DataRow item in rolesTable.Rows)
            {
                start++;
                var rolesName = Getlabel(item["ROLESNAME"].ToString());
                tlpnData.Controls.Add(rolesName, start, 0);
            }

            start = 0;
            foreach (DataRow item in actionTable.Rows)
            {
                start++;
                var obj = Getlabel(item["ACTIONNAME"].ToString());
                tlpnData.Controls.Add(obj, 0, start);
            }

            int hang = 1, cot = 0;
            for (int i = 0; i < x; i++)
            {
                cot++;
                if (cot > m)
                {
                    hang++;
                    cot = 1;
                }
                BunifuiOSSwitch myOsSwitch = new BunifuiOSSwitch();
                myOsSwitch.OnColor = SystemColors.HotTrack;
                myOsSwitch.Text = allData.Rows[i]["ID"].ToString();
                myOsSwitch.Value = allData.Rows[i]["ISTRUE"].ToString() != "0";
                tlpnData.Controls.Add(myOsSwitch, cot, hang);
            }
        }

        private void UcRolesAction_Enter(object sender, EventArgs e)
        {
            //LoadForm();
        }

        private void UcRolesAction_MouseClick(object sender, MouseEventArgs e)
        {
            //LoadForm();
        }

        private void UcRolesAction_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật quyền cho Roles?", "Câu hỏi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                List<RolesAction> myArray = new List<RolesAction>();
                List<BunifuiOSSwitch> myList = tlpnData.Controls.OfType<BunifuiOSSwitch>().ToList();
                foreach (BunifuiOSSwitch item in myList)
                {
                    RolesAction temp = new RolesAction();
                    temp.ID = int.Parse(item.Text);
                    if (item.Value)
                        temp.IsTrue = 1;
                    else
                        temp.IsTrue = 0;
                    myArray.Add(temp);
                }

                if (myRolesActionBus.Update(myArray) == -1)
                {
                    MessageBox.Show("Thành công!");
                    LoadForm();
                }
                else
                    MessageBox.Show("Thất bại!");

            }
        }
    }
}
