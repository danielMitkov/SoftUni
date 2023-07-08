﻿using Raiding.Heroes;
namespace Raiding;
public static class HeroFactory
{
    public static Hero GetHero(string type, string name)
    {
        switch(type)
        {
            case "Druid":
                return new Druid(name);
            case "Paladin":
                return new Paladin(name);
            case "Rogue":
                return new Rogue(name);
            case "Warrior":
                return new Warrior(name);
            default:
                throw new ArgumentException("Invalid hero!");
        }
    }
}