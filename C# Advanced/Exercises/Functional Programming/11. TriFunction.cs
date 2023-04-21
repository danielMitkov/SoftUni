int target = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
Func<string,int,bool> isMatch = (str,n) => str.Sum(c=>c)>=n;
static string Calc(Func<string,int,bool> isMatch,string[] names,int n) => names.First(name => isMatch(name,n));
Console.WriteLine(Calc(isMatch,names,target));
