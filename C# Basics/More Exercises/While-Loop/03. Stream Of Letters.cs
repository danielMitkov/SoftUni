using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string text = Console.ReadLine();
            string first = "";
            bool metC = false;
            bool metO = false;
            bool metN = false;
            while (text != "End") {
                bool addText = true;
                if (char.Parse(text) < 65 || (char.Parse(text) > 90 && char.Parse(text) < 97) || char.Parse(text) > 122) {
                    addText = false;
                }
                if (text == "c" && metC) {
                    first += text;
                    addText = false;
                } else if (text == "o" && metO) {
                    first += text;
                    addText = false;
                } else if (text == "n" && metN) {
                    first += text;
                    addText = false;
                }
                if (text == "c" && !metC) {
                    metC = true;
                    addText = false;
                } else if (text == "o" && !metO) {
                    metO = true;
                    addText = false;
                } else if (text == "n" && !metN) {
                    metN = true;
                    addText = false;
                }
                if (metC && metO && metN) {
                    Console.Write(first + " ");
                    first = "";
                    metC = false;
                    metO = false;
                    metN = false;
                    addText = false;
                }
                if (addText) {
                    first += text;
                }
                text = Console.ReadLine();
            }
        }
    }
}