using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string thing = Console.ReadLine();

            switch (thing) {
                case "dog":
                    Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}