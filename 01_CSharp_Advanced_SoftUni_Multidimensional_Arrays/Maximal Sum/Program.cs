using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            long sum = 0,temp = 0;
            int[,] array = new int[a, b];
            int[,] result = new int[3, 3];
            for (int i = 0; i < a; i++)
            {
                input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = Convert.ToInt32(input[j]);
                }
            }
            for (int i = 0; i < a - 2; i++)
            {

                for (int j = 0; j < b - 2; j++)
                {
                    temp = array[i, j] + array[i + 1, j] + array[i + 2, j] + array[i, j + 1] + array[i + 1, j + 1] +
                           array[i + 2, j + 1] + array[i, j + 2] + array[i + 1, j + 2] + array[i + 2, j + 2];
                    if (temp > sum)
                    {
                        sum = temp;
                        result[0, 0] = array[i, j];
                        result[0, 1] = array[i, j + 1];
                        result[0, 2] = array[i, j + 2];
                        result[1, 0] = array[i + 1, j ];
                        result[1, 1] = array[i + 1, j + 1];
                        result[1, 2] = array[i + 1, j + 2];
                        result[2, 0] = array[i + 2, j];
                        result[2, 1] = array[i + 2, j + 1];
                        result[2, 2] = array[i + 2, j + 2];
                    }
                    temp = 0;
                }
            }
            Console.WriteLine("Sum = "+sum);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i,j] + " ");
                }
                Console.WriteLine();
            }



        }
    }
}
