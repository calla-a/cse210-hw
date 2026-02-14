using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine($"This activity will help you {_description}.");
            Console.WriteLine();
            Console.WriteLine("In seconds, how long do you want the activity to last? ");
            _duration = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Get ready");
            ShowDots(6);
            Console.WriteLine();
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("well done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
            ShowSpinner(4);
            Console.Clear();
        }

        public void ShowSpinner(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            List<string> spinnerStrings = new List<string>();
            spinnerStrings.Add("|");
            spinnerStrings.Add("/");
            spinnerStrings.Add("-");
            spinnerStrings.Add("\\");
            int i = 0;
            Console.CursorVisible = false;
            while (DateTime.Now < endTime)
            {
                string spinner = spinnerStrings[i];
                Console.Write(spinner);
                Thread.Sleep(200);
                Console.Write("\b");
                i++;
                if (i >= spinnerStrings.Count)
                {
                    i = 0;
                }
            }
            Console.WriteLine(" \b \b");
            Console.CursorVisible = true;
        }

        public void ShowCountDown(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            Console.CursorVisible = false;
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.CursorVisible = true;
            Console.WriteLine();
        }

        public void ShowDots(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            while (DateTime.Now < endTime)
            {
                Console.CursorVisible = false;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write("\b \b\b \b\b");
            }
            Console.WriteLine(" \b");
            Console.CursorVisible = true;
        }

        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }
        
        public string GetName()
        {
            return _name;
        }
    }
}