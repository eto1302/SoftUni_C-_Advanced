using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            var filesDictionary = new Dictionary<string,List<FileInfo>>();
            var directory = Directory.GetFiles(path);
            foreach (var file in directory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }
                filesDictionary[extension].Add(fileInfo);

            }
            filesDictionary = filesDictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FileName = desktop + "/report.txt";
            using (var writer = new StreamWriter(FileName))
            {
                foreach (var element in filesDictionary)
                {
                    string extension = element.Key;
                    writer.WriteLine(extension);
                    var fileInfos = element.Value.OrderByDescending(x =>x.Length);
                    foreach (var info in fileInfos)
                    {
                        double size = info.Length/1024;
                        writer.WriteLine($"--{info.Name} - {size}kb");
                    }
                }
            }
        }
    }
}
