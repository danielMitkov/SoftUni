using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        string line;
        while ((line = Console.ReadLine()) != "end") {
            string[] tokens = line.Split();
            if (tokens[0] == "Delete") {
                nums.RemoveAll(x => x == int.Parse(tokens[1]));
            } else if (tokens[0] == "Insert") {
                nums.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
            }
        }
        Console.WriteLine(string.Join(" ", nums));
    }
}