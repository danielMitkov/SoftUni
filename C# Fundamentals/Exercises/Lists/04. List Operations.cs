using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        string input;
        while ((input = Console.ReadLine()) != "End") {
            var args = input.Split(' ').ToList();
            switch (args[0]) {
                case "Add":
                    nums.Add(int.Parse(args[1]));
                    break;
                case "Insert":
                    if (int.Parse(args[2]) >= 0 && int.Parse(args[2]) <= nums.Count - 1) {
                        nums.Insert(int.Parse(args[2]), int.Parse(args[1]));
                    } else {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Remove":
                    if (int.Parse(args[1]) >= 0 && int.Parse(args[1]) <= nums.Count - 1) {
                        nums.RemoveAt(int.Parse(args[1]));
                    } else {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Shift":
                    if (args[1] == "left") {
                        for (int i = 0; i < int.Parse(args[2]); ++i) {
                            nums.Add(nums[0]);
                            nums.RemoveAt(0);
                        }
                    } else {
                        for (int i = 0; i < int.Parse(args[2]); ++i) {
                            nums.Insert(0, nums[nums.Count - 1]);
                            nums.RemoveAt(nums.Count - 1);
                        }
                    }
                    break;
            }
        }
        Console.WriteLine(String.Join(' ', nums));
    }
}