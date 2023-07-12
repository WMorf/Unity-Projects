using System;

namespace DailyReport
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("The Tech Academy \nStudent Daily Report\n\nWhat is your name?");
            string yourName = Console.ReadLine();
            Console.WriteLine("Hello " + yourName + " What course are you currently on?");
            string yourCourse = Console.ReadLine();
            Console.WriteLine("Ok, and in " + yourCourse + ", what page or step number are you currently on?");
            string stepNumber = Console.ReadLine();
            int stepNum = Convert.ToInt32(stepNumber);
            //Assuming that the current course has only 150 steps
            int finishNum = 150 - stepNum;
            Console.WriteLine("Great job " + yourName + " making it to step " + stepNum + "!  \nThis means you will be done with the "+yourCourse +" in "+ finishNum + " more steps! \nDo you need help with anything?  Please answer \"true\" or \"false\".  (Please mind spelling and capitalization.)");
            string needHelp= Console.ReadLine();
            bool helpNeeded = Convert.ToBoolean(needHelp);
            switch (helpNeeded)
            {
                case true:
                    Console.WriteLine("What can we help you with?");
                    string whatHelp = Console.ReadLine();
                    break;
                case false:
                    break;
            }
            Console.WriteLine("Where there any positive experiences you would like to share? Please give specifics.");
            string posExp = Console.ReadLine();
            Console.WriteLine("Ok, thank you.  Is there any other feedback you\'d like to provide? Please be specific.");
            string otherFeedback = Console.ReadLine();
            Console.WriteLine("How many hours were you able to study today?");
            string hoursStudied = Console.ReadLine();
            int studyHours = Convert.ToInt32(hoursStudied);
            Console.WriteLine("Great job " + yourName + " for studying " + studyHours + " hours today!\nThank you for your answers.  An instructor will respond to this shortly.  Have a great day!");
            Console.ReadLine();

        }
    }
}
