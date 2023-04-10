using System;
class Program {
	static void Main() {
            double plastic = (double.Parse(Console.ReadLine()) + 2) * 1.5;
            double paint = double.Parse(Console.ReadLine()) * 14.5;
            paint += paint * 0.1;
            double thinner = double.Parse(Console.ReadLine()) * 5;
            double sum = plastic + paint + thinner + 0.4;
            double workers = double.Parse(Console.ReadLine()) * (sum * 0.3);
            Console.WriteLine(sum + workers);
	}
}