using System;
class Program {
	static void Main() {
		string first = Console.ReadLine();
            string second = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            Console.WriteLine($"You are {first} {second}, a {age}-years old person from {town}.");
	}
}