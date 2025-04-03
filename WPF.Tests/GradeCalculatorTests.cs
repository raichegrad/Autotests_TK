using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WPF.Tests
{
    [TestClass]
    public class GradeCalculatorTests
    {
        private GradeCalculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new GradeCalculator();
        }

        // Позитивные тесты
        [TestMethod]
        public void Calculate_ValidInputs_Grade5()
        {
            // Arrange
            int task1 = 10, task2 = 50, task3 = 30, task4 = 10;

            // Act
            var result = _calculator.Calculate(task1, task2, task3, task4);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(100, result.TotalPoints);
            Assert.AreEqual("5", result.Grade);
        }

        [TestMethod]
        public void Calculate_ValidInputs_Grade4()
        {
            var result = _calculator.Calculate(5, 25, 15, 5);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(50, result.TotalPoints);
            Assert.AreEqual("4", result.Grade);
        }

        [TestMethod]
        public void Calculate_ValidInputs_Grade3()
        {
            var result = _calculator.Calculate(3, 15, 7, 3);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(28, result.TotalPoints);
            Assert.AreEqual("3", result.Grade);
        }

        [TestMethod]
        public void Calculate_ValidInputs_Grade2()
        {
            var result = _calculator.Calculate(2, 10, 5, 2);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(19, result.TotalPoints);
            Assert.AreEqual("2", result.Grade);
        }

        // Негативные тесты
        [TestMethod]
        public void Calculate_Task1ExceedsMaximum_ReturnsError()
        {
            var result = _calculator.Calculate(11, 50, 30, 10);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_Task2ExceedsMaximum_ReturnsError()
        {
            var result = _calculator.Calculate(10, 51, 30, 10);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_NegativeValues_ReturnsError()
        {
            var result = _calculator.Calculate(-1, 50, 30, 10);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_AllZeros_ReturnsGrade2()
        {
            var result = _calculator.Calculate(0, 0, 0, 0);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.TotalPoints);
            Assert.AreEqual("2", result.Grade);
        }
    }
} 