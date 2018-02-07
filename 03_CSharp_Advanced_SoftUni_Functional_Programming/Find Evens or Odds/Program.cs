using System;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = input[0];
            int b = input[1];
            string s = Console.ReadLine();
            Predicate<int> even = temp => temp % 2 == 0;
            for (int i = a; i <= b; i++)
            {
                if (even(i)&&s=="even")
                {
                    Console.Write($"{i} ");
                }
                if ((!even(i)) && s == "odd")
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}