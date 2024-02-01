using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models;
public class Task
{
    public Task()
    {
        EmployeesTasks = new HashSet<EmployeeTask>();
    }
    [Key]
    public int Id { get; set; }

    [MaxLength(40)]
    public string Name { get; set; }

    public DateTime OpenDate { get; set; }

    public DateTime DueDate { get; set; }

    public ExecutionType ExecutionType { get; set; }

    public LabelType LabelType { get; set; }

    public int ProjectId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }

    public ICollection<EmployeeTask> EmployeesTasks { get; set; }
}
