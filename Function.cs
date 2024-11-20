using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Function
    {
        public string Func { get; private set; }
        public Function(string func)
        {
            Func = func;
        }
    }
}
