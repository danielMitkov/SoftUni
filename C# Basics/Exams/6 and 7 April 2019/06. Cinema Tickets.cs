using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string film = Console.ReadLine();
            double tickets = 0;
            int standardGlobal = 0;
            int studentGlobal = 0;
            int kidGlobal = 0;
            while (film != "Finish") {
                double seats = double.Parse(Console.ReadLine());
                int standard = 0;
                int student = 0;
                int kid = 0;
                string type = " ";
                for (double i = seats; i > 0; --i) {
                    type = Console.ReadLine();
                    if (type == "End" || type == "Finish") {
                        break;
                    } else if (type == "standard") {
                        standard++;
                    } else if (type == "student") {
                        student++;
                    } else if (type == "kid") {
                        kid++;
                    }
                    tickets++;
                }
                Console.WriteLine($"{film} - {(((standard + student + kid) / seats) * 100):f2}% full.");
                standardGlobal += standard;
                studentGlobal += student;
                kidGlobal += kid;
                if (type == "Finish") {
                    break;
                }
                film = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {tickets}");
            Console.WriteLine($"{((studentGlobal / tickets) * 100):f2}% student tickets.");
            Console.WriteLine($"{((standardGlobal / tickets) * 100):f2}% standard tickets.");
            Console.WriteLine($"{((kidGlobal / tickets) * 100):f2}% kids tickets.");
        }
    }
}