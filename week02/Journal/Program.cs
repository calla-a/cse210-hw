using System;
using System.Security.Cryptography.X509Certificates;
using Journal;

class Program
{

    // Added "mood", included in the Entry class. Before the prompt, the program will ask the user for their feelings
    // Added confirmation messages when saving and loading files. Additionally, if the user enters the name of a file
    // that does not exist when loading, they will be advised about it

    static void Main(string[] args)
    {
        Journal.Journal journal = new Journal.Journal();

        PromptGenerator promptsList = new PromptGenerator();
        promptsList._prompts.Add("What is one thing I know now that I didn't know when I woke up this morning?");
        promptsList._prompts.Add("Which activity today was the most energizing?");
        promptsList._prompts.Add("Which activity today was the most draining?");
        promptsList._prompts.Add("What is one thing that stayed on my mind today?");
        promptsList._prompts.Add("What is a small victory I achieved today?");
        promptsList._prompts.Add("How did my actions affect someone else's day today?");
        promptsList._prompts.Add("At what point today did I feel the most frustated?");
        promptsList._prompts.Add("Did I do at least one thing today to take care of my physical well-being?");
        promptsList._prompts.Add("Did I do at least one thing today to take care of my mental well-being?");
        promptsList._prompts.Add("If I could carry only one lesson from today into tomorrow, what would it be?");

        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();
            Console.WriteLine();

            if (userChoice == "1")
            {
                Entry entry = new Entry();
                string mood = "";

                entry. _mood = journal.AskForMood(mood);

                string prompt = promptsList.GetRandomPromt();
                Console.WriteLine(prompt);
                Console.Write("> ");

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = Console.ReadLine();

                journal.AddEntry(entry);
            }

            else if (userChoice == "2")
            {
                journal.DisplayAll();
            }

            else if (userChoice == "3")
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }

            else if (userChoice == "4")
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }

            else
            {
                Console.WriteLine("Please, select a valid option.");
            }
            Console.WriteLine();
        } while (userChoice != "5");
    }
}