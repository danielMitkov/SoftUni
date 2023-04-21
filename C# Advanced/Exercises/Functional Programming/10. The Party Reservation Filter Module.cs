var names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
Dictionary<string,Predicate<string>> filters = new();
var line = "";
while((line=Console.ReadLine())!="Print") {
    var data = line.Split(";",StringSplitOptions.RemoveEmptyEntries);
    bool isRemove = data[0]=="Remove filter";
    var filter = data[1];
    var value = data[2];
    if(!isRemove) filters.Add(filter+value,GetPredicate(filter,value));
    else filters.Remove(filter+value);
}
foreach(var (str, predicate) in filters) names.RemoveAll(predicate);
Console.Write(string.Join(" ",names));
static Predicate<string> GetPredicate(string filter,string value) {
    if(filter=="Starts with") return name => name.StartsWith(value);
    if(filter=="Ends with") return name => name.EndsWith(value);
    if(filter=="Length") return name => name.Length==int.Parse(value);
    if(filter=="Contains") return name => name.Contains(value);
    throw new Exception("GetPredicate didnt return anything!");
}
