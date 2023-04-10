using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string target = Console.ReadLine();
            string book = Console.ReadLine();
            int checkedCount = 0;
            bool isFound = false;
            while (book != "No More Books") {
                if (book == target) {
                    isFound = true;
                    break;
                }
                checkedCount++;
                book = Console.ReadLine();
            }
            if (isFound) {
                Console.WriteLine($"You checked {checkedCount} books and found it.");
            } else {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {checkedCount} books.");
            }
        }
    }
}