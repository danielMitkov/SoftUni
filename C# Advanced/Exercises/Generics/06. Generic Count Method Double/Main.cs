List<Box<double>> boxes = new();
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
}
Box<double> box = new(double.Parse(Console.ReadLine()));
Console.WriteLine(box.GetComparison(boxes));