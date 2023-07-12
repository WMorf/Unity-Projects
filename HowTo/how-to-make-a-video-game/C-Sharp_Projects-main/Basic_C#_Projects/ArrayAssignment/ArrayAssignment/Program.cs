using System;
using System.Collections.Generic;

namespace ArrayAssignment
{
    class Program
    {
        static void Main()
        {
            //Instantiating Arrays and List to be used in app
            string[] stringArray = { "Hello", "Bonjour", "Konnichi wa", "Halo", "Guten tag", "Szia" };
            int[] intArray = { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
            List<string> stringList = new List<string>();
            stringList.Add("Rock");
            stringList.Add("Paper");
            stringList.Add("Scissors");

            //Begin App - First Choice
            Console.WriteLine("Please select a number between 1-6 to see your greeting:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index >= 0 && index <= 5)
            {
                Console.WriteLine(stringArray[index]);
                Console.ReadLine();
            }
            else
            {
                while (index < 0 || index > 5)
                {
                    Console.WriteLine("Please only select a number between 1-6:");
                    index = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                Console.WriteLine(stringArray[index]);
                Console.ReadLine();
            }

            //Second Choice
            Console.WriteLine("Let us math a little... \nWe are going to take 2 to a power between 0 and 8.\nPlease choose which power you would like to see:");
            int index2 = Convert.ToInt32(Console.ReadLine());
            if (index2 >= 0 && index2 <= 8)
            {
                Console.WriteLine(intArray[index2]);
                Console.ReadLine();
            }
            else
            {
                while (index2 < 0 || index2 > 8)
                {
                    Console.WriteLine("Please only select a number between 0-8:");
                    index2 = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine(intArray[index2]);
                Console.ReadLine();
            }

            //Third Choice (Rock-Paper-Scissors)
            Console.WriteLine("Now let\'s play a quick game....\nPlease choose a number between 1 and 3:");
            int index3 = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index3 >= 0 && index3 <= 2)
            {
                Console.WriteLine("You have chosen "+ stringList[index3]+ ".\nHow foolish since I have chosen dynamite which destroys your " + stringList[index3] + "!");
                Console.ReadLine();
            }
            else
            {
                while (index3 < 0 || index3 > 2)
                {
                    Console.WriteLine("Please only select a number between 1-3:");
                    index3 = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("You have chosen " + stringList[index3] + ".\nHow foolish since I have chosen dynamite which destroys your " + stringList[index3] + "!");
                Console.ReadLine();
            }
        }
    }
}
