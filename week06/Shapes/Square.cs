using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        private double _side;

        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        public override double GetArea()
        {
            double area = _side * _side;
            return area;
        }
    }
}