using System;
using System.Collections.Generic;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            List<string> list = new List<string>();
            list.Add(Console.ReadLine());
            list.Add(Console.ReadLine());
            list.Add(Console.ReadLine());
            list.Reverse();
            foreach (string str in list) {
                Console.Write(str + " ");
            }
        }
    }
}