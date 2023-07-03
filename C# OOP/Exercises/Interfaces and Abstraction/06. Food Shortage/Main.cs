using FoodShortage;
using FoodShortage.People;
Dictionary<string,IBuyer> buyers = new();
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    if(data.Length == 4)
    {
        buyers.Add(data.First(),new Citizen());
    }
    else
    {
        buyers.Add(data.First(),new Rebel());
    }
}
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{//input = name
    if(buyers.ContainsKey(input))
    {
        buyers[input].BuyFood();
    }
}
Console.Write(buyers.Sum(x => x.Value.Food));