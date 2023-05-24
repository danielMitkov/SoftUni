char[][] matrix = new char[int.Parse(Console.ReadLine())][];
int shipRow = 0;
int shipCol = 0;
int enemies = 0;
for(int row = 0;row < matrix.Length;++row)
{
    matrix[row] = Console.ReadLine().ToCharArray();
    int col = matrix[row].ToList().IndexOf('S');
    if(col > -1)
    {
        matrix[row][col] = '-';
        shipRow = row;
        shipCol = col;
    }
    enemies += matrix[row].Count(x => x == 'C');
}
int hp = 3;
while(true)
{
    string input = Console.ReadLine();
    if(input == "left") shipCol--;
    if(input == "right") shipCol++;
    if(input == "up") shipRow--;
    if(input == "down") shipRow++;
    if(matrix[shipRow][shipCol] == '*')
    {
        hp--;
        matrix[shipRow][shipCol] = '-';
    }
    if(hp == 0)
    {
        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{shipRow}, {shipCol}]!");
        break;
    }
    if(matrix[shipRow][shipCol] == 'C')
    {
        matrix[shipRow][shipCol] = '-';
        enemies--;
    }
    if(enemies == 0)
    {
        Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
        break;
    }
}
matrix[shipRow][shipCol] = 'S';
foreach(char[] row in matrix) Console.WriteLine(string.Join("",row));
