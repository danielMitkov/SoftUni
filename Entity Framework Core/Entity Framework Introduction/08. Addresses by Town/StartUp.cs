using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;
public class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext dbSoftUniContext = new SoftUniContext();
        Console.WriteLine(GetAddressesByTown(dbSoftUniContext));
    }
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town!.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town!.Name,
                EmployeeCount = a.Employees.Count
            })
            .ToArray();

        StringBuilder sb = new();

        foreach(var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
        }
        return sb.ToString().TrimEnd();
    }
}
