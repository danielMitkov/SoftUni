using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            int count = 0;
            for (int i = a; i <= b; i++) {
                for (int n = a; n <= b; ++n) {
                    for (int m = a; m <= b; ++m) {
                        if (n != c && m != c && i != c) {
                            Console.Write($"{(char)i}{(char)n}{(char)m} ");
                            count++;
                        }
                    }
                }
            }
            Console.Write(count);
        }
    }
}