using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            int[] param = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] elements = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            for(int i = 0;i<param[0];++i) queue.Enqueue(elements[i]);
            for (int i = 0; i < param[1]; ++i) queue.Dequeue();
            if(queue.Contains(param[2]) == true) Console.WriteLine("true");
            else if(queue.Count!=0) Console.WriteLine(queue.Min());
            else Console.WriteLine(0);
        }
    }
}
