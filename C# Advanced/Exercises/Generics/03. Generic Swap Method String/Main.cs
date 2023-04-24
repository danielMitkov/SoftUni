List<Box<string>> boxes = new();
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    boxes.Add(new Box<string>(Console.ReadLine()));
}
int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
(boxes[ids[0]], boxes[ids[1]]) = (boxes[ids[1]], boxes[ids[0]]);
foreach(Box<string> box in boxes)
{
    Console.WriteLine(box);
}