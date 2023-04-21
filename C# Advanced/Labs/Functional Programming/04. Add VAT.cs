double[] arr = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(x => x*1.2).ToArray();
foreach(var item in arr) {
    Console.WriteLine($"{item:f2}");
}
