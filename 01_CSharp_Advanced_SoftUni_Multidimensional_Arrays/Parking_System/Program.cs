using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            Dictionary<int, HashSet<int>> array = new Dictionary<int, HashSet<int>>();

            while (true)
            {


                input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "stop") break;
                
                int a = 0;
                int b = int.Parse(input[0]);
                int x = int.Parse(input[1]);
                int y = int.Parse(input[2]);
                if (!check(array, x, y))
                {
                    a = y;
                }
                else
                {
                    for (int i = 1; i < m - 1; i++)
                    {
                        if (((y - i) > 0) &&
                            !check(array, x, (y - i)))
                        {
                            a = (y - i);
                            break;
                        }
                        else if (((y + i) < m) &&
                                 !check(array, x, (y + i)))
                        {
                            a = (y + i);
                            break;
                        }
                    }
                }

                if (a == 0)
                {
                    Console.WriteLine("Row " +x+ " full");
                }
                else
                {
                    array[x].Add(a);
                    int steps = Math.Abs(b - x) + 1 + a;
                    Console.WriteLine(steps);
                }

                
            }
        }

        private static bool check(Dictionary<int,HashSet<int>> array, int x, int y)
        {
            if (array.ContainsKey(x))
            {
                if (array[x].Contains(y))
                {
                    return true;
                }
            }
            else
            {
                array.Add(x, new HashSet<int>());
            }
            return false;
        }

        
    }

    }

