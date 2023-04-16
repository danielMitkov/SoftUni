var jag = new int[Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[0]][];
for(int row = 0;row<jag.Length;++row) jag[row]=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var win = new int[3];
for(int row = 0;row<jag.Length-2;row++) {
    for(int col = 0;col<jag[row].Length-2;col++) {
        int sum = jag[row][col]+jag[row][col+1]+jag[row][col+2]+jag[row+1][col]+jag[row+1][col+1]+jag[row+1][col+2]+jag[row+2][col]+jag[row+2][col+1]+jag[row+2][col+2];
        if(sum>win[0]) win=new[] { sum,row,col };
    }
}
Console.WriteLine($"Sum = {win[0]}");
for(int row = win[1];row<win[1]+3;row++) {
    for(int col = win[2];col<win[2]+3;col++) Console.Write($"{jag[row][col]} ");
    Console.WriteLine();
}