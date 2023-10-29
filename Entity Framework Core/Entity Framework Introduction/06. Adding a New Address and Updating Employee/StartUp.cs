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
        Console.WriteLine(AddNewAddressToEmployee(dbSoftUniContext));
    }
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        Employee? employeeNakov = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        employeeNakov!.Address = address;

        context.SaveChanges();

        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => new
            {
                e.Address!.AddressText
            })
            .ToArray();

        StringBuilder sb = new();

        foreach(var em in employees)
        {
            sb.AppendLine(em.AddressText);
        }
        return sb.ToString().TrimEnd();
    }
}