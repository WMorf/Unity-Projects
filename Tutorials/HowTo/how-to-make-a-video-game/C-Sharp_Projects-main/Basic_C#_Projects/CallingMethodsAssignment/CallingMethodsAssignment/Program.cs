using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethodsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plese choose any integer: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("We will now perform the following operations on " + choice);
            int choiceSquared = Operations.Square(choice);
            Console.WriteLine(choice + " squared = " + choiceSquared);
            int choiceDoubled = Operations.Double(choice);
            Console.WriteLine(choice + " doubled = " + choiceDoubled);
            int choiceCubed = Operations.Cube(choice);
            Console.WriteLine(choice + " cubed = " + choiceCubed);
            Console.ReadLine();
        }
    }
}
