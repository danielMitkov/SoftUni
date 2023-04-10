using System;
class Program {
	static void Main() {
            double pens = int.Parse(Console.ReadLine()) * 5.8;
            double markers = int.Parse(Console.ReadLine()) * 7.2;
            double cleaner = int.Parse(Console.ReadLine()) * 1.2;
            double discount = double.Parse(Console.ReadLine()) / 100;
            double sum = pens + markers + cleaner;
            Console.WriteLine(sum - (sum * discount));
	}
}