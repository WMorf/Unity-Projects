using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Matt";
            string quote = "The man said, \"Hello\", "+name+".\n Hello on a new line.\n\tHello on a tab.";
            string fileName = @"C:\Users\keefe";

            bool trueOrFalse = name.Contains("s");
            trueOrFalse = name.EndsWith("s");

            int length = name.Length;

            name = name.ToLower();
            name = name.ToUpper();

            StringBuilder sb = new StringBuilder();

            sb.Append("My name is Matt");

            Console.WriteLine(sb);
            Console.WriteLine(fileName);
            Console.WriteLine(length);

            Console.ReadLine();
        }
    }
}
