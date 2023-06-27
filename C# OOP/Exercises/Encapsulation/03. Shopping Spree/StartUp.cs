namespace ShoppingSpree;
public class StartUp
{
    public static void Main(string[] args)
    {
        Dictionary<string,Person> people = new();
        Dictionary<string,Product> products = new();
        string[] dataPeople = Console.ReadLine().Replace(" ","").Split(';',StringSplitOptions.RemoveEmptyEntries);
        foreach(string info in dataPeople)
        {
            string[] data = info.Split('=');
            try
            {
                Person person = new(data[0],double.Parse(data[1]));
                people.Add(person.Name,person);
            }
            catch(ArgumentException err)
            {
                Console.WriteLine(err.Message);
                return;
            }
        }
        string[] dataProducts = Console.ReadLine().Replace(" ","").Split(';',StringSplitOptions.RemoveEmptyEntries);
        foreach(string info in dataProducts)
        {
            string[] data = info.Split('=');
            try
            {
                Product product = new(data[0],double.Parse(data[1]));
                products.Add(product.Name,product);
            }
            catch(ArgumentException err)
            {
                Console.WriteLine(err.Message);
                return;
            }
        }
        string input = string.Empty;
        while((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string namePerson = data[0];
            string nameProduct = data[1];
            Console.WriteLine(people[namePerson].TryAddProduct(products[nameProduct]));
        }
        foreach(var (name, person) in people)
        {
            Console.Write($"{name} - ");
            if(person.Bag.Any())
            {
                Console.WriteLine(string.Join(", ",person.Bag.Select(x => x.Name)));
            }
            else
            {
                Console.WriteLine("Nothing bought");
            }
        }
    }
}