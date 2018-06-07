using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator317
{
    public partial class Calculator : Form
    {
        protected decimal equationLeft;     // first half of equation
        protected decimal equationRight;    // second half of equation
        protected decimal solution;         // solution
        string operation;                   // operation
        Boolean isDecimal = false;          // determine if decimal point is being used in current string.    
        protected decimal memory;           // memory variable

        public Calculator()
        {
            InitializeComponent();

            TxtDisplay.Text = "0";
        }

        // CLEAR BUTTONS //
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;
        }

        private void BtnClearEverything_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;
            operation = "";
            equationLeft = 0;
            equationLeft = 0;
        }


        // NUMBER BUTTONS //
        private void BtnOne_Click(object sender, EventArgs e)
        {
            SetDisplay("1");
        }

        private void BtnTwo_Click(object sender, EventArgs e)
        {
            SetDisplay("2");
        }

        private void BtnThree_Click(object sender, EventArgs e)
        {
            SetDisplay("3");
        }

        private void BtnFour_Click(object sender, EventArgs e)
        {
            SetDisplay("4");
        }

        private void BtnFive_Click(object sender, EventArgs e)
        {
            SetDisplay("5");
        }

        private void BtnSix_Click(object sender, EventArgs e)
        {
            SetDisplay("6");
        }

        private void BtnSeven_Click(object sender, EventArgs e)
        {
            SetDisplay("7");
        }

        private void BtnEight_Click(object sender, EventArgs e)
        {
            SetDisplay("8");
        }

        private void BtnNine_Click(object sender, EventArgs e)
        {
            SetDisplay("9");
        }

        private void BtnZero_Click(object sender, EventArgs e)
        {
            SetDisplay("0");
        }

        // decimal
        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            SetDisplay(".");
            isDecimal = true;

            BtnDecimal.Enabled = false;
        }


        // OPERATORS //
        // add
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);
            // operation
            operation = "+";
            TxtDisplay.Text = "0";
            IsDecimal(TxtDisplay.Text);
        }

        // subtract
        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);

            operation = "-";
            TxtDisplay.Text = "0";
            IsDecimal(TxtDisplay.Text);

        }

        // multiply
        private void BtnMultiply_Click(object sender, EventArgs e)
        {

            equationLeft = Convert.ToDecimal(TxtDisplay.Text);
            operation = "*";
            TxtDisplay.Text = "0";
            IsDecimal(TxtDisplay.Text);

        }

        // divide 
        private void BtnDivide_Click(object sender, EventArgs e)
        {
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);

            operation = "/";
            TxtDisplay.Text = "0";
            IsDecimal(TxtDisplay.Text);
        }

        // equals
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            equationRight = Convert.ToDecimal(TxtDisplay.Text);

            switch (operation)
            {
                case "+":
                    solution = equationLeft + equationRight;
                    TxtDisplay.Text = solution.ToString();
                    IsDecimal(TxtDisplay.Text);
                    break;

                case "-":
                    solution = equationLeft - equationRight;
                    TxtDisplay.Text = solution.ToString();
                    IsDecimal(TxtDisplay.Text);
                    break;

                case "*":
                    solution = equationLeft * equationRight;
                    TxtDisplay.Text = solution.ToString();
                    IsDecimal(TxtDisplay.Text);
                    break;

                case "/":
                    try
                    {
                        solution = equationLeft / equationRight;
                        TxtDisplay.Text = solution.ToString();
                        IsDecimal(TxtDisplay.Text);
                    }
                    catch (DivideByZeroException)
                    {
                        TxtDisplay.Text = "Error";
                    }
                    break;
            }

        }


        // MEMORY OPERATORS //
        // Memory Store
        private void BtnMemStore_Click(object sender, EventArgs e)
        {
            memory = Convert.ToDecimal(TxtDisplay.Text);
        }

        // Memory retreive
        private void BtnMemRet_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = memory.ToString();
        }

        // Memory clear
        private void BtnMemClear_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        // Memory add
        private void BtnMemAdd_Click(object sender, EventArgs e)
        {
            decimal m = Convert.ToDecimal(TxtDisplay.Text);
            TxtDisplay.Text = (m + memory).ToString();

        }

        // EXTRAS //
        // invert value
        private void BtnNegative_Click(object sender, EventArgs e)
        {
            decimal n = Convert.ToDecimal(TxtDisplay.Text) * -1;
            TxtDisplay.Text = n.ToString();

        }

        // square 
        private void BtnSquare_Click(object sender, EventArgs e)
        {
            decimal x = Convert.ToDecimal(TxtDisplay.Text);
            decimal y = x * x;
            TxtDisplay.Text = y.ToString();
        }


        // BACKEND FUNCTIONS //
        // determine if string in display has a decimal point
        private void IsDecimal(string x)
        {
            if (CheckDecimal(x))
            {
                isDecimal = true;
                BtnDecimal.Enabled = false;
            }
            else
            {
                isDecimal = false;
                BtnDecimal.Enabled = true;
            }
        }

        // check if string has a decimal point in it.
        private Boolean CheckDecimal(string x)
        {
            for(int i = 0; i < x.Length; i++)
            {
                if (x[i].ToString() == ".")
                    return true;
            }

            return false;
        }

        // function for displaying the number in the TxtDisplay textbox
        public void SetDisplay(string x)
        {
            if (TxtDisplay.Text == "0")
                TxtDisplay.Text = x;
            else
                TxtDisplay.Text = TxtDisplay.Text + x;
        }

        // Key events 
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            // switch statement to handle key events
            switch (e.KeyCode)
            {
                // Numbers
                case Keys.D1:
                    BtnOne_Click(sender, e);
                    break;

                case Keys.NumPad1:
                    BtnOne_Click(sender, e);
                    break;

                case Keys.D2:
                    BtnTwo_Click(sender, e);
                    break;

                case Keys.NumPad2:
                    BtnTwo_Click(sender, e);
                    break;

                case Keys.D3:
                    BtnThree_Click(sender, e);
                    break;

                case Keys.NumPad3:
                    BtnThree_Click(sender, e);
                    break;

                case Keys.D4:
                    BtnFour_Click(sender, e);
                    break;

                case Keys.NumPad4:
                    BtnFour_Click(sender, e);
                    break;

                case Keys.D5:
                    BtnFive_Click(sender, e);
                    break;
                    
                case Keys.NumPad5:
                    BtnFive_Click(sender, e);
                    break;

                case Keys.D6:
                    BtnSix_Click(sender, e);
                    break;

                case Keys.NumPad6:
                    BtnSix_Click(sender, e);
                    break;

                case Keys.D7:
                    BtnSeven_Click(sender, e);
                    break;

                case Keys.NumPad7:
                    BtnSeven_Click(sender, e);
                    break;

                case Keys.D8:
                    BtnEight_Click(sender, e);
                    break;

                case Keys.NumPad8:
                    BtnEight_Click(sender, e);
                    break;

                case Keys.D9:
                    BtnNine_Click(sender, e);
                    break;

                case Keys.NumPad9:
                    BtnNine_Click(sender, e);
                    break;

                case Keys.D0:
                    BtnZero_Click(sender, e);
                    break;

                case Keys.NumPad0:
                    BtnZero_Click(sender, e);
                    break;

                // Decimal and Period for decimal
                case Keys.Decimal:
                    if (CheckDecimal(TxtDisplay.Text))
                        break;
                    else
                        BtnDecimal_Click(sender, e);
                    break;

                case Keys.OemPeriod:
                    if (CheckDecimal(TxtDisplay.Text))
                        break;
                    else
                        BtnDecimal_Click(sender, e);
                    break;

                // Addition
                case Keys.Add:
                    BtnAdd_Click(sender, e);
                    break;

                case Keys.Oemplus:
                    BtnAdd_Click(sender, e);
                    break;

                // subtraction
                case Keys.OemMinus:
                    BtnSubtract_Click(sender, e);
                    break;

                case Keys.Subtract:
                    BtnSubtract_Click(sender, e);
                    break;

                // Multiplication
                case Keys.Multiply:
                    BtnMultiply_Click(sender, e);
                    break;
                
                // Division
                case Keys.Divide:
                    BtnDivide_Click(sender, e);
                    break;

                case Keys.OemBackslash:
                    BtnDivide_Click(sender, e);
                    break;

                // Equals
                case Keys.Enter:
                    BtnEquals_Click(sender, e);
                    break;

                // clear
                case Keys.C:
                    BtnClear_Click(sender, e);
                    break;

                // Clear all
                case Keys.Delete:
                    BtnClearEverything_Click(sender, e);
                    break;
            }
                
        }
    }

   
}
