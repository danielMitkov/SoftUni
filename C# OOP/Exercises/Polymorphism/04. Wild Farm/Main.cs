using WildFarm;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;
List<Animal> animals = new();
bool readAnimal = true;
string line;
while((line = Console.ReadLine()) != "End")
{
    string[] data = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    if(readAnimal)
    {
        string animalType = data[0];
        string name = data[1];
        double weight = double.Parse(data[2]);
        switch(animalType)
        {
            case "Hen":
                double wingSize = double.Parse(data[3]);
                animals.Add(new Hen(name,weight,wingSize));
                break;
            case "Owl":
                wingSize = double.Parse(data[3]);
                animals.Add(new Owl(name,weight,wingSize));
                break;
            case "Dog":
                string livingRegion = data[3];
                animals.Add(new Dog(name,weight,livingRegion));
                break;
            case "Mouse":
                livingRegion = data[3];
                animals.Add(new Mouse(name,weight,livingRegion));
                break;
            case "Cat":
                livingRegion = data[3];
                string breed = data[4];
                animals.Add(new Cat(name,weight,livingRegion,breed));
                break;
            case "Tiger":
                livingRegion = data[3];
                breed = data[4];
                animals.Add(new Tiger(name,weight,livingRegion,breed));
                break;
        }
        Console.WriteLine(animals.Last().AskForFood());
        readAnimal = false;
    }
    else
    {
        string foodType = data[0];
        int quantity = int.Parse(data[1]);
        Food food;
        switch(foodType)
        {
            case "Fruit":
                food = new Fruit(quantity);
                break;
            case "Meat":
                food = new Meat(quantity);
                break;
            case "Seeds":
                food = new Seeds(quantity);
                break;
            case "Vegetable":
                food = new Vegetable(quantity);
                break;
        }
        try
        {
            animals.Last().Eat(foodType,quantity);
        }
        catch(ArgumentException err)
        {
            Console.WriteLine(err.Message);
        }
        readAnimal = true;
    }
}
foreach(Animal animal in animals)
{
    Console.WriteLine(animal);
}