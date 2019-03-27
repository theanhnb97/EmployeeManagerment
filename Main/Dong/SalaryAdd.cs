using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Dong
{
    public partial class SalaryAdd : Form
    {
        public SalaryAdd()
        {
            InitializeComponent();
        }
       private void Add_Load(object sender, EventArgs e)
        {
            cbbDept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbDept.AutoCompleteSource = AutoCompleteSource.ListItems;
            var temp = 
        }
    }
}
