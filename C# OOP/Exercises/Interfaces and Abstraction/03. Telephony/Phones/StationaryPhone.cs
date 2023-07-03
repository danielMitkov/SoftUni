using Telephony.Interfaces;
namespace Telephony.Phones;
public class StationaryPhone:ICallable
{
    public string Call(string number) => $"Dialing... {number}";
}