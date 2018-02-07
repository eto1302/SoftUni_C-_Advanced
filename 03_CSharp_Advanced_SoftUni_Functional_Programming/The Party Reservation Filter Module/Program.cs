using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();
            List<string> filters = new List<string>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(';');
                if (commands[0]=="Print")
                {
                    break;
                }
                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + ";" +commands[2]);

                }
                if (commands[0] == "Remove filter")
                {
                    filters.Remove(commands[1] + ";" + commands[2]);
                }
                
            }
            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(';');
                if (tokens[0] == "Starts with")
                {
                    
                    var temp = names.Where(x => x.Substring(0, tokens[1].Length) != tokens[1]).ToList();
                    names = temp;
                }
                if (tokens[0] == "Ends with")
                {
                    var temp = names.Where(x => x.Substring(x.Length-tokens[1].Length,tokens[1].Length) != tokens[1]).ToList();
                    names = temp;
                }
                if (tokens[0] == "Length")
                {
                    var temp = names.Where(x => x.Length.ToString() != tokens[1]).ToList();
                    names = temp;
                }
                if (tokens[0] == "Contains")
                {
                    var temp = names.Where(x => !x.Contains(tokens[1])).ToList();
                    names = temp;
                }
            }
            Console.WriteLine(string.Join(" ",names));
        }
    }
}