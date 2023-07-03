using Telephony.Interfaces;
using Telephony.Phones;
string[] phoneNumbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
string[] urls = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
ICallable callable;
foreach(string number in phoneNumbers)
{
    if(number.Any(x => !char.IsDigit(x)))
    {
        Console.WriteLine("Invalid number!");
        continue;
    }
    if(number.Length == 10)
    {
        callable = new Smartphone();
        Console.WriteLine(callable.Call(number));
    }
    else
    {
        callable = new StationaryPhone();
        Console.WriteLine(callable.Call(number));
    }
}
IBrowsable browsable = new Smartphone();
foreach(string url in urls)
{
    Console.WriteLine(browsable.Browse(url));
}