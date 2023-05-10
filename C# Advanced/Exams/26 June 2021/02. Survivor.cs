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
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().Replace(" ","").ToCharArray();
            }
            int myTokens = 0;
            int opTokens = 0;
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Gong")
            {
                string[] data = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                if(data[0] == "Find" && isPosValid(matrix,row,col))
                {
                    myTokens += GetToken(matrix,row,col);
                }
                if(data[0] == "Opponent" && isPosValid(matrix,row,col))
                {
                    opTokens += GetToken(matrix,row,col);
                    for(int n = 3;n > 0;--n)
                    {
                        if(data[3] == "up" && isPosValid(matrix,row - 1,col))
                        {
                            row--;
                            opTokens += GetToken(matrix,row,col);
                        }
                        if(data[3] == "down" && isPosValid(matrix,row + 1,col))
                        {
                            row++;
                            opTokens += GetToken(matrix,row,col);
                        }
                        if(data[3] == "left" && isPosValid(matrix,row,col - 1))
                        {
                            col--;
                            opTokens += GetToken(matrix,row,col);
                        }
                        if(data[3] == "right" && isPosValid(matrix,row,col + 1))
                        {
                            col++;
                            opTokens += GetToken(matrix,row,col);
                        }
                    }
                }
            }
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opTokens}");
        }
        public static bool isPosValid(char[][] matrix,int row,int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
        public static int GetToken(char[][] matrix,int row,int col)
        {
            if(matrix[row][col] == 'T')
            {
                matrix[row][col] = '-';
                return 1;
            }
            return 0;
        }
    }
}
