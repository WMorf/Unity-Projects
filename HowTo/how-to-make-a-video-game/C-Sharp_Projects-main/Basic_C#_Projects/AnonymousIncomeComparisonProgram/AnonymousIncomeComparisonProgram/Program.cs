using System;

namespace AnonymousIncomeComparisonProgram
{
    class Program
    {
        static void Main()
        {   
            //Person 1 Details
            Console.WriteLine("Anonymous Income Comparison Program \nPlease enter the following details for Person 1: \nHourly Rate?");
            string hourlyOne = Console.ReadLine();
            decimal rateOne = Convert.ToDecimal(hourlyOne);
            Console.WriteLine("\nHours worked per week?");
            string hoursWorked = Console.ReadLine();
            decimal hours = Convert.ToDecimal(hoursWorked);

            //Person 2 Details
            Console.WriteLine("\nNow plese provide the following details about Person 2: \nHourly Rate?");
            string hourlyTwo = Console.ReadLine();
            decimal rateTwo = Convert.ToDecimal(hourlyTwo);
            Console.WriteLine("\nHours worked per week?");
            string secondHoursWorked = Console.ReadLine();
            decimal hoursTwo = Convert.ToDecimal(secondHoursWorked);

            //Computations
            decimal salaryOne = rateOne * hours * 52;
            decimal salaryTwo = rateTwo * hoursTwo * 52;
            bool whoMakesMore = salaryOne > salaryTwo;

            //Output
            Console.WriteLine("Press any key to see the results....");
            Console.ReadLine();
            Console.WriteLine("\nAnnual salary of Person 1:\n$" + salaryOne + "\nAnnual salary of Person 2:\n$" + salaryTwo + "\nDoes Person 1 make more money than Person 2? \n" + whoMakesMore);
            Console.ReadLine();
        }
    }
}
