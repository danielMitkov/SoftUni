using Animals.Animals;
using Animals.Animals.Cats;
using System;

namespace Animals;
public class StartUp
{
    public static void Main(string[] args)
    {
        string input = string.Empty;
        while((input = Console.ReadLine()) != "Beast!")
        {
            string type = input;
            string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            int age = int.Parse(data[1]);
            string gender = data[2];
            try
            {
                switch(type)
                {
                    case "Dog":
                        Console.WriteLine(new Dog(name,age,gender));
                        break;
                    case "Cat":
                        Console.WriteLine(new Cat(name,age,gender));
                        break;
                    case "Frog":
                        Console.WriteLine(new Frog(name,age,gender));
                        break;
                    case "Kittens":
                        Console.WriteLine(new Kitten(name,age));
                        break;
                    case "Tomcat":
                        Console.WriteLine(new Tomcat(name,age));
                        break;
                }
            }
            catch(ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
        }
    }
}