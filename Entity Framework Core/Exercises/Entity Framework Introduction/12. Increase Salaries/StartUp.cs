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
        Console.WriteLine(IncreaseSalaries(dbSoftUniContext));
    }
    public static string IncreaseSalaries(SoftUniContext context)
    {
        string[] departmentNames = { "Engineering","Tool Design","Marketing","Information Services" };

        var employeesBefore = context.Employees
            .Where(e => departmentNames.Contains(e.Department.Name))
            .ToArray();

        foreach(var e in employeesBefore)
        {
            e.Salary += e.Salary * 0.12m;
        }
        context.SaveChanges();

        var employeesAfter = context.Employees
            .Where(e => departmentNames.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new();

        foreach(var e in employeesAfter)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
        }
        return sb.ToString().TrimEnd();
    }
}
