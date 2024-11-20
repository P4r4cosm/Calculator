using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        static double DoOperation(double a, double b, Operation operation)
        {
            switch (operation.MathOperation)
            {
                case "+": return a+b;
                case "-": return a-b;
                case "*": return a*b;
                case "/": return a/b;
                case "^": return Math.Pow(a, b);
                case "%": return a%b;
                default: return 0;
            }
        }
        static double DoFunction(double a, Function function)
        {
           switch (function.Func)
            {
                case "sin":return Math.Sin(a);
                case "cos": return Math.Cos(a);
                default: return 0;
            }
        }
    }
}
