using System;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Action<string> sir = message => Console.WriteLine("Sir " + message);
            for (int i = 0; i < input.Length; i++)
            {
                sir(input[i]);
            }
        }
    }
}