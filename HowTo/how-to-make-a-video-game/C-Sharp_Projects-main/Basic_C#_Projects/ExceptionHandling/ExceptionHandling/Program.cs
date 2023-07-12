using System;


namespace ExceptionHandling
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Pick a number.");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pick a second number");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dividing the two...");
                int num3 = num1 / num2;
                Console.WriteLine(num1 + " divided by " + num2 + " = " + num3);
                Console.ReadLine();
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Please type an integer.");
                return;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Please don\'t divide by zero.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
