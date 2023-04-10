using System;
class Program {
    static void Main(string[] args) {
        int n1 = 0;
        int n2 = 0;
        int n3 = 1;
        int n = int.Parse(Console.ReadLine());
        if (n > 0) {
            Console.Write(1 + " ");
        }
        for (int i = n; i > 1; --i) {
            int num = n1 + n2 + n3;
            Console.Write(num + " ");
            n1 = n2;
            n2 = n3;
            n3 = num;
        }
    }
}