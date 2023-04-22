using System;
namespace Date_Modifier;
public class StartUp {
    public static void Main() {
        string start = Console.ReadLine();
        string end = Console.ReadLine();
        Console.Write(DateModifier.GetDiff(start,end));
    }
}