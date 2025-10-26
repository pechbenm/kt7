using System;
using static System.Console;

class Calculator
{
    public static double Add(double x, double y)
    { return x + y; }

    public static double Subtract(double x, double y)
    { return x - y; }

    public static double Multiply(double x, double y)
    { return x * y; }

    public static double Divide(double x, double y)
    { return x / y; }
}

class Program
{
    public static void CalcUse(double x, double y, Func<double, double, double> Eval)
    {
        double result = Eval(x, y);
        WriteLine($"Результат: {result}");
    }

    static void Main(string[] args)
    {
        double a = 10;
        double b = 5;

        CalcUse(a, b, Calculator.Add);
        CalcUse(a, b, Calculator.Subtract);
        CalcUse(a, b, Calculator.Multiply);
        CalcUse(a, b, Calculator.Divide);

        ReadKey();
    }
}
