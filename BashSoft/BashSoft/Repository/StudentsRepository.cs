using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data ...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData(string fileName)
        {

            
            
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_[0-9]{4})\s+([A-Z][a-z]{0,3}[0-9]{2}_[0-9]{2,4})\s+([0-9]+)";
                Regex regex = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    
                    if ((!string.IsNullOrEmpty(allInputLines[line])) && (regex.IsMatch(allInputLines[line])))
                    {
                        
                        Match current = regex.Match(allInputLines[line]);
                        string courseName = current.Groups[1].Value;
                        string username = current.Groups[2].Value;
                        int studentScoreOnTask;
                        bool hasParsedScore = int.TryParse(current.Groups[3].Value, out studentScoreOnTask);
                        
                        if (hasParsedScore && studentScoreOnTask>=0 && studentScoreOnTask <=100)
                        {
                            
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                            }
                            if (!studentsByCourse[courseName].ContainsKey(username))
                            {
                                studentsByCourse[courseName].Add(username,new List<int>());
                            }
                            studentsByCourse[courseName][username].Add(studentScoreOnTask);
                            
                        }
                    }
                    
                }


                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }


        }

        private static bool isQueryforCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }

        private static bool isQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (isQueryforCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }


        public static void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (isQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }
        }

        

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (isQueryforCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarksEntry);
                }
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (isQueryforCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }
                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
        public static void FilterAndTake(string courseName, string GivenFilter, int? studentsToTake = null)
        {
            if (isQueryforCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }
                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], GivenFilter, studentsToTake.Value);
            }
        }
    }

}
