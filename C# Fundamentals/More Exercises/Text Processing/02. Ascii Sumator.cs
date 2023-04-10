using System;
using System.Linq;
class SoftUni {
    static void Main() {
        char start = char.Parse(Console.ReadLine());
        char end = char.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        int sum = 0;
        for (int i = 0; i < str.Length; i++) {
            if (str[i] > start && str[i] < end) sum += str[i];
        }
        Console.WriteLine(sum);
    }
}