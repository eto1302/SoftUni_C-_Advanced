using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData,x => x >= 5,studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentstToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentstToTake)
                {
                    break;
                }
                double averageScore = userName_Points.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double mark = percentageOfFullfilment * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    
                    counterForPrinted++;
                }
            }
        }

        

        private static double Average(List<int> scoresOnTasks)
        {
            int totalScore = 0;
            foreach (var score in scoresOnTasks)
            {
                totalScore += score;

            }
            double percentageOfAll = totalScore / (scoresOnTasks.Count * 100.0);
            double mark = percentageOfAll * 4 + 2;
            
            return mark;
        }
    }
}
