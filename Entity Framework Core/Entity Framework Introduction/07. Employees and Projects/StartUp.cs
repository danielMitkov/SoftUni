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
        Console.WriteLine(GetEmployeesInPeriod(dbSoftUniContext));
    }
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })
                    .ToArray()//select only the rows and columns you need but dont proccess the data in the database
            })
            .ToArray();

        StringBuilder sb = new();

        foreach(var em in employees)
        {
            sb.AppendLine($"{em.FirstName} {em.LastName} - Manager: {em.ManagerFirstName} {em.ManagerLastName}");

            foreach(var p in em.Projects)
            {
                string endDate = p.EndDate.HasValue ? $"{p.EndDate:M/d/yyyy h:mm:ss tt}" : "not finished";

                sb.AppendLine($"--{p.Name} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {endDate}");
            }
        }
        return sb.ToString().TrimEnd();
    }
}
