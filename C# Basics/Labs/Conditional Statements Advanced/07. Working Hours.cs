using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string answer = "closed";

            if (hour >= 10 && hour <= 18) {

                switch (day) {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        answer = "open";
                        break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}