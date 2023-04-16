char[][] field = new char[int.Parse(Console.ReadLine())][];
string[] moves = Console.ReadLine().Split();
int posRow = 0;
int posCol = 0;
for(int row = 0;row < field.Length;++row)
{
    field[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
    int sCol = field[row].ToList().IndexOf('s');
    if(sCol > -1)
    {
        posRow = row;
        posCol = sCol;
    }
}
int coals = field.Sum(arr => arr.Count(c => c == 'c'));
foreach(string move in moves)
{
    if(move == "up" && posRow - 1 >= 0)
    {
        posRow -= 1;
    }
    if(move == "down" && posRow + 1 < field.Length)
    {
        posRow += 1;
    }
    if(move == "left" && posCol - 1 >= 0)
    {
        posCol -= 1;
    }
    if(move == "right" && posCol + 1 < field.Length)
    {
        posCol += 1;
    }
    if(field[posRow][posCol] == 'c')
    {
        coals--;
        field[posRow][posCol] = '*';
        if(coals == 0)
        {
            Console.WriteLine($"You collected all coals! ({posRow}, {posCol})");
            return;
        }
    }
    if(field[posRow][posCol] == 'e')
    {
        Console.WriteLine($"Game over! ({posRow}, {posCol})");
        return;
    }
}
Console.WriteLine($"{coals} coals left. ({posRow}, {posCol})");