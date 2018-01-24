using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            int[] param = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] elements = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < param[0]; ++i) stack.Push(elements[i]);
            for (int i = 0; i < param[1]; ++i) stack.Pop();
            if(stack.Contains(param[2]) == true) Console.WriteLine("true");
            else  if(stack.Count != 0)Console.WriteLine(stack.Min());
            else Console.WriteLine(0);

        }
    }
}
