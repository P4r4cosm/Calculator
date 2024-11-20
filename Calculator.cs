using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public enum Operation
        {
            Add,      
            Subtract, 
            Multiply, 
            Divide,   
            Power,    
            Modulo    
        }

        public enum Function
        {
            Sin,
            Cos,
            Sqrt,
            Floor,
            Ceil
        }

        public static double DoOperation(double a, double b, Operation operation)
        {
            switch (operation)
            {
                case Operation.Add: return a + b;
                case Operation.Subtract: return a - b;
                case Operation.Multiply: return a * b;
                case Operation.Divide: return a / b;
                case Operation.Power: return Math.Pow(a, b);
                case Operation.Modulo: return a % b;
                default: return a;
            }
        }


        public static double DoFunction(double a, Function function)
        {
            switch (function)
            {
                case Function.Sin: return Math.Sin(a);
                case Function.Cos: return Math.Cos(a);
                case Function.Sqrt: return Math.Sqrt(a);
                case Function.Floor: return Math.Floor(a);
                case Function.Ceil: return Math.Ceiling(a);
                default: return 0;
            }
        }
    }
}
