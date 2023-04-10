using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double money = double.Parse(Console.ReadLine());
            bool man = Console.ReadLine() == "m" ? true : false;
            double age = double.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double cena = 0;
            switch (sport) {
                case "Gym":
                    if (man) {
                        cena = 42;
                    } else {
                        cena = 35;
                    }
                    break;
                case "Boxing":
                    if (man) {
                        cena = 41;
                    } else {
                        cena = 37;
                    }
                    break;
                case "Yoga":
                    if (man) {
                        cena = 45;
                    } else {
                        cena = 42;
                    }
                    break;
                case "Zumba":
                    if (man) {
                        cena = 34;
                    } else {
                        cena = 31;
                    }
                    break;
                case "Dances":
                    if (man) {
                        cena = 51;
                    } else {
                        cena = 53;
                    }
                    break;
                case "Pilates":
                    if (man) {
                        cena = 39;
                    } else {
                        cena = 37;
                    }
                    break;
            }
            if(age <= 19) {
                cena -= cena * 0.2;
            }
            if (cena <= money) {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            } else{
                Console.WriteLine($"You don't have enough money! You need ${cena - money:f2} more.");
            }
        }
    }
}