using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        char[][] matrix = new char[int.Parse(Console.ReadLine())][];
        int pRow = 0;
        int pCol = 0;
        for(int row = 0;row < matrix.Length;++row)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
            int col = matrix[row].ToList().IndexOf('S');
            if(col > -1)
            {
                pRow = row;
                pCol = col;
                matrix[pRow][pCol] = '-';
            }
        }
        int money = 0;
        while(true)
        {
            string input = Console.ReadLine();
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
                Console.WriteLine("Bad news, you are out of the bakery.");
                break;
            }
            if(matrix[pRow][pCol] == 'O')
            {
                matrix[pRow][pCol] = '-';
                int portalRow = 0;
                int portalCol = 0;
                for(int row = 0;row < matrix.Length;++row)
                {
                    int col = matrix[row].ToList().IndexOf('O');
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
            else if(matrix[pRow][pCol] != '-')
            {
                char charNum = matrix[pRow][pCol];
                money += int.Parse($"{charNum}");
                matrix[pRow][pCol] = '-';
            }
            if(money >= 50)
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
                matrix[pRow][pCol] = 'S';
                break;
            }
        }
        Console.WriteLine($"Money: {money}");
        foreach(char[] row in matrix)
        {
            Console.WriteLine(string.Join("",row));
        }
    }
}
