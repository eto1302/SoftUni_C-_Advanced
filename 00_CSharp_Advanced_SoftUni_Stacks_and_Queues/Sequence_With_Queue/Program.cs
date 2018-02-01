using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<long>();
            long n = long.Parse(Console.ReadLine());
            int ind = 1;
            queue.Enqueue(n);
            Console.Write(n + " ");
            for (int i = 1; i < 50; ++i)
            {
                if (ind == 1)
                {
                    queue.Enqueue(queue.Peek() + 1);
                    Console.Write((queue.Peek()+1) + " " );
                }
                if (ind == 2)
                {
                    queue.Enqueue(2*queue.Peek() + 1);
                    Console.Write((2*queue.Peek() + 1) + " " );
                }
                if (ind == 3)
                {
                    queue.Enqueue( queue.Peek() + 2);
                    Console.Write((queue.Peek() + 2) + " " );
                    queue.Dequeue();
                    ind = 0;
                   
                }
                ind++;
            }
        }
    }
}
