using System;
class Program {
	static void Main() {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;
            double volume = (length * width * height) * 0.001;
            Console.WriteLine(volume * (1 - percent));
	}
}