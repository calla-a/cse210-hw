using System;
using Shapes;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square1 = new Square("red", 3);
        shapes.Add(square1);
        Rectangle rectangle1 = new Rectangle("red", 3, 5);
        shapes.Add(rectangle1);
        Circle circle1 = new Circle("red", 6);
        shapes.Add(circle1);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }
    }
}