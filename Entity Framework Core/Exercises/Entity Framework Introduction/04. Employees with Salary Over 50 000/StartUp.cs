using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;
public class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext dbSoftUniContext = new SoftUniContext();
        Console.WriteLine(GetEmployeesWithSalaryOver50000(dbSoftUniContext));
    }
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ToArray();

        StringBuilder sb = new();

        foreach(var em in employees)
        {
            sb.AppendLine($"{em.FirstName} - {em.Salary:F2}");
        }
        return sb.ToString().TrimEnd();
    }
}