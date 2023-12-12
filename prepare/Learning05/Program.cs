using System;

public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Square : Shape
{
    public double SideLength { get; set; }

    public override double CalculateArea()
    {
        return Math.Pow(SideLength, 2);
    }
}
