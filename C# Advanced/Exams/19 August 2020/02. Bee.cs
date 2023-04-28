using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            int col = matrix[row].ToList().IndexOf('B');
            if(col > -1)
            {
                pRow = row;
                pCol = col;
                matrix[pRow][pCol] = '.';
            }
        }
        int flowers = 0;
        string input = string.Empty;
        while((input = Console.ReadLine()) != "End")
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
                Console.WriteLine("The bee got lost!");
                break;
            }
            if(matrix[pRow][pCol] == 'O')
            {
                matrix[pRow][pCol] = '.';
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
            }
            if(matrix[pRow][pCol] == 'f')
            {
                flowers++;
                matrix[pRow][pCol] = '.';
            }
        }
        if(flowers >= 5)
        {
            Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
        }
        else
        {
            Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
        }
        if(pRow >= 0 && pRow < matrix.Length && pCol >= 0 && pCol < matrix[pRow].Length)
        {
            matrix[pRow][pCol] = 'B';
        }
        foreach(char[] row in matrix)
        {
            Console.WriteLine(string.Join("",row));
        }
    }
}
