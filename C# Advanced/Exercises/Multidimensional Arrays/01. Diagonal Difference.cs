var jag = new int[int.Parse(Console.ReadLine())][];
for(int row = 0;row<jag.Length;++row) jag[row]=Console.ReadLine().Split().Select(int.Parse).ToArray();
int sumPri = 0;
for(int row = 0; row < jag.Length; ++row) sumPri+=jag[row][row];
int sumSec = 0;
for(int row = 0;row<jag.Length;++row) sumSec+=jag[row][jag.Length-row-1];
Console.WriteLine(Math.Abs(sumPri - sumSec));