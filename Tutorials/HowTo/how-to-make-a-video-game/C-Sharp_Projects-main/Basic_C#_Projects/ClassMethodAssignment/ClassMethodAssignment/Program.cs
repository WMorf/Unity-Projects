using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calling Parts 1 - 3 on Methods Assignment
            Test data = new Test();
            Console.WriteLine("Today I am going to use a class method and divide a number you give, by 2.\nPlease enter a number.");
            int newNum = Convert.ToInt32(Console.ReadLine());
            data.Half(newNum, out int nextNum);
            Console.WriteLine(nextNum);
            Console.ReadLine();

            //Calling parts 4 - 6 on Methods Assingment
            Console.WriteLine("Let us look at another number, please input an integer to  see it doubled.");
            int nextVar = Convert.ToInt32(Console.ReadLine());
            Double.Dub(nextVar, out int newDubVar);
            Console.WriteLine(newDubVar);
            Console.ReadLine();

            Console.WriteLine("Let us look at another number, please input a decimal to  see it doubled.");
            decimal nextVar2 = Convert.ToDecimal(Console.ReadLine());
            Double.Dub(nextVar2, out decimal newDubVar2);
            Console.WriteLine(newDubVar2);
            Console.ReadLine();



        }
    }
}
