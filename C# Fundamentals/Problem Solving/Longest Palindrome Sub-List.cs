using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program {
    static string letters = Console.ReadLine();
    static void Main() {
        int maxLen = 0;
        // Check all single letter central points
        for (var c = 0; c < letters.Length; c++)
            maxLen = Math.Max(maxLen, PalindromeLen(c, c));
        // Check all double letter central points
        for (var c = 0; c < letters.Length - 1; c++)
            maxLen = Math.Max(maxLen, PalindromeLen(c, c + 1));
        Console.WriteLine(maxLen);

    }
    static int PalindromeLen(int leftIndex, int rightIndex) {
        while (leftIndex >= 0 && rightIndex < letters.Length
      && letters[leftIndex] == letters[rightIndex]) {
            leftIndex--;
            rightIndex++;
        }
        return rightIndex - leftIndex - 1;

    }
}