using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationForms
{
    class Result
    {
        public string name;
        public string mark;
        public string ci;
        public double value;

        public Result(string inputName, string inputMark, string inputCi, double inputValue)
        {
            name = inputName;
            ci = inputCi;
            value = inputValue;
            mark = inputMark;
        }
    }
}
