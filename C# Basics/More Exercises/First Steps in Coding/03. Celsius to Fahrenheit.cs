using System;
namespace app{
    internal class Program{
        static void Main(string[] args){
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}",(double)((c*9/5)+32)));
        }
    }
}