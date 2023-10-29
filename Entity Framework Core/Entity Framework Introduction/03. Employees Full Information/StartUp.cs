using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;
public class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext dbSoftUniContext = new SoftUniContext();
        Console.WriteLine(GetEmployeesFullInformation(dbSoftUniContext));
    }
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new 
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new ();
        
        foreach(var em in employees)
        {
            sb.AppendLine($"{em.FirstName} {em.LastName} {em.MiddleName} {em.JobTitle} {em.Salary:F2}");
        }
        return sb.ToString().TrimEnd();
    }
}