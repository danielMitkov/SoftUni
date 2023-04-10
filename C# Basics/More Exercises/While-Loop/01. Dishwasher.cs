using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double cleaner = double.Parse(Console.ReadLine()) * 750;
            string text = Console.ReadLine();
            double counter = 1;
            double plates = 0;
            double lther = 0;
            while (text != "End") {
                if(counter < 3) {
                    cleaner -= 5 * int.Parse(text);
                    plates += int.Parse(text);
                    counter++;
                } else {
                    cleaner -= 15 * int.Parse(text);
                    lther += int.Parse(text);
                    counter = 1;
                }
                if (cleaner < 0) {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(cleaner)} ml. more necessary!");
                    return;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine($"Detergent was enough!");
            Console.WriteLine($"{plates} dishes and {lther} pots were washed.");
            Console.WriteLine($"Leftover detergent {cleaner} ml.");
        }
    }
}