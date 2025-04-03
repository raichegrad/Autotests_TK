using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPF_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGradeCalculation_Excellent()
        {
            int task1 = 10;
            int task2 = 45;
            int task3 = 25;
            int task4 = 10;
            string expected = "5 (отлично)";

            string actual = CalculateGrade(task1 + task2 + task3 + task4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Good()
        {
            int task1 = 5;
            int task2 = 25;
            int task3 = 15;
            int task4 = 5;
            string expected = "4 (хорошо)";

            string actual = CalculateGrade(task1 + task2 + task3 + task4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Satisfactory()
        {
            int task1 = 3;
            int task2 = 15;
            int task3 = 10;
            int task4 = 2;
            string expected = "3 (удовлетворительно)";

            string actual = CalculateGrade(task1 + task2 + task3 + task4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeCalculation_Unsatisfactory()
        {
            int task1 = 2;
            int task2 = 8;
            int task3 = 5;
            int task4 = 1;
            string expected = "2 (неудовлетворительно)";

            string actual = CalculateGrade(task1 + task2 + task3 + task4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGradeBoundaries_70Points()
        {
            Assert.AreEqual("5 (отлично)", CalculateGrade(70));
        }

        [TestMethod]
        public void TestGradeBoundaries_40Points()
        {
            Assert.AreEqual("4 (хорошо)", CalculateGrade(40));
        }

        [TestMethod]
        public void TestGradeBoundaries_20Points()
        {
            Assert.AreEqual("3 (удовлетворительно)", CalculateGrade(20));
        }

        [TestMethod]
        public void TestGradeBoundaries_0Points()
        {
            Assert.AreEqual("2 (неудовлетворительно)", CalculateGrade(0));
        }

        [TestMethod]
        public void TestInputValidation_ValidNumber()
        {
            Assert.IsTrue(IsValidScore("10", 10));
        }

        [TestMethod]
        public void TestInputValidation_InvalidNumber()
        {
            Assert.IsFalse(IsValidScore("abc", 10));
        }

        [TestMethod]
        public void TestInputValidation_NegativeNumber()
        {
            Assert.IsFalse(IsValidScore("-5", 10));
        }

        [TestMethod]
        public void TestInputValidation_OutOfRange()
        {
            Assert.IsFalse(IsValidScore("15", 10));
        }

        [TestMethod]
        public void TestInputValidation_EmptyString()
        {
            Assert.IsFalse(IsValidScore("", 10));
        }

        [TestMethod]
        public void TestMaxScoreValidation_Task1()
        {
            Assert.IsTrue(IsValidScore("10", 10));
            Assert.IsFalse(IsValidScore("11", 10));
        }

        [TestMethod]
        public void TestMaxScoreValidation_Task2()
        {
            Assert.IsTrue(IsValidScore("50", 50));
            Assert.IsFalse(IsValidScore("51", 50));
        }

        private string CalculateGrade(int totalScore)
        {
            if (totalScore >= 70) return "5 (отлично)";
            if (totalScore >= 40) return "4 (хорошо)";
            if (totalScore >= 20) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }

        private bool IsValidScore(string input, int maxScore)
        {
            if (!int.TryParse(input, out int score))
                return false;

            return score >= 0 && score <= maxScore;
        }
    }
}
