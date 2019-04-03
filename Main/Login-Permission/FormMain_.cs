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
        /// Defines the btnMenuButtons
        /// </summary>
        private List<Button> btnMenuButtons;

        /// <summary>
        /// Defines the salary
        /// </summary>
        private SalaryManagement salary;

        /// <summary>
        /// Defines the ucActionManagement
        /// </summary>
        private UcAction ucActionManagement;

        /// <summary>
        /// Defines the ucRoles
        /// </summary>
        private UcRoles ucRoles;

        /// <summary>
        /// Defines the ucRolesAction
        /// </summary>
        private UcRolesAction ucRolesAction;

        /// <summary>
        /// Defines the ucEmployees
        /// </summary>
        private Employees ucEmployees;

        /// <summary>
        /// Defines the ucTask
        /// </summary>
        private UcTask ucTask;

        /// <summary>
        /// Defines the ucDepartment
        /// </summary>
        private UcDepartment ucDepartment;

        /// <summary>
        /// Defines the ucUpdateProfile
        /// </summary>
        private UcUpdateProfile_ ucUpdateProfile;

        /// <summary>
        /// The LoadUC
        /// </summary>
        private void LoadUC()
        {
            lblUserName.Text = String.Format("Xin chào: {0}!",userName);
            lblUserName.Location= new Point(pnBot.Width-(lblUserName.Width+10),lblUserName.Location.Y);
            salary = new SalaryManagement(RolesID);
            pnMain.Controls.Add(salary);
            salary.Dock = DockStyle.Fill;
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
            var myDialogResult = MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
                Application.Exit();
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
        private void LoacationSlide(Panel slide,Button inActiceButton)
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
            if (ucRolesAction == null)
            {
                ucRolesAction = new UcRolesAction(RolesID);
                pnMain.Controls.Add(ucRolesAction);
                ucRolesAction.Dock = DockStyle.Fill;
            }
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
            ucRoles = new UcRoles(RolesID);
            pnMain.Controls.Add(ucRoles);
            ucRoles.Dock = DockStyle.Fill;
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
            ucActionManagement = new UcAction(RolesID);
            pnMain.Controls.Add(ucActionManagement);
            ucActionManagement.Dock = DockStyle.Fill;
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
            salary = new SalaryManagement(RolesID);
            pnMain.Controls.Add(salary);
            salary.Dock = DockStyle.Fill;
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
            ucTask = new UcTask(RolesID);
            pnMain.Controls.Add(ucTask);
            ucTask.Dock = DockStyle.Fill;
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
            ucDepartment = new UcDepartment(RolesID);
            pnMain.Controls.Add(ucDepartment);
            ucDepartment.Dock = DockStyle.Fill;
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
            ucEmployees = new Employees(RolesID);
            pnMain.Controls.Add(ucEmployees);
            ucEmployees.Dock = DockStyle.Fill;
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
            ucUpdateProfile = new UcUpdateProfile_(userName);
            pnMain.Controls.Add(ucUpdateProfile);
            ucUpdateProfile.Dock = DockStyle.Fill;
            ucUpdateProfile.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var myDialogResult = MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myDialogResult == DialogResult.Yes)
            {
                var threadMainForm = new Thread(new ThreadStart(ShowFormLogin));
                threadMainForm.TrySetApartmentState(ApartmentState.STA);
                threadMainForm.Start();
                Application.Exit();
            }
        }

    }
}
