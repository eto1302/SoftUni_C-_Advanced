using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            switch (command)
            {
                case "quit":
                    Environment.Exit(0);
                    break;
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "decorder":
                    TryDecoder(input, data);
                    break;
                case "download":
                    TryDownload(input, data);
                    break;
                case "downloadAsynch":
                    TryDownloadAsynch(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                default:
                    displayInvalidCommandMessage(input);
                    break;
            }

        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName,
            string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter,null);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName,filter,studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();
                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string orderCommand = data[3].ToLower();
                string orderQuantity = data[4].ToLower();
                TryParseParametersForOrderAndTake(orderCommand, orderQuantity, courseName, filter);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }
        private static void TryParseParametersForOrderAndTake(string orderCommand, string orderQuantity, string courseName,
            string filter)
        {
            if (orderCommand == "take")
            {
                if (orderQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, filter, null);
                }
                else
                {
                    int studentsToOrder;
                    bool hasParsed = int.TryParse(orderQuantity, out studentsToOrder);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, filter, studentsToOrder);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length ==  2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if(data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryDownloadAsynch(string input, string[] data)
        {
            throw new NotImplementedException();
        }

        private static void TryDownload(string input, string[] data)
        {
            throw new NotImplementedException();
        }

        private static void TryDecoder(string input, string[] data)
        {
            throw new NotImplementedException();
        }

        
    

        private static void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "open a file - open:path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                IOManager.ChangeCurrrentDirectoryAbsolute(data[1]);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                IOManager.ChangeCurrrentDirectoryRelative(data[1]);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void displayInvalidCommandMessage(string input)
        {

            OutputWriter.DisplayException($"The command '{input}' is invalid");

        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstFilePath = data[1];
                string secondFilePath = data[2];
                Tester.CompareContent(firstFilePath, secondFilePath);
            }
            else displayInvalidCommandMessage(input);
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 2)
            {
                int depth = int.Parse(data[1]);
                IOManager.TraverseDirectory(depth);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                displayInvalidCommandMessage(input);
            }
        }
    }
}
