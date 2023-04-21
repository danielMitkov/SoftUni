Console.Write(string.Join("\n",Console.ReadLine()
    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
    .Where(x => char.IsUpper(x[0]))));
