using System;
using System.Collections.Generic;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string str = Console.ReadLine();
            List<char> list = new List<char>();
            foreach (char c in str.ToCharArray()) {
                list.Add(c);
            }
            list.Reverse();
            foreach (char c in list) {
                Console.Write(c);
            }
        }
    }
}