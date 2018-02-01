using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posionous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[] input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            
            var array = new int[n];
            var stack = new Stack<int>();
            stack.Push(0);
            for (int i = 0; i < input.Length; ++i)
            {
                int maxn = 0;
                while (stack.Count > 0 && input[stack.Peek()] >= input[i])
                {
                    maxn = Math.Max(maxn, array[stack.Pop()]);
                }
                if (stack.Count!=0)
                {
                    array[i] = maxn + 1;
                }
                stack.Push(i);
            }
            Console.WriteLine(array.Max());
        }
    }
}
