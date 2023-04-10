using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            int f = int.Parse(Console.ReadLine());
            int f1 = f / 1000;
            int f2 = f / 100 % 10;
            int f3 = f / 10 % 10;
            int f4 = f % 10;
            int s = int.Parse(Console.ReadLine());
            int s1 = s / 1000;
            int s2 = s / 100 % 10;
            int s3 = s / 10 % 10;
            int s4 = s % 10;
            for (int i = 1; i <= 9; i++) {
                for (int j = 1; j <= 9; j++) {
                    for (int k = 1; k <= 9; k++) {
                        for (int l = 1; l <= 9; l++) {
                            if ((i % 2 != 0 || i == 1) && i >= f1 && i <= s1) {
                                if ((j % 2 != 0 || j == 1) && j >= f2 && j <= s2) {
                                    if ((k % 2 != 0 || k == 1) && k >= f3 && k <= s3) {
                                        if ((l % 2 != 0 || l == 1) && l >= f4 && l <= s4)
                                            Console.Write($"{i}{j}{k}{l} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}