using System;
using ScriptureMemorizer;

// I decided to create a text file called "Scriptures.txt" whiich stores many scriptures with their references. The books, chapters, versicles and text are propietly divide by "|"
// Due this, the classes's design had to change a bit, but I keep it as similar as the suggested design.
// Added a new member variable to the Reference class which recieves and stores the text of the versicles and the GetDisplayText method were replaced.
// Due this, the Scripture constructor also changed.
// Now, the program hides only words that haven't been hidden.

class Program
{
    static void Main(string[] args)
    {
        string fileName = "Scriptures.txt";
        List<Reference> scriptures = Reference.GenerateList(fileName);

        Scripture scripture = new Scripture(scriptures);
        string decision;

        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayReference());
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            decision = Console.ReadLine();

            if (decision != "quit")
            {
                scripture.HideRandomWord(3);
            }
        } while (decision != "quit" && !scripture.IsCompletelyHidden());

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayReference());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            Console.ReadLine();
        }
    }
}