using System;
class SoftUni {
    static void Main(string[] args) {
        int f = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        for (int i = f; i <= s; i++) {
            Console.Write((char)i + " ");
        }
    }
}