using System.Reflection;
using System.Text;
namespace Stealer;
public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type clas = Type.GetType(className);
        MethodInfo[] methods = clas.GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
        StringBuilder sb = new();
        foreach(var method in methods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach(var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        return sb.ToString().Trim();
    }
}