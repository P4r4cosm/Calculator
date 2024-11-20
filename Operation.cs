using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operation
    {
        public string MathOperation { get; private set; }
        Operation(string oper)
        {
            MathOperation = oper;
        }

    }
}
