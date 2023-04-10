using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string f = Console.ReadLine();
            string s = Console.ReadLine();
            double fp = 0;
            double sp = 0;
            while (true) {
                string t = Console.ReadLine();
                if (t == "End of game") {
                    Console.WriteLine($"{f} has {fp} points");
                    Console.WriteLine($"{s} has {sp} points");
                    return;
                }
                double fc = double.Parse(t);
                double sc = double.Parse(Console.ReadLine());
                if (fc > sc) {
                    fp += fc - sc;
                }
                if (fc < sc) {
                    sp += sc - fc;
                }
                if (fc == sc) {
                    Console.WriteLine("Number wars!");
                    fc = double.Parse(Console.ReadLine());
                    sc = double.Parse(Console.ReadLine());
                    if (fc > sc) {
                        Console.WriteLine($"{f} is winner with {fp} points");
                    } else {
                        Console.WriteLine($"{s} is winner with {sp} points");
                    }
                    return;
                }
            }
        }
    }
}