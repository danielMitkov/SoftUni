using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int months = int.Parse(Console.ReadLine());
            double sum = 0;
            double count = 0;
            double elec = 0;
            double water = 0;
            double net = 0;
            double other = 0;
            for (int i = 1; i <= months; ++i) {
                double cost = double.Parse(Console.ReadLine());
                elec += cost;
                water += 20;
                net += 15;
                count++;
                other += (cost + 20 + 15) + ((cost + 20 + 15) * 0.2);
            }
            double avg = (elec + water + net + other)/months;
            Console.WriteLine($"Electricity: {elec:f2} lv");
            Console.WriteLine($"Water: {water:f2} lv");
            Console.WriteLine($"Internet: {net:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {avg:f2} lv");
        }
    }
}