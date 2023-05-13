using System;
using System.Linq;
using System.Collections.Generic;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Dictionary<string,string> words = new Dictionary<string, string>()
            {
                { "pear","pear" },
                { "flour","flour" },
                { "pork","pork" },
                { "olive","olive" }
            };
            while(consonants.Any())
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();
                foreach(var (word, build) in words)
                {
                    List<char> chars = new List<char>(build);
                    chars.RemoveAll(x => x == vowel || x == consonant);
                    words[word] = new string(chars.ToArray());
                }
                vowels.Enqueue(vowel);
            }
            Console.WriteLine($"Words found: {words.Count(x => x.Value == string.Empty)}");
            foreach(var (word, build) in words)
            {
                if(build == string.Empty)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
