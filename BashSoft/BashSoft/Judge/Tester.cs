using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {

            OutputWriter.WriteMessageOnNewLine("Reading files ...");
            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);
                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);
                int minOutputLines = actualOutputLines.Length;

                bool hasMismatch = false;
                if (actualOutputLines.Length != expectedOutputLines.Length)
                {
                    minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                    OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
                }
                string[] mismatches = new string[minOutputLines];
                for (int index = 0; index < minOutputLines; index++)
                {

                }
                mismatches =
                    GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, hasMismatch, minOutputLines);
                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }

            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
                return;
            }
            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, bool hasMismatch, int minOutputLines)
        {
            hasMismatch = false;
            string output = string.Empty;
            string[] mismatches = new string[expectedOutputLines.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];
                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format("Mismatch at line {0} -- expected: \"{1}\",actual: \"{2}\"",
                        index, expectedLine, actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }
                mismatches[index] = output;
            }
            return mismatches;
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}
