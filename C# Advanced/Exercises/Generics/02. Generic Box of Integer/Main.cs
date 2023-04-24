for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    int num = int.Parse(Console.ReadLine());
    Box<int> box = new(num);
    Console.WriteLine(box);
}