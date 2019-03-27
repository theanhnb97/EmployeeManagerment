using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public class FormControls:Form
    {
        protected override void OnLoad(EventArgs e)
        {
            string formName=base.Name;

            base.OnLoad(e);
        }
    }
}
