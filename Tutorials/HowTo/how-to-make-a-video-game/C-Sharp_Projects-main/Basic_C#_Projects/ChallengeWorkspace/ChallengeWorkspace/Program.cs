using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWorkspace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please pick a fruit choice by entering the letter of your choice:\nA.) Apple\nB.) Banana\nC.) Cantelope\nD.) Dragon Fruit");
            //string choice = Console.ReadLine();
            //if (choice != "A")
            //{
            //    Console.WriteLine("Hmmmm.... why don\'t you like apples?");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("Nice selection, apples are amazing!");
            //    Console.ReadLine();

            //}

            //Console.WriteLine("What is your annual salary?");
            //string annualPay = Console.ReadLine();
            //double salary = Convert.ToDouble(annualPay);
            //if (salary > 100000.0)
            //{
            //    Console.WriteLine("Wow, you makde decent money for today\'s economy!");
            //    Console.ReadLine();
            //}
            //else if (salary <= 100000.0 && salary > 60000.0)
            //{
            //    Console.WriteLine("Unfortunately that is about the average in today\'s economy and I am sure you are holding on to make ends meet...");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("I hope you live in a dual income household....");
            //    Console.ReadLine();
            //}

            //int num1 = 7;
            //if (num1 <7 || num1 == 12)
            //{
            //    Console.WriteLine("At least one value is true.");
            //    Console.ReadLine();
            //}
            //if (num1==12 || num1 == 18)
            //{
            //    Console.WriteLine("At least one value is true.");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("No value is true.");
            //    Console.ReadLine();
            //}
            //if (num1 == 12 || num1 == 18 || num1==20 || num1 == 7)
            //{
            //    Console.WriteLine("Something must be true.");
            //    Console.ReadLine();
            //}

            //Console.WriteLine("Pick a number, any number.");
            //string pickedNumber = Console.ReadLine();
            //double num1 = Convert.ToDouble(pickedNumber);
            //if (num1 == 184)
            //{
            //    Console.WriteLine("Your number is the same as mine!");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    string result = num1 > 184 ? "Your number is bigger than mine" : "Your number is smaller than mine.";
            //    Console.WriteLine(result);
            //    Console.ReadLine();


            //Console.WriteLine("Please pick a fruit choice by entering the letter of your choice:\nA.) Apple\nB.) Banana\nC.) Cantelope\nD.) Dragon Fruit");
            //string choice = Console.ReadLine();
            //switch (choice)
            //{
            //    case "A":
            //        Console.WriteLine("Applese are the best.");
            //        break;
            //    case "B":
            //        Console.WriteLine("Bananas are ok... a bit to phallic shaped for my taste... but hey man, you do you...");
            //        break;
            //    case "C":
            //        Console.WriteLine("I like cantelope too, but they are often out of season, or not ripe enough... \nbut a good cantelope beats an apple any day!");
            //        break;
            //    case "D":
            //        Console.WriteLine("I\'ve never had dragon fruit before.  Looks a little sus though...");
            //        break;
            //}
            //Console.ReadLine();

            string greeting = "Hello, ";
            string name = "Matt";
            name = name.ToUpper();
            string pleasentry = ". How are you today?";
            string welcomeMessage = greeting + name + pleasentry;

            Console.WriteLine(welcomeMessage);
            Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append("There once was a ship that put to sea");
            sb.Append("\nAnd the name of this ship was the Bully O\'Tea.");
            sb.Append("\nThe winds blew up, her bow dipped down");
            sb.Append("\nOh blow my bully boys blow...");

            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
}
