Dictionary<string,string> courses = new();
SortedDictionary<string,Dictionary<string,int>> users = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "end of contests")
{
    string[] data = input.Split(':',StringSplitOptions.RemoveEmptyEntries);
    string courseName = data[0];
    string pass = data[1];
    if(!courses.ContainsKey(courseName))
    {
        courses.Add(courseName,pass);
    }
}
while((input = Console.ReadLine()) != "end of submissions")
{
    string[] data = input.Split("=>",StringSplitOptions.RemoveEmptyEntries);
    string nameCourse = data[0];
    string pass = data[1];
    string nameUser = data[2];
    int points = int.Parse(data[3]);
    if(!courses.ContainsKey(nameCourse))
    {
        continue;
    }
    if(pass != courses[nameCourse])
    {
        continue;
    }
    if(!users.ContainsKey(nameUser))
    {
        users.Add(nameUser,new Dictionary<string,int>());
    }
    if(!users[nameUser].ContainsKey(nameCourse))
    {
        users[nameUser].Add(nameCourse,0);
    }
    if(points > users[nameUser][nameCourse])
    {
        users[nameUser][nameCourse] = points;
    }
}
var top = users.OrderByDescending(x => x.Value.Sum(x => x.Value)).First();
Console.WriteLine($"Best candidate is {top.Key} with total {top.Value.Sum(x => x.Value)} points.");
Console.WriteLine("Ranking:");
foreach(var (nameUser, contests) in users)
{
    Console.WriteLine(nameUser);
    foreach(var (course, points) in contests.OrderByDescending(x=>x.Value))
    {
        Console.WriteLine($"#  {course} -> {points}");
    }
}