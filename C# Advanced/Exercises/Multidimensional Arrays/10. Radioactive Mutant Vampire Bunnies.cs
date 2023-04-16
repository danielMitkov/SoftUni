char[][] lair = new char[Console.ReadLine().Split().Select(int.Parse).ToArray()[0]][];
(int row, int col) pos = (0, 0);
for(int row = 0;row < lair.Length;++row)
{
    lair[row] = Console.ReadLine().ToCharArray();
    int playerCol = lair[row].ToList().IndexOf('P');
    if(playerCol >= 0)
    {
        pos.row = row;
        pos.col = playerCol;
        lair[pos.row][pos.col] = '.';
    }
}
char[] moves = Console.ReadLine().ToCharArray();
foreach(char move in moves)
{
    (int row, int col) oldPos = (pos.row, pos.col);
    if(move == 'U') pos.row--;
    if(move == 'D') pos.row++;
    if(move == 'L') pos.col--;
    if(move == 'R') pos.col++;
    char[][] copy = lair.Select(arr => arr.ToArray()).ToArray();
    for(int row = 0;row < lair.Length;++row)
    {
        for(int col = 0;col < lair[row].Length;++col)
        {
            if(lair[row][col] != 'B') continue;
            if(row - 1 >= 0) copy[row - 1][col] = 'B';
            if(col - 1 >= 0) copy[row][col - 1] = 'B';
            if(row + 1 < lair.Length) copy[row + 1][col] = 'B';
            if(col + 1 < lair[row].Length) copy[row][col + 1] = 'B';
        }
    }
    lair = copy;
    if(pos.row < 0 || pos.col < 0 || pos.row == lair.Length || pos.col == lair[0].Length)
    {
        foreach(char[] row in lair) Console.WriteLine(string.Join("",row));
        Console.WriteLine($"won: {oldPos.row} {oldPos.col}");
        return;
    }
    if(lair[pos.row][pos.col] == 'B')
    {
        foreach(char[] row in lair) Console.WriteLine(string.Join("",row));
        Console.WriteLine($"dead: {pos.row} {pos.col}");
        return;
    }
}