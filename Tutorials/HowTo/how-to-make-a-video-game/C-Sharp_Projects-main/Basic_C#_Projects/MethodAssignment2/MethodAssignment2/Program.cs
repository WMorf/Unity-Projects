using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Performing first Operation Method
            Operations test1 = new Operations();
            int newNum = test1.Operation(5);

            Console.WriteLine(newNum);
            Console.ReadLine();

            //Performing second Operation method
            Operations test2 = new Operations();
            int nextNum = test2.Operation(6.3m);

            Console.WriteLine(nextNum);
            Console.ReadLine();

            //Performing third Operation method
            Operations test3 = new Operations();
            int finalNum = test3.Operation("5");

            Console.WriteLine(finalNum);
            Console.ReadLine();


        }
    }
}
