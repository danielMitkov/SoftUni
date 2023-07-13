using System.Reflection;
using System.Text;
namespace Stealer;
public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type clas = Type.GetType(className);
        MethodInfo[] methods = clas.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        StringBuilder sb = new();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {clas.BaseType.Name}");
        foreach(var method in methods)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString().Trim();
    }
}