using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni;
public class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext dbSoftUniContext = new SoftUniContext();
        Console.WriteLine(RemoveTown(dbSoftUniContext));
    }
    public static string RemoveTown(SoftUniContext context)
    {
        var adressesToDelete = context.Addresses
            .Where(a => a.Town.Name == "Seattle")
            .ToArray();

        foreach(var employee in context.Employees)
        {
            if(adressesToDelete.Contains(employee.Address))
            {
                employee.AddressId = null;
            }
        }

        context.Addresses.RemoveRange(adressesToDelete);

        context.Towns.Remove(context.Towns.FirstOrDefault(t => t.Name == "Seattle"));

        context.SaveChanges();

        return $"{adressesToDelete.Count()} addresses in Seattle were deleted";
    }
}
