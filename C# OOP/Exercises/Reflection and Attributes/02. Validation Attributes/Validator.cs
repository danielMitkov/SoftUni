using System.Data;
using System.Reflection;
using ValidationAttributes.Attributes;
namespace ValidationAttributes;
public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type clas = obj.GetType();
        PropertyInfo[] propertyInfos = clas
            .GetProperties()
            .Where(p => p.CustomAttributes
            .Any(ca => typeof(MyValidationAttribute)
            .IsAssignableFrom(ca.AttributeType)))
            .ToArray();
        foreach(var property in propertyInfos)
        {
            IEnumerable<MyValidationAttribute> attributes = property
                .GetCustomAttributes(true)
                .Where(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.GetType()))
                .Cast<MyValidationAttribute>();
            foreach(var attribute in attributes)
            {
                if(!attribute.IsValid(property.GetValue(obj)))
                {
                    return false;
                }
            }
        }
        return true;
    }
}