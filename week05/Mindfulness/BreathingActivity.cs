using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
        "relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {

        }
        
        public void Run()
        {
            DisplayStartingMessage();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(GetDuration());
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                ShowCountDown(4);
                Console.Write("Breathe out... ");
                ShowCountDown(5);
            }
            Console.WriteLine();
            DisplayEndingMessage();
        }
    }
}