using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted += 1;
                if (_amountCompleted == _target)
                {
                    Console.WriteLine($"Congratulations! You have earned {GetPoints() + _bonus} points!");
                }
                else if (_amountCompleted > 0 && _amountCompleted < _target)
                {
                    Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");
                }
            }
            else
            {
                Console.WriteLine("This goal has already been achieved.");
            }
        }

        public override bool IsComplete()
        {
            if (_amountCompleted >= _target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string GetDetailsString()
        {
            if (IsComplete() == true)
            {
                return $"[X] {GetName()} ({GetDescription()}) -- Completed: {_amountCompleted}/{_target}";
            }
            else
            {
                return $"[ ] {GetName()} ({GetDescription()}) -- Currently: {_amountCompleted} /{_target}";
            }
        }

        public override string GetStringRepresentation()
        {
            string stringRepresentation = $"ChecklistGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
            return stringRepresentation;
        }
    }
}