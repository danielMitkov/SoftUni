using System;
using System.Linq;
class SoftUni {
    static void Main() {
        for (int n = int.Parse(Console.ReadLine()); n > 0; n--) {
            string input = Console.ReadLine();
            string name = input.Split('@')[1].Split('|')[0];
            string age = input.Split('#')[1].Split('*')[0];
            Console.WriteLine($"{name} is {age} years old.");
        }
    }
}