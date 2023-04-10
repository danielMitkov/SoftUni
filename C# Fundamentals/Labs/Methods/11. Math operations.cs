using System;
class Program {
    static void Main(string[] args) {
        double first = double.Parse(Console.ReadLine());
        char action = char.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        if (action == '+') {
            Console.WriteLine(first + second);
        }
        if (action == '-') {
            Console.WriteLine(first - second);
        }
        if (action == '*') {
            Console.WriteLine(first * second);
        }
        if (action == '/') {
            Console.WriteLine(first / second);
        }
    }
}