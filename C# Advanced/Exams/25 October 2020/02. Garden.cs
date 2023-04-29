using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = size[0];
        int cols = size[1];
        int[][] matrix = new int[rows][];
        for(int row = 0;row < matrix.Length;++row)
        {
            matrix[row] = Enumerable.Repeat(0,cols).ToArray();
        }
        var coords = new List<(int row, int col)>();
        string input = string.Empty;
        while((input = Console.ReadLine()) != "Bloom Bloom Plow")
        {
            var data = input.Split().Select(int.Parse).ToArray();
            int row = data[0];
            int col = data[1];
            if(row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
            {
                Console.WriteLine("Invalid coordinates.");
                continue;
            }
            matrix[row][col]++;
            for(int currentRow = row - 1;currentRow >= 0;--currentRow)
            {
                matrix[currentRow][col]++;
            }
            for(int currentRow = row + 1;currentRow < matrix.Length;++currentRow)
            {
                matrix[currentRow][col]++;
            }
            for(int currentCol = col - 1;currentCol >= 0;--currentCol)
            {
                matrix[row][currentCol]++;
            }
            for(int currentCol = col + 1;currentCol < matrix[row].Length;++currentCol)
            {
                matrix[row][currentCol]++;
            }
        }
        foreach(var row in matrix)
        {
            Console.WriteLine(string.Join(" ",row));
        }
    }
}
