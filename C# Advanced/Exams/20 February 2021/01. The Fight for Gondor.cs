namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int countWaves = int.Parse(Console.ReadLine());
            var plates = new List<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var wave = new List<int>();
            int timer = 3;
            for(int n = countWaves;n > 0;--n)
            {
                wave = new List<int>(Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                timer--;
                if(timer == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                    timer = 3;
                }
                while(wave.Any() && plates.Any())
                {
                    if(wave.Last() > plates[0])
                    {
                        wave[wave.Count - 1] -= plates[0];
                        plates.RemoveAt(0);
                        continue;
                    }
                    if(plates[0] > wave.Last())
                    {
                        plates[0] -= wave.Last();
                        wave.RemoveAt(wave.Count - 1);
                        continue;
                    }
                    if(plates[0] == wave.Last())
                    {
                        wave.RemoveAt(wave.Count - 1);
                        plates.RemoveAt(0);
                    }
                }
                if(!plates.Any())
                {
                    Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                    if(plates.Any())
                    {
                        Console.WriteLine($"Plates left: {string.Join(", ",plates)}");
                    }
                    else
                    {
                        wave.Reverse();
                        Console.WriteLine($"Orcs left: {string.Join(", ",wave)}");
                    }
                    return;
                }
            }
            Console.WriteLine($"The people successfully repulsed the orc's attack.");
            if(plates.Any())
            {
                Console.WriteLine($"Plates left: {string.Join(", ",plates)}");
            }
            else
            {
                wave.Reverse();
                Console.WriteLine($"Orcs left: {string.Join(", ",wave)}");
            }
        }
    }
}
