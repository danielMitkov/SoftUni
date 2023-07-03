using ExplicitInterfaces;
using ExplicitInterfaces.INames;
List<IPerson> people = new();
List<IResident> residents = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    Citizen citizen = new Citizen(data[0],data[1],int.Parse(data[2]));
    people.Add(citizen);
    residents.Add(citizen);
}
for(int i = 0;i < people.Count;++i)
{//they have equal count
    Console.WriteLine(people[i].GetName());
    Console.WriteLine(residents[i].GetName());
}