using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();
            long n = long.Parse(Console.ReadLine());
            bool flag = false;
            for(long i = 0;i<n;++i) queue.Enqueue(Console.ReadLine());

            
            for (long i = 0; i < n; ++i)
            {
                long fuel = 0;

                foreach (var ind in queue)
                {
                    fuel = fuel + ind.Trim().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                               .Select(long.Parse).ToArray()[0];
                    
                    fuel = fuel - ind.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(long.Parse).ToArray()[1];
                   
                    if (fuel < 0)
                    {
                        flag = false;
                        break;

                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    Console.WriteLine(i);
                    break;
                }
                string temp = queue.Dequeue();
                queue.Enqueue(temp);
            }
        }
    }
}
