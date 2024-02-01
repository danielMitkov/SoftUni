// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context,string xmlString)
        {
            ImportProjectDto[] projectDtos = XmlDeserialize<ImportProjectDto[]>(xmlString,"Projects");

            List<Project> projects = new();

            StringBuilder sb = new();

            foreach(ImportProjectDto projectDto in projectDtos)
            {
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate
                    ,@"dd/MM/yyyy"
                    ,CultureInfo.InvariantCulture
                    ,DateTimeStyles.None,
                    out DateTime projectOpenDate);

                bool isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate
                    ,@"dd/MM/yyyy"
                    ,CultureInfo.InvariantCulture
                    ,DateTimeStyles.None,
                    out DateTime projectDueDate);

                if(!IsValid(projectDto)
                    || !isProjectOpenDateValid
                    || (!string.IsNullOrEmpty(projectDto.DueDate) && !isProjectDueDateValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };
                foreach(ImportTaskDto taskDto in projectDto.Tasks)
                {
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate
                        ,@"dd/MM/yyyy"
                        ,CultureInfo.InvariantCulture
                        ,DateTimeStyles.None,
                        out DateTime taskOpenDate);

                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate
                        ,@"dd/MM/yyyy"
                        ,CultureInfo.InvariantCulture
                        ,DateTimeStyles.None,
                        out DateTime taskDueDate);

                    bool isExecutionTypeValid = Enum.TryParse(taskDto.ExecutionType,out ExecutionType executionType);
                    bool isLabelTypeValid = Enum.TryParse(taskDto.LabelType,out LabelType labelType);

                    if(!IsValid(taskDto)
                        || !isTaskOpenDateValid
                        || !isTaskDueDateValid
                        || !isExecutionTypeValid
                        || !isLabelTypeValid
                        || taskOpenDate < projectOpenDate
                        || (!string.IsNullOrEmpty(projectDto.DueDate) && taskDueDate > projectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    project.Tasks.Add(new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = executionType,
                        LabelType = labelType
                    });
                }
                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject,project.Name,project.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context,string jsonString)
        {
            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString)!;

            List<Employee> employees = new();
            StringBuilder sb = new();

            foreach(ImportEmployeeDto employeeDto in employeeDtos)
            {
                if(!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };
                int[] tasksIds = context.Tasks.Select(t => t.Id).ToArray();

                foreach(int taskId in employeeDto.Tasks.Distinct())
                {
                    if(!tasksIds.Contains(taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        TaskId = taskId
                    });
                }
                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee,employee.Username,employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static T XmlDeserialize<T>(string xml,string rootName)
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringReader reader = new(xml);

            return (T)serializer.Deserialize(reader)!;
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto,validationContext,validationResult,true);
        }
    }
}
