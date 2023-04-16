var jag = new int[int.Parse(Console.ReadLine())][];
for(int row = 0;row<jag.Length;++row) jag[row]=Console.ReadLine().Split().Select(int.Parse).ToArray();
var str = "";
while((str=Console.ReadLine())!="END") {
    var data = str.Split();
    var action = data[0];
    int row = int.Parse(data[1]);
    int col = int.Parse(data[2]);
    int value = int.Parse(data[3]);
    if(row<0||row>=jag.Length||col<0||col>=jag[row].Length) {
        Console.WriteLine("Invalid coordinates");
        continue;
    }
    if(action=="Add") jag[row][col]+=value;
    if(action=="Subtract") jag[row][col]-=value;
}
foreach(var arr in jag) Console.WriteLine(string.Join(' ',arr));