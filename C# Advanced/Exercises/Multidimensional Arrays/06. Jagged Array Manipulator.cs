int rows = int.Parse(Console.ReadLine());
int[][] jag = new int[rows][];
for(int row = 0;row<rows;row++) {
    int[] cols = Console.ReadLine()
        .Split(" ",StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    jag[row]=cols;
}
for(int row = 0;row<rows-1;row++) {
    if(jag[row].Length==jag[row+1].Length) {
        for(int col = 0;col<jag[row].Length;col++) {
            jag[row][col]*=2;
            jag[row+1][col]*=2;
        }
    } else {
        for(int col = 0;col<jag[row].Length;col++) jag[row][col]/=2;
        for(int col = 0;col<jag[row+1].Length;col++) jag[row+1][col]/=2;
    }
}
while(true) {
    string str = Console.ReadLine();
    if(str=="End") break;
    var data = str.Split(" ",StringSplitOptions.RemoveEmptyEntries);
    int row = int.Parse(data[1]);
    int col = int.Parse(data[2]);
    int value = int.Parse(data[3]);
    if(data[0]=="Add") {
        if(ValidCoordinates(row,col,jag)) jag[row][col]+=value;
    } else if(ValidCoordinates(row,col,jag)) jag[row][col]-=value;
}
foreach(var arr in jag) Console.WriteLine(string.Join(' ',arr));
static bool ValidCoordinates(int row,int col,int[][] jag) {
    return row>=0
        &&row<jag.Length
        &&col>=0
        &&col<jag[row].Length;
}