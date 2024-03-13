using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapeList = new();
        Circle circle1 = new Circle("Red",4);
        Square square1 = new Square("Blue",5);
        Rectangle rectangle1 = new Rectangle("Green",6,7);

        shapeList.Add(circle1);
        shapeList.Add(square1);
        shapeList.Add(rectangle1);

        foreach (Shape shape in shapeList){
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}