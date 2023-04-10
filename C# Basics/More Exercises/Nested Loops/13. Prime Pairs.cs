using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int r1 = int.Parse(Console.ReadLine());
            int r2 = int.Parse(Console.ReadLine());
            for (int a = n1; a <= n1 + r1; a++) {
                for (int b = n2; b <= n2 + r2; ++b) {
                    if (IsPrime(a) && IsPrime(b)) {
                        Console.WriteLine($"{a}{b}");
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