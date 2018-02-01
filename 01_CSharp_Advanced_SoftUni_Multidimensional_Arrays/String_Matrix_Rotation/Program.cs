using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input_rotations = Console.ReadLine();
            int rotations = int.Parse(input_rotations.Substring(7,input_rotations.Length-8));
            List<List<char>> list = new List<List<char>>();
            int maxcount = 0;
            int n, m;
            while (true)
            {
                char[] input = Console.ReadLine().ToArray();
                string s = new string(input);
                if (s == "END") break;
                if (maxcount < input.ToList().Count) maxcount = input.ToList().Count;
                list.Add(input.ToList());
                
                

            }
           
            n = list.Count;
            m = maxcount;
            var array = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                var temp = list[i].ToArray();
                for (int j = 0; j < m; j++)
                {
                    if (j < temp.Length) array[i, j] = temp[j];
                    else array[i, j] = ' ';
                }
            }
            rotations = rotations / 90;
            rotations = rotations % 4;
            if(rotations == 2)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = m - 1; j >= 0; j--)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            if (rotations == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            if (rotations == 1)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = n-1; j >=0; j--)
                    {
                        Console.Write(array[j,i]);
                    }
                    Console.WriteLine();
                }

            }
            if (rotations == 3)
            {
                for (int i = m-1; i >=0; i--)
                {
                    for (int j = 0; j <n; j++)
                    {
                        Console.Write(array[j, i]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
