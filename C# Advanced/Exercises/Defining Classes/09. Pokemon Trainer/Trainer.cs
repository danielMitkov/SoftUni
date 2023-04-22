namespace DefiningClasses;
public class Trainer
{
    private int badges;
    private Dictionary<string,Pokemon> pokemons;
    public Trainer()
    {
        badges = 0;
        pokemons = new Dictionary<string,Pokemon>();
    }
    public int Badges { get => badges; }
    public Dictionary<string,Pokemon> Pokemons { get => pokemons; }
    public void AddPokemon(string name,string element,int hp)
    {
        Pokemons.Add(name,new Pokemon(element,hp));
    }
    public void AddBadge()
    {
        badges++;
    }
    public void RemovePokemon(string namePokemon)
    {
        Pokemons.Remove(namePokemon);
    }
}