using System;
class Program {
	static void Main() {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine()) + 15;
            if (min >= 60) {
                hour = hour == 23 ? 0 : ++hour;
                min -= 60;
            }
            Console.WriteLine(min < 10 ? hour + ":0" + min : hour + ":" + min);
	}
}