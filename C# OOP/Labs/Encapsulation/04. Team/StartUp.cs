namespace PersonsInfo;
public class StartUp
{
    public static void Main(string[] args)
    {
        var persons = new List<Person>();
        for(int n = int.Parse(Console.ReadLine());n > 0;--n)
        {
            var data = Console.ReadLine().Split();
            try
            {
                var person = new Person(data[0],data[1],int.Parse(data[2]),decimal.Parse(data[3]));
                persons.Add(person);
            }
            catch(ArgumentException err)
            {
                Console.WriteLine(err.Message);
            }
        }
        //var parcentage = decimal.Parse(Console.ReadLine());
        //persons.ForEach(p => p.IncreaseSalary(parcentage));
        //persons.ForEach(p => Console.WriteLine(p.ToString()));
        Team team = new Team("SoftUni");

        foreach(Person person in persons)
        {
            team.AddPlayer(person);
        }
        team.PrintTeams();
    }
}