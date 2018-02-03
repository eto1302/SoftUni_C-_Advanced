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
           StreamReader input = new StreamReader("text.txt");
            using (input)
            {
                int index = 0;
                string line = input.ReadLine();
                while (line!=null)
                {
                    index++;
                    line = input.ReadLine();
                    if(index%2==1&&line!=null) Console.WriteLine(line);
                    
                    
                }
            }
        }
    }
}
