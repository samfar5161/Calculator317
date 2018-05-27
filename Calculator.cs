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
        protected decimal equationLeft;
        protected decimal equationRight;
        protected decimal solution;
        string operation;           // operation
        Boolean isDecimal = false;  // determine if decimal is used   
        protected decimal memory;   // memory variable

        public Calculator()
        {
            InitializeComponent();

            if (TxtDisplay.Text == "")
                TxtDisplay.Text = "0";
        }

        // CLEAR BUTTON
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


        // NUMBER BUTTONS
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

        // function for displaying the number in the TxtDisplay textbox
        public void SetDisplay(string x)
        {
            if (TxtDisplay.Text == "0")
                TxtDisplay.Text = x;
            else
                TxtDisplay.Text = TxtDisplay.Text + x;
        }

        // decimal
        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            SetDisplay(".");
            isDecimal = true;

            BtnDecimal.Enabled = false;
        }

        // OPERATORS
        // add
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);
            // operation
            operation = "+";
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;
        }

        // subtract
        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);

            operation = "-";
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;

        }

        // multiply
        private void BtnMultiply_Click(object sender, EventArgs e)
        {

            equationLeft = Convert.ToDecimal(TxtDisplay.Text);
            operation = "*";
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;

        }

        // divide 
        private void BtnDivide_Click(object sender, EventArgs e)
        {
            equationLeft = Convert.ToDecimal(TxtDisplay.Text);

            operation = "/";
            TxtDisplay.Text = "0";
            isDecimal = false;
            BtnDecimal.Enabled = true;
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
                    break;

                case "-":
                    solution = equationLeft - equationRight;
                    TxtDisplay.Text = solution.ToString();
                    break;

                case "*":
                    solution = equationLeft * equationRight;
                    TxtDisplay.Text = solution.ToString();
                    break;

                case "/":
                    try
                    {
                        solution = equationLeft / equationRight;
                        TxtDisplay.Text = solution.ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        TxtDisplay.Text = "Error";
                        isDecimal = false;
                        BtnDecimal.Enabled = true;
                    }
                    break;
            }

        }

        // Memory Operators
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

        // invert value
        private void BtnNegative_Click(object sender, EventArgs e)
        {
            decimal n = Convert.ToDecimal(TxtDisplay.Text) * -1;
            TxtDisplay.Text = n.ToString();

        }
        
    }

   
}
