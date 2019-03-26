using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Main
{
    public partial class ActionManagement : UserControl
    {
        public ActionManagement()
        {
            InitializeComponent();
        }
        ActionBUS myAction=new ActionBUS();
        private void ActionManagement_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = myAction.Get();
        }
    }
}
