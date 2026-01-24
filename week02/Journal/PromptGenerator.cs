using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal
{
    public class PromptGenerator
    {
        public List<string> _prompts = new List<string>();

        public string GetRandomPromt()
        {
            string randomPrompt = _prompts[Random.Shared.Next(_prompts.Count)];
            return randomPrompt;
        }
    }
}