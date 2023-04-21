var names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
var line = "";
while((line=Console.ReadLine())!="Party!") {
    var data = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
    bool isRemove = data[0]=="Remove";
    var criteria = data[1];
    var value = data[2];
    if(isRemove) names.RemoveAll(GetPredicate(criteria,value));
    else {
        List<string> toAdd = names.FindAll(GetPredicate(criteria,value));
        foreach(var name in toAdd) {
            int i = names.FindIndex(x=> x==name);
            names.Insert(i,name);
        }
    }
}
if(names.Any()) Console.Write(string.Join(", ",names)+" are going to the party!");
else Console.Write("Nobody is going to the party!");
static Predicate<string> GetPredicate(string criteria,string value) {
    if(criteria=="StartsWith") return name => name.StartsWith(value);
    if(criteria=="Length") return name => name.Length==int.Parse(value);
    else return name => name.EndsWith(value);
}
