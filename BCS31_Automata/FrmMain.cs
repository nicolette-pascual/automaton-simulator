using BCS31_Automata.CFG;
using BCS31_Automata.Global_Form_Class;
using BCS31_Automata.PDA;
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
    public partial class FrmMain : Form
    {

        Checking c = new Checking();
        private int[] validity= new int[5];
        private char[] sim;
        private string stringSimulation;

        private int valid, forCTR = 0, currentState = 0;

        public FrmMain()
        {
            InitializeComponent();
            disableTextbox();
            disableButton();
        }

        #region Enabling and Disabling Objects
        private void enableButton()
        {
            btnSim1.Enabled = true;
            btnSim2.Enabled = true;
            btnSim3.Enabled = true;
            btnSim4.Enabled = true;
            btnSim5.Enabled = true;
            btnCheck.Enabled = true;
        }
        
        private void enableTextbox()
        {
            txtboxInput1.Enabled = true;
            txtboxInput2.Enabled = true;
            txtboxInput3.Enabled = true;
            txtboxInput4.Enabled = true;
            txtboxInput5.Enabled = true;
        }
        
        private void disableTextbox()
        {
            txtboxInput1.Enabled = false;
            txtboxInput2.Enabled = false;
            txtboxInput3.Enabled = false;
            txtboxInput4.Enabled = false;
            txtboxInput5.Enabled = false;
        }

        private void disableButton()
        {
            btnSim1.Enabled = false;
            btnSim2.Enabled = false;
            btnSim3.Enabled = false;
            btnSim4.Enabled = false;
            btnSim5.Enabled = false;
            btnCheck.Enabled = false;
        }

        private void hideCheckbox()
        {
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            checkBox4.Hide();
            checkBox5.Hide();
        }

        private void showCheckbox()
        {
            checkBox1.Show(); //checkBox1.Checked = false;
            checkBox2.Show(); //checkBox2.Checked = false;
            checkBox3.Show(); //checkBox3.Checked = false;
            checkBox4.Show(); //checkBox4.Checked = false;
            checkBox5.Show(); //checkBox5.Checked = false;
        }

        private void simulateButtonsEnable()
        {
            btnNext.Enabled = true;
            btnStop.Enabled = true;
        }

        private void hideStateDFA1()
        {
            DFA2simState0.Hide();
            DFA2simState1.Hide();
            DFA2simState2.Hide();
            DFA2simState3.Hide();
            DFA2simState4.Hide();
            DFA2simState5.Hide();
            DFA2simState6.Hide();
            DFA2simStateEndLoop.Hide();
        }

        private void hideStateDFA2()
        {
            DFA1simState0.Hide();
            DFA1simState1a.Hide();
            DFA1simState1b.Hide();
            DFA1simState2.Hide();
            DFA1simState3.Hide();
            DFA1simState4.Hide();
            DFA1simState6.Hide();
            DFA1simStateEndLoop.Hide();
        }
        #endregion

        #region Checkbox Method (Enabling and Disbaling Textboxes)
        private void checkBoxChecked(object sender, EventArgs e)
        {
            btnCheck.Enabled = true;
            CheckBox cb = sender as CheckBox;

            if (cb.Checked)
            {
                switch (cb.Name)
                {
                    case "checkBox1":
                        checkBox1.Show();
                        txtboxInput1.Enabled = true;
                        btnSim1.Enabled = true;
                    break;
                    case "checkBox2":
                        checkBox2.Show();
                        txtboxInput2.Enabled = true;
                        btnSim2.Enabled = true;
                    break;
                    case "checkBox3":
                        checkBox3.Show();
                        txtboxInput3.Enabled = true;
                        btnSim3.Enabled = true;
                    break;
                    case "checkBox4":
                        checkBox4.Show();
                        txtboxInput4.Enabled = true;
                        btnSim4.Enabled = true;
                    break;
                    case "checkBox5":
                        checkBox5.Show();
                        txtboxInput5.Enabled = true;
                        btnSim5.Enabled = true;
                    break;
                }
            }
            else
            {
                switch (cb.Name)
                {
                    case "checkBox1":
                        checkBox1.Show();
                        txtboxInput1.Clear();
                        txtboxInput1.Enabled = false;
                        btnSim1.Enabled = false;
                        picValid1.Hide(); picInvalid1.Hide();
                        break;
                    case "checkBox2":
                        checkBox2.Show();
                        txtboxInput2.Clear();
                        txtboxInput2.Enabled = false;
                        btnSim2.Enabled = false;
                        picValid2.Hide(); picInvalid2.Hide();
                        break;
                    case "checkBox3":
                        checkBox3.Show();
                        txtboxInput3.Clear();
                        txtboxInput3.Enabled = false;
                        btnSim3.Enabled = false;
                        picValid3.Hide(); picInvalid3.Hide();
                        break;
                    case "checkBox4":
                        checkBox4.Show();
                        txtboxInput4.Clear();
                        txtboxInput4.Enabled = false;
                        btnSim4.Enabled = false;
                        picValid4.Hide(); picInvalid4.Hide();
                        break;
                    case "checkBox5":
                        checkBox5.Show();
                        txtboxInput5.Clear();
                        txtboxInput5.Enabled = false;
                        btnSim5.Enabled = false;
                        picValid5.Hide(); picInvalid5.Hide();
                        break;
                }
            }
        }

        private void checkCheckBox()
        {
            btnCheck.Enabled = true;
            if (checkBox1.Checked)
            {
                txtboxInput1.Enabled = true;
                btnSim1.Enabled = true;
            }
            if (checkBox2.Checked)
            {
                txtboxInput2.Enabled = true;
                btnSim2.Enabled = true;
            }
            if (checkBox3.Checked)
            {
                txtboxInput3.Enabled = true;
                btnSim3.Enabled = true;
            }
            if (checkBox4.Checked)
            {
                txtboxInput4.Enabled = true;
                btnSim4.Enabled = true;
            }
            if (checkBox5.Checked)
            {
                txtboxInput5.Enabled = true;
                btnSim5.Enabled = true;
            }
        }
        #endregion

        #region Tool Strip Menu Method
        private void toolstripmenu_Clicked(object sender, EventArgs e)
        {
            var clickedMenuItem = sender as ToolStripMenuItem;
            var menuText = clickedMenuItem.Text;

            switch (menuText)
            {
                case "Regular Expression 1":
                        resetSimulation();
                        picDFA2.Hide();
                        picDFA1.Show();
                        hideStateDFA1();
                        hideStateDFA2();
                        showCheckbox();
                        lblRegex.Text = "Regular Expression:  (aa+bb)(a+b)* (a+b+ab+ba) (a+b+ab+ba)* (aa+bab)* (a+b+aa) (a+b+bb)*";
                    break;
                case "Regular Expression 2":
                        resetSimulation();
                        picDFA1.Hide();
                        picDFA2.Show();
                        hideStateDFA2();
                        hideStateDFA1();
                        showCheckbox();
                        lblRegex.Text = "Regular Expression: ((101+111+101) + (1+0+11)*) (1+0+01)* (111+000+101) (1+0)*";
                    break;
                case "Regular Expression 1 CFG":
                    FrmCFG1 frmcfg1 = new FrmCFG1();
                    GlobalFormClass.CheckMdiChildren(frmcfg1);
                    break;
                case "Regular Expression 2 CFG":
                    FrmCFG2 frmcfg2 = new FrmCFG2();
                    GlobalFormClass.CheckMdiChildren(frmcfg2);
                    break;
                case "Regular Expression 1 PDA":
                    FrmPDA1 frmpda1 = new FrmPDA1();
                    GlobalFormClass.CheckMdiChildren(frmpda1);
                    break;
                case "Regular Expression 2 PDA":
                    FrmPDA2 frmpda2 = new FrmPDA2();
                    GlobalFormClass.CheckMdiChildren(frmpda2);
                    break;
            }
        }
        #endregion

        #region Button Clicked Method
        private void buttonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btnSim1":
                    disableTextbox();
                    disableButton();
                    hideCheckbox();
                    simulateButtonsEnable();
                    stringSimulation = txtboxInput1.Text;
                    lblTestingInput.Text = "Input: " + stringSimulation;
                    break;
                case "btnSim2":
                    disableTextbox();
                    disableButton();
                    hideCheckbox();
                    simulateButtonsEnable();
                    stringSimulation = txtboxInput2.Text;
                    lblTestingInput.Text = "Input: " + stringSimulation;
                    break;
                case "btnSim3":
                    disableTextbox();
                    disableButton();
                    hideCheckbox();
                    simulateButtonsEnable();
                    stringSimulation = txtboxInput3.Text;
                    lblTestingInput.Text = "Input: " + stringSimulation;
                    break;
                case "btnSim4":
                    disableTextbox();
                    disableButton();
                    hideCheckbox();
                    simulateButtonsEnable();
                    stringSimulation = txtboxInput4.Text;
                    lblTestingInput.Text = "Input: " + stringSimulation;
                    break;
                case "btnSim5":
                     disableTextbox();
                    disableButton();
                    hideCheckbox();
                    simulateButtonsEnable();
                    stringSimulation = txtboxInput5.Text;
                    lblTestingInput.Text = "Input: " + stringSimulation;
                    break;
                case "btnCheck":
                    checkInput();
                    break;
            }
        }
        #endregion

        #region validating of input
        private void checkInput()
        {
            if(txtboxInput1.Enabled){
                c.InputArray1 = txtboxInput1.Text.ToCharArray();
                checkingValidity();
                if (valid == 1) { validity[0] = 1; } else { validity[0] = 0; }
                showingValidity();
            }
            if (txtboxInput2.Enabled)
            {
                c.InputArray1 = txtboxInput2.Text.ToCharArray();
                checkingValidity();
                if (valid == 1) { validity[1] = 1; } else { validity[1] = 0; }
                showingValidity();
            }
            if (txtboxInput3.Enabled)
            {
                c.InputArray1 = txtboxInput3.Text.ToCharArray();
                checkingValidity();
                if (valid == 1) { validity[2] = 1; } else { validity[2] = 0; }
                showingValidity();
            }
            if (txtboxInput4.Enabled)
            {
                c.InputArray1 = txtboxInput4.Text.ToCharArray();
                checkingValidity();
                if (valid == 1) { validity[3] = 1; } else { validity[3] = 0; }
                showingValidity();
            }
            if (txtboxInput5.Enabled)
            {
                c.InputArray1 = txtboxInput5.Text.ToCharArray();
                checkingValidity();
                if (valid == 1) { validity[4] = 1; } else { validity[4] = 0; }
                showingValidity();
            }
        }

        private void checkingValidity()
        {
            switch (lblRegex.Text)
            {
                case "Regular Expression:  (aa+bb)(a+b)* (a+b+ab+ba) (a+b+ab+ba)* (aa+bab)* (a+b+aa) (a+b+bb)*":
                    c.checkinput1();
                    switch (c.State) //checking if reached the 'end' state (state = 5)
                    {
                        case 5: valid = 1;
                            break;
                        default:
                            valid = 0;
                            break;
                    }
                    break;
                case "Regular Expression: ((101+111+101) + (1+0+11)*) (1+0+01)* (111+000+101) (1+0)*":
                    c.checkinput2();
                    switch (c.State) //checking if reached the 'end' state (state = 6)
                    {
                        case 6: valid = 1;
                            break;
                        default:
                            valid = 0;
                            break;
                    }
                    break;
            }
        }
        #endregion

        #region Displaying if valid or invalid
        private void showingValidity()
        {
            if (txtboxInput1.Enabled) 
            { 
                if (validity[0] == 1)   {picInvalid1.Hide(); picValid1.Show();}
                else                    {picValid1.Hide(); picInvalid1.Show();}
            
            }

            if (txtboxInput2.Enabled)
            {
                if (validity[1] == 1) { picInvalid2.Hide(); picValid2.Show(); }
                else { picValid2.Hide(); picInvalid2.Show(); }

            }

            if (txtboxInput3.Enabled)
            {
                if (validity[2] == 1) { picInvalid3.Hide(); picValid3.Show(); }
                else { picValid3.Hide(); picInvalid3.Show(); }

            }

            if (txtboxInput4.Enabled)
            {
                if (validity[3] == 1) { picInvalid4.Hide(); picValid4.Show(); }
                else { picValid4.Hide(); picInvalid4.Show(); }

            }

            if (txtboxInput5.Enabled)
            {
                if (validity[4] == 1) { picInvalid5.Hide(); picValid5.Show(); }
                else { picValid5.Hide(); picInvalid5.Show(); }

            }
        }
        #endregion

        #region Simulation Next Button
        private void onNext(object sender, EventArgs e)
        {
            sim = stringSimulation.ToCharArray(); //sim = stringSimulation.ToCharArray();
            switch (lblRegex.Text)
            {
                #region REGEX1
                case "Regular Expression:  (aa+bb)(a+b)* (a+b+ab+ba) (a+b+ab+ba)* (aa+bab)* (a+b+aa) (a+b+bb)*":
                    if (forCTR <= stringSimulation.Length - 1)
                    {
                        if (currentState == 0)
                        {
                            DFA1simState0.Show();
                            //StatusBar.Text = "The string enters start state!";
                            currentState++;
                        }

                        else if (currentState == 1)
                        {
                            if (sim[forCTR] == 'a')
                            {
                                DFA1simState0.Hide();
                                DFA1simState1a.Show();
                                lblInputChar.Text = Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "Since input is a, the string enters state 1a";
                                forCTR++;
                                currentState++;
                            }

                            else if (sim[forCTR] == 'b')
                            {
                                DFA1simState0.Hide();
                                DFA1simState1b.Show();
                                lblInputChar.Text = Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "Since input is b, the string enters state 1b";
                                forCTR++;
                                currentState++;
                            }

                            else
                            {
                                //start state only
                                lblInputChar.Text = "INVALID INPUT";
                                //StatusBar.Text = "The string is stuck in start state, and is therefore invalid";
                                btnNext.Enabled = false;
                            }
                        }

                        else if (currentState == 2)
                        {
                            if (sim[forCTR - 1] == 'a' && sim[forCTR] == 'a')
                            {
                                DFA1simState1a.Hide();
                                DFA1simState2.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 1a, the input is a, therefore the string enters state 2";
                                forCTR++;
                                currentState++;
                            }

                            else if (sim[forCTR - 1] == 'b' && sim[forCTR] == 'b')
                            {
                                DFA1simState1b.Hide();
                                DFA1simState2.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 1b, the input is b, therefore the string enters state 2";
                                forCTR++;
                                currentState++;
                            }

                            else if (sim[forCTR - 1] == 'a' && sim[forCTR] == 'b')
                            {
                                DFA1simState1a.Hide();
                                DFA1simState6.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 1a, the input is b, the string enters a trap state, and therefore is considered invalid for the DFA";
                                lblInputChar.Text = "INVALID INPUT";
                                forCTR++;
                                currentState++;
                                btnNext.Enabled = false;
                            }

                            else if (sim[forCTR - 1] == 'b' && sim[forCTR] == 'a')
                            {
                                DFA1simState1b.Hide();
                                DFA1simState6.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 1b, the input is a, the string enters a trap state, and therefore is considered invalid for the DFA";
                                lblInputChar.Text = "INVALID INPUT";
                                forCTR++;
                                currentState++;
                                btnNext.Enabled = false;
                            }

                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                //StatusBar.Text = "The string does not reach the end state, and is therefore invalid";
                                btnNext.Enabled = false;
                            }
                        }

                        else if (currentState == 3)
                        {
                            if (sim[forCTR] == 'a' || sim[forCTR] == 'b')
                            {
                                DFA1simState2.Hide();
                                DFA1simState3.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState++;

                            }

                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                //StatusBar.Text = "The string does not reach the end state, and is therefore invalid";
                                btnNext.Enabled = false;
                            }
                        }

                        else if (currentState == 4)
                        {
                            if (sim[forCTR] == 'a' || sim[forCTR] == 'b')
                            {
                                DFA1simState3.Hide();
                                DFA1simState4.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 3, the input is " + sim[forCTR] + ", therefore the string enters state 4";
                                forCTR++;
                                currentState++;
                            }

                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                //StatusBar.Text = "The string does not reach the end state, and is therefore invalid";
                                btnNext.Enabled = false;
                            }
                        }

                        else if (currentState > 4)
                        {
                            if (sim[forCTR] == 'a' || sim[forCTR] == 'b')
                            {
                                DFA1simState4.Hide();
                                DFA1simStateEndLoop.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                //StatusBar.Text = "From state 4, the input is " + sim[forCTR] + ", therefore the string stays in state 4";
                                forCTR++;
                                currentState++;
                            }

                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                //StatusBar.Text = "Input is neither a or b so the string doesn't go to any state, and is therefore invalid";
                                btnNext.Enabled = false;
                            }
                        }
                    }

                    else
                    {
                        if (currentState > 4)
                        {
                            lblInputChar.Text = "VALID INPUT";
                            //StatusBar.Text = "The string ends in the end state, and is therefore valid!";
                            btnNext.Enabled = false;
                        }

                        else if (currentState <= 4)
                        {
                            lblInputChar.Text = "INVALID INPUT";
                            // StatusBar.Text = "The string does not end in the end state, and is therefore invalid!";
                            btnNext.Enabled = false;
                        }
                        currentState++;
                    }
                    break;
                #endregion

                #region REGEX2
                case "Regular Expression: ((101+111+101) + (1+0+11)*) (1+0+01)* (111+000+101) (1+0)*":
                    if (forCTR <= stringSimulation.Length - 1)
                    {
                        if (currentState == 0)
                        {
                            DFA2simState0.Show();
                            currentState = 1;
                        }
                        else if (currentState == 1)//starting state
                        {
                            if (sim[forCTR] == '1')
                            {
                                DFA2simState0.Hide();
                                DFA2simState1.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 2;
                            }

                            else if (sim[forCTR] == '0')
                            {
                                DFA2simState0.Hide();
                                DFA2simState1.Hide();
                                DFA2simState2.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 2;
                            }

                            else
                            {
                                //start state only
                                lblInputChar.Text = "INVALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                        else if (currentState == 2)
                        {
                            if (sim[forCTR - 1] == '1' && sim[forCTR] == '1')
                            {
                                DFA2simState1.Hide();
                                DFA2simState3.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 3;
                            }

                            else if (sim[forCTR - 1] == '1' && sim[forCTR] == '0')
                            {
                                DFA2simState1.Hide();
                                DFA2simState4.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 4;
                            }
                            else if (sim[forCTR - 1] == '0' && sim[forCTR] == '0')
                            {
                                DFA2simState2.Hide();
                                DFA2simState5.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 5;
                            }
                            else if (sim[forCTR - 1] == '0' && sim[forCTR] == '1')
                            {
                                DFA2simState2.Hide();
                                DFA2simState1.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 2;
                            }
                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                        else if (currentState == 3)
                        {
                            if (sim[forCTR] == '1')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState6.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 6;
                            }
                            else if (sim[forCTR] == '0')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 4;
                            }
                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                        else if (currentState == 4)
                        {
                            if (sim[forCTR] == '1')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState6.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 6;
                            }
                            else if (sim[forCTR] == '0')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState5.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 5;
                            }
                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                        else if (currentState == 5)
                        {
                            if (sim[forCTR] == '1')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState5.Hide();
                                DFA2simState1.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 2;
                            }
                            else if (sim[forCTR] == '0')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState5.Hide();
                                DFA2simState6.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState = 6;
                            }
                            else
                            {
                                //STAYS WHEREVER IT IS
                                lblInputChar.Text = "INVALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                        else if (currentState >= 6)
                        {
                            if (sim[forCTR] == '1' || sim[forCTR] == '0')
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState5.Hide();
                                DFA2simState6.Hide();
                                DFA2simStateEndLoop.Show();
                                lblInputChar.Text += Convert.ToString(sim[forCTR]);
                                forCTR++;
                                currentState++;
                            }
                            else
                            {
                                DFA2simState1.Hide();
                                DFA2simState2.Hide();
                                DFA2simState3.Hide();
                                DFA2simState4.Hide();
                                DFA2simState5.Hide();
                                DFA2simState6.Show();
                                lblInputChar.Text = "VALID INPUT";
                                btnNext.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (currentState >= 6)
                        {
                            lblInputChar.Text = "VALID INPUT";
                            btnNext.Enabled = false;
                        }

                        else if (currentState < 6)
                        {
                            lblInputChar.Text = "INVALID INPUT";
                            btnNext.Enabled = false;
                        }
                        currentState++;
                    }

                        break;
                   
            }
        }
                #endregion

        #endregion

        #region Simulation Stop Button
        private void onStop(object sender, EventArgs e)
        {
            resetSimulation();

        }

        private void resetSimulation()
        {
            currentState = 0;
            forCTR = 0;
            lblTestingInput.Text = "Input: ";
            lblInputChar.Text = "";
            btnNext.Enabled = false;
            btnStop.Enabled = false;
            hideStateDFA1();
            hideStateDFA2();
            showCheckbox();
            checkCheckBox();
                //switch (cb.Name)
                //{
                //    case "checkBox1":
                //        //checkBox1.Show();
                //        txtboxInput1.Enabled = true;
                //        btnSim1.Enabled = true;
                //        break;
                //    case "checkBox2":
                //        //checkBox2.Show();
                //        txtboxInput2.Enabled = true;
                //        btnSim2.Enabled = true;
                //        break;
                //    case "checkBox3":
                //        //checkBox3.Show();
                //        txtboxInput3.Enabled = true;
                //        btnSim3.Enabled = true;
                //        break;
                //    case "checkBox4":
                //        // checkBox4.Show();
                //        txtboxInput4.Enabled = true;
                //        btnSim4.Enabled = true;
                //        break;
                //    case "checkBox5":
                //        //checkBox5.Show();
                //        txtboxInput5.Enabled = true;
                //        btnSim5.Enabled = true;
                //        break;
                //}
            
            //enableButton();
        }
        #endregion
}    
}

