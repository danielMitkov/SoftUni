using System;
class Program {
	static void Main() {
		int timeFirst = int.Parse(Console.ReadLine());
            int timeSecond = int.Parse(Console.ReadLine());
            int timeThird = int.Parse(Console.ReadLine());
            int time = timeFirst + timeSecond + timeThird;
            int minutes = 0;
            string seconds = "";
            while (time >= 60) { 
                minutes++;
                time -= 60;
            }
            seconds = time < 10 ? "0" + time : "" + time;
            Console.WriteLine($"{minutes}:{seconds}");
	}
}