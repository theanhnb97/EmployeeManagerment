namespace Main
{
    using BusinessLayer;
    using Main.Dai;
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
    /// Defines the <see cref="FormMain_" />
    /// </summary>
    public partial class FormMain_ : Form
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
            //DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            //bool result = RolesID == 1;
            //string formName = base.Name+".";
            //string Action = "";
            //foreach (DataRow item in myDataTable.Rows)
            //    Action += item["ACTIONNAME"].ToString().Trim() + ".";
            //if (Action.Contains(formName)) result = true;
            //if (result)
            base.OnLoad(e);
            //else
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập vào Hệ thống này!");
            //    //picLogout_Click(picLogout, e);
            //}
        }

        /// <summary>
        /// Defines the btnMenuButtons
        /// </summary>
        private List<Button> btnMenuButtons;

        /// <summary>
        /// Defines the salary
        /// </summary>
        internal SalaryManagement salary;

        /// <summary>
        /// Defines the ucActionManagement
        /// </summary>
        internal UcAction ucActionManagement;

        /// <summary>
        /// Defines the ucRoles
        /// </summary>
        internal UcRoles ucRoles;

        /// <summary>
        /// Defines the ucRolesAction
        /// </summary>
        internal UcRolesAction ucRolesAction;

        /// <summary>
        /// Defines the ucEmployees
        /// </summary>
        internal Employees ucEmployees;

        /// <summary>
        /// Defines the ucTask
        /// </summary>
        internal UcTask ucTask;

        /// <summary>
        /// Defines the ucDepartment
        /// </summary>
        internal UcDepartment ucDepartment;

        /// <summary>
        /// Defines the ucUpdateProfile
        /// </summary>
        private UcUpdateProfile_ ucUpdateProfile;

        /// <summary>
        /// The LoadUC
        /// </summary>
        private void LoadUC()
        {
            pnMain.Controls.Add(ucActionManagement);
            ucActionManagement.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucEmployees);
            ucEmployees.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucTask);
            ucTask.Dock = DockStyle.Fill;
            pnMain.Controls.Add(salary);
            salary.Dock = DockStyle.Fill;
            pnMain.Controls.Add(ucRoles);
            ucRoles.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucRolesAction);
            ucRolesAction.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucDepartment);
            ucDepartment.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucUpdateProfile);
            ucUpdateProfile.Dock = DockStyle.Fill;


            salary.BringToFront();
        }

        /// <summary>
        /// Defines the userName
        /// </summary>
        private string userName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain_"/> class.
        /// </summary>
        /// <param name="rolesId">The rolesId<see cref="int"/></param>
        /// <param name="username">The username<see cref="string"/></param>
        public FormMain_(int rolesId,string username)
        {
            this.RolesID = rolesId;
            this.userName = username;
            InitializeComponent();
            ucUpdateProfile = new UcUpdateProfile_(username);
            ucActionManagement = new UcAction(RolesID);
            ucRoles = new UcRoles(RolesID);
            ucRolesAction = new UcRolesAction(RolesID);
            ucTask = new UcTask(RolesID);
            ucEmployees = new Employees(RolesID);
            ucDepartment = new UcDepartment(RolesID);
            salary = new SalaryManagement(RolesID);
            btnMenuButtons = new List<Button>();
        }

        /// <summary>
        /// The FormMain_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            btnSalary.BackColor = pnSlide.BackColor;
            btnSalary.ForeColor = Color.AliceBlue;
            btnMenuButtons.Add(btnAction);
            btnMenuButtons.Add(btnRole);
            btnMenuButtons.Add(btnPhanQuyen);
            btnMenuButtons.Add(btnDepartment);
            btnMenuButtons.Add(btnEmployee);
            btnMenuButtons.Add(btnTask);
            btnMenuButtons.Add(btnSalary);
            LoadUC();
        }

        /// <summary>
        /// The picLogout_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void picLogout_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult = MessageBox.Show("Do you want logout?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                Thread threadMainForm = new Thread(new ThreadStart(ShowFormLogin));
                threadMainForm.Start();
                Application.Exit();
            }
        }

        /// <summary>
        /// The ShowFormLogin
        /// </summary>
        private void ShowFormLogin()
        {
            Login_ f = new Login_();
            f.ShowDialog();
        }

        /// <summary>
        /// The LoacationSlide
        /// </summary>
        /// <param name="slide">The slide<see cref="Panel"/></param>
        /// <param name="inActiceButton">The inActiceButton<see cref="Button"/></param>
        internal void LoacationSlide(Panel slide,Button inActiceButton)
        {
            foreach (Button item in btnMenuButtons)
            {
                if (item != inActiceButton)
                {
                    item.BackColor = Color.FloralWhite;
                    item.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    item.BackColor = pnSlide.BackColor;
                    item.ForeColor = Color.AliceBlue;
                }
            }
            slide.Height = inActiceButton.Height;
            slide.Top = inActiceButton.Top;
        }

        /// <summary>
        /// The btnMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            Button inActiceButton = (Button) sender;
            LoacationSlide(this.pnSlide,inActiceButton);
        }

        /// <summary>
        /// The btnPhanQuyen_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender,e);
            ucRolesAction.BringToFront();
        }

        /// <summary>
        /// The btnRole_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnRole_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucRoles.BringToFront();
        }

        /// <summary>
        /// The btnAction_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAction_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucActionManagement.BringToFront();
        }

        /// <summary>
        /// The btnSalary_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnSalary_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            salary.BringToFront();
        }

        /// <summary>
        /// The btnTask_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucTask.BringToFront();
        }

        /// <summary>
        /// The btnDepartment_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucDepartment.BringToFront();
        }

        /// <summary>
        /// The btnEmployee_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucEmployees.BringToFront();
        }

        /// <summary>
        /// The btnProfile_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnProfile_Click(object sender, EventArgs e)
        {
            ucUpdateProfile.BringToFront();
        }
    }
}
