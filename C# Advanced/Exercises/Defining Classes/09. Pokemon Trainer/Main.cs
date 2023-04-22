namespace DefiningClasses;
public class StartUp
{
    public static void Main()
    {
        Dictionary<string,Trainer> trainers = new();
        string line = string.Empty;
        while((line = Console.ReadLine())!= "Tournament")
        {
            string[] data = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string trainerName = data[0];
            string pokemonName = data[1];
            string pokemonElement = data[2];
            int pokemonHealth = int.Parse(data[3]);
            if(!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName,new Trainer());
            }
            trainers[trainerName].AddPokemon(pokemonName,pokemonElement,pokemonHealth);
        }
        string element = string.Empty;
        while((element = Console.ReadLine()) != "End")
        {
            foreach(var (nameTrainer,trainer) in trainers)
            {
                if(!trainer.Pokemons.Any(kvp=>kvp.Value.Element == element))
                {
                    foreach(var (namePokemon,pokemon) in trainer.Pokemons)
                    {
                        pokemon.Hit10Hp();
                        if(pokemon.Hp <= 0)
                        {
                            trainer.RemovePokemon(namePokemon);
                        }
                    }
                }
                else
                {
                    trainer.AddBadge();
                }
            }
        }
        foreach(var (name,trainer) in trainers.OrderByDescending(kvp=>kvp.Value.Badges))
        {
            Console.WriteLine($"{name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}