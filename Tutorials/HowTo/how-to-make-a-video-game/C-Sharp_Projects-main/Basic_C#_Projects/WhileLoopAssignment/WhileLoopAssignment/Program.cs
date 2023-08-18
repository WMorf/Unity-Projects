using System;


namespace WhileLoopAssignment
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to my loop game!\nPick a number, any number.");
            double num1 = Convert.ToDouble(Console.ReadLine());
            int myNumber = 184;
            if (num1 == myNumber)
            {
                Console.WriteLine("Wow you guessed my number quickly!");
                Console.ReadLine();
                return;
            }
            else while (num1 != myNumber)
                {
                    string result = num1 > myNumber ? "Your number is bigger than mine" : "Your number is smaller than mine.";
                    Console.WriteLine(result);
                    num1 = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Great job guessing my number!  \nDouble or nothing... and I won\'t make it easy on you! \nNow what number am I thinking of?");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Random rnd = new Random();
            int newNumber = rnd.Next();
            do
            {
                if (num2 == 184)
                {
                    Console.WriteLine("Did you really think I would choose the same number again?");
                    Console.WriteLine("Guess again.");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    
                }
                else if (num2 == 1)
                {
                    Console.WriteLine("Psssh that number is too simple....");
                    Console.WriteLine("Guess again.");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    
                }
                else if (num2 == newNumber)
                {
                    Console.WriteLine("How... how did you guess my number?!?!?!\nLooks like you win... this time...");
                    Console.ReadLine();
                    
                }
                else
                {
                    Console.WriteLine("Guess again. Hint:");
                    string result = num2 > newNumber ? "Your number is bigger than mine" : "Your number is smaller than mine.";
                    Console.WriteLine(result);
                    num2 = Convert.ToDouble(Console.ReadLine());
                    
                }
            }
            while (num2 != newNumber);
            //This may seem infinite, but it is just because the number could be VERY VERY large. Persistance is Key!
        }
    }
}
