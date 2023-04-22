﻿namespace DefiningClasses;
public class Cargo
{
    private string type;
    private int weight;
    public Cargo(string type,int weight)
    {
        this.type = type;
        this.weight = weight;
    }
    public string Type { get => type; }
    public int Weight { get => weight; }
}