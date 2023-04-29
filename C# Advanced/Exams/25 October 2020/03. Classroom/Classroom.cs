using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get => students.Count; }
        public string RegisterStudent(Student student)
        {
            if(Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName,string lastName)
        {
            var obj = students.FirstOrDefault(x=>x.FirstName==firstName&&x.LastName==lastName);
            if(obj != null)
            {
                students.Remove(obj);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            var list = students.Where(x => x.Subject == subject).ToList();
            if(!list.Any())
            {
                return "No students enrolled for the subject";
            }
            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach(var obj in list)
            {
                sb.AppendLine($"{obj.FirstName} {obj.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName,string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

    }
}
