using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        string str = Console.ReadLine();
        List<char> list = new List<char>();
        if (str.Length % 2 == 0) {
            list.Add(str[str.Length / 2 - 1]);
            list.Add(str[str.Length / 2]);
        } else {
            list.Add(str[str.Length / 2]);
        }
        list.ForEach(x => Console.Write(x));
    }
}