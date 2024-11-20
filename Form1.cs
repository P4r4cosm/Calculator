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
            result = Calculator.DoFunction(result, Calculator.Function.Sqrt);
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
    }
}
