using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MAximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            var stack = new Stack<int>();
            var maxes = new Stack<int>();
            int maxn = 0;
            int temp = 0;
            int[] param = new int[2];
            for (int i = 0; i < n; ++i)
            {
                param = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                if (param[0] == 1)
                {
                    stack.Push(param[1]);
                    if (maxn < param[1])
                    {
                        maxn = param[1];
                        maxes.Push(maxn);
                    }
                    
                }
                if (param[0] == 2)
                {
                    temp = stack.Peek();
                    stack.Pop();
                    if (temp == maxes.Peek())
                    {
                        
                        maxes.Pop();
                        if (maxes.Count != 0) maxn = maxes.Peek();
                        else maxn = 0;
                    }

                }
                if (param[0] == 3)
                {
                    Console.WriteLine(maxes.Peek());
                }

            }
        }
    }
}
