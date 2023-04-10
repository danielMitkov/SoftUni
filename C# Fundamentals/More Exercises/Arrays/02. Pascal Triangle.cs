using System;
static class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        string[] previous = { "1" };
        for (int row = 1; row <= n; ++row) {
            string[] current = new string[row];
            for (int col = 0; col < current.Length; ++col) {
                int above = col == previous.Length ? 0 : int.Parse(previous[col]);
                int left = col - 1 < 0 ? 0 : int.Parse(previous[col - 1]);
                current[col] = (above + left).ToString();
            }
            Console.WriteLine(String.Join(" ", current));
            previous = current;
        }
    }
}