using System;
using System.Linq;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            for (int num = 1111; num <= 9999; ++num) {
                bool isValid = true;
                var arr = num.ToString().Select(c => Convert.ToInt32(c.ToString())).ToArray();
                for (int pos = 0; pos < 4; ++pos) {
                    if (arr[pos] == 0 || n % arr[pos] != 0) {
                        isValid = false;
                    }
                }
                if (isValid) {
                    Console.Write(num + " ");
                }
            }
        }
    }
}