using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(array);
            array = array.Where(x => x != 1).ToArray();
            bool flag = true;
            Func<int, int, bool> divisible = (a, b) => a % b == 0;
            for (int i = n; i > 0; i--)
            {
                flag = true;
                for (int j = array.Length-1; j >=0; j--)
                {
                    
                    if (!divisible(i,array[j]))
                    {
                        flag = false;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    result.Add(i);
                }
                
            }
            Console.WriteLine(string.Join(" ",result.ToArray().Reverse()));
        }
    }
}