using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Streams_and_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("../../../../Streams and Files/resources/text.txt");
            using (input)
            {
                int index = 0;
                string line = input.ReadLine();
                while (line != null)
                {
                    index++;
                    
                    Console.WriteLine("Line {0}: "+line,index);
                    line = input.ReadLine();

                }
            }
        }
    }
}
