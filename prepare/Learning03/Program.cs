using System;

public class Fraction
{
    private int top;
    private int bottom;

    // Constructors
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int top)
    {
        this.top = top;
        bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this.top = top;
        this.bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int top)
    {
        this.top = top;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            this.bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero.");
        }
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{top}/{bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}

class Program
{
    static void Main()
    {
        // Creating instances using different constructors
        Fraction fraction1 = new Fraction();         // 1/1
        Fraction fraction2 = new Fraction(6);        // 6/1
        Fraction fraction3 = new Fraction(6, 7);     // 6/7

        // Displaying fractions
        Console.WriteLine(fraction1.GetFractionString());  // 1/1
        Console.WriteLine(fraction2.GetFractionString());  // 6/1
        Console.WriteLine(fraction3.GetFractionString());  // 6/7

        // Changing values using setters
        fraction1.SetTop(3);
        fraction1.SetBottom(4);

        // Displaying the modified fraction
        Console.WriteLine(fraction1.GetFractionString());  // 3/4

        // Displaying decimal values
        Console.WriteLine(fraction1.GetDecimalValue());    // 0.75
        Console.WriteLine(fraction2.GetDecimalValue());    // 6.0
        Console.WriteLine(fraction3.GetDecimalValue());    // 0.8571428571428571
    }
}