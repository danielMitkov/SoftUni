using System;
class Program {
    static void Main(string[] args) {
        string str = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        Console.Write(GetStr(str, n));
    }
    static string GetStr(string str, int n) {
        string output = "";
        for (int i = 0; i < n; i++) {
            output = output + str;
        }
        return output;
    }
}