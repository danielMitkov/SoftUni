using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[][] matrix = new char[int.Parse(Console.ReadLine())][];
            int bRow = 0;
            int bCol = 0;
            int toFind = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                int indexB = matrix[row].ToList().IndexOf('B');
                if(indexB > -1)
                {
                    bRow = row;
                    bCol = indexB;
                }
                toFind += matrix[row].Count(x => char.IsLower(x));
            }
            var branches = new Stack<char>();
            string input = string.Empty;
            while((input = Console.ReadLine().ToLower()) != "end" && branches.Count < toFind)
            {
                int oldBRow = bRow;
                int oldBCol = bCol;
                if(input == "up")
                {
                    bRow--;
                }
                if(input == "down")
                {
                    bRow++;
                }
                if(input == "left")
                {
                    bCol--;
                }
                if(input == "right")
                {
                    bCol++;
                }
                if(bRow < 0 || bRow == matrix.Length || bCol < 0 || bCol == matrix[bRow].Length)
                {
                    bRow = oldBRow;
                    bCol = oldBCol;
                    if(branches.Any())
                    {
                        branches.Pop();
                        toFind--;
                    }
                    continue;
                }
                matrix[oldBRow][oldBCol] = '-';
                if(matrix[bRow][bCol] == 'F')
                {
                    matrix[bRow][bCol] = '-';
                    if(input == "up")
                    {
                        if(bRow > 0)
                        {
                            bRow = 0;
                        }
                        else
                        {
                            bRow = matrix.Length - 1;
                        }
                    }
                    if(input == "down")
                    {
                        if(bRow < matrix.Length - 1)
                        {
                            bRow = matrix.Length - 1;
                        }
                        else
                        {
                            bRow = 0;
                        }
                    }
                    if(input == "left")
                    {
                        if(bCol > 0)
                        {
                            bCol = 0;
                        }
                        else
                        {
                            bCol = matrix.Length - 1;
                        }
                    }
                    if(input == "right")
                    {
                        if(bCol < matrix.Length - 1)
                        {
                            bCol = matrix.Length - 1;
                        }
                        else
                        {
                            bCol = 0;
                        }
                    }
                }
                if(char.IsLower(matrix[bRow][bCol]))
                {
                    branches.Push(matrix[bRow][bCol]);
                }
                matrix[bRow][bCol] = 'B';
            }
            if(branches.Count == toFind)
            {
                Console.WriteLine($"The Beaver successfully collect {toFind} wood branches: {string.Join(", ",branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {toFind - branches.Count} branches left.");
            }
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
