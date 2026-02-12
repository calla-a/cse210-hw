using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(string color, double lenght, double width) : base(color)
        {
            _length = lenght;
            _width = width;
        }

        public override double GetArea()
        {
            double area = _length * _width;
            return area;
        }
    }
}