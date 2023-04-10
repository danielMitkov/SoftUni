using System;
class Program {
    static void Main(string[] args) {
        ulong n1 = ulong.Parse(Console.ReadLine());
        ulong n2 = ulong.Parse(Console.ReadLine());
        double fN1 = Factoriel(n1);
        double fN2 = Factoriel(n2);
        double output = fN1 / fN2;
        Console.WriteLine($"{output:f2}");
    }
    static ulong Factoriel(ulong n) {
        ulong f = 1;
        for (ulong i = 1; i <= n; i++) {
            f *= i;
        }
        return f;
    }
}