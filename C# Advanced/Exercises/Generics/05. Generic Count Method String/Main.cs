List<Box<string>> boxes = new();
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    boxes.Add(new Box<string>(Console.ReadLine()));
}
Box<string> box = new(Console.ReadLine());
Console.WriteLine(box.GetComparison(boxes));