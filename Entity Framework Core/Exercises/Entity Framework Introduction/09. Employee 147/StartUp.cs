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
        Console.WriteLine(GetEmployee147(dbSoftUniContext));
    }
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Select(ep => ep.Project.Name)
                    .ToArray()
            })
            .FirstOrDefault();

        StringBuilder sb = new();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach(string projectName in employee.Projects)
        {
            sb.AppendLine(projectName);
        }
        return sb.ToString().TrimEnd();
    }
}
