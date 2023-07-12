using System;
using System.Collections.Generic;


namespace IterationAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //String Array that will be iterated through and added to
            string[] adLibs = { "Giant ", "Big \'Ol ", "Heaping pile of ", "The world\'s oldest ", "Hot and fresh " };

            Console.WriteLine("Lets do some Adlibs!\nPlease enter a noun or noun phrase: ");
            string nounChoice = Console.ReadLine();

            Console.WriteLine("Here is what your choice produced: ");
            for (int i = 0; i < adLibs.Length; i++)
            {
                adLibs[i] = adLibs[i] + nounChoice;
                Console.WriteLine(adLibs[i]);
            }
            Console.ReadLine();

            //String array loop that was purposefully made in to an infinite loop and then fixed 
            string[] adLibs2 = { " to the bathroom!", " into my pants!", " out of an airplane!", " before you eat!", " before you swim!" };

            Console.WriteLine("Lets try some more Adlibs!\nPlease enter a verb or verb phrase: ");
            string verbChoice = Console.ReadLine();
            //Loop with a < operator
            Console.WriteLine("Here is what your choice produced: ");
            for (int j = 0; j < adLibs2.Length; j++) //Set j>=0 at first which made this an infinite loop, then fixed it.
            {
                adLibs2[j] = verbChoice + adLibs2[j];
                Console.WriteLine(adLibs2[j]);
            }
            Console.ReadLine();

            //Loop with a <= operator
            Console.WriteLine("Now let\'s play a counting game.\nPick any positive integer and we will count to it!");
            int countNum = Convert.ToInt32(Console.ReadLine());
            for (int k = 0; k <= countNum; k++)
            {
                Console.WriteLine(k);
            }
            Console.ReadLine();

            //Part 4 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            List<string> baseballLineup = new List<string>() { "Pitcher", "Catcher", "First-base", "Second-base", "Third-base", "Shortstop", "Left-field", "Center-field", "Right-field" };
            Console.WriteLine("Here is a list of names of baseball positions:\n" + baseballLineup[1] + "\n" + baseballLineup[3] + "\n" + baseballLineup[5] + "\n" + baseballLineup[7] + "\n" + baseballLineup[0] + "\n" + baseballLineup[2] + "\n" + baseballLineup[4] + "\n" + baseballLineup[6] + "\n" + baseballLineup[8]);
            Console.WriteLine("Plese enter in one of the above positions to see it\'s position number.");
            string lineupName = Console.ReadLine();
            if (baseballLineup.Contains(lineupName))
            {
                for (int l = 0; l < baseballLineup.Count; l++)
                {
                    if (lineupName == baseballLineup[l])
                    {
                        Console.WriteLine(l);
                        break;
                    }
                }
                Console.ReadLine();
            }
            else
            {
                while (!baseballLineup.Contains(lineupName))
                {
                    Console.WriteLine("Please type the position exactly as it appears");
                    lineupName = Console.ReadLine();
                }
                for (int l = 0; l < baseballLineup.Count; l++)
                {
                    if (lineupName == baseballLineup[l])
                    {
                        Console.WriteLine(l);
                        break;
                    }
                }
                Console.ReadLine();
            }

            //Part 5 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            List<string> fruitList = new List<string>() { "apples", "bananas", "strawberries", "oranges", "pineapples", "apples" };
            Console.WriteLine("This part of the app will tell you how I rank your favorite fruit.\nPlease enter your favorite fruit. (plural)");
            string favFruit = Console.ReadLine().ToLower();
            if (fruitList.Contains(favFruit))
            {
                for (int m = 0; m < fruitList.Count; m++)
                {
                    if (favFruit == fruitList[m])
                    {
                        Console.WriteLine(m);
                    }
                }
                Console.ReadLine();
            }
            else
            {
                while (!fruitList.Contains(favFruit))
                {
                    Console.WriteLine("I\'m sorry, that is not one of the items in the list.  Please try again.");
                    favFruit = Console.ReadLine();
                }
                for (int m = 0; m < fruitList.Count; m++)
                {
                    if (favFruit == fruitList[m])
                    {
                        Console.WriteLine(m);
                    }
                }
                Console.ReadLine();
            }


            //Part 6 (Revised)-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            List<string> colors = new List<string>() { "red", "orange", "yellow", "green", "blue", "indigo", "violet", "green" };
            List<string> seenColors = new List<string>();
            foreach(string color in colors)
            {
                if (!seenColors.Contains(color))
                {
                    seenColors.Add(color);
                    Console.WriteLine(color + " has not been seen.");
                }
                else
                {
                    Console.WriteLine(color + " has already been seen");
                }
            }
            Console.ReadLine();


            ////Part 6 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //List<string> colors = new List<string>() { "red", "orange", "yellow", "green", "blue", "indigo", "violet", "green" };
            //Console.WriteLine("This part of the app will tell you what index your favorire color is in the rainbow!\nWhat is your favorite color?");
            //string favColor = Console.ReadLine().ToLower();
            //if (colors.Contains(favColor))
            //{
            //    int counter = 0;
            //    foreach (string color in colors)
            //    {
            //        if (favColor == color)
            //        {
            //            Console.WriteLine(color);
            //            counter++;
            //            switch (counter)
            //            {
            //                case 1:
            //                    Console.WriteLine("This is the first occurance of " + favColor);
            //                    break;
            //                case 2:
            //                    Console.WriteLine("This is the second occurance of " + favColor);
            //                    break;
            //            }
            //        }
            //    }
            //    Console.ReadLine();
            //}
            //else
            //{
            //    while (!colors.Contains(favColor))
            //    {
            //        Console.WriteLine("I\'m sorry, the color you selected is not part of the rainbow.  Please select another color.  (Hint: ROY G. Biv)");
            //        favColor = Console.ReadLine().ToLower();
            //    }
            //    int counter = 0;
            //    foreach (string color in colors)
            //    {
            //        if (favColor == color)
            //        {
            //            Console.WriteLine(color);
            //            counter++;
            //            switch (counter)
            //            {
            //                case 1:
            //                    Console.WriteLine("This is the first occurance of " + favColor);
            //                    break;
            //                case 2:
            //                    Console.WriteLine("This is the second occurance of " + favColor);
            //                    break;
            //            }
            //        }
            //    }
            //    Console.ReadLine();
     

        }
    }
}
