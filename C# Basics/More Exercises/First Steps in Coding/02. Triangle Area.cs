using System;
namespace app{
    internal class Program{
        static void Main(string[] args){
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            
            Console.WriteLine(String.Format("{0:0.00}",a*h/2));
        }
    }
}