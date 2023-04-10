using System;
class Program {
    static void Main(string[] args) {
        string input = Console.ReadLine();
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        Console.WriteLine(GetMax(input, first, second));
    }
    static string GetMax(string input, string first, string second) {
        switch (input) {
            case "int":
                return (Math.Max(int.Parse(first), int.Parse(second))).ToString();
            case "char":
            case "string":
                return first[0] > second[0] ? first : second;
        }
        return null;
    }
}