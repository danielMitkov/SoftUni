using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());

            if (n == 0 || (n >= 100 && n <= 200)) {

            } else {
                Console.WriteLine("invalid");
            }
        }
    }
}