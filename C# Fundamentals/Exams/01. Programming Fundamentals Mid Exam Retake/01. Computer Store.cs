using System;
class SoftUni {
    static void Main() {
        decimal costs = 0m;
        string input = Console.ReadLine();
        while (true) {
            if (input == "special" || input == "regular") {
                break;
            }
            decimal price = decimal.Parse(input);
            if (price < 0) {
                Console.WriteLine("Invalid price!");
            } else {
                costs += price;
            }
            input = Console.ReadLine();
        }
        var taxes = costs * 0.2m;
        var total = costs + taxes;
        total = input == "special" ? total * 0.9m : total;
        if (total <= 0m) {
            Console.WriteLine("Invalid order!");
        } else {
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {costs:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}