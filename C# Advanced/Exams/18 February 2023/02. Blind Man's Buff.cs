int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
char[][] matrix = new char[size[0]][];
int pRow = 0;
int pCol = 0;
for(int row = 0;row < matrix.Length;++row)
{
    matrix[row] = Console.ReadLine().Replace(" ","").ToCharArray();
    int col = matrix[row].ToList().IndexOf('B');
    if(col > -1)
    {
        pRow = row;
        pCol = col;
        matrix[pRow][pCol] = '-';
    }
}
int moves = 0;
int touched = 0;
string input = string.Empty;
while((input = Console.ReadLine()) != "Finish")
{
    int oldPRow = pRow;
    int oldPCol = pCol;
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
    matrix[oldPRow][oldPCol] = '-';//mark old pos in all cases
    if(pRow < 0 || pRow == matrix.Length || pCol < 0 || pCol == matrix[pRow].Length)
    {
        pRow = oldPRow;
        pCol = oldPCol;
        continue;
    }
    if(matrix[pRow][pCol] == 'O')
    {
        pRow = oldPRow;
        pCol = oldPCol;
        continue;
    }
    if(matrix[pRow][pCol] == 'P')
    {
        touched++;
        matrix[pRow][pCol] = '-';
    }
    if(matrix[pRow][pCol] == '-')
    {
        moves++;
    }
    if(touched == 3)
    {
        break;
    }
}
Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touched} Moves made: {moves}");
