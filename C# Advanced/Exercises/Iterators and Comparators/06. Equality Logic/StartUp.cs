HashSet<Person> peopleHashSet = new();
SortedSet<Person> peopleSortedSet = new();
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
    string name = data[0];
    int age = int.Parse(data[1]);
    peopleHashSet.Add(new Person(name,age));
    peopleSortedSet.Add(new Person(name,age));
}
Console.WriteLine(peopleSortedSet.Count);
Console.WriteLine(peopleHashSet.Count);