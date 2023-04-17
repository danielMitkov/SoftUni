Dictionary<string,Dictionary<string,double>> dict = new();
var str = "";
while((str=Console.ReadLine())!="Revision") {
    var data = str.Split(", ");
    var shop = data[0];
    var product = data[1];
    var price = double.Parse(data[2]);
    if(!dict.ContainsKey(shop)) dict.Add(shop,new Dictionary<string, double>());
    if(!dict[shop].ContainsKey(product)) dict[shop].Add(product,0);
    dict[shop][product]=price;
}
foreach(var shopDict in dict.OrderBy(x=>x.Key)) {
    Console.WriteLine($"{shopDict.Key}->");
    foreach(var namePrice in shopDict.Value) Console.WriteLine($"Product: {namePrice.Key}, Price: {namePrice.Value}");
}