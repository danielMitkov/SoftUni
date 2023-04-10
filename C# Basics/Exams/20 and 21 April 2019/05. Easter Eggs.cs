using System;
using System.Collections;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double eggs = double.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int max = 0;
            for (int i = 1; i <= eggs; i++) {
                switch (Console.ReadLine()) {
                    case "red":
                        red++;
                        if (red > max) {
                            max = red;
                        }
                        break;
                    case "orange":
                        orange++;
                        if (orange > max) {
                            max = orange;
                        }
                        break;
                    case "blue":
                        blue++;
                        if (blue > max) {
                            max = blue;
                        }
                        break;
                    case "green":
                        green++;
                        if (green > max) {
                            max = green;
                        }
                        break;
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            if (max == red) {
                Console.WriteLine($"Max eggs: {red} -> red");
            }
            if (max == orange) {
                Console.WriteLine($"Max eggs: {orange} -> orange");
            }
            if (max == blue) {
                Console.WriteLine($"Max eggs: {blue} -> blue");
            }
            if (max == green) {
                Console.WriteLine($"Max eggs: {green} -> green");
            }
        }
    }
}