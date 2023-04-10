using System;
class Program {
    static void Main() {
        string shape = Console.ReadLine();
        if(shape == "square") {
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine(a * a);
        } else if(shape == "rectangle") {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            Console.WriteLine(l * w);
        } else if(shape == "circle") {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.PI * (r * r));
        } else if(shape == "triangle") {
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine((b * h) / 2);
        } else Console.WriteLine("err");
    }
}