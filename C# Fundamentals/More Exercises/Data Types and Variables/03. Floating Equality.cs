using System;
class SoftUni {
    static void Main(string[] args){
        double eps = 0.000001;
        double n1 = double.Parse(Console.ReadLine());
        double n2 = double.Parse(Console.ReadLine());
        if (Math.Abs(n1 - n2) < eps) {
            Console.WriteLine("True");
        } else {
            Console.WriteLine("False");
        }
    }
}