using System;
class Program {
    static void Main(string[] args) {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int sum2 = n1 + n2;
        Console.WriteLine(sum2 - n3);
    }
}