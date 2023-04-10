using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double needed = double.Parse(Console.ReadLine());
            string price = Console.ReadLine();
            int counter = 1;
            double[] avgCash = { 0, 0 };
            double[] avgCard = { 0, 0 };
            while (price != "End") {
                if(counter % 2 != 0) {//broi
                    if (int.Parse(price) <= 100) {
                        needed -= int.Parse(price);
                        avgCash[0]++;
                        avgCash[1] += int.Parse(price);
                        Console.WriteLine("Product sold!");
                    } else {
                        Console.WriteLine("Error in transaction!");
                    }
                } else {
                    if (int.Parse(price) > 10) {
                        needed -= int.Parse(price);
                        avgCard[0]++;
                        avgCard[1] += int.Parse(price);
                        Console.WriteLine("Product sold!");
                    } else {
                        Console.WriteLine("Error in transaction!");
                    }
                }
                counter++;
                if (needed <= 0) {
                    Console.WriteLine($"Average CS: {avgCash[1] / avgCash[0]:f2}");
                    Console.WriteLine($"Average CC: {avgCard[1] / avgCard[0]:f2}");
                    return;
                }
                price = Console.ReadLine();
            }
            Console.WriteLine("Failed to collect required money for charity.") ;
        }
    }
}