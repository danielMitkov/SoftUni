using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double days = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double count = 0;
            double cookies = 0;
            double eatDog = 0;
            double eatCat = 0;
            for (int i = 0; i < days; i++) {
                double dog = double.Parse(Console.ReadLine());
                double cat = double.Parse(Console.ReadLine());
                eatDog += dog;
                eatCat += cat;
                count++;
                if (count == 3) {
                    cookies += (dog + cat) * 0.1;
                    count = 0;
                }
            }
            Console.WriteLine($"Total eaten biscuits: {Math.Round(cookies)}gr.");
            Console.WriteLine($"{(eatDog + eatCat) / food * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{eatDog / (eatDog + eatCat) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{eatCat / (eatDog + eatCat) * 100:f2}% eaten from the cat.");
        }
    }
}