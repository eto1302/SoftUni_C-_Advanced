using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n-1; i++)
            {
                long temp = stack.Pop();
                long r = stack.Peek()+temp;
                stack.Push(temp);
                stack.Push(r);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
