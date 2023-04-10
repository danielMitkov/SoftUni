using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            double van = 0;
            double truck = 0;
            double train = 0;
            for (int i = 1; i <= count; ++i) {
                int cargo = int.Parse(Console.ReadLine());
                sum += cargo;
                if (cargo <= 3) {
                    van += cargo;
                } else if (cargo <= 11) {
                    truck += cargo;
                } else if (cargo >= 12) {
                    train += cargo;
                }
            }
            double avg = (van * 200 + truck * 175 + train * 120) / sum;
            van = van / sum * 100;
            truck = truck / sum * 100;
            train = train / sum * 100;

            Console.WriteLine($"{avg:f2}");
            Console.WriteLine($"{van:f2}%");
            Console.WriteLine($"{truck:f2}%");
            Console.WriteLine($"{train:f2}%");
        }
    }
}