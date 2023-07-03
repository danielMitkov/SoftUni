using BirthdayCelebrations;
using BirthdayCelebrations.Identities;
using BirthdayCelebrations.Interfaces;
List<IBirthdate> dates = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string type = data[0];
    string name = data[1];
    if(type == "Pet")
    {
        dates.Add(new Pet(name,data.Last()));
    }
    else if(type == "Citizen")
    {
        int age = int.Parse(data[2]);
        string id = data[3];
        dates.Add(new Citizen(name,age,id,data.Last()));
    }
}
string year = Console.ReadLine();
foreach(IBirthdate date in dates)
{
    if(date.Birthdate.EndsWith(year))
    {
        Console.WriteLine(date.Birthdate);
    }
}