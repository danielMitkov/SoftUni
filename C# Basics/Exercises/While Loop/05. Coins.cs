using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int[] types = { 200, 100, 50, 20, 10, 5, 2, 1 };
            double input = double.Parse(Console.ReadLine());
            double change = Math.Floor(input * 100);
            int coins = 0;
            for (int i = 0; i < types.Length; i++) {
                while (change - types[i] >= 0) {
                    change -= types[i];
                    coins++;
                }
            }
            Console.WriteLine(coins);
        }
    }
}