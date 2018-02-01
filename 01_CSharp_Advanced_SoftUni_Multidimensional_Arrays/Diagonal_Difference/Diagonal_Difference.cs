using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    class Diagonal_Difference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sum = 0;
            long sum1 = 0;
            for (int i = 0; i < n; i++)
            {
                
                    string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                sum = sum + Convert.ToInt32(input[i]);
                sum1 = sum1 + Convert.ToInt32(input[n - 1 - i]);

            }
            Console.WriteLine(Math.Abs(sum-sum1));
        }
    }
}
