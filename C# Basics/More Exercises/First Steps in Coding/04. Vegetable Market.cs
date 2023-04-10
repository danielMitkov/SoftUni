using System;
namespace app{
    internal class Program{
        static void Main(string[] args){
            double vegiePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegieKilos = int.Parse(Console.ReadLine());
            int fruitKilos = int.Parse(Console.ReadLine());
            vegiePrice*=vegieKilos;
            fruitPrice*=fruitKilos;
            Console.WriteLine(String.Format("{0:0.00}",(vegiePrice + fruitPrice)/1.94));
        }
    }
}