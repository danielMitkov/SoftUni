using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;
namespace UniversityCompetition.Models;
public class Student:IStudent
{
    private List<int> coveredExams = new();
    private int id;
    private string firstName;
    private string lastName;
    public int Id { get => id; private set => id = value; }
    public string FirstName
    {
        get => firstName;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get => lastName;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            }
            lastName = value;
        }
    }
    public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();
    public IUniversity University { get; private set; }
    public Student(int studentId,string firstName,string lastName)
    {
        Id = studentId;
        FirstName = firstName;
        LastName = lastName;
    }
    public void CoverExam(ISubject subject) => coveredExams.Add(subject.Id);
    public void JoinUniversity(IUniversity university) => University = university;
}