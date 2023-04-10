using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double juniors = double.Parse(Console.ReadLine());
            double seniors = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            bool isCross = false;
            switch (type) {
                case "trail":
                    juniors *= 5.5;
                    seniors *= 7;
                    break;
                case "cross-country":
                    if (juniors + seniors >= 50) {
                        isCross = true;
                    }
                    juniors *= 8;
                    seniors *= 9.5;
                    break;
                case "downhill":
                    juniors *= 12.25;
                    seniors *= 13.75;
                    break;
                case "road":
                    juniors *= 20;
                    seniors *= 21.5;
                    break;
            }
            double sum = juniors + seniors;
            if (isCross) {
                sum -= sum * 0.25;
            }
            sum -= sum * 0.05;
            Console.WriteLine($"{sum:f2}");
        }
    }
}