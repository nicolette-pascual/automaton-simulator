using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCS31_Automata
{
    public class Checking
    {
        private char[] inputArray1, simInputArray;
        private int state = 0;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        #region Getters and Setters (Input Array)
        public char[] SimInputArray
        {
            get { return simInputArray; }
            set { simInputArray = value; }
        }

        public char[] InputArray1
        {
            get { return inputArray1; }
            set { inputArray1 = value; }
        }
        #endregion

        #region Regular Expression 1 Checking
        public void checkinput1()
        {
            state = 0;
            for (int i = 0; i < InputArray1.Length; i++)
            {
                switch (state) //Main Switch
                {
                    case 0:
                        switch (InputArray1[i])
                        {
                            case 'a':
                                State = 1;
                                break;
                            case 'b':
                                State = 2;
                                break;
                        }
                        break;
                    case 1:
                        switch (InputArray1[i])
                        {
                            case 'a':
                                State = 3;
                                break;
                            case 'b':
                                State = 6; //trap state
                                break;
                        }
                        break;
                    case 2:
                        switch (InputArray1[i])
                        {
                            case 'a':
                                State = 6; //trap state
                                break;
                            case 'b':
                                State = 3;
                                break;
                        }
                        break;
                    case 3:
                        switch (InputArray1[i])
                        {
                            case 'a':
                                State = 4;
                                break;
                            case 'b':
                                State = 4;
                                break;
                        }
                        break;
                    case 4:
                        switch (InputArray1[i])
                        {
                            case 'a':
                                State = 5;
                                break;
                            case 'b':
                                State = 5;
                                break;
                        }
                        break;
                }

            }//for loop ends here
        }
        #endregion

        #region Regular Expression 2 Checking
        public void checkinput2()
        {
            state = 0;
            for (int i = 0; i < InputArray1.Length; i++)
            {
                switch (state)
                {
                    case 0:
                        switch (InputArray1[i])
                        {
                            case '1': State = 1; break;
                            case '0': State = 2; break;
                        }
                        break;
                    case 1:
                        switch (InputArray1[i])
                        {
                            case '1': State = 3; break;
                            case '0': State = 4; break;
                        }
                        break;
                    case 2:
                        switch (InputArray1[i])
                        {
                            case '1': State = 1; break;
                            case '0': State = 5; break;
                        }
                        break;
                    case 3:
                        switch (InputArray1[i])
                        {
                            case '1': State = 6; break;
                            case '0': State = 4; break;
                        }
                        break;
                    case 4:
                        switch (InputArray1[i])
                        {
                            case '1': State = 6; break;
                            case '0': State = 5; break;
                        }
                        break;
                    case 5:
                        switch (InputArray1[i])
                        {
                            case '1': State = 1; break;
                            case '0': State = 6; break;
                        }
                        break;
                }
            }//for loop ends here
        }
        #endregion


    }
}
