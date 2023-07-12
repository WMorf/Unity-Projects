using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Optional data = new Optional();
            Console.WriteLine("Hello, today we are going to examine the leading term in a quadratic function.\nPlease choose the number to use as your variable.");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Thank you, if you would like to include a scalar, you may do so, now.\n(this is optional, press enter if you do not want to include)");
            string num2 = Console.ReadLine();
            if (num2 == "")
            {
                int result = data.Squared(num1);
                Console.WriteLine("Your result is = " + result);
                Console.ReadLine();
            }
            else
            {
                int scalar = Convert.ToInt32(num2);
                int result = data.Squared(num1, scalar);
                Console.WriteLine("Your result is = "+ result);
                Console.ReadLine();
            }
            
            
        }
    }
}
