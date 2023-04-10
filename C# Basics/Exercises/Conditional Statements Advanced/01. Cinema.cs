using System;
namespace SoftUni {
    internal class Program {
            static int rows = int.Parse(Console.ReadLine());
            static int cols = int.Parse(Console.ReadLine());
            static int seats = rows * cols;
        static void Main(string[] args) {
            string type = Console.ReadLine();
            switch (type) {
                case "Premiere":
                    calc(12.0);
                    break;
                case "Normal":
                    calc(7.5);
                    break;
                case "Discount":
                    calc(5.0);
                    break;
            }
        }
        static void calc(double ticketPrice) {
            Console.WriteLine("{0:F2} leva", seats * ticketPrice);
        }
    }
}