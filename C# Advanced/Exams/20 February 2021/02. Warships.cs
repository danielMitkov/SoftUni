using System;
using System.Linq;
public class Program
{
    public static char[][] matrix;
    public static int p1Ships = 0;
    public static int p2Ships = 0;
    public static int totalDead = 0;
    public static void Main()
    {
        matrix = new char[int.Parse(Console.ReadLine())][];
        var coords = Console.ReadLine().Split(new char[] { ' ',',' },StringSplitOptions.RemoveEmptyEntries);
        for(int row = 0;row < matrix.Length;++row)
        {
            matrix[row] = Console.ReadLine().Replace(" ","").ToCharArray();
            p1Ships += matrix[row].Count(x => x == '<');
            p2Ships += matrix[row].Count(x => x == '>');
        }
        for(int i = 0;i < coords.Length;i += 2)
        {
            int row = int.Parse(coords[i]);
            int col = int.Parse(coords[i + 1]);
            if(!IsPosValid(row,col))
            {
                continue;
            }
            if(matrix[row][col] == '#')
            {
                KillShip(row - 1,col);
                KillShip(row + 1,col);
                KillShip(row,col - 1);
                KillShip(row,col + 1);
                KillShip(row - 1,col - 1);
                KillShip(row - 1,col + 1);
                KillShip(row + 1,col - 1);
                KillShip(row + 1,col + 1);
            }
            KillShip(row,col);
            if(p1Ships == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalDead} ships have been sunk in the battle.");
                return;
            }
            if(p2Ships == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalDead} ships have been sunk in the battle.");
                return;
            }
        }
        Console.WriteLine($"It's a draw! Player One has {p1Ships} ships left. Player Two has {p2Ships} ships left.");
    }
    public static bool IsPosValid(int row,int col)
    {
        return row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length;
    }
    public static void KillShip(int row,int col)
    {
        if(!IsPosValid(row,col))
        {
            return;
        }
        if(matrix[row][col] == '<')
        {
            p1Ships--;
            totalDead++;
        }
        if(matrix[row][col] == '>')
        {
            p2Ships--;
            totalDead++;
        }
        matrix[row][col] = 'X';
    }
}
