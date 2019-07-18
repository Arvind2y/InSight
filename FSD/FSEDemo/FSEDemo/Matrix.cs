using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSEDemo
{
    public class Matrix
    {
        /// <summary>
        /// Display the Matrix of 3 X 3
        /// </summary>
        public static void DisplayMatrix()
        {
            int i, j;
            int[,] matrix = new int[3, 3];

            Console.Write("\n\nRead a 2D array of size 3x3 and print the matrix :\n");
            Console.Write("------------------------------------------------------\n");


            /* Stored values into the array*/
            Console.Write("Input elements in the matrix :\n");
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    Console.Write("Element - [{0},{1}] : ", i, j);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Display matrix output
            PrintMatrix(matrix);
            Console.Write(Environment.NewLine);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("Values of array elements:");
            for (int outer = matrix.GetLowerBound(0); outer <= matrix.GetUpperBound(0); outer++)
            {
                Console.Write($"{'\u007b'}");
                for (int inner = matrix.GetLowerBound(1); inner <= matrix.GetUpperBound(1); inner++)
                {
                    Console.Write($"{matrix.GetValue(outer, inner)}\t");
                }
                Console.Write($"\b\b\b\b\b\b{'\u007d'}\n");
            }
        }

        /// <summary>
        ///  Iterate the 2-dimensional array and display its values.
        /// </summary>
        /// <param name="matrix"></param>
        private static void PrintMatrix1(int[,] matrix)
        {
            Console.WriteLine("Values of array elements:");
            for (int outer = matrix.GetLowerBound(0); outer <= matrix.GetUpperBound(0); outer++)
                for (int inner = matrix.GetLowerBound(1); inner <= matrix.GetUpperBound(1); inner++)
                    Console.WriteLine($"{'\u007b'}{outer}, {inner}{'\u007d'} = {matrix.GetValue(outer, inner)}");
        }
    }
}
