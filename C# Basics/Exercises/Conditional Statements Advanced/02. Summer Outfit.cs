using System;
namespace SoftUni {
    internal class Program {
        static int temp = int.Parse(Console.ReadLine());
        static string time = Console.ReadLine();
        static void Main(string[] args) {
            if (temp >= 10 && temp <= 18) {
                calc(new string[] { "Sweatshirt" , "Sneakers" }, new string[] { "Shirt", "Moccasins" }, new string[] { "Shirt", "Moccasins" });
            } else if (temp > 18 && temp <= 24) {
                calc(new string[] { "Shirt", "Moccasins" }, new string[] { "T-Shirt", "Sandals" }, new string[] { "Shirt", "Moccasins" });
            } else if (temp >= 25) {
                calc(new string[] { "T-Shirt", "Sandals" }, new string[] { "Swim Suit", "Barefoot" }, new string[] { "Shirt", "Moccasins" });
            }
        }
        static void calc(string[] pairM, string[] pairA, string[] pairE) {
            switch (time) {
                case "Morning":
                    final(pairM[0], pairM[1]);
                    break;
                case "Afternoon":
                    final(pairA[0], pairA[1]);
                    break;
                case "Evening":
                    final(pairE[0], pairE[1]);
                    break;
            }
        }
        static void final(string outfit, string shoes) {
            Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
        }
    }
}