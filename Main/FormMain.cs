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


namespace Main
{
    public partial class FormMain : Form
    {
        private List<Button> btnMenuButtons;
        ActionManagement ucActionManagement=new ActionManagement();
        Employees ucEmployees=new Employees();
        UcTask ucTask =new UcTask();

        private void LoadUC()
        {
            pnMain.Controls.Add(ucActionManagement);
            ucActionManagement.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucEmployees);
            ucEmployees.Dock = DockStyle.Fill;

            pnMain.Controls.Add(ucTask);
            ucTask.Dock = DockStyle.Fill;


        }

        public FormMain()
        {
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
                Thread threadMainForm = new Thread(new ThreadStart(ShowFormMain));
                threadMainForm.Start();
                Application.Exit();
            }
        }

        private void ShowFormMain()
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
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucActionManagement.BringToFront();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucTask.BringToFront();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            btnMenuItem_Click(sender, e);
            ucEmployees.BringToFront();
        }
    }
}
