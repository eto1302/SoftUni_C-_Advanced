using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Streams_and_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("../../../../Streams and Files/resources/text.txt");
            StreamReader words = new StreamReader("words.txt");
            StreamWriter writer = new StreamWriter("result.txt");
            using (input)
            {
                using (writer)
                {


                    int index = 0;

                    string[] w = words.ReadToEnd()
                        .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string s1 = Regex.Replace(input.ReadToEnd(), "[^A-Za-z0-9]", " ");
                    string[] s = s1.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    int[] array = new int[w.Length];
                    for (int i = 0; i < w.Length; i++)
                    {
                        dictionary.Add(w[i], 0);
                    }
                    for (int i = 0; i < s.Length; i++)
                    {

                        for (int j = 0; j < w.Length; j++)
                        {
                            if (s[i].ToLower() == w[j].ToLower())
                            {
                                dictionary[w[j]]++;
                            }
                            else Console.WriteLine(s[i].ToLower() + " " + w[j].ToLower() + "      2");
                        }

                    }
                    var ordered = dictionary.OrderByDescending(x => x.Value);
                    foreach (var VARIABLE in ordered)
                    {
                        Console.WriteLine(VARIABLE.Key + "-" + VARIABLE.Value);
                        writer.WriteLine(VARIABLE.Key + "-" + VARIABLE.Value);

                    }
                }
            }
        }
    }
}
