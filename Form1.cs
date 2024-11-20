using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private double currentNumber = 0;
        private Calculator.Operation currentOperation;

        public Form1()
        {
            InitializeComponent();
            Input.Text = "0";
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber = currentNumber * 10 + Convert.ToDouble(button.Text);
            Input.Text = currentNumber.ToString();
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            if (currentOperation != null)
            {
                result = Calculator.DoOperation(result, currentNumber, currentOperation);
                Input.Text = result.ToString();
            }
            else
            {
                result = currentNumber;
            }

            currentOperation = GetOperationFromString(operation);
            currentNumber = 0;
        }

        private Calculator.Operation GetOperationFromString(string operation)
        {
            switch (operation)
            {
                case "+": return Calculator.Operation.Add;
                case "-": return Calculator.Operation.Subtract;
                case "*": return Calculator.Operation.Multiply;
                case "/": return Calculator.Operation.Divide;
                case "^": return Calculator.Operation.Power;
                case "%": return Calculator.Operation.Modulo;
                default: return Calculator.Operation.Add;
            }
        }

        private void button_mclear_Click(object sender, EventArgs e)
        {
         
        }

        private void button_msave_Click(object sender, EventArgs e)
        {

        }

        private void button_msub_Click(object sender, EventArgs e)
        {

        }

        private void button_madd_Click(object sender, EventArgs e)
        {

        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            result = Calculator.DoFunction(Convert.ToInt16(Input.Text), Calculator.Function.Sqrt);
            Input.Text = result.ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            operation_Click(sender, e);
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            if (currentOperation != null)
            {
                result = Calculator.DoOperation(result, currentNumber, currentOperation);
                Input.Text = result.ToString();
                currentOperation = Calculator.Operation.Add; 
            }
        }

        private void button_7_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "7";
            }
            else
            {
                Input.Text += "7";
            }
        }

        private void button_8_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "8";
            }
            else
            {
                Input.Text += "8";
            }
        }

        private void button_9_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "9";
            }
            else
            {
                Input.Text += "9";
            }
        }

        private void button_4_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "4";
            }
            else
            {
                Input.Text += "4";
            }
        }

        private void button_5_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "5";
            }
            else
            {
                Input.Text += "5";
            }
        }

        private void button_6_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "6";
            }
            else
            {
                Input.Text += "6";
            }
        }

        private void button_1_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "1";
            }
            else
            {
                Input.Text += "1";
            }
        }

        private void button_2_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "2";
            }
            else
            {
                Input.Text += "2";
            }
        }

        private void button_3_onclick(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = "3";
            }
            else
            {
                Input.Text += "3";
            }
        }

        private void button_00_onclick(object sender, EventArgs e)
        {
            if (Input.Text != "0")
            {
                Input.Text += "00";
            }
            
        }

        private void button_0_input(object sender, EventArgs e)
        {
            if (Input.Text != "0")
            {
                Input.Text += "0";
            }
            
        }

        private void button_dot_onclick(object sender, EventArgs e)
        {
            Input.Text += ".";
        }

        private void button_c_onclick(object sender, EventArgs e)
        {
            Input.Text = "0";
        }
    }
}
