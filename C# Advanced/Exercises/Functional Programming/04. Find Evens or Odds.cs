var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
bool isEven = Console.ReadLine()=="even" ? true : false;
for(int n = range[0];n<=range[1];n++) {
    if(isEven&&n%2==0) Console.Write(n+" ");
    if(!isEven&&n%2!=0) Console.Write(n+" ");
}
