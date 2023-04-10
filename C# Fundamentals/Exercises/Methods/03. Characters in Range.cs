using System;
class Program {
    static void Main(string[] args) {
        char c1 = char.Parse(Console.ReadLine());
        char c2 = char.Parse(Console.ReadLine());
        if (c2 < c1) {
            (c1, c2) = (c2, c1);
        }
        Count(c1, c2);
    }
    static void Count(char c1, char c2) {
        for (int i = c1 + 1; i < c2; ++i) {
            Console.Write((char)i + " ");
        }
    }
}