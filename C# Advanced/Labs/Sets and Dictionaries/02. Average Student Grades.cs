Dictionary<string,List<decimal>> students = new();
for(int n = int.Parse(Console.ReadLine());n>0;n--) {
    string[] person = Console.ReadLine().Split(' ');
    string name = person[0];
    decimal grade = decimal.Parse(person[1]);
    if(!students.ContainsKey(name)) students.Add(name,new List<decimal>());
    students[name].Add(grade);
}
foreach(var kvp in students) Console.WriteLine($"{kvp.Key} -> {string.Join(' ',kvp.Value.Select(x=> $"{x:f2}"))} (avg: {kvp.Value.Average():f2})");