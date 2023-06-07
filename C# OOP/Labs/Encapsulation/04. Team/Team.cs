﻿namespace PersonsInfo;
public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;
    public Team(string name)
    {
        this.name = name;
        firstTeam = new();
        reserveTeam = new();
    }
    public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();
    public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();
    public void AddPlayer(Person person)
    {
        if(person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
    public void PrintTeams()
    {
        Console.WriteLine($"First team has {firstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {reserveTeam.Count} players.");
    }
}