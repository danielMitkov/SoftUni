using System;
namespace PlayersAndMonsters;
public class StartUp
{
    public static void Main(string[] args)
    {
        Elf elf = new("Bob",100);
        Console.WriteLine(elf);
    }
}