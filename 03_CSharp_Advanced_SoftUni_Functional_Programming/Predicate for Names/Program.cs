using System;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');
            Predicate<string> solve = s => s.Length <= n;
            for (int i = 0; i < names.Length; i++)
            {
                if (solve(names[i]))
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}