Dictionary<int,int> dict = new();
for(int n = int.Parse(Console.ReadLine());n>0;n--) {
    int num = int.Parse(Console.ReadLine());
    if(!dict.ContainsKey(num)) dict.Add(num,0);
    dict[num]++;
}
Console.WriteLine(dict.Single(x => x.Value%2==0).Key);