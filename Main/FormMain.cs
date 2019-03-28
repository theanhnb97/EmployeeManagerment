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
using BusinessLayer;
using Main.Dai;


namespace Main
{
    public partial class FormMain : Form
    {

        private readonly RolesActionBUS myRolesActionBus = new RolesActionBUS();
        protected int RolesID { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            DataTable myDataTable = myRolesActionBus.GetTrue(RolesID);
            bool result = RolesID == 1;
            string formName = base.Name+".";
            string Action = "";
            foreach (DataRow item in myDataTable.Rows)
                Action += item["ACTIONNAME"].ToString().Trim() + ".";
            if (Action.Contains(formName)) result = true;
            if (result)
                base.OnLoad(e);
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào Hệ thống này!");
                //picLogout_Click(picLogout, e);
            }
        }



        private List<Button> btnMenuButtons;
        SalaryManagement salary;
        ActionManagement ucActionManagement;
        UcRoles ucRoles;
        UcRolesAction ucRolesAction;
        Employees ucEmployees;
        UcTask ucTask;
        UcDepartment ucDepartment;

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

        }


        public FormMain(int rolesId)
        {
            this.RolesID = rolesId;
            ucActionManagement = new ActionManagement(RolesID);
            ucRoles = new UcRoles(RolesID);
            ucRolesAction = new UcRolesAction(RolesID);
            ucTask = new UcTask(RolesID);
            ucEmployees = new Employees(RolesID);
            ucDepartment = new UcDepartment(RolesID);


            InitializeComponent();
            btnMenuButtons = new List<Button>();
        }

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

        private void ShowFormLogin()
        {
            Login f = new Login();
            f.ShowDialog();
        }

        void LoacationSlide(Panel slide,Button inActiceButton)
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


        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            Button inActiceButton = (Button) sender;
            LoacationSlide(this.pnSlide,inActiceButton);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender,e);
            ucRolesAction.BringToFront();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucRoles.BringToFront();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucActionManagement.BringToFront();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            salary.BringToFront();
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucTask.BringToFront();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucDepartment.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucEmployees.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

        }
    }
}
