namespace Main
{
    using Bunifu.Framework.UI;
    using BusinessLayer;
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="UcRolesAction" />
    /// </summary>
    public partial class UcRolesAction : UserControl
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
        /// Defines the myRoles
        /// </summary>
        internal RolesBUL myRoles = new RolesBUL();

        /// <summary>
        /// Defines the myAction
        /// </summary>
        internal ActionBUS myAction = new ActionBUS();

        /// <summary>
        /// Defines the tlpnData
        /// </summary>
        private TableLayoutPanel tlpnData;
        private TableLayoutPanel tlpnHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="UcRolesAction"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public UcRolesAction(int id)
        {
            this.RolesID = id;
            CreateTable();
            InitializeComponent();
            this.Controls.Add(tlpnData);
            this.Controls.Add(tlpnHeader);
        }

        /// <summary>
        /// Defines the rolesTable, actionTable, allData
        /// </summary>
        private DataTable rolesTable, actionTable, allData;

        /// <summary>
        /// Defines the m, n, x
        /// </summary>
        private int m, n, x;

        /// <summary>
        /// The CreateTable
        /// </summary>
        internal void CreateTable()
        {
            tlpnData = new TableLayoutPanel();
            tlpnData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpnData.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpnData.Location = new Point(7, 80);
            tlpnData.Name = "tlpnData";
            tlpnData.AutoScroll = true;
            tlpnData.MaximumSize = new Size(793, 449);
            tlpnData.Size = new Size(793, 479);
            
            tlpnHeader = new TableLayoutPanel();
            tlpnHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpnHeader.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpnHeader.Name = "tlpnHeader";
            tlpnHeader.AutoScroll = true;
            tlpnHeader.Size = new Size(793, 30);
            tlpnHeader.Location = new Point(7, 50);
        }

        /// <summary>
        /// The Getlabel
        /// </summary>
        /// <param name="Text">The Text<see cref="String"/></param>
        /// <returns>The <see cref="Label"/></returns>
        internal Label Getlabel(String Text)
        {
            Label obj = new Label();
            obj.Text = Text;
            obj.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            obj.ForeColor = SystemColors.HotTrack;
            return obj;
        }

        /// <summary>
        /// The LoadForm
        /// </summary>
        private void LoadForm()
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

        /// <summary>
        /// The LoadDataTable
        /// </summary>
        private void LoadDataTable()
        {
            // Roles List
            tlpnData.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpnHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            int start = 0;
            foreach (DataRow item in rolesTable.Rows)
            {
                tlpnData.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
                tlpnHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
                start++;
                var rolesName = Getlabel(item["ROLESNAME"].ToString());
                //var rolesName = Getlabel(item["DESCRIPTION"].ToString());
                tlpnHeader.Controls.Add(rolesName, start, 0);
            }

            // Action List
            start = 0;
            foreach (DataRow item in actionTable.Rows)
            {
                start++;
                //var obj = Getlabel(item["ACTIONNAME"].ToString());
                var obj = Getlabel(item["DESCRIPTION"].ToString());
                tlpnData.Controls.Add(obj, 0, start);
            }

            // Load Data
            int hang = 1, cot = 0;
            for (int i = 0; i < x; i++)
            {
                cot++;
                if (cot > m)
                {
                    hang++;
                    cot = 1;
                }
                var myOsSwitch = new BunifuiOSSwitch();
                myOsSwitch.OnColor = SystemColors.HotTrack;
                myOsSwitch.Name = allData.Rows[i]["ID"].ToString();
                myOsSwitch.Value = allData.Rows[i]["ISTRUE"].ToString() != "0";
                tlpnData.Controls.Add(myOsSwitch, cot, hang);
            }
        }

        /// <summary>
        /// The UcRolesAction_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void UcRolesAction_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The UcRolesAction_MouseClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="MouseEventArgs"/></param>
        private void UcRolesAction_MouseClick(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The UcRolesAction_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void UcRolesAction_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        /// <summary>
        /// The btnAdd_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var myDialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật quyền cho Roles?", "Câu hỏi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                var myArray = new List<RolesAction>();
                var myList = tlpnData.Controls.OfType<BunifuiOSSwitch>().ToList();
                foreach (var item in myList)
                {
                    var temp = new RolesAction();
                    temp.ID = int.Parse(item.Name);
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
