using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int n = int.Parse(Console.ReadLine());
            int br = 1;
            int[,] array = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = br;
                    br++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (input[1])
                {
                    case "up":
                        {
                            for (int j = 0; j < Convert.ToInt32(input[2])%a; j++)
                            {

                                int temp = array[0, Convert.ToInt32(input[0])];
                                for (int l = 0; l < a - 1; l++)
                                {
                                    array[l, Convert.ToInt32(input[0])] = array[l + 1, Convert.ToInt32(input[0])];
                                }
                                array[a - 1, Convert.ToInt32(input[0])] = temp;

                            }
                            break;
                        }
                    case "down":
                        {
                            
                            for (int j = 0; j < Convert.ToInt32(input[2])%a; j++)
                            {

                                int temp = array[a - 1, Convert.ToInt32(input[0])];
                                for (int l = a - 1; l > 0; l--)
                                {
                                    array[l, Convert.ToInt32(input[0])] = array[l - 1, Convert.ToInt32(input[0])];
                                }
                                array[0, Convert.ToInt32(input[0])] = temp;

                            }
                            break;
                        }
                    case "right":
                        {
                            for (int j = 0; j < Convert.ToInt32(input[2])%b; j++)
                            {

                                int temp = array[Convert.ToInt32(input[0]), a - 1];
                                for (int l = a - 1; l > 0; l--)
                                {
                                    array[Convert.ToInt32(input[0]), l] = array[Convert.ToInt32(input[0]), l - 1];
                                }
                                array[Convert.ToInt32(input[0]), 0] = temp;

                            }
                            break;
                        }
                    case "left":
                        {
                            for (int j = 0; j < Convert.ToInt32(input[2])%b; j++)
                            {

                                int temp = array[Convert.ToInt32(input[0]), 0];
                                for (int l = 0; l < a - 1; l++)
                                {
                                    array[Convert.ToInt32(input[0]), l] = array[Convert.ToInt32(input[0]), l + 1];
                                }
                                array[Convert.ToInt32(input[0]), a - 1] = temp;

                            }
                            break;
                        }

                }

            }
            br = 1;

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (array[i, j] == br) Console.WriteLine("No swap required");
                    else
                    {
                        for (int k = 0; k < a; k++)
                        {
                            for (int l = 0; l < b; l++)
                            {

                                if (array[k, l] == br)
                                {
                                    Console.WriteLine("Swap (" + i + ", " + j + ") with (" + k + ", " + l + ")");
                                    array[k, l] = array[i, j];
                                    array[i, j] = br;
                                }
                            }
                        }
                    }
                    br++;
                }
            }

        }
    }
}