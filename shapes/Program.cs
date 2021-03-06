using System;

namespace shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle();
            Console.WriteLine($"Current Position - X:{triangle.yPosition} Y:{triangle.yPosition}");
            triangle.Spin(Triangle.Direction.Horizonal, 200);
            Console.WriteLine($"Current Position - X:{triangle.xPosition} Y:{triangle.yPosition}");
        }
    }
}