using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private float _distance;

        public Running(int length, float distance) : base(length)
        {
            _distance = distance;
        }

        public override float GetDistance()
        {
            return _distance;
        }

        public override float GetSpeed()
        {
            float speed = _distance / GetLength() * 60;
            return speed;
        }

        public override float GetPace()
        {
            float pace = GetLength() / _distance;
            return pace;
        }

        public override string GetActivityType()
        {
            return "Running";
        }
    }
}