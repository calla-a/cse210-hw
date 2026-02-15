using System;
using System.Security.Cryptography.X509Certificates;
using Mindfulness;

// Now, for the reflecting and listing activities repeated prompts and questions won't be selected until
// they all had been displayed at leat one time.
// The number of times that the activities were perfomed in the sesion will be showed to the user when
// the program finishes.

class Program
{
    static void Main(string[] args)
    {
        string userChoice;
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        Console.Clear();

        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflecting activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                breathingCount++;
            }

            else if (userChoice == "2")
            {
                reflectingActivity.Run();
                reflectingCount++;
            }

            else if (userChoice == "3")
            {
                listingActivity.Run();
                listingCount++;
            }

            else if (userChoice != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Please, select a valid option.");
            }
        } while (userChoice != "4");
        ActivityCounter(breathingCount, "Breathing Activity");
        ActivityCounter(reflectingCount, "Reflecting Activity");
        ActivityCounter(listingCount, "Listing Activity");
    }

    public static void ActivityCounter(int count, string activity)
    {
        if (count > 0)
        {
            if (count == 1)
            {
                Console.WriteLine($"You completed the {activity} {count} time.");
            }
            else
            {
                Console.WriteLine($"You have completed the {activity} {count} times.");
            }
        }
    }
}