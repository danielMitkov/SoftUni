using System;
class Program {
    static void Main(string[] args) {
        string input = Console.ReadLine();
        Console.WriteLine(count(input));
    }
    static int count(string text) {
        int counter = 0;
        for (int i = 0; i < text.Length; i++) {
            if (text[i] == 'a' || text[i] == 'A') {
                counter++;
            } else if (text[i] == 'e' || text[i] == 'E') {
                counter++;
            } else if (text[i] == 'i' || text[i] == 'I') {
                counter++;
            } else if (text[i] == 'o' || text[i] == 'O') {
                counter++;
            } else if (text[i] == 'u' || text[i] == 'U') {
                counter++;
            } else if (text[i] == 'y' || text[i] == 'Y') {
                counter++;
            }
        }
        return counter;
    }
}