namespace DefiningClasses;
public class Pokemon
{
    private string element;
    private int hp;
    public Pokemon(string element,int hp)
    {
        this.element = element;
        this.hp = hp;
    }
    public string Element { get => element; }
    public int Hp { get => hp; }
    public void Hit10Hp()
    {
        hp -= 10;
    }
}