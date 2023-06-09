﻿public class Person:IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public Person(string name,int age)
    {
        Name = name;
        Age = age;
    }
    public int CompareTo(Person other)
    {
        if(Name.CompareTo(other.Name) != 0)
        {
            return Name.CompareTo(other.Name);
        }
        return Age.CompareTo(other.Age);
    }
    public override bool Equals(object obj)
    {
        Person other = obj as Person;
        if(other == null)
        {
            return false;
        }
        return GetHashCode() == other.GetHashCode();
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name,Age);
    }
}