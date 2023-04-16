int[][] matrix = new int[int.Parse(Console.ReadLine())][];
for(int row = 0;row < matrix.Length;++row)
{
    matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}
string[] coords = Console.ReadLine().Split();
foreach(string coord in coords)
{
    int[] rowCol = coord.Split(',').Select(int.Parse).ToArray();
    int row = rowCol[0];
    int col = rowCol[1];
    int damage = matrix[row][col];
    if(damage <= 0)
    {
        continue;
    }
    bool hasLeft = col - 1 >= 0;
    bool hasRight = col + 1 < matrix[0].Length;
    bool hasUp = row - 1 >= 0;
    bool hasDown = row + 1 < matrix.Length;
    if(hasUp && matrix[row - 1][col] > 0)
    {
        matrix[row - 1][col] -= damage;
    }
    if(hasDown && matrix[row + 1][col] > 0)
    {
        matrix[row + 1][col] -= damage;
    }
    if(hasLeft && matrix[row][col - 1] > 0)
    {
        matrix[row][col - 1] -= damage;
    }
    if(hasRight && matrix[row][col + 1] > 0)
    {
        matrix[row][col + 1] -= damage;
    }
    if(hasUp && hasLeft && matrix[row - 1][col - 1] > 0)
    {
        matrix[row - 1][col - 1] -= damage;
    }
    if(hasDown && hasRight && matrix[row + 1][col + 1] > 0)
    {
        matrix[row + 1][col + 1] -= damage;
    }
    if(hasUp && hasRight && matrix[row - 1][col + 1] > 0)
    {
        matrix[row - 1][col + 1] -= damage;
    }
    if(hasDown && hasLeft && matrix[row + 1][col - 1] > 0)
    {
        matrix[row + 1][col - 1] -= damage;
    }
    matrix[row][col] = 0;
}
Console.WriteLine($"Alive cells: {matrix.Sum(arr => arr.Count(n => n > 0))}");
Console.WriteLine($"Sum: {matrix.Sum(arr => arr.Where(n => n > 0).Sum())}");
foreach(var arr in matrix)
{
    Console.WriteLine(string.Join(" ",arr));
}