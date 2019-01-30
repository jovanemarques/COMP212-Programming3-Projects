using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnDelegate
{
          public class Driver
          {
                    public static void Main(string[] args)
                    {
                        Console.WriteLine("please enter the operation you like to do: 1: add; 2: sub; 3: times; 4: division");
                              int intoperation = Convert.ToInt32(Console.ReadLine());
                              Console.WriteLine("please enter the first operand: ");
                              int operatorX = Convert.ToInt32(Console.ReadLine());
                              Console.WriteLine("please enter the second operand: ");
                              int operatorY = Convert.ToInt32(Console.ReadLine());

                              Calculator obj = new Calculator();

                              int result=obj.GetDelegateRef(intoperation).Invoke(operatorX, operatorY);

                              Console.WriteLine("the result ="+result);
                              Console.ReadLine();
                    }
          }
}
