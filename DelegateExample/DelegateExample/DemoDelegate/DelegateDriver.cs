using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
          public class DelegateDriver
          {
                    delegate void SumDelegate(int x, int y);

                    static void Main(string[] args)
                    {
                              //Declare Delegate Objetc
                              SumDelegate objDelegate = null;

                              //Point to method reference in our example "Sum"
                              objDelegate = Sum;

                              //Final Step Invoke Delegate
                              objDelegate.Invoke(10, 20);
                              Console.ReadLine();
                    }

                    static void Sum(int x, int y)
                    {
                              Console.WriteLine((x + y).ToString());
                    }
          }
}
