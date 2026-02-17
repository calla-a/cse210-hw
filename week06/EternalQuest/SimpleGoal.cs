using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false;
        }
        public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override void RecordEvent()
        {
            if (_isComplete == true)
            {
                _isComplete = true;
                Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");
            }
            else
            {
                Console.WriteLine("This goal has already been achieved.");
            }
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            string stringRepresentation = $"SimpleGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}";
            return stringRepresentation;
        }
    }
}