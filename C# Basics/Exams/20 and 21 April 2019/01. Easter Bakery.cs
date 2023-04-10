using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double priceB = double.Parse(Console.ReadLine());
            double kgB = double.Parse(Console.ReadLine());
            double kgS = double.Parse(Console.ReadLine());
            double countE = double.Parse(Console.ReadLine());
            double countM = double.Parse(Console.ReadLine());
            double priceS = priceB * 0.75;
            double priceE = priceB * 1.1;
            double priceM = priceS * 0.2;
            priceB *= kgB;
            priceS *= kgS;
            priceE *= countE;
            priceM *= countM;
            Console.WriteLine($"{priceB + priceS + priceE + priceM:f2}");
        }
    }
}