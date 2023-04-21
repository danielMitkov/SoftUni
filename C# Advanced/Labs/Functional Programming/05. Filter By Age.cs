Dictionary<string,int> people = new();
for(int n = int.Parse(Console.ReadLine());n>0;n--) {
    string[] line = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
    people.Add(line[0],int.Parse(line[1]));
}
bool isOlder = Console.ReadLine()=="older" ? true : false;
int age = int.Parse(Console.ReadLine());
Func<KeyValuePair<string,int>,int,bool> filter = (kvp,age) => {
    if(isOlder&&kvp.Value>=age) return true;
    if(!isOlder&&kvp.Value<age) return true;
    return false;
};
string format = Console.ReadLine();
foreach(var kvp in people.Where(x => filter(x,age))) {
    if(format=="name") Console.WriteLine(kvp.Key);
    if(format=="age") Console.WriteLine(kvp.Value);
    if(format=="name age") Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}
