using System.Reflection;
using System.Text;
namespace Stealer;
public class Spy
{
    public string AnalyzeAccessModifiers(string className)
    {
        Type clas = Type.GetType(className);
        StringBuilder sb = new();
        FieldInfo[] fields = clas.GetFields();
        foreach(FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        MethodInfo[] methods = clas.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach(MethodInfo method in methods.Where(x=>x.Name.StartsWith("get") && x.IsPrivate))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach(MethodInfo method in methods.Where(x => x.Name.StartsWith("set") && x.IsPublic))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
}