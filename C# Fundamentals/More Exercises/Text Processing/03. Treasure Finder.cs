using System;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string input = "";
        while ((input = Console.ReadLine()) != "find") {
            int keyIndex = 0;
            var builder = new StringBuilder();
            for (int i = 0; i < input.Length; ++i) {
                builder.Append((char)(input[i] - key[keyIndex]));
                keyIndex++;
                if (keyIndex == key.Length) keyIndex = 0;
            }
            string type = builder.ToString().Split('&')[1];
            string coords = builder.ToString().Split('<')[1].Split('>')[0];
            Console.WriteLine($"Found {type} at {coords}");
        }
    }
}