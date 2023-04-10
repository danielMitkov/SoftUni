using System;
class Program {
	static void Main() {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            if (num1 > num2) Console.WriteLine(num1);
            else Console.WriteLine(num2);
	}
}