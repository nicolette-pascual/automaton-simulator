using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCS31_Automata.Global_Form_Class
{
    class GlobalFormClass
    {
        public static void CheckMdiChildren(Form form)
        {
            foreach (Form frm in FrmMain.ActiveForm.MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Focus();
                    return;
                }
            }
            form.MdiParent = FrmMain.ActiveForm;
            form.Show();
            form.BringToFront();
        }
    }
}
