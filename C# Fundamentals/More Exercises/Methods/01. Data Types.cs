using System;
class Program {
    static void Main(string[] args) {
        string type = Console.ReadLine();
        string input = Console.ReadLine();
        switch (type) {
            case "int":
                Console.WriteLine(getResult(int.Parse(input)));
                break;
            case "real":
                Console.WriteLine(getResult(double.Parse(input)));
                break;
            default:
                Console.WriteLine(getResult(input));
                break;
        }
    }
    static int getResult(int num) {
        return num * 2;
    }
    static string getResult(double num) {
        return $"{(num * 1.5):F2}";
    }
    static string getResult(string str) {
        return "$" + str + "$";
    }
}