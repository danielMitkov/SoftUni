using System.Linq;
using System;
public class Program
{
    public static void Main()
    {
        char[][] matrix = new char[int.Parse(Console.ReadLine())][];
        int rowV = 0;
        int colV = 0;
        int holes = 1;
        int rodsHit = 0;
        for(int row = 0;row < matrix.Length;++row)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
            int col = matrix[row].ToList().IndexOf('V');
            if(col > -1)
            {
                matrix[row][col] = '*';
                rowV = row;
                colV = col;
            }
        }
        string input = string.Empty;
        while((input = Console.ReadLine()) != "End")
        {
            int rowPast = rowV;
            int colPast = colV;
            if(input == "left") colV--;
            if(input == "right") colV++;
            if(input == "up") rowV--;
            if(input == "down") rowV++;
            if(colV < 0 || colV == matrix[0].Length || rowV < 0 || rowV == matrix.Length)
            {
                rowV = rowPast;
                colV = colPast;
                continue;
            }
            if(matrix[rowV][colV] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                continue;
            }
            if(matrix[rowV][colV] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodsHit++;
                rowV = rowPast;
                colV = colPast;
                continue;
            }
            if(matrix[rowV][colV] == 'C')
            {
                holes++;
                matrix[rowV][colV] = 'E';
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                foreach(char[] row in matrix) Console.WriteLine(string.Join("",row));
                return;
            }
            matrix[rowV][colV] = '*';
            holes++;
        }
        Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodsHit} rod(s).");
        matrix[rowV][colV] = 'V';
        foreach(char[] row in matrix) Console.WriteLine(string.Join("",row));
    }
}
