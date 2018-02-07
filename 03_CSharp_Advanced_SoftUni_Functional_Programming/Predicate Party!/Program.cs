using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();
            List<string> temp = new List<string>();
            int k = 0;
            
            string input = Console.ReadLine();
            
            while (input!="Party!")
            {
                string[] tokens = input.Split(' ');
                if (tokens[0]=="Remove")
                {
                    if (tokens[1] == "StartsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            
                            if (names[i].Substring(0, tokens[2].Length) == tokens[2])
                            {
                                
                                temp.RemoveAt(k);
                                k--;
                            }
                            k++;

                        }
                    }
                    if (tokens[1] == "EndsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            
                            if (names[i].Substring(names[i].Length - tokens[2].Length, tokens[2].Length) == tokens[2])
                            {
                                temp.RemoveAt(k);
                                k--;

                            }
                            k++;
                        }
                    }
                    if (tokens[1] == "Length")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            
                            if (names[i].Length.ToString() == tokens[2])
                            {
                                temp.RemoveAt(k);
                                k--;
                            }
                            k++;
                        }
                    }
                }
                if (tokens[0]=="Double")
                {
                    if (tokens[1]=="StartsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            if (names[i].Substring(0,tokens[2].Length)==tokens[2])
                            {
                                
                                temp.Add(names[i]);
                            }
                            
                        }
                    }
                    if (tokens[1] == "EndsWith")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            if (names[i].Substring(names[i].Length-tokens[2].Length,tokens[2].Length) == tokens[2])
                            {
                                
                                temp.Add(names[i]);
                                
                            }

                        }
                    }
                    if (tokens[1] == "Length")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            temp.Add(names[i]);
                            if (names[i].Length.ToString() == tokens[2])
                            {
                                
                                temp.Add(names[i]);
                            }

                        }
                    }
                }
                names = new List<string>();
                names = temp;
                temp = new List<string>();
                k = 0;

                
                input = Console.ReadLine();
                if (input=="Party!")
                {
                    break;
                }
            }
            if (names.Count>0)
            {
                Console.WriteLine(string.Join(", ",names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }
    }
}