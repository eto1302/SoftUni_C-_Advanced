using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fibonacci
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            long[] array = new long[51];
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Fibbonacci(n,array));
        }

        private static long Fibbonacci(long n,long[] array)
        {
            if (n == 2 || n == 1) return 1;
            if (array[n-1] != 0 && array[n - 2] != 0) return array[n - 1] + array[n - 2];
            else {array[n]=Fibbonacci(n-1, array) + Fibbonacci(n -2, array);
                return array[n ];
            }
        }
    }
}
