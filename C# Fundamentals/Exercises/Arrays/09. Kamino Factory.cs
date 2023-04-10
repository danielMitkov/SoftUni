using System.Linq;
using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        Console.ReadLine();
        int row = 0;
        Match best = Regex.Match("","");
        string bestFull = string.Empty;
        int bestRow = -1;
        string input;
        while((input = Console.ReadLine()) != "Clone them!")
        {
            row++;
            string line = input.Replace(" ","").Replace("!","");
            int dnaRow = row;
            var matches = Regex.Matches(line,@"1+");
            if(matches.Count == 0)
            {
                if(bestRow == -1)
                {
                    bestFull = line;
                    bestRow = dnaRow;
                }
                continue;
            }
            Match dna = matches.OrderByDescending(x => x.Length).ThenBy(x => x.Index).First();
            if(dna.Length > best.Length)
            {
                best = dna;
                bestFull = line;
                bestRow = dnaRow;
            }
            else if(dna.Length == best.Length && dna.Index < best.Index)
            {
                best = dna;
                bestFull = line;
                bestRow = dnaRow;
            }
            else if(dna.Index == best.Index && line.Replace("0","").Length > bestFull.Replace("0","").Length)
            {
                best = dna;
                bestFull = line;
                bestRow = dnaRow;
            }
        }
        Console.WriteLine($"Best DNA sample {bestRow} with sum: {bestFull.Replace("0","").Length}.");
        Console.WriteLine(string.Join(' ',bestFull.ToCharArray()));
    }
}