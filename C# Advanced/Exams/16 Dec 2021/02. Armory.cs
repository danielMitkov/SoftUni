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
            int pRow = 0;
            int pCol = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                int col = matrix[row].ToList().IndexOf('A');
                if(col > -1)
                {
                    pRow = row;
                    pCol = col;
                    matrix[pRow][pCol] = '-';
                }
            }
            int coins = 0;
            string input = string.Empty;
            while((input = Console.ReadLine().ToLower()) != "end")
            {
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
                if(pRow < 0 || pRow == matrix.Length || pCol < 0 || pCol == matrix[pRow].Length)
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                if(matrix[pRow][pCol] != '-' && matrix[pRow][pCol] != 'M')
                {
                    coins += int.Parse($"{matrix[pRow][pCol]}");
                    matrix[pRow][pCol] = '-';
                }
                if(coins >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    matrix[pRow][pCol] = 'A';
                    break;
                }
                if(matrix[pRow][pCol] == 'M')//teleport
                {
                    matrix[pRow][pCol] = '-';
                    int portalRow = 0;//other portal
                    int portalCol = 0;
                    for(int row = 0;row < matrix.Length;++row)
                    {
                        int col = matrix[row].ToList().IndexOf('M');
                        if(col > -1)
                        {
                            portalRow = row;
                            portalCol = col;
                            break;
                        }
                    }
                    pRow = portalRow;
                    pCol = portalCol;
                    matrix[pRow][pCol] = '-';
                }
            }
            Console.WriteLine($"The king paid {coins} gold coins.");
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
