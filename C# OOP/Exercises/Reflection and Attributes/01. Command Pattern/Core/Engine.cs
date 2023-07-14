﻿using CommandPattern.Core.Contracts;
namespace CommandPattern.Core;
public class Engine:IEngine
{
    private readonly ICommandInterpreter commandInterpreter;
    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }
    public void Run()
    {
        while(true)
        {
            string input = Console.ReadLine();
            string result = commandInterpreter.Read(input);
            if(result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}