Dictionary<string,Dictionary<string,int>> colorClothes = new();
for(int n = int.Parse(Console.ReadLine());n>0;--n) {
    var data = Console.ReadLine().Split(new string[] { " -> ","," },StringSplitOptions.RemoveEmptyEntries);
    if(!colorClothes.ContainsKey(data[0])) colorClothes.Add(data[0],new Dictionary<string, int>());
    for(int i = 1;i<data.Length;i++) {
        if(!colorClothes[data[0]].ContainsKey(data[i])) colorClothes[data[0]].Add(data[i],0);
        colorClothes[data[0]][data[i]]++;
    }
}
var target = Console.ReadLine().Split();
foreach(var colorDic in colorClothes) {
    Console.WriteLine($"{colorDic.Key} clothes:");
    foreach(var clothingCount in colorDic.Value) {
        Console.Write($"* {clothingCount.Key} - {clothingCount.Value}");
        if(colorDic.Key==target[0]&&clothingCount.Key==target[1]) Console.WriteLine(" (found!)");
        else Console.WriteLine();
    }
}