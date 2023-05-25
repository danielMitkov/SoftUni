Queue<int> textiles = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> medicaments = new(Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Patch", 30},
                {"Bandage",40 },
                {"MedKit", 100}
            };
Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Patch", 0},
                {"Bandage",0 },
                {"MedKit", 0}
            };
while(textiles.Any() && medicaments.Any())
{
    int textile = textiles.Peek();
    int medicament = medicaments.Peek();
    int sum = textile + medicament;
    var kvp = types.FirstOrDefault(x => x.Value == sum);
    if(kvp.Key != null)
    {
        made[kvp.Key]++;
        textiles.Dequeue();
        medicaments.Pop();
    }
    else if(sum > types["MedKit"])
    {
        made["MedKit"]++;
        textiles.Dequeue();
        medicaments.Pop();
        sum -= types["MedKit"];
        medicaments.Push(medicaments.Pop() + sum);
    }
    else
    {
        textiles.Dequeue();
        medicaments.Pop();
        medicaments.Push(medicament + 10);
    }
}
if(!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else
{
    if(!textiles.Any())
    {
        Console.WriteLine("Textiles are empty.");
    }
    if(!medicaments.Any())
    {
        Console.WriteLine("Medicaments are empty.");
    }
}
foreach(var (type, amount) in made.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{type} - {amount}");
}
if(medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ",medicaments)}");
}
if(textiles.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ",textiles)}");
}
