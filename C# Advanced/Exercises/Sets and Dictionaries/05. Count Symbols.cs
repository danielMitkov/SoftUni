string str = Console.ReadLine();
SortedDictionary<char,int> chars = new();
foreach(char c in str) {
    if(!chars.ContainsKey(c)) chars.Add(c,0);
    chars[c]++;
}
foreach(var kvp in chars) Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");