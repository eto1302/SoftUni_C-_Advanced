using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {

            Slice("../../../../Streams and Files/resources/sliceMe.mp4", "", 5);

            Compress("../../../../Streams and Files/resources/sliceMe.mp4", "", 5);
            var files = new List<string>
            {
                "../../Part -0.mp4",
                "../../Part -1.mp4",
                "../../Part -2.mp4",
                "../../Part -3.mp4",
                "../../Part -4.mp4",
            };
            var zippedfiles = new List<string>
            {
                "../../Part -0.mp4.gz",
                "../../Part -1.mp4.gz",
                "../../Part -2.mp4.gz",
                "../../Part -3.mp4.gz",
                "../../Part -4.mp4.gz",
            };
            Assemble(files, "");
            Decompress(zippedfiles, "");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));
                long pieceSize = reader.Length / parts;
                for (int i = 0; i < parts; i++)
                {
                    long current = 0;
                    destinationDirectory = destinationDirectory == string.Empty ? "../../" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part -{i}{extension}";
                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {

                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            current = current + buffer.Length;

                            if (current >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Compress(string sourceFile,string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));
                long pieceSize = reader.Length / parts;
                for (int i = 0; i < parts; i++)
                {
                    long current = 0;
                    destinationDirectory = destinationDirectory == string.Empty ? "../../" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part -{i}{extension}.gz";
                    
                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {

                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            current = current + buffer.Length;

                            if (current >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void Decompress(List<string> files, string destinationDirectory)
        {

            string extension = files[0].Substring(files[0].LastIndexOf('.'));
            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "../../";
            }
            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }
            string assembledFile = $"{destinationDirectory}Assembled{extension}";
            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var source = new FileStream(file, FileMode.Open))
                    {
                        using (var compressed = new GZipStream(source, CompressionMode.Decompress, false))
                        {
                            // Create a byte array of the content of the current file
                            Byte[] bytePart = new byte[4096];
                            while (true)
                            {
                                int readBytes = compressed.Read(bytePart, 0, bytePart.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                // Write the bytes to the reconstructed file
                                writer.Write(bytePart, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }
        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.'));
            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "../../";
            }
            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }
            string assembledFile = $"{destinationDirectory}Assembled{extension}";
            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
