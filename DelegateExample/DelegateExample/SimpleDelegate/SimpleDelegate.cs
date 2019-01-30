using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    public class SimpleDelegate
    {
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod2;

            Del handler2 = DelegateMethod;

            // Call the delegate.
            handler("Hello World");
            handler2.Invoke("this is through invoke: Hello World");

            Console.ReadKey();
        }

        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
            //return message;
        }

        public static void DelegateMethod2(string name)
        {
            System.Console.WriteLine("hello "+ name);
        }
    }
}
