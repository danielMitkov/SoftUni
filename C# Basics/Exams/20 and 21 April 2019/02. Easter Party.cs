using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double guests = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            if (guests >= 10 && guests <= 15) {
                price -= price * 0.15;
            }
            if (guests > 15 && guests <= 20) {
                price -= price * 0.2;
            }
            if (guests > 20) {
                price -= price * 0.25;
            }
            double cake = budget * 0.1;
            double total = guests * price + cake;
            if (total > budget) {
                Console.WriteLine($"No party! {total - budget:f2} leva needed.");
            } else {
                Console.WriteLine($"It is party time! {budget - total:f2} leva left.");
            }
        }
    }
}