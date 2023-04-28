using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        char[][] matrix = new char[int.Parse(Console.ReadLine())][];
        int sRow = 0;
        int sCol = 0;
        for(int row = 0;row < matrix.Length;++row)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
            int col = matrix[row].ToList().IndexOf('S');
            if(col > -1)
            {
                sRow = row;
                sCol = col;
                matrix[sRow][sCol] = '-';
            }
        }
        int food = 0;
        while(food < 10)
        {
            string input = Console.ReadLine();
            matrix[sRow][sCol] = '.';
            if(input == "up")
            {
                sRow--;
            }
            if(input == "down")
            {
                sRow++;
            }
            if(input == "left")
            {
                sCol--;
            }
            if(input == "right")
            {
                sCol++;
            }
            if(sRow < 0 || sRow == matrix.Length || sCol < 0 || sCol == matrix[sRow].Length)
            {
                Console.WriteLine("Game over!");
                break;
            }
            if(matrix[sRow][sCol] == 'B')
            {
                matrix[sRow][sCol] = '.';
                int portalRow = 0;
                int portalCol = 0;
                for(int row = 0;row < matrix.Length;++row)
                {
                    int col = matrix[row].ToList().IndexOf('B');
                    if(col > -1)
                    {
                        portalRow = row;
                        portalCol = col;
                        break;
                    }
                }
                sRow = portalRow;
                sCol = portalCol;
            }
            if(matrix[sRow][sCol] == '*')
            {
                food += 1;
            }
        }
        if(food >= 5)
        {
            Console.WriteLine("You won! You fed the snake.");
            matrix[sRow][sCol] = 'S';
        }
        Console.WriteLine($"Food eaten: {food}");
        foreach(char[] row in matrix)
        {
            Console.WriteLine(string.Join("",row));
        }
    }
}
