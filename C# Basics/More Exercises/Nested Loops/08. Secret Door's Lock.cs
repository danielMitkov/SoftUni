using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            b = b > 7 ? 7 : b;
            for (int i = 2; i <= a; i++) {
                for (int n = 2; n <= b; ++n) {
                    for (int m = 2; m <= c; ++m) {
                        if (i % 2 == 0 && m % 2 == 0 && IsPrime(n)) {
                            Console.WriteLine($"{i} {n} {m}");
                        }
                    }
                }
            }
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