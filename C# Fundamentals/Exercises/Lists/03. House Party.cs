using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        int numberOfGuests = int.Parse(Console.ReadLine());
        List<string> names = new List<string>();
        for (int i = 0; i < numberOfGuests; i++) {
            string message = Console.ReadLine();
            List<string> messages = message
            .Split()
            .ToList();
            if (messages[2] == "going!") {
                if (names.Contains(messages[0])) {
                    Console.WriteLine($"{messages[0]} is already in the list!");
                } else {
                    names.Add(messages[0]);
                }
            }
            if ((messages[2] == "not")) {
                if (names.Contains(messages[0])) {
                    names.Remove(messages[0]);
                } else {
                    Console.WriteLine($"{messages[0]} is not in the list!");
                }
            }
        }
        foreach (string item in names) {
            Console.WriteLine(item);
        }
    }
}