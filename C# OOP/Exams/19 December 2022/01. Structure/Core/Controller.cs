using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;
namespace UniversityCompetition.Core;
public class Controller:IController
{
    private SubjectRepository subjects = new();
    private StudentRepository students = new();
    private UniversityRepository universities = new();
    public string AddStudent(string firstName,string lastName)
    {
        if(students.FindByName(firstName + " " + lastName) != null)
        {
            return string.Format(OutputMessages.AlreadyAddedStudent,firstName,lastName);
        }
        IStudent student = new Student(students.Models.Count + 1,firstName,lastName);
        students.AddModel(student);
        return string.Format(OutputMessages.StudentAddedSuccessfully,firstName,lastName,"StudentRepository");
    }
    public string AddSubject(string subjectName,string subjectType)
    {
        if(subjectType != nameof(EconomicalSubject)
            && subjectType != nameof(HumanitySubject)
            && subjectType != nameof(TechnicalSubject))
        {
            return string.Format(OutputMessages.SubjectTypeNotSupported,subjectType);
        }
        if(subjects.FindByName(subjectName) != null)
        {
            return string.Format(OutputMessages.AlreadyAddedSubject,subjectName);
        }
        ISubject subject = null;
        int subjectId = subjects.Models.Count + 1;
        switch(subjectType)
        {
            case "EconomicalSubject":
                subject = new EconomicalSubject(subjectId,subjectName);
                break;
            case "HumanitySubject":
                subject = new HumanitySubject(subjectId,subjectName);
                break;
            case "TechnicalSubject":
                subject = new TechnicalSubject(subjectId,subjectName);
                break;
        }
        subjects.AddModel(subject);
        return string.Format(OutputMessages.SubjectAddedSuccessfully,subjectType,subjectName,subjects.GetType().Name);
    }
    public string AddUniversity(string universityName,string category,int capacity,List<string> requiredSubjects)
    {
        if(universities.FindByName(universityName) != null)
        {
            return string.Format(OutputMessages.AlreadyAddedUniversity,universityName);
        }
        List<int> ids = new();
        foreach(string subjectName in requiredSubjects)
        {
            ids.Add(subjects.FindByName(subjectName).Id);
        }
        IUniversity university = new University(universities.Models.Count + 1,universityName,category,capacity,ids);
        universities.AddModel(university);
        return string.Format(OutputMessages.UniversityAddedSuccessfully,universityName,"UniversityRepository");
    }
    public string ApplyToUniversity(string studentName,string universityName)
    {
        IStudent student = students.FindByName(studentName);
        IUniversity university = universities.FindByName(universityName);
        if(student == null)
        {
            return string.Format(OutputMessages.StudentNotRegitered,student.FirstName,student.LastName);
        }
        if(university == null)
        {
            return string.Format(OutputMessages.UniversityNotRegitered,universityName);
        }
        foreach(int id in university.RequiredSubjects)
        {
            if(!student.CoveredExams.Contains(id))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams,studentName,universityName);
            }
        }
        if(student.University != null && student.University.Name == universityName)
        {
            return string.Format(OutputMessages.StudentAlreadyJoined,
                student.FirstName,student.LastName,universityName);
        }
        student.JoinUniversity(university);
        return string.Format(OutputMessages.StudentSuccessfullyJoined,
            student.FirstName,student.LastName,universityName);
    }
    public string TakeExam(int studentId,int subjectId)
    {
        IStudent student = students.FindById(studentId);
        ISubject subject = subjects.FindById(subjectId);
        if(student == null)
        {
            return OutputMessages.InvalidStudentId;
        }
        if(subject == null)
        {
            return OutputMessages.InvalidSubjectId;
        }
        if(student.CoveredExams.Contains(subjectId))
        {
            return string.Format(OutputMessages.StudentAlreadyCoveredThatExam,
                student.FirstName,student.LastName,subject.Name);
        }
        student.CoverExam(subject);
        return string.Format(OutputMessages.StudentSuccessfullyCoveredExam,
            student.FirstName,student.LastName,subject.Name);
    }
    public string UniversityReport(int universityId)
    {
        IUniversity university = universities.FindById(universityId);
        int admitted = students.Models.Where(x => x.University == university).Count();
        StringBuilder sb = new();
        sb.AppendLine($"*** {university.Name} ***");
        sb.AppendLine($"Profile: {university.Category}");
        sb.AppendLine($"Students admitted: {admitted}");
        sb.Append($"University vacancy: {university.Capacity - admitted}");
        return sb.ToString();
    }
}