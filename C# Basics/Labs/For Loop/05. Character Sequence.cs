using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; ++i) { 
                Console.WriteLine(str[i]);
            }
        }
    }
}