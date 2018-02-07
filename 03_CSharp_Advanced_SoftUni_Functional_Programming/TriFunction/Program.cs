using System;
using System.Linq;
namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');
            Func<string, int, bool> check = (s, a) => s.Select(x => (int) x).ToArray().Sum() >= n;
            Func<string[], int, Func<string, int, bool>, string> solve = (array, n1, func) => array.FirstOrDefault(x => func(x, n1));
            Console.WriteLine(solve(names,n,check));
        }
    }
}