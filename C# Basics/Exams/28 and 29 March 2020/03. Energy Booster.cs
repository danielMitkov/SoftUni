using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            string what = Console.ReadLine();
            bool isBig = Console.ReadLine() == "big" ? true : false;
            double setove = double.Parse(Console.ReadLine());
            double cena = 0;
            switch (what) {
                case "Watermelon":
                    if (!isBig) {
                        cena = 56;
                    } else {
                        cena = 28.7;
                    }
                    break;
                case "Mango":
                    if (!isBig) {
                        cena = 36.66;
                    } else {
                        cena = 19.6;
                    }
                    break;
                case "Pineapple":
                    if (!isBig) {
                        cena = 42.1;
                    } else {
                        cena = 24.8;
                    }
                    break;
                case "Raspberry":
                    if (!isBig) {
                        cena = 20;
                    } else {
                        cena = 15.2;
                    }
                    break;
            }
            if(isBig) {
                cena *= 5;
            } else {
                cena *= 2;
            }
            cena *= setove;
            if (cena >= 400 && cena <= 1000) {
                cena -= cena * 0.15;
            }else if (cena > 1000) {
                cena -= cena * 0.5;
            }
            Console.WriteLine($"{cena:f2} lv.");
        }
    }
}