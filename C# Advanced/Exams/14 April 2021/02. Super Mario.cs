namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            char[][] matrix = new char[int.Parse(Console.ReadLine())][];
            int mRow = 0;
            int mCol = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                int col = matrix[row].ToList().IndexOf('M');
                if(col > -1)
                {
                    mRow = row;
                    mCol = col;
                    matrix[mRow][mCol] = '-';
                }
            }
            while(true)
            {
                int oldMRow = mRow;
                int oldMCol = mCol;
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);
                matrix[spawnRow][spawnCol] = 'B';
                if(input[0] == "W")
                {
                    mRow--;
                }
                if(input[0] == "S")
                {
                    mRow++;
                }
                if(input[0] == "A")
                {
                    mCol--;
                }
                if(input[0] == "D")
                {
                    mCol++;
                }
                lives--;
                if(mRow < 0 || mRow == matrix.Length || mCol < 0 || mCol == matrix[mRow].Length)
                {
                    mRow = oldMRow;
                    mCol = oldMCol;
                    continue;
                }
                if(matrix[mRow][mCol] == 'B')
                {
                    lives -= 2;
                    matrix[mRow][mCol] = '-';
                }
                if(matrix[mRow][mCol] == 'P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    matrix[mRow][mCol] = '-';
                    break;
                }
                if(lives <= 0)
                {
                    matrix[mRow][mCol] = 'X';
                    Console.WriteLine($"Mario died at {mRow};{mCol}.");
                    break;
                }
            }
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
