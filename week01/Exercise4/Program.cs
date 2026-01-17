using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 whe finished.");
        List<int> numbers = new List<int>();
        int number;
        double sum = 0;
        int largest = 0;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        foreach (int n in numbers)
        {
            sum += n;

            if (n > largest)
            {
                largest = n;
            }
        }

        double average = sum / numbers.Count();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}