using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                List<int> intList = new List<int>() { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
                Console.WriteLine("Hello, we are going to divide the powers of two.\nPlease pick a number to divide by.");
                int divisor = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < intList.Count; i++)
                {
                    decimal divNum = intList[i] / divisor;
                    Console.WriteLine(divNum);
                }
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter integer values.");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Please do not divide by zero");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Try/Catch has returned to main program.");
                Console.ReadLine();
            }
        }
    }
}
