using System;
class Program {
	static void Main() {
            double depositSum = double.Parse(Console.ReadLine());
            int depositMonths = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;
            double sum = depositSum + depositMonths * ((depositSum * percent) / 12);
            Console.WriteLine(sum);
	}
}