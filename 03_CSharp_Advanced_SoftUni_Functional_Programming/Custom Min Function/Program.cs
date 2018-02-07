using System;
using System.Dynamic;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> min = ar => ar.Min();
            
            Console.WriteLine(min(array));
        }
    }
}