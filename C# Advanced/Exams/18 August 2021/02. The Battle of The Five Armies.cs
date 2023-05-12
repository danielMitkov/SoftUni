using System;
using System.Linq;
using System.Collections.Generic;

namespace Programtest
{
    public class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            var matrix = new char[int.Parse(Console.ReadLine())][];
            int armyRow = 0;
            int armyCol = 0;
            for(int row = 0;row < matrix.Length;++row)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                int col = matrix[row].ToList().IndexOf('A');
                if(col > -1)
                {
                    armyRow = row;
                    armyCol = col;
                    matrix[armyRow][armyCol] = '-';
                }
            }
            while(true)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);
                matrix[orcRow][orcCol] = 'O';
                if(input[0] == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                    armor--;
                }
                else if(input[0] == "up")
                {
                    armor--;
                }
                if(input[0] == "down" && armyRow + 1 < matrix.Length)
                {
                    armyRow++;
                    armor--;
                }
                else if(input[0] == "down")
                {
                    armor--;
                }
                if(input[0] == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                    armor--;
                }
                else if(input[0] == "left")
                {
                    armor--;
                }
                if(input[0] == "right" && armyCol + 1 < matrix[0].Length)
                {
                    armyCol++;
                    armor--;
                }
                else if(input[0] == "right")
                {
                    armor--;
                }
                if(matrix[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                    if(armor > 0)
                    {
                        matrix[armyRow][armyCol] = '-';
                    }
                }
                if(armor <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                if(matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
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
