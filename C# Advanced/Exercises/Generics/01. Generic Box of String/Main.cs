for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    string num = Console.ReadLine();
    Box<string> box = new(num);
    Console.WriteLine(box);
}