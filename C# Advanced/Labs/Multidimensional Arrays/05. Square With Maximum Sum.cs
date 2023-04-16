var jag = new int[Console.ReadLine().Split(", ").Select(int.Parse).ToArray()[0]][];
for(int row = 0;row < jag.Length;++row) jag[row] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
var win = new int[4];
for(int row = 0;row < jag.Length - 1;row++)
{
    for(int col = 0;col < jag[0].Length - 1;col++)
    {
        int[] sub = { jag[row][col],jag[row][col + 1],jag[row + 1][col],jag[row + 1][col + 1] };
        if(sub.Sum() > win.Sum()) win = sub;
    }
}
Console.WriteLine($"{win[0]} {win[1]}\n{win[2]} {win[3]}\n{win.Sum()}");