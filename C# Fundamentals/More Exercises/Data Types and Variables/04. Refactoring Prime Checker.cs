using System;
class SoftUni {
    static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        for (int num = 2; num <= n; num++) {
            bool isPrime = IsPrime(num);
            Console.WriteLine($"{num} -> {isPrime.ToString().ToLower()}");
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