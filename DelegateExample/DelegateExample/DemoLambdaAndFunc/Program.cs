using System;

namespace DemoLambdaAndFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            string mid = ", middle part, ";

            //Func<string, string> del = message =>
            //{
            //    message += mid;
            //    message += " and this was added to the message ";
            //    return message;
            //};
            Func<string, string> del = Greeting;
            Action<string, string> aDel = ConcatString;


            Console.WriteLine(del("Start of spring"));
            aDel("Jovane", "Marques");
        }

        public static string Greeting(string name)
        {
            return "Hello " + name;
        }

        public static void ConcatString(string firstName, string lastName)
        {
            Console.WriteLine("Hello " + firstName + " " + lastName);
        }
    }
}
