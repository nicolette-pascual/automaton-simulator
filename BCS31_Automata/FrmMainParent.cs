using BCS31_Automata.Global_Form_Class;
using BCS31_Automata.User_s_Manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCS31_Automata
{
    public partial class FrmMainParent : Form
    {
        public FrmMainParent()
        {
            InitializeComponent();
        }

        private void menuStripClicked(object sender, EventArgs e)
        {
            var clickedMenuItem = sender as ToolStripMenuItem;
            var menuText = clickedMenuItem.Text;

            switch (menuText)
            {
                case "Automaton Simulator":
                    FrmMain frmmain = new FrmMain();
                    GlobalFormClass.CheckMdiChildren(frmmain);
                    break;
                case "User's Manual":
                    FrmManual frmmanual = new FrmManual();
                    GlobalFormClass.CheckMdiChildren(frmmanual);
                    break;
                case "Exit":
                    this.Close();
                    break;
            }

        }
    }
}
