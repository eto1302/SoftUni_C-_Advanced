using System;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int, int, int> sort = (a, b) =>(a % 2 == 0 && b % 2 != 0) ? -1 :(a % 2 != 0 && b % 2 == 0) ? 1 :a.CompareTo(b);
                
                    
                        
            Array.Sort<int>(array, new Comparison<int>(sort));
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}