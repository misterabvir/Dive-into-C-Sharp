using System.Text;

namespace HW2.Extensions;

public static class MatrixExtensions
{
    public static int[,] GenerateMatrix(this (int rows, int cols) size)
    {
        return Enumerable
            .Range(1, size.rows * size.cols)
            .ToArray()
            .Shuffle()
            .Transpose(size.rows, size.cols);
    }


    public static string GetString(this int[,] matrix)
    {
        StringBuilder builder = new();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                builder.Append(' ').Append(matrix[row, col]);
            }
            builder.Append("\r\n");
        }
        return builder.ToString();
    }

    public static void Print(this int[,] matrix) => Console.WriteLine(matrix.GetString());

    public static int[] Transpose(this int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int length = cols * rows;
        int[] array = new int[length];
        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                array[index++] = matrix[row, col];
            }
        }
        return array;
    }

    public static int[,] Transpose(this int[] array, int rows, int cols, int[,]? matrix = null)
    {
        int length = array.Length;
        if (length != rows * cols)
        {
            throw new ArgumentException("Invalid arguments");
        }
        matrix ??= new int[rows, cols];
        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = array[index++];
            }
        }
        return matrix;
    }

    public static int[] Shuffle(this int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = new Random().Next(i, array.Length);
            (array[i], array[j]) = (array[j], array[i]);
        }
        return array;
    }

    public static int[] Sort(this int[] array){
        Array.Sort(array);
        return array;
    }

    public static int[,] Sort(this int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        return matrix.Transpose().Sort().Transpose(rows, cols, matrix);       
    }
}
