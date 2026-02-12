using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(string color, double raius) : base(color)
        {
            _radius = raius;
        }

        public override double GetArea()
        {
            double area = 3.1416 * (_radius * _radius);
            return area;
        }
    }
}