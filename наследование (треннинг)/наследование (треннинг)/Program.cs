using System.Drawing;
using System.Security.Principal;
using System;
using System.Reflection.Metadata;


Tetragon quadrilateral = new Quadrilateral(4, 5, 30);
Tetragon convexQuadrilateral = new ConvexQuadrilateral(5, 6, 45);
Tetragon parallelogram = new Parallelogram(7, 8, 60);
Tetragon rhombus = new Rhombus(9, 10, 75);
Tetragon rectangle = new Rectangle(11, 12);
Tetragon square = new Square(13);

Console.WriteLine("Quadrilateral:");
Console.WriteLine($"Perimeter: {quadrilateral.CountPerimeter(quadrilateral.SideA, quadrilateral.SideB)}");
Console.WriteLine($"Area: {quadrilateral.CountArea(quadrilateral.SideA, quadrilateral.SideB, quadrilateral.Angle)}");

Console.WriteLine("\nConvex Quadrilateral:");
Console.WriteLine($"Perimeter: {convexQuadrilateral.CountPerimeter(convexQuadrilateral.SideA, convexQuadrilateral.SideB)}");
Console.WriteLine($"Area: {convexQuadrilateral.CountArea(convexQuadrilateral.SideA, convexQuadrilateral.SideB, convexQuadrilateral.Angle)}");

Console.WriteLine("\nParallelogram:");
Console.WriteLine($"Perimeter: {parallelogram.CountPerimeter(parallelogram.SideA, parallelogram.SideB)}");
Console.WriteLine($"Area: {parallelogram.CountArea(parallelogram.SideA, parallelogram.SideB, parallelogram.Angle)}");

Console.WriteLine("\nRhombus:");
Console.WriteLine($"Perimeter: {rhombus.CountPerimeter(rhombus.SideA, rhombus.SideB)}");
Console.WriteLine($"Area: {rhombus.CountArea(rhombus.SideA, rhombus.SideB, rhombus.Angle)}");

Console.WriteLine("\nRectangle:");
Console.WriteLine($"Perimeter: {rectangle.CountPerimeter(rectangle.SideA, rectangle.SideB)}");
Console.WriteLine($"Area: {rectangle.CountArea(rectangle.SideA, rectangle.SideB, rectangle.Angle)}");

Console.WriteLine("\nSquare:");
Console.WriteLine($"Perimeter: {square.CountPerimeter(square.SideA, square.SideB)}");
Console.WriteLine($"Area: {square.CountArea(square.SideA, square.SideB, square.Angle)}");




public abstract class Tetragon
{
    public float SideA { get; protected set; }
    public float SideB { get; protected set; }
    public float Angle { get; protected set; }

    public Tetragon(float sideA, float sideB, float angle)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;

    }



    public virtual float CountPerimeter(float a, float b)
    {
        return a + b;
    }

    public virtual float CountArea(float a, float b, float angle)
    {
        return a * b * (float)Math.Sin(angle * Math.PI / 180); //переводим радианы в грудусы, чтобы не выдало фигню страшную
    }
}

public class Quadrilateral : Tetragon
{
    public Quadrilateral(float sideA, float sideB, float angle) : base(sideA, sideB, angle)
    {
    }

    public override float CountArea(float a, float b, float angle)
    {
        return base.CountArea(a, b, angle);
    }
}

public class ConvexQuadrilateral : Quadrilateral
{
    public ConvexQuadrilateral(float sideA, float sideB, float angle) : base(sideA, sideB, angle)
    {
    }
}

public class Parallelogram : ConvexQuadrilateral
{
    public Parallelogram(float sideA, float sideB, float angle) : base(sideA, sideB, angle)
    {
    }

    public override float CountPerimeter(float a, float b)
    {
        return 2 * (a + b);
    }

}


public class Rhombus : Parallelogram
{
    public Rhombus(float sideA, float sideB, float angle) : base(sideA, sideB, angle)
    {
    }

    public override float CountPerimeter(float a, float b)
    {
        return 4 * a;
    }

}


public class Rectangle : Parallelogram
{
    public Rectangle(float sideA, float sideB) : base(sideA, sideB, 90)
    {
    }

    public override float CountPerimeter(float a, float b)
    {
        return 2 * (a + b);
    }

    public override float CountArea(float a, float b, float angle)
    {
        return a * b;
    }
}


public class Square : Rectangle
{
    public Square(float side) : base(side, side)
    {
    }

    public override float CountPerimeter(float a, float b)
    {
        return 4 * a;
    }

    public override float CountArea(float a, float b, float angle)
    {
        return a * a;
    }
}


