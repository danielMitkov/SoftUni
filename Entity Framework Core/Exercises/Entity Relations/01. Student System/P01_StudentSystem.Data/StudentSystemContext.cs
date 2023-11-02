using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data;

public class StudentSystemContext:DbContext
{
    public StudentSystemContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<Homework> Homeworks { get; set; }

    public DbSet<StudentCourse> StudentsCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(st => new { st.StudentId,st.CourseId });
        });
    }
}
