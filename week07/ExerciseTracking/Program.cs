using System;
using System.Diagnostics;
using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {
        List<ExerciseTracking.Activity> activities = new List<ExerciseTracking.Activity>();

        Running running1 = new Running(17, 2);
        activities.Add(running1);
        Running running2 = new Running(40, 7);
        activities.Add(running2);

        Cycling cycling1 = new Cycling(35, 8);
        activities.Add(cycling1);
        Cycling cycling2 = new Cycling(75, 33);
        activities.Add(cycling2);

        Swimming swimming1 = new Swimming(25, 15);
        activities.Add(swimming1);
        Swimming swimming2 = new Swimming(45, 36);
        activities.Add(swimming2);

        foreach (ExerciseTracking.Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary(""));
            Console.WriteLine();
        }
    }
}