using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += hours * 60 + 30;
            int finalHour = minutes / 60;
            finalHour = finalHour >= 24 ? finalHour - 24 : finalHour;
            int finalMinute = minutes % 60;
            finalMinute = finalMinute >= 60 ? finalMinute - 60 : finalMinute;
            Console.WriteLine($"{finalHour}:{finalMinute:d2}");
        }
    }
}