using System;
using System.Linq;
using System.Collections.Generic;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var personCapacities = new List<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var platesCapacities = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wasted = 0;
            while(personCapacities.Any() && platesCapacities.Any())
            {
                int plate = platesCapacities.Pop();
                personCapacities[0] -= plate;
                if(personCapacities[0] <= 0)
                {
                    wasted += Math.Abs(personCapacities[0]);
                    personCapacities.RemoveAt(0);
                }
            }
            if(!personCapacities.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ",platesCapacities)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ",personCapacities)}");
            }
            Console.WriteLine($"Wasted grams of food: {wasted}");
        }
    }
}
