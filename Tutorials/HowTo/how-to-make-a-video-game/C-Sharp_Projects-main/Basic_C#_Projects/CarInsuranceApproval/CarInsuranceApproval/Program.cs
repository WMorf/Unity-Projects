using System;


namespace CarInsuranceApproval
{
    class Program
    {
        static void Main()
        {
            //Input - Form
            Console.WriteLine("Car Insurance Approval Program\nPlease provide the following information:\nWhat is your age?");
            string givenAge = Console.ReadLine();
            int age = Convert.ToInt32(givenAge);
            Console.WriteLine("\nThank You\nHave you ever had a DUI or other similar offense either midemeanor or felony?\nPlease enter\"true\" if so, otherwise please enter \"false\".");
            string drivingUnderInfluence = Console.ReadLine();
            bool dUI = Convert.ToBoolean(drivingUnderInfluence);
            Console.WriteLine("\nThank You\nPlease provide the number of speeding citations you have been given.");
            string speedingTickets = Console.ReadLine();
            int speedTick = Convert.ToInt32(speedingTickets);
            Console.WriteLine("Thank You\nPlease press any key to see results...");
            Console.ReadLine();

            //Determining Qualification
            bool qualification = ((age > 15) && (dUI == false) && (speedTick <= 3));
            if (qualification == true)
            {
                Console.WriteLine("Congratulations, you are qualified to recieve insurance on your vehicle!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("We are sorry, but your application cannot be approved at this time. \nPlease make sure you have read through our approval guidelines to determine your eligibility. \nPlease try again once you meet all requirements. \nThank you.");
                Console.ReadLine();
            }
        }
    }
}
