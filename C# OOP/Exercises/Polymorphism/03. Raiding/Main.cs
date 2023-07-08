using Raiding;
List<Hero> heroes = new();
int count = int.Parse(Console.ReadLine());
while(count > 0)
{
    string name = Console.ReadLine();
    string type = Console.ReadLine();
    try
    {
        heroes.Add(HeroFactory.GetHero(type,name));
        count--;
    }
    catch(ArgumentException err)
    {
        Console.WriteLine(err.Message);
    }
}
int bossPower = int.Parse(Console.ReadLine());
int heroesPower = 0;
foreach(Hero hero in heroes)
{
    Console.WriteLine(hero.CastAbility());
    heroesPower += hero.Power;
}
if(heroesPower >= bossPower)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}