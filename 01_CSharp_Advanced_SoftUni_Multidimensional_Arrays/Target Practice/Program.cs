using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            long a = long.Parse(input[0]);
            long b = long.Parse(input[1]);
            string word = Console.ReadLine();
            input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            long a1 = long.Parse(input[0]);
            long b1 = long.Parse(input[1]);
            long r = long.Parse(input[2]);
            char[,] array = new char[a,b];
            
            int br = 0;
            for (long i = a-1; i>=0; --i)
            {
                if ((a-1-i)%2==0)
                {
                    for (long j = b-1; j>=0; j--)
                    {
                       
                        array[i, j] = word[br];
                        br++;
                        if (br == word.Length) br = 0;
                        
                    }
                }
               
                if ((a - 1 - i) % 2 != 0)
                {
                    for (long j = 0; j<b; j++)
                    {
                       
                        array[i, j] = word[br];
                        br++;
                        if (br == word.Length) br = 0;
                        
                    }
                }
                
            }
            array[a1, b1] = ' ';

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {

                    if (Math.Sqrt((i - a1) * (i - a1) + (j - b1) * (j - b1)) <= r)
                        array[i, j] = ' ';
                }
            }

            array[a1, b1] = ' ';
            bool flag = true;
            for (long i = 0; i < a*b; i++)
            {
                for (long j = 0; j < a-1; j++)
                {
                    for (long k = 0; k < b; k++)
                    {
                        if (array[j + 1, k] == ' ')
                        {
                            flag = false;
                            char temp = array[j, k];
                            array[j, k] = array[j + 1, k];
                            array[j + 1, k] = temp;
                        }
                    }
                }
                if (flag) break;
                flag = false;
            }
            
            for (long i = 0; i < a; i++)
            {
                for (long j = 0; j < b; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
       
    }
}
