using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double money = double.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int tickets = 0;
            int others = 0;
            while (text != "End") {
                if (text.Length > 8) {
                    if ((char)text[0] + (char)text[1] > money) {
                        break;
                    }
                    tickets++;
                    money -= (char)text[0] + (char)text[1];
                }
                if (text.Length <= 8) {
                    if ((char)text[0] > money) {
                        break;
                    }
                    others++;
                    money -= (char)text[0];
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(tickets);
            Console.WriteLine(others);
        }
    }
}