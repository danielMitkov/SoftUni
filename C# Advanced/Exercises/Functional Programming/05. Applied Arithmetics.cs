var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
var str = "";
while((str = Console.ReadLine()) != "end"){
    if(str=="add") for(int i = 0;i<nums.Count;++i) nums[i]++;
    if(str=="multiply") for(int i = 0;i<nums.Count;++i) nums[i]*=2;
    if(str=="subtract") for(int i = 0;i<nums.Count;++i) nums[i]--;
    if(str=="print") Console.WriteLine(string.Join(" ",nums));
}
