using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        int e1 = int.Parse(Console.ReadLine());
        int e2 = int.Parse(Console.ReadLine());
        int e3 = int.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        int perH = e1 + e2 + e3;
        int hours = 0;
        int pauseTimer = 0;
        while (people > 0) {
            pauseTimer++;
            hours++;
            if (pauseTimer == 4) {
                pauseTimer = 0;
                continue;
            }
            people -= perH;
        }
        Console.WriteLine($"Time needed: {hours}h.");
    }
}