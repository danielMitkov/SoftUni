using System.Reflection;
namespace AuthorProblem;
public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type clas = typeof(StartUp);
        MethodInfo[] methods = clas.GetMethods(BindingFlags.Static|BindingFlags.Public);
        foreach(var method in methods)
        {
            if(method.CustomAttributes.Any(x=>x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach(AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}