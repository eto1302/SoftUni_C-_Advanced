using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2x2_Squares_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            long br = 0;
            char[,] array = new char[a, b];
            for (int i = 0; i < a; i++)
            {
                input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = Convert.ToChar(input[j]);
                }
            }
            for (int i = 0; i < a-1; i++)
            {
                
                for (int j = 0; j < b-1; j++)
                {
                    if (array[i, j] == array[i, j + 1] && array[i + 1, j] == array[i + 1, j + 1] &&
                        array[i, j] == array[i + 1, j]) br++;
                }
            }
            Console.WriteLine(br);
        }
    }
}
