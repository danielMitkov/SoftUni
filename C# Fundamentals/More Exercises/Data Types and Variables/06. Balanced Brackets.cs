using System;
class SoftUni {
    static void Main(string[] args){
        int openCount = 0;
        int closeCount = 0;
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            string input = Console.ReadLine();
            if (input == "(") {
                openCount++;
            } else if (input == ")") {
                closeCount++;
                if (openCount - closeCount != 0) {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
        }
        if (openCount == closeCount) {
            Console.WriteLine("BALANCED");
        } else {
            Console.WriteLine("UNBALANCED");
        }
    }
}