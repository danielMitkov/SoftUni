string[] pairs = Console.ReadLine().Split(new char[] { '-',',' },StringSplitOptions.RemoveEmptyEntries);
Dictionary<string,decimal> accounts = new();
for(int i = 0;i < pairs.Length;i += 2)
{
    string id = pairs[i];
    decimal money = decimal.Parse(pairs[i + 1]);
    accounts.Add(id,money);
}
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string command = data[0];
    string id = data[1];
    if(!accounts.ContainsKey(id))
    {
        Console.WriteLine("Invalid account!");
        Console.WriteLine("Enter another command");
        continue;
    }
    decimal amount = decimal.Parse(data[2]);
    if(command == "Deposit")
    {
        accounts[id] += amount;
        Console.WriteLine($"Account {id} has new balance: {accounts[id]:F2}");
    }
    else if(command == "Withdraw")
    {
        if(amount > accounts[id])
        {
            Console.WriteLine("Insufficient balance!");
        }
        else
        {
            accounts[id] -= amount;
            Console.WriteLine($"Account {id} has new balance: {accounts[id]:F2}");
        }
    }
    else
    {
        Console.WriteLine("Invalid command!");
    }
    Console.WriteLine("Enter another command");
}
