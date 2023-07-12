using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAndComparisonOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //int total = 5 + 10;
            //int otherTotal = 12 + 22;
            //int combined = total + otherTotal;
            //Console.WriteLine(combined);
            //Console.ReadLine();

            //int difference = 10 - 5;
            //Console.WriteLine("Ten minus Five = " + difference.ToString());
            //Console.ReadLine();

            //int product = 10 * 5;
            //Console.WriteLine(product);
            //Console.ReadLine();

            //double quotient = 100.0 / 17.0;
            //Console.WriteLine(quotient);
            //Console.ReadLine();

            //int remainder = 11 % 2;
            //Console.WriteLine(remainder);
            //Console.ReadLine();

            //bool trueOrFalse = 12 < 5;
            //Console.WriteLine(trueOrFalse.ToString());
            //Console.ReadLine();

            //int roomTemp = 70;
            //int currentTemp = 70;

            //bool isWarm = currentTemp <= roomTemp;
            //bool isWarm = currentTemp != roomTemp;
            //Console.WriteLine(isWarm);
            //Console.ReadLine();

            Console.WriteLine("Please choose a number (any number): ");
            string number1 = Console.ReadLine();
            decimal num1 = Convert.ToDecimal(number1);
            decimal product = num1 * 50;
            Console.WriteLine("Your number multiplied by Fifty = " + product);
            Console.ReadLine();

            Console.WriteLine("Please choose another number (any number), or use the same number again: ");
            string number2 = Console.ReadLine();
            decimal num2 = Convert.ToDecimal(number2);
            decimal addTwoFive = num2 + 25;
            Console.WriteLine("Your number plus twenty five = " + addTwoFive);
            Console.ReadLine();

            Console.WriteLine("Please choose another number (any number), or use the same number again: ");
            string number3 = Console.ReadLine();
            decimal num3 = Convert.ToDecimal(number3);
            decimal divTwelveFive = num3 / 12.5m;
            Console.WriteLine("Your number divided by twelve and a half = " + divTwelveFive);
            Console.ReadLine();

            Console.WriteLine("Please choose another number (any number), or use the same number again: ");
            string number4 = Console.ReadLine();
            decimal num4 = Convert.ToDecimal(number4);
            bool checkFifty = num4 > 50;
            Console.WriteLine("It is " + checkFifty + " that your number is greater than Fifty.");
            Console.ReadLine();

            Console.WriteLine("Please choose another number (any number), or use the same number again: ");
            string number5 = Console.ReadLine();
            decimal num5 = Convert.ToDecimal(number5);
            long divSeven = (long)num5 / 7;
            long remainder = (long)num5 % 7;
            Console.WriteLine("Your number divided by seven = " + divSeven + " with a reminder of "+ remainder);
            Console.ReadLine();






        }
    }
}
