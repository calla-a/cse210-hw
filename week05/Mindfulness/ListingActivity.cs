using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;
        private List<string> _avaiblePrompts;
        private Random _randomElement = new Random();

        public ListingActivity() : base("Listing Activity",
        "reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
            _avaiblePrompts = new List<string>(_prompts);
        }

        public void Run()
        {
            DisplayStartingMessage();
            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($" --- {GetRandomPrompt()} ---");
            Console.Write($"You may begin in: ");
            ShowCountDown(5);
            var userList = GetListFromUser();
            _count = userList.Count();
            Console.WriteLine($"You listed {_count} items!");
            Console.WriteLine();
            DisplayEndingMessage();
        }

        public string GetRandomPrompt()
        {
            if (_avaiblePrompts.Count == 0)
            {
                _avaiblePrompts = new List<string>(_prompts);
            }
            int i = _randomElement.Next(_avaiblePrompts.Count);
            string selectedPrompt = _avaiblePrompts[i];
            _avaiblePrompts.RemoveAt(i);
            return selectedPrompt;
        }

        public List<string> GetListFromUser()
        {
            List<string> userList = new List<string>();
            string userResponse;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(GetDuration());
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                userResponse = Console.ReadLine();
                userList.Add(userResponse);
            }
            return userList;
        }
    }
}