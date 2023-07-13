using System.Reflection;
using System.Text;

namespace Stealer;
public class Spy
{
    public string StealFieldInfo(string className,params string[] fieldNames)
    {
        Type clas = Type.GetType(className);
        FieldInfo[] fields = clas.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        StringBuilder sb = new();
        sb.AppendLine($"Class under investigation: {className}");
        object instance = Activator.CreateInstance(clas);
        foreach(FieldInfo field in fields.Where(x=>fieldNames.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }
        return sb.ToString().Trim();
    }
}