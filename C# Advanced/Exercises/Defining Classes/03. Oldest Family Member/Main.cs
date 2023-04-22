namespace DefiningClasses;
public class StartUp {
    public static void Main() {
        Family family = new Family();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--) {
            string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            int age = int.Parse(data[1]);
            family.AddMember(new Person(name,age));
        }
        Person oldest = family.GetOldestMember();
        Console.Write($"{oldest.Name} {oldest.Age}");
    }
}