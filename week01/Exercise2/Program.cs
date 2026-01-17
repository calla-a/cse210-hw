using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());
        Console.WriteLine();

        string letterGrade;

        if (gradePercentage >= 90 && gradePercentage <= 100)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80 && gradePercentage < 90)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70 && gradePercentage < 80)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60 && gradePercentage < 70)
        {
            letterGrade = "D";
        }
        else if (gradePercentage >= 0 && gradePercentage < 60)
        {
            letterGrade = "F";
        }
        else
        {
            letterGrade = ($"Don't lie, it's imposible to get {gradePercentage}");
        }
        Console.WriteLine(letterGrade);

        if (gradePercentage >= 70 && gradePercentage <= 100)
        {
            Console.WriteLine("Congratulations!!! You have passed the course!");
        }
        else if (gradePercentage < 70 && gradePercentage >= 0)
        {
            Console.WriteLine("You shall not pass.");
        } 
    }
}