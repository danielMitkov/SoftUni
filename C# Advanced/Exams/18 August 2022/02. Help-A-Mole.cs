using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[int.Parse(Console.ReadLine())][];
            int moleRow = 0;
            int moleCol = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                int indexMole = matrix[row].ToList().IndexOf('M');
                if(indexMole > -1)
                {
                    moleRow = row;
                    moleCol = indexMole;
                    matrix[moleRow][moleCol] = '-';
                }
            }
            int points = 0;
            string input = string.Empty;
            while((input = Console.ReadLine().ToLower()) != "end")
            {
                int oldMoleRow = moleRow;
                int oldMoleCol = moleCol;
                if(input == "up")
                {
                    moleRow--;
                }
                if(input == "down")
                {
                    moleRow++;
                }
                if(input == "left")
                {
                    moleCol--;
                }
                if(input == "right")
                {
                    moleCol++;
                }
                matrix[oldMoleRow][oldMoleCol] = '-';//mark old pos in all cases
                if(moleRow < 0 || moleRow == matrix.Length || moleCol < 0 || moleCol == matrix[moleRow].Length)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    moleRow = oldMoleRow;
                    moleCol = oldMoleCol;
                    continue;
                }
                if(matrix[moleRow][moleCol] == 'S')//teleport
                {
                    matrix[moleRow][moleCol] = '-';
                    int portalRow = 0;//other portal
                    int portalCol = 0;
                    for(int row = 0;row < matrix.Length;++row)
                    {
                        int col = matrix[row].ToList().IndexOf('S');
                        if(col > -1)
                        {
                            portalRow = row;
                            portalCol = col;
                            break;
                        }
                    }
                    moleRow = portalRow;
                    moleCol = portalCol;
                    matrix[moleRow][moleCol] = '-';
                    points -= 3;
                }
                else if(matrix[moleRow][moleCol] != '-')
                {
                    char charNum = matrix[moleRow][moleCol];
                    points += int.Parse($"{charNum}");
                }
                if(points >= 25)
                {
                    break;
                }
            }
            if(points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            matrix[moleRow][moleCol] = 'M';
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
