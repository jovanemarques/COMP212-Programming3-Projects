using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
          public class Driver
          {
                    public static void Main(string[] args)
                    {
                              int operatorX = Convert.ToInt32(Console.ReadLine());
                              int operatorY = Convert.ToInt32(Console.ReadLine());
                              Calculator obj = new Calculator();
                              Console.WriteLine(obj.Add(operatorX, operatorY));
                              Console.WriteLine(obj.Sub(operatorX, operatorY));
                              Console.WriteLine(obj.Multi(operatorX, operatorY));
                              Console.WriteLine(obj.Div(operatorX, operatorY));
                              Console.ReadLine();
                    }
          }
}
