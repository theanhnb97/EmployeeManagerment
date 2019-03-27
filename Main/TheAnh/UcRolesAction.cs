using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using BusinessLayer;

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
        private void UcRolesAction_Load(object sender, EventArgs e)
        {
            rolesTable = myRoles.Get();
            actionTable = myAction.Get();
            allData = myRolesActionBus.Get();
            m = rolesTable.Rows.Count;
            n = actionTable.Rows.Count;
            x = allData.Rows.Count;
            if (m * n != x) MessageBox.Show("Có lỗi về dữ liệu của bảng ma trận phân quyền!");
            LoadDataTable();
        }

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

        void LoadDataTable()
        {
            tlpnData.Controls.Add(new Label() { Text = "Tên Action" }, 0, 0);
            int start = 0;
            foreach (DataRow item in rolesTable.Rows)
            {
                start++;
                Label rolesName = new Label();
                rolesName.Text = item["ROLESNAME"].ToString();
                tlpnData.Controls.Add(rolesName, start, 0);
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
                BunifuiOSSwitch myOsSwitch= new BunifuiOSSwitch();
                myOsSwitch.Value = allData.Rows[i]["ISTRUE"].ToString()!="0";
                tlpnData.Controls.Add(myOsSwitch, cot, hang);
            }
        }
    }
}
