using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace наследование_тренажер_2_часть_
{
public interface ITetragon
{
    float SideA { get; }
    float SideB { get; }
    float Angle { get; }

    float CountPerimeter(float a, float b);
    float CountArea(float a, float b, float angle);
}


public class Quadrilateral : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; }

    public Quadrilateral(float sideA, float sideB, float angle)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }

    public float CountPerimeter(float a, float b)
    {
        return a + b;
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b * (float)Math.Sin(angle * Math.PI / 180); //переводим радианы в грудусы, чтобы не выдало фигню страшную
        }
}


public class ConvexQuadrilateral : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; }

    public ConvexQuadrilateral(float sideA, float sideB, float angle)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }

    public float CountPerimeter(float a, float b)
    {
        return a + b;
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b * (float)Math.Sin(angle * Math.PI / 180);
    }
}


public class Parallelogram : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; }

    public Parallelogram(float sideA, float sideB, float angle)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }

    public float CountPerimeter(float a, float b)
    {
        return 2 * (a + b);
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b * (float)Math.Sin(angle * Math.PI / 180);
    }
}


public class Rhombus : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; }

    public Rhombus(float sideA, float sideB, float angle)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }

    public float CountPerimeter(float a, float b)
    {
        return 4 * a;
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b * (float)Math.Sin(angle * Math.PI / 180);
    }
}


public class Rectangle : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; } = 90f;

    public Rectangle(float sideA, float sideB)
    {
        SideA = sideA;
        SideB = sideB;
    }

    public float CountPerimeter(float a, float b)
    {
        return 2 * (a + b);
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b;
    }
}


public class Square : ITetragon
{
    public float SideA { get; private set; }
    public float SideB { get; private set; }
    public float Angle { get; private set; } = 90f;

    public Square(float side)
    {
        SideA = side;
        SideB = side;
    }

    public float CountPerimeter(float a, float b)
    {
        return 4 * a;
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * a;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        ITetragon quadrilateral = new Quadrilateral(4, 5, 30);
        ITetragon convexQuadrilateral = new ConvexQuadrilateral(5, 6, 45);
        ITetragon parallelogram = new Parallelogram(7, 8, 60);
        ITetragon rhombus = new Rhombus(9, 10, 75);
        ITetragon rectangle = new Rectangle(11, 12);
        ITetragon square = new Square(13);

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
    }
}
}
