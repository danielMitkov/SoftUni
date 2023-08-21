﻿using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;
namespace UniversityCompetition.Models;
public class University:IUniversity
{
    private int id;
    private string name;
    private string category;
    private int capacity;
    public int Id { get => id; private set => id = value; }
    public string Name
    {
        get => name;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            }
            name = value;
        }
    }
    public string Category
    {
        get => category;
        private set
        {
            string[] valids = { "Technical","Economical","Humanity" };
            if(!valids.Contains(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed,value));
            }
            category = value;
        }
    }
    public int Capacity
    {
        get => capacity;
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException(ExceptionMessages.CapacityNegative);
            }
            capacity = value;
        }
    }
    public IReadOnlyCollection<int> RequiredSubjects { get; private set; }
    public University(int id,string name,string category,int capacity,IReadOnlyCollection<int> requiredSubjects)
    {
        Id = id;
        Name = name;
        Category = category;
        Capacity = capacity;
        RequiredSubjects = requiredSubjects;
    }
}