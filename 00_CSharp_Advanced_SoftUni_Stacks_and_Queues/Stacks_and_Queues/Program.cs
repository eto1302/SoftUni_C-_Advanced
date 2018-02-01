using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var input = Console.ReadLine();
            try
            {



                int[] array = input.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (var i in array)
                {
                  stack.Push(i);  
                }
                if(stack.Count == 0) Console.WriteLine(0);
                while (stack.Count != 0)
                {
                    Console.Write(stack.Peek() +" ");
                    
                    stack.Pop();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(0);
                
            }
        }
    }
}
