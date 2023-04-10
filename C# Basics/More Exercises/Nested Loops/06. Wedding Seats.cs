using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            char s = char.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int count = 0;
            for (int a = 65; a <= s; a++) {
                for (int b = 1; b <= r; ++b) {
                    if (b % 2 != 0) {
                        for (int c = 97; c < 97 + m; ++c) {
                            Console.WriteLine($"{(char)a}{b}{(char)c}");
                            count++;
                        }
                    }else {
                        for (int c = 97; c < 97 + m + 2; ++c) {
                            Console.WriteLine($"{(char)a}{b}{(char)c}");
                            count++;
                        }
                    }
                    
                }
                r++;
            }
            Console.WriteLine(count);
        }
    }
}