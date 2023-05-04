namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            char[][] matrix = new char[int.Parse(Console.ReadLine())][];
            int commands = int.Parse(Console.ReadLine());
            int pRow = 0;
            int pCol = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                int col = matrix[row].ToList().IndexOf('f');
                if(col > -1)
                {
                    pRow = row;
                    pCol = col;
                    matrix[pRow][pCol] = '-';
                }
            }
            for(int n = commands;n>0;--n)
            {
                string input = Console.ReadLine();
                int oldPRow = pRow;
                int oldPCol = pCol;
                if(input == "up")
                {
                    pRow--;
                }
                if(input == "down")
                {
                    pRow++;
                }
                if(input == "left")
                {
                    pCol--;
                }
                if(input == "right")
                {
                    pCol++;
                }
                if(pRow == -1)
                {
                    pRow = matrix.Length - 1;
                }
                if(pRow == matrix.Length)
                {
                    pRow = 0;
                }
                if(pCol == -1)
                {
                    pCol = matrix.Length - 1;
                }
                if(pCol == matrix.Length)
                {
                    pCol = 0;
                }
                if(matrix[pRow][pCol] == 'T')
                {
                    pRow = oldPRow;
                    pCol = oldPCol;
                }
                if(matrix[pRow][pCol] == 'B')
                {
                    oldPRow = pRow;
                    oldPCol = pCol;
                    if(input == "up")
                    {
                        pRow--;
                    }
                    if(input == "down")
                    {
                        pRow++;
                    }
                    if(input == "left")
                    {
                        pCol--;
                    }
                    if(input == "right")
                    {
                        pCol++;
                    }
                    if(pRow == -1)
                    {
                        pRow = matrix.Length - 1;
                    }
                    if(pRow == matrix.Length)
                    {
                        pRow = 0;
                    }
                    if(pCol == -1)
                    {
                        pCol = matrix.Length - 1;
                    }
                    if(pCol == matrix.Length)
                    {
                        pCol = 0;
                    }
                }
                if(matrix[pRow][pCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[pRow][pCol] = 'f';
                    foreach(char[] row in matrix)
                    {
                        Console.WriteLine(string.Join("",row));
                    }
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            matrix[pRow][pCol] = 'f';
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
