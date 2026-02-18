using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private float _length;

        public Activity(float length)
        {
            _date = DateTime.Now;
            _length = length;
        }

        public abstract float GetDistance();

        public abstract float GetSpeed();

        public abstract float GetPace();

        public abstract string GetActivityType();

        public virtual string GetSummary(string activityName)
        {
            string summary = $"{_date:dd MMM yyyy} {GetActivityType()} ({_length} min): Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace {GetPace():F2} min per km";
            return summary;
        }

        public float GetLength()
        {
            return _length;
        }
    }
}