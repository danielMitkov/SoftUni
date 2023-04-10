using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double guests = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int breads = (int)Math.Ceiling(guests / 3);
            double eggs = guests * 2;
            double pbreads = breads * 4;
            double peggs = eggs * 0.45;
            double total = pbreads + peggs;
            if (total > budget) {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {total - budget:f2} lv. more.");
            } else {
                Console.WriteLine($"Lyubo bought {breads} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {budget - total:f2} lv. left.");
            }
        }
    }
}