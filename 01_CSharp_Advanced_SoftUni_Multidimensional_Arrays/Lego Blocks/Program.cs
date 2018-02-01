using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var array = new int[n][];
            var array1 = new int[n][];
            int br = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                br = br + array[i].Length;
            }
            for (int i = 0; i < n; i++)
            {
                array1[i] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                br = br + array1[i].Length;
            }
            long sum = array[0].Length + array1[0].Length;
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                if (array[i].Length+array1[i].Length!=sum) flag = false;
                
            }
            
            if (flag)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ",array[i]));
                    Console.Write(", ");
                    Console.Write(string.Join(", ", array1[i].Reverse()));
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: " + br);
            }
        }
    }
}
