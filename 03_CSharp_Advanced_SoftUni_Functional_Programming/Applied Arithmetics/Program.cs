using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            string input = Console.ReadLine();
            Func<double, double> add = temp => temp+1;
            Func<double, double> multiply = temp => temp * 2;
            Func<double, double> subtract = temp => temp-1;
            while (input!="end")
            {
                if (input == "add")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = add(array[i]);
                    }
                }
                if (input == "subtract")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = subtract(array[i]);
                    }
                }
                if (input == "multiply")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = multiply(array[i]);
                    }
                }
                if (input == "print")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write($"{array[i]} ");
                    }
                    Console.WriteLine();
                }
                input = Console.ReadLine();
            }
            
        }
    }
}