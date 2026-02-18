using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private float _speed;

        public Cycling(float length, float speed) : base(length)
        {
            _speed = speed;
        }

        public override float GetDistance()
        {
            float _distance = _speed * GetLength() / 60;
            return _distance;
        }

        public override float GetSpeed()
        {
            return _speed;
        }

        public override float GetPace()
        {
            float pace = 60 / _speed;
            return pace;
        }

        public override string GetActivityType()
        {
            return "Cycling";
        }
    }
}