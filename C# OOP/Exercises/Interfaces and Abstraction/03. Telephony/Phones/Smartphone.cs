using Telephony.Interfaces;
namespace Telephony.Phones;
public class Smartphone:ICallable, IBrowsable
{
    public string Call(string number) => $"Calling... {number}";
    public string Browse(string url)
    {
        if(url.Any(x => char.IsDigit(x)))
        {
            return "Invalid URL!";
        }
        return $"Browsing: {url}!";
    }
}