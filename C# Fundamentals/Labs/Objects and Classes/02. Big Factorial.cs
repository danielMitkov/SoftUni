using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
class SoftUni {
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        BigInteger fac = 1;
        for (int i = 2; i <= n; ++i) {
            fac *= i;
        }
        Console.WriteLine(fac);
    }
}