using System;
static class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        int[] results = new int[n];
        for (int i = 0; i < n; ++i) {
            string str = Console.ReadLine();
            int vowels = 0;
            int cons = 0;
            foreach (char index in str) {
                if (index == 'a' || index == 'e' || index == 'i' || index == 'o' || index == 'u'
                    || index == 'A' || index == 'E' || index == 'I' || index == 'O' || index == 'U') {
                    vowels += ((int)index * str.Length);
                } else {
                    cons += ((int)index / str.Length);
                }
            }
            results[i] = vowels + cons;
        }
        Array.Sort(results);
        Console.WriteLine(String.Join("\n", results));
    }
}