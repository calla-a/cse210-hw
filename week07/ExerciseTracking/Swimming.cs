using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private float _laps;

        public Swimming(float length, int laps) : base(length)
        {
            _laps = laps;
        }

        public override float GetDistance()
        {
            float distance = _laps * 50 / 1000;
            return distance;
        }

        public override float GetSpeed()
        {
            float speed = GetDistance() / GetLength() * 60;
            return speed;
        }

        public override float GetPace()
        {
            float pace = GetLength() / GetDistance();
            return pace;
        }

        public override string GetActivityType()
        {
            return "Swimming";
        }
    }
}