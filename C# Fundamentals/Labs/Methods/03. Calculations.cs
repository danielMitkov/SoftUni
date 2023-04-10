using System;
class Program {
    static void Main(string[] args) {
        string action = Console.ReadLine();
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        if (action == "add") {
            Add(firstNum, secondNum);
        }
        if (action == "multiply") {
            Multiply(firstNum, secondNum);
        }
        if (action == "subtract") {
            Subtract(firstNum, secondNum);
        }
        if (action == "divide") {
            Divide(firstNum, secondNum);
        }
    }
    private static void Divide(int firstNum, int secondNum) {
        int result = firstNum / secondNum;
        Console.WriteLine(result);
    }
    private static void Subtract(int firstNum, int secondNum) {
        int result = firstNum - secondNum;
        Console.WriteLine(result);
    }
    private static void Multiply(int firstNum, int secondNum) {
        int result = firstNum * secondNum;
        Console.WriteLine(result);
    }
    private static void Add(int firstNum, int secondNum) {
        int result = firstNum + secondNum;
        Console.WriteLine(result);
    }
}