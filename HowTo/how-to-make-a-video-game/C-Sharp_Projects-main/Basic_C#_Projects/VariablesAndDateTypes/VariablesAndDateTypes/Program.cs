using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAndDateTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a simple program
            //Console.WriteLine("What is your name?");
            //string yourName = Console.ReadRine();
            //Console.WriteLine("your name is: " + yourname);
            //Console.ReadLine();

            //Console.WriteLine("What is your favorite number?");
            //string favoriteNumber = Console.ReadLine();
            //int favNum = Convert.ToInt32(favoriteNumber);
            //int total = favNum + 5;
            //Console.WriteLine("Your favorite number plus 5 is: " + total);
            //Console.ReadLine();

            //bool isStudying = false;
            //byte hoursWorked = 42;
            //sbyte currentTemperature = -23;
            //char questionMark = '\u2103';

            //decimal moneyInBank = 100.5m;

            //double heightInCm = 2112.302302092;

            //float secondsLeft = 2.62f;

            //short tempartureOnMars = -341;

            //int currentAge = 30;
            //string yearsOld = currentAge.ToString();

            //bool isRaining = true;
            //string rainingStatus = Convert.ToString(isRaining);

            //Console.WriteLine(rainingStatus);
            //Console.ReadLine();

            //Math Challenge
            decimal x = 5;
            short y = 7;
            decimal totalAdd = x + y;
            decimal totalSubt = x - y;
            decimal totalMult = x * y;
            decimal divInt = x / y;
            //decimal totalDiv = Convert.ToDecimal(divInt);
            decimal totalRemainder = x % y;
            Console.WriteLine("x and y added together = " + totalAdd);
            Console.ReadLine();
            Console.WriteLine("x subtract y = " + totalSubt);
            Console.ReadLine();
            Console.WriteLine("x multiplied by y = " + totalMult);
            Console.ReadLine();
            Console.WriteLine("x divided by y = " + divInt);
            Console.ReadLine();
            Console.WriteLine("Remainder of x divided by y = " + totalRemainder);
            Console.ReadLine();

        }
    }
}
