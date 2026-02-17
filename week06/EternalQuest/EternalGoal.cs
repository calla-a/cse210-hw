using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {

        }

        public override void RecordEvent()
        {
            Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetStringRepresentation()
        {
            string stringRepresentation = $"EternalGoal:{GetName()}|{GetDescription()}|{GetPoints()}";
            return stringRepresentation;
        }
    }
}