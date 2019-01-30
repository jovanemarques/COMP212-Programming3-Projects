using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    public class Class1
    {
        // Declare Delegate
        public delegate int CalculatorDelegate(int x, int y);

        //Create Delegat Reference
        CalculatorDelegate delegateObj;

        public CalculatorDelegate GetDelegateRef(int intoperation)
        {
            switch (intoperation)
            {
                case 1:
                    delegateObj = Add;
                    break;
                case 2:
                    delegateObj = Sub;
                    break;
                case 3:
                    delegateObj = Multi;
                    break;
                case 4:
                    delegateObj = Div;
                    break;
            }
            return delegateObj;
        }
        private int Add(int a, int b)
        {
            return a + b;
        }
        private int Sub(int a, int b)
        {
            return a - b;
        }
        private int Multi(int a, int b)
        {
            return a * b;
        }
        private int Div(int a, int b)
        {
            return a / b;
        }
    }
