﻿using System;
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
        private Calculator.Operation currentOperation;
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
            result = Calculator.DoOperation(currentNumber, secondNumber, currentOperation); 
            Input.Text = result.ToString();
            currentNumber = result;  
        }


        //ОБРАБОТКА ФУНКЦИЙ
        private void button_sqrt_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator.DoFunction(currentNumber, Calculator.Function.Sqrt); 
            Input.Text = result.ToString();
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator.DoFunction(currentNumber, Calculator.Function.Sin); 
            Input.Text = result.ToString();
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            currentNumber = double.Parse(Input.Text); 
            result = Calculator.DoFunction(currentNumber, Calculator.Function.Cos); 
            Input.Text = result.ToString();
        }
        //TODO: ПОФИКСИТЬ НЕПРАВИЛЬНОЕ СЧИТЫВАНИЕ ПОЛЗУНКА
        private void RoundingMode_Scroll(object sender, EventArgs e)
        {
            int value = RoundingMode.Value;

            double roundedNumber = double.Parse(Input.Text);

            if (value < 33) 
            {
                roundedNumber = Calculator.DoFunction(roundedNumber, Calculator.Function.Floor);
            }
            else if (value > 66) 
            {
                roundedNumber = Calculator.DoFunction(roundedNumber, Calculator.Function.Ceil);
            }

            Input.Text = roundedNumber.ToString();
        }


        //ОБРАБОТКА ОПЕРАЦИЙ
        private void button_add_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Add;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Subtract;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Multiply;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0"; 
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Divide;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_raise_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Power;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0";  
        }

        private void button_mod_Click(object sender, EventArgs e)
        {
            currentOperation = Calculator.Operation.Modulo;
            currentNumber = double.Parse(Input.Text);
            Input.Text = "0"; 
        }

        //ОБАБОТКА MC, MS B Т.Д.
        private void button_mclear_Click(object sender, EventArgs e)
        {
            memoryValue = 0;
        }

        private void button_msave_Click(object sender, EventArgs e)
        {
            memoryValue = result;
        }

        private void button_msub_Click(object sender, EventArgs e)
        {
            result = result - memoryValue;
            Input.Text = result.ToString();
        }

        private void button_madd_Click(object sender, EventArgs e)
        {
            result = result + memoryValue;
            Input.Text = result.ToString();
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

        private void button_7_onclick(object sender, EventArgs e)
        {
            UpdateInput("7");
        }

        private void button_8_onclick(object sender, EventArgs e)
        {
            UpdateInput("8");
        }

        private void button_9_onclick(object sender, EventArgs e)
        {
            UpdateInput("9");
        }

        private void button_4_onclick(object sender, EventArgs e)
        {
            UpdateInput("4");
        }

        private void button_5_onclick(object sender, EventArgs e)
        {
            UpdateInput("5");
        }

        private void button_6_onclick(object sender, EventArgs e)
        {
            UpdateInput("6");
        }

        private void button_1_onclick(object sender, EventArgs e)
        {
            UpdateInput("1");
        }

        private void button_2_onclick(object sender, EventArgs e)
        {
            UpdateInput("2");
        }

        private void button_3_onclick(object sender, EventArgs e)
        {
            UpdateInput("3");
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
            UpdateInput("0");
        }
        private void button_dot_onclick(object sender, EventArgs e)
        {
            if (Input.Text[Input.Text.Length - 1].ToString() 
                != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                Input.Text += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        }

        private void button_c_onclick(object sender, EventArgs e)
        {
            Input.Text = "0";
        }
        private void Input_Click(object sender, EventArgs e)
        {

        }
        
    }
}
