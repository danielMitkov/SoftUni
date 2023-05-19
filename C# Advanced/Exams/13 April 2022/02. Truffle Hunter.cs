using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int foundB = 0;
            int foundS = 0;
            int foundW = 0;
            int eaten = 0;
            char[][] matrix = new char[int.Parse(Console.ReadLine())][];
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] data = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                if(data[0] == "Collect")
                {
                    if(matrix[row][col] == 'B')
                    {
                        foundB++;
                    }
                    if(matrix[row][col] == 'S')
                    {
                        foundS++;
                    }
                    if(matrix[row][col] == 'W')
                    {
                        foundW++;
                    }
                    matrix[row][col] = '-';
                    continue;
                }
                if(matrix[row][col] != '-')
                {
                    eaten++;
                    matrix[row][col] = '-';
                }
                string direction = data[3];
                bool shouldEat = false;
                while(true)
                {
                    if(direction == "up")
                    {
                        row--;
                    }
                    if(direction == "down")
                    {
                        row++;
                    }
                    if(direction == "left")
                    {
                        col--;
                    }
                    if(direction == "right")
                    {
                        col++;
                    }
                    if(row == -1 || row == matrix.Length || col == -1 || col == matrix.Length)
                    {   
                        break;
                    }
                    if(!shouldEat)
                    {
                        shouldEat = true;
                        continue;
                    }
                    if(matrix[row][col] != '-')
                    {
                        eaten++;
                        matrix[row][col] = '-';
                    }
                    shouldEat = false;
                }
            }
            Console.WriteLine($"Peter manages to harvest {foundB} black, {foundS} summer, and {foundW} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");
            foreach(char[] row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
