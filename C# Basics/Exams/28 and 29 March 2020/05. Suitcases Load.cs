using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double space = double.Parse(Console.ReadLine());
            double count = 0;
            double bags = 0;
            while(true) {
                string text = Console.ReadLine();
                if (text == "End") {
                    Console.WriteLine($"Congratulations! All suitcases are loaded!");
                    break;
                }
                double bag = double.Parse(text);
                count++;
                if (count == 3) {
                    count = 0;
                    bag += bag * 0.1;
                }
                if (space < bag) {
                    Console.WriteLine($"No more space!");
                    break;
                }
                bags++;
                space -= bag;
            }
            Console.WriteLine($"Statistic: {bags} suitcases loaded.");
        }
    }
}