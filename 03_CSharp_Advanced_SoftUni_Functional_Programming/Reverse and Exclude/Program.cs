using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> divisible = temp => temp % n == 0;
            for (int i = array.Length-1; i >= 0  ;i--)
            {
                if (!divisible(array[i]))
                {
                    Console.Write($"{array[i]} ");
                }
                
            }
        }
    }
}