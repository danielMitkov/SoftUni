using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            bool isSummer = Console.ReadLine() == "summer" ? true : false;
            string destination = "";
            string type = isSummer ? "Camp" : "Hotel";
            double spent = 0;
            if (budget <= 100) {
                destination = "Bulgaria";
                if (isSummer) {
                    spent += budget * 0.3;
                } else {
                    spent += budget * 0.7;
                }
            } else if(budget <= 1000) {
                destination = "Balkans";
                if (isSummer) {
                    spent += budget * 0.4;
                } else {
                    spent += budget * 0.8;
                }
            } else {
                destination = "Europe";
                spent += budget * 0.9;
                type = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {spent:F2}");
        }
    }
}