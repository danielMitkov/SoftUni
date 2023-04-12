using System;
using System.Linq;
using System.Collections.Generic;
class SoftUni {
    static void Main() {
        List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        string command = Console.ReadLine();
        int numberOfMoves = 0;
        while (true) {
            if (command == "end") {
                break;
            }
            numberOfMoves++;
            string[] indexes = command.Split();
            int index1 = int.Parse(indexes[0]);
            int index2 = int.Parse(indexes[1]);
            if (index1 >= 0 && index2 >= 0 && index1 < input.Count && index2 < input.Count && index1 != index2) {
                if (input[index1] == input[index2]) {
                    Console.WriteLine($"Congrats! You have found matching elements - {input[index1]}!");
                    if (index1 > index2) {
                        input.RemoveAt(index1);
                        input.RemoveAt(index2);
                    } else {
                        input.RemoveAt(index2);
                        input.RemoveAt(index1);
                    }
                    if (input.Count == 0) {
                        Console.WriteLine($"You have won in {numberOfMoves} turns!");
                        return;
                    }
                } else if (input[index1] != input[index2]) {
                    Console.WriteLine("Try again!");
                }
            } else {
                input.Insert(input.Count / 2, $"-{numberOfMoves}a");
                input.Insert(input.Count / 2, $"-{numberOfMoves}a");
                Console.WriteLine("Invalid input! Adding additional elements to the board");
            }
            //Console.WriteLine(String.Join(" ", input));
            command = Console.ReadLine();
        }
        Console.WriteLine("Sorry you lose :(");
        Console.WriteLine(String.Join(" ", input));
    }
}