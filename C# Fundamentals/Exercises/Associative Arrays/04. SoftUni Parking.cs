using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var data = new Dictionary<string, string>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var line = Console.ReadLine().Split(' ');
            if (line[0] == "register") {
                if (data.ContainsKey(line[1]))
                    Console.WriteLine($"ERROR: already registered with plate number {data[line[1]]}");
                else {
                    data[line[1]] = line[2];
                    Console.WriteLine($"{line[1]} registered {data[line[1]]} successfully");
                }
            }else if (line[0] == "unregister") {
                if (!data.ContainsKey(line[1]))
                    Console.WriteLine($"ERROR: user {line[1]} not found");
                else {
                    data.Remove(line[1]);
                    Console.WriteLine($"{line[1]} unregistered successfully");
                }
            }
        }
        Console.Write(String.Join('\n', data
            .Select(x => $"{x.Key} => {x.Value}")));
    }
}