using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subfolders = new Queue<string>();
            subfolders.Enqueue(SessionData.currentPath);
            while (subfolders.Count != 0)
            {
                string currentPath = subfolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                if (depth - identation < 0)
                {
                    break;

                }
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}",
                                                                 new string('-', identation),
                                                                 currentPath));
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subfolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }

            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\" + name;
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }

        }

        public static void ChangeCurrrentDirectoryRelative(string relativePath)
        {

            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrrentDirectoryAbsolute(currentPath);
            }


        }

        public static void ChangeCurrrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
