int n = int.Parse(Console.ReadLine());
long[] prev = { 1 };
for(int row = 1;row<=n;row++) {
    var arr = new long[row];
    for(int col = 0;col<row;col++) {
        long top = col<prev.Length ? prev[col] : 0;
        long topLeft = col-1>=0 ? prev[col-1] : 0;
        arr[col]=top+topLeft;
    }
    Console.WriteLine(string.Join(' ',arr));
    prev=arr;
}