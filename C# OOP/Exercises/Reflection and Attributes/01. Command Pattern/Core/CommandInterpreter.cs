using CommandPattern.Core.Contracts;
using System.Reflection;
namespace CommandPattern.Core;
public class CommandInterpreter:ICommandInterpreter
{
    public string Read(string args)
    {
        string[] data = args.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        string commandName = data[0];
        string[] arguments = data.Skip(1).ToArray();
        Type commandClass = Assembly
            .GetEntryAssembly()
            .GetTypes()
            .FirstOrDefault(t=>t.Name == $"{commandName}Command");
        if(commandClass is null)
        {
            return null;
        }
        ICommand commandObj = (ICommand)Activator.CreateInstance(commandClass);
        return commandObj.Execute(arguments);
    }
}