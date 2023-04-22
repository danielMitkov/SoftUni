﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DefiningClasses;
public class Family {
    public List<Person> People { get; set; } = new List<Person>();
    public void AddMember(Person member) {
        People.Add(member);
    }
    public Person GetOldestMember() {
        return People.MaxBy(x => x.Age);
    }
}