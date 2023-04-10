using System;
class Program {
	static void Main() {
		double meters = double.Parse(Console.ReadLine());
            double priceFull = meters * 7.61;
            double discount = priceFull * 0.18;
            double priceFinal = priceFull - discount;
            Console.WriteLine($"The final price is: {priceFinal} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
	}
}