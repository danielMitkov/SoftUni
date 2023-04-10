using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            switch (op) {
                case '+':
                    string oddPlus = (n1 + n2) % 2 == 0 ? "even" : "odd";
                    Console.WriteLine($"{n1} + {n2} = {n1 + n2} - {oddPlus}");
                    break;
                case '-':
                    string oddMinus = (n1 - n2) % 2 == 0 ? "even" : "odd";
                    Console.WriteLine($"{n1} - {n2} = {n1 - n2} - {oddMinus}");
                    break;
                case '*':
                    string oddMult = (n1 * n2) % 2 == 0 ? "even" : "odd";
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2} - {oddMult}");
                    break;
                case '/':
                    if (n1 == 0) {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    } else {
                        Console.WriteLine($"{n1} / {n2} = {(n1 / n2):F2}");
                    }
                    break;
                case '%':
                    if (n1 == 0) {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    } else {
                        Console.WriteLine($"{n1} % {n2} = {n1 % n2}");
                    }
                    break;
            }
        }
    }
}