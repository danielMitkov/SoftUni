Queue<string> conqueredPeaks = new Queue<string>();
Stack<int> foodSupplies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
Dictionary<string,int> peaks = new Dictionary<string,int>()
{
    { "Vihren", 80 },
    { "Kutelo", 90},
    { "Banski Suhodol", 100 },
    { "Polezhan", 60 },
    { "Kamenitza", 70 }
};
Queue<string> peaksNames = new Queue<string>();
foreach(var peak in peaks)
{
    peaksNames.Enqueue(peak.Key);
}
while(foodSupplies.Any() && stamina.Any() && peaksNames.Any())
{
    if(foodSupplies.Pop() + stamina.Dequeue() >= peaks[peaksNames.Peek()])
    {
        conqueredPeaks.Enqueue(peaksNames.Dequeue());
    }
}
if(peaksNames.Any())
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
if(conqueredPeaks.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(string.Join(Environment.NewLine,conqueredPeaks));
}
