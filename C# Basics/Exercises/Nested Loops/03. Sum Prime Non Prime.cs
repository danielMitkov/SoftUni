using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            int sumPrime = 0;
            int sumPrimeNot = 0;
            while (input != "stop") {
                if (int.Parse(input) < 0) {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }
                if (IsPrime(int.Parse(input))) {
                    sumPrime += int.Parse(input);
                } else {
                    sumPrimeNot += int.Parse(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumPrimeNot}");
        }
        public static bool IsPrime(int number) {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}