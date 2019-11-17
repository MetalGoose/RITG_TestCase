using System;

namespace MatrixSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[,] testStringArray = new string[,]
            {
                { "А", "П", "К", "А", "Н" } ,
                { "Б", "З", "А", "Б", "В" } ,
                { "Г", "П", "Ы", "А", "У" } ,
                { "Х", "Ш", "И", "И", "Н" }
            };

            int[,] testIntArray = new[,]
            {
                { 1, 3, 5, 6, 1 },
                { 3, 6, 9, 2, 6 },
                { 7, 2, 3, 10, 29 },
                { 77, 0, -1, 9, 1 },
            };

            PrintMatrix(testStringArray);
            Console.WriteLine();
            PrintMatrix(testIntArray);
            Console.WriteLine();

            Sort2DArray(testIntArray);
            Sort2DArray(testStringArray);

            PrintMatrix(testStringArray);
            Console.WriteLine();
            PrintMatrix(testIntArray);

            Console.ReadKey();
        }

        /// <summary>
        /// Prints a two-dimensional array to the console
        /// </summary>
        /// <typeparam name="T">Type of two-dimensional array</typeparam>
        /// <param name="matrix">Two-dimensional array to be printed</param>
        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Sorts the columns of a two-dimensional array by the first column value.
        /// If the values ​​match, the values ​​of the next line are compared.
        /// The Selection sort algorithm is used for sorting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Sort2DArray<T>(T[,] arr) where T : IComparable
        {
            int min;
            T temp;

            int columnsCount = arr.GetLength(1);
            int rowsCount = arr.GetLength(0);
            int currentRow = 0;

            for (int i = 0; i < columnsCount - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < columnsCount; j++)
                {
                    if (currentRow == rowsCount) // => Columns have the same elements
                    {
                        currentRow = 0;
                        break;
                    }
                    if (arr[currentRow, j].CompareTo(arr[currentRow, min]) == 0) // Restart the loop iteration and compare the next line
                    {
                        currentRow++;
                        j--;
                        continue;
                    }

                    if (arr[currentRow, j].CompareTo(arr[currentRow, min]) == -1)
                    {
                        min = j;
                    }

                    currentRow = 0;
                }

                if (min != i) // Reorder the columns if a smaller element is found
                {
                    for (int row = 0; row < rowsCount; row++)
                    {
                        temp = arr[row, i];
                        arr[row, i] = arr[row, min];
                        arr[row, min] = temp;
                    }
                }
            }
        }
    }
}