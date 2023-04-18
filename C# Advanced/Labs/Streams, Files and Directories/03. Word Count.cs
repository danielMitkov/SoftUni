namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string,int> dict = new();
            string rgx = @"[A-z']+";
            var words = Regex.Matches(File.ReadAllText(wordsFilePath), rgx);
            foreach(Match word in words) dict[word.Value.ToLower()]=0;
            var text = Regex.Matches(File.ReadAllText(textFilePath),rgx);
            foreach(Match word in text) if(dict.ContainsKey(word.Value.ToLower())) dict[word.Value.ToLower()]++;
            //Console.WriteLine(string.Join("\n",text));
            using(StreamWriter writer = new(outputFilePath)) {
                foreach(var wordCount in dict.OrderByDescending(x=>x.Value)) {
                    if(wordCount.Value > 0) {
                        writer.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                    }
                }
            }
        }
    }
}
