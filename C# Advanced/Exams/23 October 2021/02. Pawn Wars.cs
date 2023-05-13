using System;
using System.Linq;
using System.Collections.Generic;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[][] board = new char[8][];
            int wRow = 0;
            int wCol = 0;
            int bRow = 0;
            int bCol = 0;
            for(int row = 0;row < board.Length;++row)
            {
                board[row] = Console.ReadLine().Replace(" ","").ToCharArray();
                int col = board[row].ToList().IndexOf('w');
                if(col > -1)
                {
                    wRow = row;
                    wCol = col;
                    board[row][col] = '-';
                }
                col = board[row].ToList().IndexOf('b');
                if(col > -1)
                {
                    bRow = row;
                    bCol = col;
                    board[row][col] = '-';
                }
            }
            while(true)
            {
                if(wRow - 1 >= 0 && wRow - 1 == bRow && wCol - 1 == bCol)
                {
                    wRow--;
                    wCol--;
                    Console.WriteLine($"Game over! White capture on {(char)(97 + wCol)}{8 - wRow}.");
                    return;
                }
                if(wRow - 1 >= 0 && wRow - 1 == bRow && wCol + 1 == bCol)
                {
                    wRow--;
                    wCol++;
                    Console.WriteLine($"Game over! White capture on {(char)(97 + wCol)}{8 - wRow}.");
                    return;
                }
                wRow--;
                if(wRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + wCol)}{8 - wRow}.");
                    return;
                }
                if(bRow < 8 && bRow + 1 == wRow && bCol - 1 == wCol)
                {
                    bRow++;
                    bCol--;
                    Console.WriteLine($"Game over! Black capture on {(char)(97 + bCol)}{8 - bRow}.");
                    return;
                }
                if(bRow < 8 && bRow + 1 == wRow && bCol + 1 == wCol)
                {
                    bRow++;
                    bCol++;
                    Console.WriteLine($"Game over! Black capture on {(char)(97 + bCol)}{8 - bRow}.");
                    return;
                }
                bRow++;
                if(bRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + bCol)}{8 - bRow}.");
                    return;
                }
            }
        }
    }
}
