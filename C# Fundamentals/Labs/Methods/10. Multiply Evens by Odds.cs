using System;
class Program {
    static void Main(string[] args) {
        int num = Math.Abs(int.Parse(Console.ReadLine()));
        Console.WriteLine(GetMultiple(num));
    }
    static int GetMultiple(int num) {
        return GetSumOdds(num) * GetSumEvens(num);
    }
    static int GetSumOdds(int num) {
        int odds = 0;
        while (num != 0) {
            int next = num % 10;
            if (next % 2 != 0) {
                odds += next;
            }
            num /= 10;
        }
        return odds;
    }
    static int GetSumEvens(int num) {
        int evens = 0;
        while (num != 0) {
            int next = num % 10;
            if (next % 2 == 0) {
                evens += next;
            }
            num /= 10;
        }
        return evens;
    }
}