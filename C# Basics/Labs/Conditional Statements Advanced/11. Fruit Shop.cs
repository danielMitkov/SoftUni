using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            switch (day) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit) {
                        case "banana":
                            Console.WriteLine("{0:F2}", amount * 2.5);
                            break;
                        case "apple":
                            Console.WriteLine("{0:F2}", amount * 1.2);
                            break;
                        case "orange":
                            Console.WriteLine("{0:F2}", amount * 0.85);
                            break;
                        case "grapefruit":
                            Console.WriteLine("{0:F2}", amount * 1.45);
                            break;
                        case "kiwi":
                            Console.WriteLine("{0:F2}", amount * 2.7);
                            break;
                        case "pineapple":
                            Console.WriteLine("{0:F2}", amount * 5.5);
                            break;
                        case "grapes":
                            Console.WriteLine("{0:F2}", amount * 3.85);
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit) {
                        case "banana":
                            Console.WriteLine("{0:F2}", amount * 2.7);
                            break;
                        case "apple":
                            Console.WriteLine("{0:F2}", amount * 1.25);
                            break;
                        case "orange":
                            Console.WriteLine("{0:F2}", amount * 0.9);
                            break;
                        case "grapefruit":
                            Console.WriteLine("{0:F2}", amount * 1.6);
                            break;
                        case "kiwi":
                            Console.WriteLine("{0:F2}", amount * 3.0);
                            break;
                        case "pineapple":
                            Console.WriteLine("{0:F2}", amount * 5.6);
                            break;
                        case "grapes":
                            Console.WriteLine("{0:F2}", amount * 4.2);
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}