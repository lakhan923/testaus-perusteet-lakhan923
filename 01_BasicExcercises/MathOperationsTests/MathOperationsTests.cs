using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathOperationProject_1;
using System;
using System.Collections.Generic;

namespace MathOperationsTest
{
    [TestClass]
    public class MathOperationsTest
    {
        // Tests for Subtract method
        [TestMethod]
        [DataRow(10, -5, 15)]  // Positive - Negative = Positive
        [DataRow(-10, -5, -5)] // Negative - Negative = Negative
        [DataRow(-10, 5, -15)] // Negative - Positive = Negative
        [DataRow(0, -5, 5)]    // Zero - Negative = Positive
        public void SubtractNumbers(int a, int b, int expectedNumber)
        {
            // Act
            int result = MathOperations.Subtract(a, b);

            // Assert
            Assert.AreEqual(expectedNumber, result);
        }


        // Tests for Square method
        [TestMethod]
        [DataRow(0, 0)] // Minimum allowed value
        [DataRow(5, 25)] // random valid input
        [DataRow(10, 100)] // random valid input
        [DataRow(100, 10000)] // Maximum allowed value
        public void CalculateSquare(int input, int expectedNumber)
        {
            // Act
            int result = MathOperations.Square(input);

            // Assert
            Assert.AreEqual(expectedNumber, result);
        }

        // Tests for SquareRoot method
        [TestMethod]
        [DataRow (4, 2)] //square root of 4
        [DataRow(9, 3)] //square root of 9
        [DataRow(16, 4)] //square root of 16
        [DataRow(25, 5)] //square root of 25
        public void CalculateSquareRoot(int input,double expectedNumber)
        {
            // Act

            double result = MathOperations.SquareRoot(input);

            // Assert
            Assert.AreEqual(expectedNumber, result);
        }


        // Tests for FindSmallestNumber method
        [TestMethod]
        [DataRow (new double[] { 12, 20, 3, 18, 66 }, 3)] //smallest is 3
        [DataRow(new double[] { 112, 60, 45, 50, 66 }, 45)]  // smallest is 45
        [DataRow(new double[] { 12, 20, 8, 18, 66 }, 8)]  // smallest is 8
        public void FindSmallestNumber(double[] numbers, double expectedResult)
        {
            // Act

            double result = MathOperations.FindSmallestNumber(new List<double>(numbers));

            // Assert
            Assert.AreEqual(expectedResult,result);

        }


        // Tests for FindLargestNumber method
        [TestMethod]
        [DataRow(new int[] { 35, 12, 50, 28, 89 }, 89)] // Largest is 89
        [DataRow(new int[] { 112, 60, 45, 50, 66 }, 112)]  
        [DataRow(new int[] { 12, 20, 8, 18, 66 }, 66)]  
        public void FindLargetNumber(int[] numbers, int expectedResult)
        {
            // Act

            double result = MathOperations.FindLargestNumber(new List<int>(numbers));

            // Assert
            Assert.AreEqual(expectedResult, result);

        }


        // Tests for FindAverageNumber method
        [TestMethod]
        [DataRow(new float[] { 4f, 14f, 20f, 6f, 8f }, 10.4f)] // Average is 10.4
        [DataRow(new float[] { 2f, 6f, 10f, 13f, 20f }, 10.2f)]  // Average is 10.2
        [DataRow(new float[] { 30f, 26f, 50f, 28f, 15f }, 29.8f)]  // Average is 29.8
        public void FindAverageNumber(float[] numbers, float expectedResult)
        {
            // Act
            float result = MathOperations.FindAverageNumber(new List<float>(numbers));

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

    }
}