using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int shirochina = int.Parse(Console.ReadLine());
            int duljina = int.Parse(Console.ReadLine());
            int visochina = int.Parse(Console.ReadLine());
            int space = shirochina  duljina  visochina;
            while (space  0) {
                string input = Console.ReadLine();
                if (input == Done) {
                    Console.WriteLine(${space} Cubic meters left.);
                    return;
                }
                space -= int.Parse(input);
            }
            Console.WriteLine($No more free space! You need {Math.Abs(space)} Cubic meters more.);
        }
    }
}