using System;
class Program {
    static void Main(string[] args) {
        double number = double.Parse(Console.ReadLine());
        double power = double.Parse(Console.ReadLine());
        double result = raiseToPower(number, power);
        Console.WriteLine(result);
    }
    static double raiseToPower(double number, double power) {
        return Math.Pow(number, power);
    }
}