using System;
class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        for (int row = 1; row <= n; row++) {
            PrintCols(row);
        }
        for (int row = n - 1; row >= 1; row--) {
            PrintCols(row);
        }
    }
    static void PrintCols(int row) {
        for (int col = 1; col <= row; col++) {
            Console.Write(col + " ");
        }
        Console.WriteLine();
    }
}