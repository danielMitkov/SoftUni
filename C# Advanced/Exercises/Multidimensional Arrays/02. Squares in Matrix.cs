var jag = new char[Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[0]][];
for(int row = 0;row<jag.Length;++row) jag[row]=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
int count = 0;
for(int row = 0;row<jag.Length-1;row++) {
    for(int col = 0;col<jag[row].Length-1;col++) {
        char c = jag[row][col];
        if(jag[row+1][col]==c&&jag[row][col+1]==c&&jag[row+1][col+1]==c) count++;
    }
}
Console.WriteLine(count);