using System;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Action<string> print =  message => Console.WriteLine(message);
            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
        }
    }
}