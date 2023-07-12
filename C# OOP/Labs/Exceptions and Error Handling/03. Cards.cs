string[] pairs = Console.ReadLine().Split(new char[] { ' ',',' },StringSplitOptions.RemoveEmptyEntries);
List<Card> cards = new();
for(int i = 0;i < pairs.Length;i += 2)
{
    string face = pairs[i];
    string suit = pairs[i + 1];
    try
    {
        cards.Add(new Card(face,suit));
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
Console.Write(string.Join(' ',cards));
public class Card
{
    private readonly string[] faces = { "2","3","4","5","6","7","8","9","10","J","Q","K","A" };
    private readonly string[] suits = { "S","H","D","C" };//limitless enumeration
    private readonly string[] suitIcons = { "\u2660","\u2665","\u2666","\u2663" };
    public string Face { get; private set; }
    public string Suit { get; private set; }
    public Card(string face,string suit)
    {
        if(!faces.Contains(face) || !suits.Contains(suit))
        {
            throw new ArgumentException("Invalid card!");
        }
        Face = face;
        Suit = suit;
    }
    public override string ToString() => $"[{Face}{suitIcons[suits.ToList().IndexOf(Suit)]}]";
}
