using System;
namespace SoftUni {
    internal class Program {
        static string town = Console.ReadLine();
        static double sales = double.Parse(Console.ReadLine());
        static void Main(string[] args) {
            switch (town) {
                case "Sofia":
                    calc(5, 7, 8, 12);
                    break;
                case "Varna":
                    calc(4.5, 7.5, 10, 13);
                    break;
                case "Plovdiv":
                    calc(5.5, 8, 12, 14.5);
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        static void calc(double m0, double m500, double m1000, double m10000) {

            if (sales >= 0 && sales <= 500) {

                Console.WriteLine("{0:F2}", sales * (m0 / 100));

            } else if (sales > 500 && sales <= 1000) {

                Console.WriteLine("{0:F2}", sales * (m500 / 100));

            } else if (sales > 1000 && sales <= 10000) {

                Console.WriteLine("{0:F2}", sales * (m1000 / 100));

            } else if (sales > 10000) {

                Console.WriteLine("{0:F2}", sales * (m10000 / 100));
            } else {
                Console.WriteLine("error");
            }
        }
    }
}