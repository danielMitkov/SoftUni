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
        Console.WriteLine(DeleteProjectById(dbSoftUniContext));
    }
    public static string DeleteProjectById(SoftUniContext context)
    {
        context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(ep => ep.ProjectId == 2));

        context.Projects.Remove(context.Projects.Find(2));

        context.SaveChanges();

        var projectNames = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return string.Join(Environment.NewLine,projectNames);
    }
}
