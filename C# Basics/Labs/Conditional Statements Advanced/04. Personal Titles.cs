using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            if (gender == 'm') {

                if (age >= 16) {

                    Console.WriteLine("Mr.");
                } else {
                    Console.WriteLine("Master");
                }
            } else {
                if(age >= 16) {

                    Console.WriteLine("Ms.");
                } else {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}