using System;
class Program {
    static void Main(string[] args) {
        double w = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine(GetArea(w, h));
    }
    static double GetArea(double w, double h) {
        return w * h;
    }
}