using System;
using System.Collections.Generic;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            List<double> list = new List<double>();
            list.Add(double.Parse(Console.ReadLine()));
            list.Add(double.Parse(Console.ReadLine()));
            list.Add(double.Parse(Console.ReadLine()));
            list.Sort();
            list.Reverse();
            foreach (double a in list) {
                Console.WriteLine(a);
            }
        }
    }
}