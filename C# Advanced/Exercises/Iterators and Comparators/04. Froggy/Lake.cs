using System.Collections;
public class Lake:IEnumerable<int>
{
    private int[] _nums;
    public Lake(IEnumerable<int> nums)
    {
        _nums = nums.ToArray();
    }
    public IEnumerator<int> GetEnumerator()
    {
        for(int i = 0;i < _nums.Length;++i)
        {
            if(i % 2 == 0)
            {
                yield return _nums[i];
            }
        }
        for(int i = _nums.Length - 1;i >= 0;--i)
        {
            if(i % 2 != 0)
            {
                yield return _nums[i];
            }
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}