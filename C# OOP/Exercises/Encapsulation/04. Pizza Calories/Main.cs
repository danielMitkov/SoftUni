using PizzaCalories;
try
{
    string name = Console.ReadLine().Split()[1];
    string[] doughData = Console.ReadLine().Split();
    string flour = doughData[1];
    string baking = doughData[2];
    decimal grams = decimal.Parse(doughData[3]);
    Pizza pizza = new(name,flour,baking,grams);
    string topping = string.Empty;
    while((topping = Console.ReadLine()) != "END")
    {
        string[] data = topping.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        string type = data[1];
        decimal gramsTopping = decimal.Parse(data[2]);
        pizza.AddTopping(type,gramsTopping);
    }
    pizza.CheckToppings();
    Console.WriteLine($"{pizza.Name} - {pizza.Calories} Calories.");
}
catch(ArgumentException err)
{
    Console.WriteLine(err.Message);
}