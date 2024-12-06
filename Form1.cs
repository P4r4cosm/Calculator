using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private Calculator1.Operation currentOperation;
        private double memoryValue = 0;

        public Form1()
        {
            InitializeComponent();
            Input.Text = "0";           
            RoundingMode.Minimum = 0;
            RoundingMode.Maximum = 2;
            RoundingMode.Value = 1;
        }


        //ОБРАБОТКА НАЖАТИЙ НА КНОПКИ
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (Input.Text == "0")
            {
                Input.Text = button.Text;
            }
            else
            {
                Input.Text += button.Text;
            }
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(Input.Text);
            result = Calculator1.DoFunction
                (Calculator1.DoOperation(currentNumber, secondNumber, currentOperation),
                (Calculator1.Function)RoundingMode.Value); 
            Input.Text = result.ToString();
            currentNumber = result;  
        }


        //ОБРАБОТКА ФУНКЦИЙ
        private void button_sqrt_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator1.DoFunction(Calculator1.DoFunction(currentNumber, Calculator1.Function.Sqrt),
                (Calculator1.Function)RoundingMode.Value); 
            Input.Text = result.ToString();
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator1.DoFunction(Calculator1.DoFunction(currentNumber, Calculator1.Function.Sin),
                (Calculator1.Function)RoundingMode.Value); 
            Input.Text = result.ToString();
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator1.DoFunction(Calculator1.DoFunction(currentNumber, Calculator1.Function.Cos),
                (Calculator1.Function)RoundingMode.Value); 
            Input.Text = result.ToString();
        }
        
        //ОБРАБОТКА ОПЕРАЦИЙ
        private void button_add_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Add;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Subtract;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Multiply;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0"; 
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Divide;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_raise_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Power;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_mod_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator1.Operation.Modulo;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0"; 
        }

        //ОБАБОТКА MC, MS B Т.Д.
        private void button_mclear_Click(object sender, EventArgs e)
        {
            memoryValue = 0;
            memoryValue -= 0; // Вычитаем текущее значение из памяти
            memoNum.Text = memoryValue.ToString();
        }

        private void button_msave_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input.Text, out double value))
            {
                memoryValue = value;
                memoNum.Text = memoryValue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Unable to save to memory.");
            }
        }


        private void button_madd_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input.Text, out double currentValue))
            {
                memoryValue += currentValue; // Увеличиваем значение памяти
                memoNum.Text = memoryValue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input for M+.");
            }
        }

        private void button_msub_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input.Text, out double currentValue))
            {
                memoryValue -= currentValue; // Уменьшаем значение памяти
                memoNum.Text = memoryValue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input for M-.");
            }
        }


        //ОБРАБОТКА ЦИФР И СИМВОЛОВ
        private void UpdateInput(string text)
        {
            if (Input.Text == "0")
            {
                Input.Text = text;
            }
            else
            {
                Input.Text += text;
            }
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Text;

                string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (buttonText == "." || buttonText == ",")
                {
                    if (!Input.Text.Contains(decimalSeparator))
                    {
                        Input.Text += decimalSeparator;
                    }
                }
                else
                {
                    if (Input.Text == "0")
                    {
                        Input.Text = buttonText; 
                    }
                    else
                    {
                        Input.Text += buttonText;
                    }
                }
            }
        }

        private void button_c_onclick(object sender, EventArgs e)
        {
            Input.Text = "0";
        }
        private void Input_Click(object sender, EventArgs e)
        {

        }

        private void inversButt_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input.Text, out double currentValue))
            {
                currentValue = -currentValue; // Инвертируем знак
                Input.Text = currentValue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input!"); // Если ввод некорректный
            }
        }
    }
}
