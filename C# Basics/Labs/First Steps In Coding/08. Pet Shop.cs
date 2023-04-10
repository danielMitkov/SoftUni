using System;
class Program {
	static void Main() {
		int foodCountDog = int.Parse(Console.ReadLine());
            int foodCountCat = int.Parse(Console.ReadLine());
            double foodSum = (foodCountDog * 2.5) + (foodCountCat * 4);
            Console.WriteLine(foodSum + " lv.");
	}
}