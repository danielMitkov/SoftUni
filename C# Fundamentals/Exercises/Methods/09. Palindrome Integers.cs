using System;
class Program {
    static void Main(string[] args) {
        string input = Console.ReadLine();
        while (input != "END") {
            string reverse = "";
            for (int i = input.Length - 1; i >= 0; i--) {
                reverse += input[i];
            }
            if (reverse == input) {
                Console.WriteLine("true");
            } else {
                Console.WriteLine("false");
            }
            input = Console.ReadLine();
        }
    }
}