using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        var str = "";
        while ((str = Console.ReadLine()) != "end") {
            var data = str.Split(" ");
            int fir = data.Length > 1 ? int.Parse(data[1]) : 0;
            int sec = data.Length > 1 ? int.Parse(data[2]) : 0;
            if (data[0] == "swap") (arr[fir], arr[sec]) = (arr[sec], arr[fir]);
            if (data[0] == "multiply") arr[fir] *= arr[sec];
            if (data[0] == "decrease") for (int i = 0; i < arr.Length; ++i) arr[i]--;
        }
        Console.WriteLine(string.Join(", ", arr));
    }
}