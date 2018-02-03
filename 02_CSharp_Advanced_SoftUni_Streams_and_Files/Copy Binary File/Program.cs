using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("../../../../Streams and Files/resources/copyMe.png", FileMode.Open);
            int buffer = 1024 * 1024;
            using (fs)
            {
                using (var destination = new FileStream("CreatedFile.png", FileMode.CreateNew))
                {
                    byte[] bytes = new byte[buffer];
                    while (true)
                    {
                        int readBytes = fs.Read(bytes, 0, buffer);
                        if (readBytes==0)
                        {
                            break;
                        }
                        destination.Write(bytes,0,buffer);

                    }
                }
            }
        }
    }
}
