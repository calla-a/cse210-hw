using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is the magic number game.");
        Console.WriteLine("Guess the number to win.");
        Random random = new Random();
        int randomNumber = random.Next(1,100);
        int guess;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > randomNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != randomNumber);
    }
}