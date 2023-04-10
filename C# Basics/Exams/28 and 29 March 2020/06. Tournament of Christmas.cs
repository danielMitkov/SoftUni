using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            int days = int.Parse(Console.ReadLine());
            int allWin = 0;
            int allLose = 0;
            double allMoney = 0;
            for (int i = 1; i <= days; i++) {
                int win = 0;
                int lose = 0;
                double money = 0;
                while (true) {
                    if (Console.ReadLine() == "Finish") {
                        break;
                    }
                    if (Console.ReadLine() == "win") {
                        win++;
                        money += 20;
                    } else {
                        lose++;
                    }
                }
                if (win > lose) {
                    money *= 1.1;
                    allWin++;
                } else {
                    allLose++;
                }
                allMoney += money;
            }
            if (allWin > allLose) {
                allMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {allMoney:F2}");
            } else {
                Console.WriteLine($"You lost the tournament! Total raised money: {allMoney:F2}");
            }
        }
    }
}