using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var strs = Console.ReadLine().Split(' ');
        Console.WriteLine(GetSum(strs[0], strs[1]));
    }
    static int GetSum(string str1, string str2) {
        if (str1.Length > str2.Length) return AddEm(str1, str2);
        else return AddEm(str2, str1);
    }
    static int AddEm(string big, string small) {
        int sum = 0;
        for (int i = 0; i < big.Length; ++i) sum += big[i] * (i < small.Length ? small[i] : 1);
        return sum;
    }
}