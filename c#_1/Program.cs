using System;

class Program
{
    static void Main(string[] args)
    {
        NumberProcessor processor = new NumberProcessor();
        processor.GetNumsCalcSum();
    }
}

class NumberProcessor
{
    private double[] numbers = new double[3];

    public void GetNumsCalcSum()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            numbers[i] = double.Parse(Console.ReadLine());
        }

        double sum = CalcSum();
        Console.WriteLine($"The sum of the numbers is {sum}");

        if (sum > 50)
        {
            Console.WriteLine("The sum is greater than 50");
        }
        else
        {
            Console.WriteLine("The sum is 50 or less");
        }
    }

    private double CalcSum()
    {
        double sum = 0;
        foreach (double num in numbers)
        {
            sum += num;
        }
        return sum;
    }
}
