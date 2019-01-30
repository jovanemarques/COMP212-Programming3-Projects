using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEventHandler
{
    public class Utility
    {
        public delegate string SignDel();

        public SignDel[] signers= { signByChair, signByCooridinator, signByN, signByY };

        public static string signByChair()
        {
            return "Your document has been signed by ICET chair";
        }

        public static string signByCooridinator()
        {
           return "Your document has been signed by Program coordintor";
        }

        public static string signByN()
        {
            return "Your document has been signed by Narendra";
        }

        public static string signByY()
        {
            return "Your document has been signed by Yin";
        }
    }
}
