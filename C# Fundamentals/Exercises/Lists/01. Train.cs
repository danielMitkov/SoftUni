using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    public static void Main() {
        var nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        int max = int.Parse(Console.ReadLine());
        string input;
        while ((input = Console.ReadLine()) != "end") {
            string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (command[0] == "Add") {
                nums.Add(int.Parse(command[1]));
            } else {
                for (int i = 0; i < nums.Count; i++) {
                    if (nums[i] + int.Parse(command[0]) <= max) {
                        nums[i] += int.Parse(command[0]);
                        break;
                    }
                }
            }
        }
        Console.WriteLine(string.Join(" ", nums));
    }
}