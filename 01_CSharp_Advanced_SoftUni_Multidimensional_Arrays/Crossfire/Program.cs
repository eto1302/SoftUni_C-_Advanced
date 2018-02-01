using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            List<List<int>> array = new List<List<int>>();           
            int br = 1;
            int a,b,r;
            for (int i = 0; i < n; i++)
            {
                array.Add(new List<int>());
                for (int j = 0; j < m; j++)
                    array[i].Add(br++);

            }
            string s = " ";
            while (s != "Nuke it from orbit")
            {
                s = Console.ReadLine();
                if (s == "Nuke it from orbit") break;
                input = s.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                a = int.Parse(input[0]);
                b = int.Parse(input[1]);
                r = int.Parse(input[2]);
                bool flag = false;
                
                if (a >= 0 && a < array.Count)
                {
                    for (int i = Math.Max(0, b - r); i <= Math.Min(b + r, array[a].Count - 1); i++)
                    {
                        array[a][i] = 0;
                        flag = true;
                    }
                }
                
                if (b >= 0)
                {
                    for (int i = Math.Max(0, a - r); i <= Math.Min(a + r, array.Count - 1); i++)
                    {
                        if (b < array[i].Count)
                        {
                            array[i][b] = 0;
                            flag = true;
                        }
                    }
                }
                
                if (flag)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        if (array[i].Contains(0))
                        {
                            List<int> elements = new List<int>();
                            for (int j = 0; j < array[i].Count; j++)
                                if (array[i][j] != 0)
                                    elements.Add(array[i][j]);
                            if (elements.Count > 0)
                                array[i] = elements;
                            else
                            {
                                array.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }

                
            }
            for (int i = 0; i < array.Count; i++)
                Console.WriteLine(string.Join(" ", array[i]));
        }
    }
}
