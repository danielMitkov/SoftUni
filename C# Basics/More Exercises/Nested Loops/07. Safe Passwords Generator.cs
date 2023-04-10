using System;
namespace Password {
    class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int i = 35;
            int j = 64;
            while (i <= 55) {
                while (j <= 96) {
                    for (int k = 1; k <= a; k++) {
                        for (int l = 1; l <= b; l++) {
                            Console.Write($"{(char)i}{(char)j}{k}{l}{(char)j}{(char)i}|");
                            max--;
                            i++;
                            j++;
                            if (max == 0 || k == a && l == b) {
                                return;
                            }
                            if (i > 55) {
                                i = 35;
                            }
                            if (j > 96) {
                                j = 64;
                            }
                        }
                    }
                }
            }
        }
    }
}