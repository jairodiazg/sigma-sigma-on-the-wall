using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.Write("Enter the third number: ");
        double num3 = double.Parse(Console.ReadLine());

        double sum = num1 + num2 + num3;

        Console.WriteLine($"The sum of {num1}, {num2}, and {num3} is {sum}.");
    }
}
