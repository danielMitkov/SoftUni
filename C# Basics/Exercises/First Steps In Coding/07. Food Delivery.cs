using System;
class Program {
	static void Main() {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int vegan = int.Parse(Console.ReadLine());
            double sum = (chicken * 10.35) + (fish * 12.4) + (vegan * 8.15);
            sum += (sum * 0.2) + 2.5;
            Console.WriteLine(sum);
	}
}