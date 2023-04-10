using System;
class Program {
    static void Main(string[] args) {
        int input = int.Parse(Console.ReadLine());
        PrintTopNumbers(input);
    }
    private static void PrintTopNumbers(int input) {
        bool isDivisable = false;
        bool isOdd = false;
        int sum = 0;
        int currDigit = 0;
        for (int i = 0; i < input; i++) {
            currDigit = i;
            while (currDigit > 0) {
                if ((currDigit % 10) % 2 == 1) {
                    isOdd = true;
                }
                sum += currDigit % 10;
                currDigit /= 10;
            }
            if (sum % 8 == 0) {
                isDivisable = true;
            }
            if (isDivisable == true && isOdd == true) {
                Console.WriteLine(i);
            }
            sum = 0;
            isDivisable = false;
            isOdd = false;
        }
    }
}