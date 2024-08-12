using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationProject_1
{
    public class MathOperations
    {
        /// <summary>
        /// Subtract two negative numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> Prints the result of two negative numbers</returns>
        public static int Subtract(int a, int b)
        {
            return a - b;
        }




        /// <summary>
        /// calculate the square/second power of the number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>prints the square/second power of the number</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Square(int number)
        {
            if (number > 100)
                throw new ArgumentException("The number cannot be greater than 100");
            return number * number;
        }





        /// <summary>
        /// calculate the integer of squareroot
        /// </summary>
        /// <param name="number"></param>
        /// <returns>prints the squareroot of the integer number</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double SquareRoot(int number)
        {
            if (number < 0)
                throw new ArgumentException("The square root cannot be of a negative number");
            return Math.Sqrt(number);
        }




        /// <summary>
        ///  Finding the smallest number in a list of type double 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>prints the smallest number in a list of type double</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double FindSmallestNumber(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty.");
            }

            double smallestNumber = numbers[0];
            foreach (double number in numbers)
            {
                if (number < smallestNumber)
                {
                    smallestNumber = number;
                }
            }

            return smallestNumber;
        }





        /// <summary>
        /// finding the largest number in a list of type int
        /// </summary>
        /// <param name="numbers">List<int> numbers</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception> <summary>
        /// throw an argument exception if the list empty or null.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>prints the largest number in a list of type int</returns>
        public static int FindLargestNumber(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty.");
            }

            int largestNumber = numbers[0];
            foreach (int number in numbers)
            {
                if (number > largestNumber)
                {
                    largestNumber = number;
                }
            }
            return largestNumber;
        }





        /// <summary>
        /// calculates the average of the numbers in a list of type float
        /// </summary>
        /// <param name="numbers">List<float> numbers</param>
        /// <returns>prints the average of the numbers in a list of type float</returns>
        public static float FindAverageNumber(List<float> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("List is empty or null");
            }

            float averageNumber = 0;
            foreach (float number in numbers)
            {
                averageNumber += number;
            }
            return averageNumber / numbers.Count;

        }
    }
}
