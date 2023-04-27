static int GetFactorial(int num)
{
    if(num == 1)
    {
        return 1;
    }
    return num * GetFactorial(num - 1);
}
Console.Write(GetFactorial(int.Parse(Console.ReadLine())));
