var input = Console.ReadLine();
var set = new HashSet<string>();
while(input!="END") {
    var data = input.Split(", ");
    if(data[0]=="IN") set.Add(data[1]);
    else set.Remove(data[1]);
    input=Console.ReadLine();
}
if(set.Count > 0) Console.Write(string.Join("\n", set));
else Console.WriteLine("Parking Lot is Empty");