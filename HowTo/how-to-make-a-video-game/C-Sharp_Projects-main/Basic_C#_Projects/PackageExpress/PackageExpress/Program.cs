using System;

namespace PackageExpress
{
    class Program
    {
        static void Main()
        {
            //App Begin
            Console.WriteLine("Welcome to the Package Express! \nPlease follow the instructions below:\nPlease enter your package weight:");
            double weight = Convert.ToDouble(Console.ReadLine());

            //Statement to stop app if package over 50lbs
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express.  Have a good day!");
                Console.ReadLine();
            }

            //If weight under 50, input measurements for price
            else
            {
                double roundedWeight = Math.Round(weight);
                Console.WriteLine("\nPlease enter the package width:");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPlease enter the package heigt:");
                int height= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPlease enter the package length:");
                int length = Convert.ToInt32(Console.ReadLine());
                int dimSum = width + height + length;
                if (dimSum > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.  Have a good day!");
                    Console.ReadLine();
                }
                else
                {
                    //Calculations
                    int product = width * height * length;
                    double quote = (product * roundedWeight) / 100;

                    //Final output
                    Console.WriteLine("\nYour estimated total for shipping this package is: $" + quote + ".00\nThank you!");
                    Console.ReadLine();
                }

            }
        }
    }
}
