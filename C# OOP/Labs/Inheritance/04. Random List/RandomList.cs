namespace CustomRandomList;
public class RandomList :List<string>
{
    public string RandomString()
    {
        Random dice = new();
        int i = dice.Next(0,Count);
        string str = this[i];
        RemoveAt(i);
        return str;
    }
}