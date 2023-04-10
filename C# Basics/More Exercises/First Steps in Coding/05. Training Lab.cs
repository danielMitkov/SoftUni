using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double duljina = double.Parse(Console.ReadLine());
            double shirochina = double.Parse(Console.ReadLine());
            int hallShiroka = (int)(shirochina * 100 - 100);
            int deskPerRow = hallShiroka / 70;
            int deskPerRowLeft = (int)Math.Floor(hallShiroka % 70.0);
            int hallDuljina = (int)(duljina * 100);
            int rows = hallDuljina / 120;
            int rowsLeft = (int)Math.Floor(hallDuljina % 120.0);
            int seats = deskPerRow * rows - 3;
            Console.WriteLine(seats);
        }
    }
}