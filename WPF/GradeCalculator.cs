using System;

namespace WPF
{
    public class GradeCalculator
    {
        public const int MAX_POINTS_TASK1 = 10;
        public const int MAX_POINTS_TASK2 = 50;
        public const int MAX_POINTS_TASK3 = 30;
        public const int MAX_POINTS_TASK4 = 10;

        public class CalculationResult
        {
            public bool IsValid { get; set; }
            public int TotalPoints { get; set; }
            public string Grade { get; set; }
            public string ErrorMessage { get; set; }
        }

        public CalculationResult Calculate(int task1, int task2, int task3, int task4)
        {
            var result = new CalculationResult();

            if (task1 > MAX_POINTS_TASK1 || task2 > MAX_POINTS_TASK2 || 
                task3 > MAX_POINTS_TASK3 || task4 > MAX_POINTS_TASK4 || 
                task1 < 0 || task2 < 0 || task3 < 0 || task4 < 0)
            {
                result.IsValid = false;
                result.ErrorMessage = $"Введены некорректные значения";
                return result;
            }

            result.IsValid = true;
            result.TotalPoints = task1 + task2 + task3 + task4;
            result.Grade = CalculateGrade(result.TotalPoints);
            
            return result;
        }

        private string CalculateGrade(int totalPoints)
        {
            if (totalPoints >= 70) return "5";
            if (totalPoints >= 40) return "4";
            if (totalPoints >= 20) return "3";
            return "2";
        }
    }
} 