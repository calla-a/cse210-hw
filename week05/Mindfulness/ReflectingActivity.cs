using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _promts;
        private List<string> _questions;
        private List<string> _avaiblePrompts;
        private List<string> _avaibleQuestions;
        private Random _randomElement = new Random();

        public ReflectingActivity() : base("Reflecting Activity",
        "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _promts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _avaiblePrompts = new List<string>(_promts);

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            _avaibleQuestions = new List<string>(_questions);
        }

        public void Run()
        {
            DisplayStartingMessage();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            DisplayPromt();
            Console.WriteLine();
            Console.WriteLine("Once you have something in mind, press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.Clear();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(GetDuration());
            while (DateTime.Now < endTime)
            {
                DisplayQuestions();
                ShowSpinner(15);
            }
            Console.WriteLine();
            DisplayEndingMessage();
        }

        public string GetRandomPrompt()
        {
            if (_avaiblePrompts.Count == 0)
            {
                _avaiblePrompts = new List<string>(_promts);
            }
            int i = _randomElement.Next(_avaiblePrompts.Count);
            string selectedPrompt = _avaiblePrompts[i];
            _avaiblePrompts.RemoveAt(i);
            return selectedPrompt;
        }

        public string GetRandomQuestion()
        {
            if (_avaibleQuestions.Count == 0)
            {
                _avaibleQuestions = new List<string>(_questions);
            }
            int i = _randomElement.Next(_avaibleQuestions.Count);
            string selectedQuestion = _avaibleQuestions[i];
            _avaibleQuestions.RemoveAt(i);
            return selectedQuestion;
        }

        public void DisplayPromt()
        {
            Console.WriteLine($" --- {GetRandomPrompt()} ---");
        }

        public void DisplayQuestions()
        {
            Console.Write($"> {GetRandomQuestion()} ");
        }
    }
}