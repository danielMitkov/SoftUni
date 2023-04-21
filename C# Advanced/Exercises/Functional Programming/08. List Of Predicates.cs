int target = int.Parse(Console.ReadLine());
var nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
List<int> result = new();
for(int n = 1;n<=target;n++) {
    bool isValid = true;
    foreach(var num in nums) if(n%num!=0) isValid=false;
    if(isValid) result.Add(n);
}
Console.Write(string.Join(" ",result));
