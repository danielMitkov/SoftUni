using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            if (n < 20) {
                if (time == "day") {
                    Console.WriteLine("{00:F2}", 0.70 + n * 0.79);
                } else {
                    Console.WriteLine("{00:F2}", 0.70 + n * 0.90);
                }
            } else if (n < 100) {

                Console.WriteLine("{00:F2}", n * 0.09);

            } else{
                Console.WriteLine("{00:F2}", n * 0.06);
            }
        }
    }
}