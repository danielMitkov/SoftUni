using System;
class Program {
	static void Main() {
            int pageCount = int.Parse(Console.ReadLine());
            int pageHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine((pageCount / pageHour) / days);
	}
}