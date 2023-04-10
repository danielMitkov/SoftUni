using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var data = Console.ReadLine().Split('\\');
        data = data[data.Length - 1].Split('.');
        Console.WriteLine($"File name: {data[0]}\nFile extension: {data[1]}");
    }
}