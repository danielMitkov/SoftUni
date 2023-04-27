namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int sum = int.Parse(Console.ReadLine());
            Dictionary<int,int> result = ChooseCoins(coins,sum);
            if(!result.Any())
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
            foreach(var (coin, amount) in result)
            {
                Console.WriteLine($"{amount} coin(s) with value {coin}");
            }
        }

        public static Dictionary<int,int> ChooseCoins(IList<int> coins,int targetSum)
        {
            Dictionary<int,int> picked = new();
            foreach(int coin in coins.OrderByDescending(x => x))
            {
                int times = targetSum / coin;
                if(times == 0)
                {
                    continue;
                }
                targetSum -= coin * times;
                if(!picked.ContainsKey(coin))
                {
                    picked.Add(coin,0);
                }
                picked[coin] += times;
            }
            if(targetSum > 0)
            {
                return new Dictionary<int,int>();
            }
            return picked;
        }
    }
}
